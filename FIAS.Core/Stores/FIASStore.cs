﻿using FIAS.Core.Enums;
using FIAS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FIAS.Core.Stores
{
    public class FIASStore
    {
        public FIASStore(string connection) => Connection = connection;

        public string Connection { get; set; }

        /// <summary>
        /// Является ли строка GUID
        /// </summary>
        public static bool IsGUID(string Search)
        {
            if (Search.Length != 36) { return false; }
            return Guid.TryParse(Search, out var G);
        }

        public Task<DataTable> FIASLevels() => Task.Run(UP_CB_Levels);

        /// <summary>
        /// Получить статус разрешения импорта таблицы
        /// </summary>
        /// <param name="table">Имя таблицы</param>
        public bool GetCanImport(string table) => (bool)UP_TablePropertyGet(table, "CanImport");

        public async Task<List<FIASRegistryAddress>> GetChilds(string GUID)
        {
            using (var DT = await Task.Run(() => UP_RegistrySelectChild(GUID)))
                return DT.Rows.Cast<DataRow>().Select(R => FIASRegistryAddress.Parse(R)).ToList();
        }

        public async Task<List<FIASHierarchyItem>> GetHierarchy(FIASDivision division, string GUID)
        {
            using (var DT = await Task.Run(() => UP_GetHierarchy(division, GUID)))
                return DT.Rows.Cast<DataRow>().Select(R => FIASHierarchyItem.Parse(R)).ToList();
        }

        /// <summary>
        /// Получить внутренний код
        /// </summary>
        public long GetID(string GUID) => UP_IDByGUID(GUID);

        /// <summary>
        /// Получать дату импорта таблицы
        /// </summary>
        public DateTime? GetLastImport(string table) => (DateTime?)UP_TablePropertyGet(table, "LastImport");

        public FIASRegistryAddress GetObject(string GUID) => GetObject(FIASDivision.mun, GUID);

        public FIASRegistryAddress GetObject(FIASDivision division, string GUID)
        {
            using (var DT = UP_RegistrySelect(division, GUID))
            {
                if (DT.Rows.Count == 0) { return null; }
                return FIASRegistryAddress.Parse(DT.Rows[0]);
            }
        }

        /// <summary>
        /// Ссылка на выписку по объекту
        /// </summary>
        /// <param name="GUID"></param>
        /// <returns></returns>
        public string GetPDFStatement(string GUID) => $"https://fias.nalog.ru/Export/ExportPdfStatement?objId={GetID(GUID)}&actual=true&division=1";

        /// <summary>
        /// Поиск адреса по AddressFull или GUID
        /// </summary>
        /// <param name="division">Иерархия</param>
        /// <param name="S">Текст для поиска</param>
        /// <param name="Level">Уровень объекта</param>
        /// <param name="Limit">Максимальное кол-во строк для вывода </param>
        /// <returns></returns>
        public async Task<List<FIASRegistryAddress>> Search(FIASDivision division, string S, int? Level, int? Limit)
        {
            using (var DT = await Task.Run(() => IsGUID(S) ? UP_SearchRegistryByGUID(division, S, Level, Limit) : UP_SearchRegistry(division, S, Level, Limit)))
                return DT.Rows.Cast<DataRow>().Select(R => FIASRegistryAddress.Parse(R)).ToList();
        }

        public void SetCanImport(string table, bool value) => UP_TablePropertySet(table, "CanImport", value);

        /// <summary>
        /// Задать дату импорта таблицы
        /// </summary>
        public void SetLastImport(string table, DateTime date) => UP_TablePropertySet(table, "LastImport", date);

        public async Task<Dictionary<string, string>> Statistics()
        {
            using (var DT = await Task.Run(UP_FIAS_Statistics))
                return DT.Rows.Cast<DataRow>().ToDictionary(R => R.Field<string>("Name"), R => R.Field<string>("Value"));
        }

        /// <summary>
        /// Информация о таблицах в БД
        /// </summary>
        public List<FIASTableInfo> TablesInfo()
        {
            using (var DT = UP_TablesInfo())
                return DT.Rows.Cast<DataRow>().Select(R => FIASTableInfo.Parse(R)).ToList();
        }

        #region SQL

        #region Execute

        private static void ExecuteNonQuery(SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                command.ExecuteNonQuery();
            }
        }

        private static object ExecuteScalar(SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                command.Connection = Connection;
                return command.ExecuteScalar();
            }
        }

        private static T ExecuteScalar<T>(SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                command.Connection = Connection;
                return (T)command.ExecuteScalar();
            }
        }

        private static DataTable ExecuteSelect(SqlCommand command, string connection)
        {
            using (var Connection = new SqlConnection(connection))
            {
                Connection.Open();
                return ExecuteSelect(command, Connection);
            }
        }

        private static DataTable ExecuteSelect(SqlCommand command, SqlConnection connection)
        {
            var Result = new DataTable() { Locale = CultureInfo.CurrentCulture };
            command.Connection = connection;
            using (var Reader = command.ExecuteReader())
            {
                Result.Load(Reader);
            }
            return Result;
        }

        private static SqlCommand NewProcedure([CallerMemberName] string name = null) => new SqlCommand(name) { CommandType = CommandType.StoredProcedure };

        #endregion Execute

        private DataTable UP_CB_Levels()
        {
            using (var Command = NewProcedure())
                return ExecuteSelect(Command, Connection);
        }

        private DataTable UP_FIAS_Statistics()
        {
            using (var Command = NewProcedure())
                return ExecuteSelect(Command, Connection);
        }

        private DataTable UP_GetHierarchy(FIASDivision H, string GUID)
        {
            using (var Command = NewProcedure($"{H}.{nameof(UP_GetHierarchy)}"))
            {
                var P = Command.Parameters;
                P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
                return ExecuteSelect(Command, Connection);
            }
        }

        private long UP_IDByGUID(string GUID)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@GUID", GUID);
                return ExecuteScalar<long>(Command, Connection);
            }
        }

        private DataTable UP_RegistrySelect(string GUID) => UP_RegistrySelect(FIASDivision.mun, GUID);

        private DataTable UP_RegistrySelect(FIASDivision H, string GUID)
        {
            using (var Command = NewProcedure($"{H}.{nameof(UP_RegistrySelect)}"))
            {
                var P = Command.Parameters;
                P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
                return ExecuteSelect(Command, Connection);
            }
        }

        private DataTable UP_RegistrySelectChild(string GUID)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
                return ExecuteSelect(Command, Connection);
            }
        }

        private DataTable UP_SearchRegistry(FIASDivision H, string Search, int? Level, int? Limit)
        {
            using (var Command = NewProcedure($"{H}.{nameof(UP_SearchRegistry)}"))
            {
                var P = Command.Parameters;
                P.Add(new SqlParameter("@Search", SqlDbType.VarChar, 500)).Value = Search;
                P.Add(new SqlParameter("@Level", SqlDbType.Int)).Value = Level;
                P.Add(new SqlParameter("@Limit", SqlDbType.Int)).Value = Limit;
                return ExecuteSelect(Command, Connection);
            }
        }

        private DataTable UP_SearchRegistryByGUID(FIASDivision H, string GUID, int? Level, int? Limit)
        {
            using (var Command = NewProcedure($"{H}.{nameof(UP_SearchRegistryByGUID)}"))
            {
                var P = Command.Parameters;
                P.Add(new SqlParameter("@GUID", SqlDbType.Char, 36)).Value = GUID;
                P.Add(new SqlParameter("@Level", SqlDbType.Int)).Value = Level;
                P.Add(new SqlParameter("@Limit", SqlDbType.Int)).Value = Limit;
                return ExecuteSelect(Command, Connection);
            }
        }

        private object UP_TablePropertyGet(string table, string name)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Table", table);
                P.AddWithValue("@Name", name);
                return ExecuteScalar(Command, Connection);
            }
        }

        private void UP_TablePropertySet(string table, string name, object value)
        {
            using (var Command = NewProcedure())
            {
                var P = Command.Parameters;
                P.AddWithValue("@Table", table);
                P.AddWithValue("@Name", name);
                P.AddWithValue("@Value", value);
                ExecuteNonQuery(Command, Connection);
            }
        }

        private DataTable UP_TablesInfo()
        {
            using (var Command = NewProcedure())
                return ExecuteSelect(Command, Connection);
        }

        #endregion SQL
    }
}