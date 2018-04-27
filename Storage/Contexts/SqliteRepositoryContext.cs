using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using Storage.Interfaces;
using Storage.Serializers.Scripts;

namespace Storage.Contexts
{
    public class SqliteRepositoryContext : IRepositoryContext<SQLiteConnection>
    {
        public SQLiteConnection Connection { get; }

        public SqliteRepositoryContext(string dbPath)
        {
            Connection = new SQLiteConnection(dbPath);
            Connection.Open();
        }

        public void CreateDb()
        {
            if (Connection == null)
                throw new ApplicationException("Cannot create DB - connection is null");

            Connection.Flags |= SQLiteConnectionFlags.NoConnectionPool;

            using (var cmd = new SQLiteCommand(Connection))
            {
                if (!TableExists(SqliteScript.CREATE_PROJECT, Connection))
                {
                    cmd.CommandText = SqliteScript.CREATE_PROJECT;
                    cmd.ExecuteNonQuery();
                }

                if (!TableExists(SqliteScript.CREATE_USERS, Connection))
                {
                    cmd.CommandText = SqliteScript.CREATE_USERS;
                    cmd.ExecuteNonQuery();
                }

                if (!TableExists(SqliteScript.CREATE_ACTIVITY, Connection))
                {
                    cmd.CommandText = SqliteScript.CREATE_ACTIVITY;
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private static bool TableExists(string query, SQLiteConnection connection)
        {
            if (string.IsNullOrEmpty(query))
                return false;

            if (connection == null)
                return false;

            var tableName = ExtractTableName(query);

            var cmdStr = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = cmdStr;
                var obj = cmd.ExecuteScalar();
                return obj != null;
            }
        }

        private static string ExtractTableName(string query)
        {
            Regex regex = new Regex(@"\[(?<table>\w+)\].*",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace |
                RegexOptions.Compiled);

            Match m = regex.Match(query);
            if (!m.Success)
                return string.Empty;

            var tableName = m.Groups["table"].Value;
            return tableName;
        }

        public int ExecuteNonQuery(DbCommand command)
        {
            if (command == null || Connection == null)
                return -1;

            command.ExecuteNonQuery();
            return (int) Connection.LastInsertRowId;
        }

        public void Dispose()
        {
            Connection?.Close();
            Connection?.Dispose();
        }
    }
}
