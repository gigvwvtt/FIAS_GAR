﻿namespace FIASUpdate.Forms
{
    partial class FormImportDelta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SL_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SL_Value = new System.Windows.Forms.ToolStripStatusLabel();
            this.LV_Archives = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Version = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Subject = new System.Windows.Forms.TextBox();
            this.B_Download = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Import = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.сolumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(362, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "OwO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SL_Status,
            this.SL_Value});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(562, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel1.Text = "Статус: ";
            // 
            // SL_Status
            // 
            this.SL_Status.Name = "SL_Status";
            this.SL_Status.Size = new System.Drawing.Size(12, 17);
            this.SL_Status.Text = "-";
            // 
            // SL_Value
            // 
            this.SL_Value.Name = "SL_Value";
            this.SL_Value.Size = new System.Drawing.Size(12, 17);
            this.SL_Value.Text = "-";
            // 
            // LV_Archives
            // 
            this.LV_Archives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.сolumnHeader4});
            this.LV_Archives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Archives.HideSelection = false;
            this.LV_Archives.Location = new System.Drawing.Point(3, 18);
            this.LV_Archives.Name = "LV_Archives";
            this.LV_Archives.Size = new System.Drawing.Size(556, 344);
            this.LV_Archives.TabIndex = 17;
            this.LV_Archives.UseCompatibleStateImageBehavior = false;
            this.LV_Archives.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Версия";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Описание";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Статус";
            this.columnHeader3.Width = 128;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TB_Version, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TB_Subject, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 56);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Версия:";
            // 
            // TB_Version
            // 
            this.TB_Version.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Version.Location = new System.Drawing.Point(70, 3);
            this.TB_Version.Name = "TB_Version";
            this.TB_Version.ReadOnly = true;
            this.TB_Version.Size = new System.Drawing.Size(100, 22);
            this.TB_Version.TabIndex = 1;
            this.TB_Version.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Субъекты:";
            // 
            // TB_Subject
            // 
            this.TB_Subject.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Subject.Location = new System.Drawing.Point(70, 31);
            this.TB_Subject.Name = "TB_Subject";
            this.TB_Subject.ReadOnly = true;
            this.TB_Subject.Size = new System.Drawing.Size(386, 22);
            this.TB_Subject.TabIndex = 1;
            this.TB_Subject.TabStop = false;
            // 
            // B_Download
            // 
            this.B_Download.AutoSize = true;
            this.B_Download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Download.Enabled = false;
            this.B_Download.Location = new System.Drawing.Point(3, 3);
            this.B_Download.Name = "B_Download";
            this.B_Download.Padding = new System.Windows.Forms.Padding(1);
            this.B_Download.Size = new System.Drawing.Size(104, 25);
            this.B_Download.TabIndex = 19;
            this.B_Download.Text = "Скачать архивы";
            this.B_Download.UseVisualStyleBackColor = true;
            this.B_Download.Click += new System.EventHandler(this.B_Download_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.AutoSize = true;
            this.B_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Cancel.Enabled = false;
            this.B_Cancel.Location = new System.Drawing.Point(224, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Padding = new System.Windows.Forms.Padding(1);
            this.B_Cancel.Size = new System.Drawing.Size(60, 25);
            this.B_Cancel.TabIndex = 20;
            this.B_Cancel.Text = "Отмена";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Import
            // 
            this.B_Import.AutoSize = true;
            this.B_Import.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.B_Import.Enabled = false;
            this.B_Import.Location = new System.Drawing.Point(113, 3);
            this.B_Import.Name = "B_Import";
            this.B_Import.Padding = new System.Windows.Forms.Padding(1);
            this.B_Import.Size = new System.Drawing.Size(105, 25);
            this.B_Import.TabIndex = 19;
            this.B_Import.Text = "Импортировать";
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.B_Download);
            this.flowLayoutPanel1.Controls.Add(this.B_Import);
            this.flowLayoutPanel1.Controls.Add(this.B_Cancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(272, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 31);
            this.flowLayoutPanel1.TabIndex = 21;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LV_Archives);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 365);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список архивов";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 421);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(562, 37);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // сolumnHeader4
            // 
            this.сolumnHeader4.Text = "Размер";
            this.сolumnHeader4.Width = 76;
            // 
            // FormImportDelta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::FIASUpdate.Properties.Settings.Default.DefaultBackColor;
            this.ClientSize = new System.Drawing.Size(562, 480);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FIASUpdate.Properties.Settings.Default, "DefaultFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::FIASUpdate.Properties.Settings.Default, "DefaultForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::FIASUpdate.Properties.Settings.Default, "DefaultBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = global::FIASUpdate.Properties.Settings.Default.DefaultFont;
            this.ForeColor = global::FIASUpdate.Properties.Settings.Default.DefaultForeColor;
            this.Name = "FormImportDelta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт БД";
            this.Load += new System.EventHandler(this.FormImportDelta_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SL_Status;
        private System.Windows.Forms.ToolStripStatusLabel SL_Value;
        private System.Windows.Forms.ListView LV_Archives;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Version;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Subject;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button B_Download;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ColumnHeader сolumnHeader4;
    }
}