﻿using FIAS.Core.API;
using FIAS.Core.Models;
using FIAS.Core.Stores;
using FIASUpdate.Properties;
using JANL;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIASUpdate
{
    public partial class FormMain : Form
    {
        private FIASStore Store = new FIASStore(Program.Connection);
        private Progress<TaskProgress> TP;

        public FormMain() => InitializeComponent();

        private void AddResult(string table, string status)
        {
            var LVI = LV_Result.Items.Add(table);
            LVI.SubItems.Add(status);
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private async void B_Import_Click(object sender, EventArgs e)
        {
            try
            {
                UIState(false);
                LV_Result.Items.Clear();
                var Options = new ImportOptions
                {
                    OnlyEmpty = CB_OnlyEmpty.Checked,
                    ShrinkDatabase = CB_Shrink.Checked
                };
                SWL.Start();
                using (var FIAS = new DBImport(TP))
                {
                    FIAS.ResultAdded += FIAS_ResultChanged;
                    await Task.Run(() => FIAS.Import(Options));
                    SetResult(FIAS.Result);
                }
            }
            catch (Exception ex) { Msgs.ShowException(ex); }
            finally
            {
                SWL.Stop();
                UIState(true);
            }
        }

        private void FIAS_ResultChanged(object sender, ResultAddedEventArgs e) => AddResult(e.Table, e.Status);

        private void FormMain_Load(object sender, EventArgs e)
        {
            TP = new Progress<TaskProgress>((T) =>
            {
                if (T.HasStatus) { SL_Status.Text = T.Status; }
                if (T.HasValue)
                {
                    SL_Value.Text = (T.Value + T.Max == 0) ? "" : $"{T.Value:N0}{new string('|', T.Value / 100_000)}";
                }
            });
            LV_Tables.Items.Clear();
            //GetFiles();
        }

        private async Task GetFiles()
        {
            using (var Client = new FIASClient())
            {
                var Files = await Client.GetAllDownloadFileInfo(new DateTime(2022, 1, 4));
                Console.WriteLine(Files.First().GarXMLDeltaURL);
            }
        }

        private void RefreshTables()
        {
            var Tables = Store.TablesInfo();
            LV_Tables.BeginUpdate();
            LV_Tables.Items.Clear();
            foreach (var T in Tables)
            {
                var LVI = new ListViewItem(new[] { $"{T.Name}", $"{T.RowCount:N0}", $"{T.TotalMB:N2} МБ", $"{T.LastImport:yyyy.MM.dd}" }) { Tag = T, Checked = T.CanImport };
                LV_Tables.Items.Add(LVI);
            }
            LV_Tables.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV_Tables.EndUpdate();
        }

        private void SaveTables()
        {
            foreach (ListViewItem item in LV_Tables.Items)
            {
                var Table = (FIASTableInfo)item.Tag;
                Store.SetCanImport(Table.Name, item.Checked);
            }
            RefreshTables();
        }

        private void SetResult(IReadOnlyDictionary<string, string> Result)
        {
            LV_Result.Items.Clear();
            foreach (var KV in Result)
            {
                var LVI = LV_Result.Items.Add(KV.Key);
                LVI.SubItems.Add(KV.Value);
            }
            LV_Result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void UIState(bool state)
        {
            B_Import.Enabled = state;
            B_SQLConnection.Enabled = state;
        }

        #region UI Events

        private void B_SQLConnection_Click(object sender, EventArgs e)
        {
            using (var F = new FormDBList())
            {
                F.ShowDialog(this);
                Store.Connection = Program.Connection;
            }
        }

        private void B_TablesRefresh_Click(object sender, EventArgs e) => RefreshTables();

        private void B_TablesSave_Click(object sender, EventArgs e)
        {
            Program.SaveSettings();
            SaveTables();
        }

        private void B_XMLPath_Click(object sender, EventArgs e)
        {
            using (var F = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                DefaultDirectory = Program.XMLPath
            })
            {
                if (F.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Settings.Default.XMLPath = F.FileName;
                    Settings.Default.Save();
                }
            }
        }

        private void MI_Search_Click(object sender, EventArgs e)
        {
            var F = new FormAddressSearch();
            F.ShowDialog(this);
        }

        #endregion UI Events
    }
}