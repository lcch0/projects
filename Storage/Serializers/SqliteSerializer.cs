using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using Storage.Contexts;
using Storage.Interfaces;
using Storage.Serializable;
using Storage.Serializers.SqlSpecific;

namespace Storage.Serializers
{
    public class SqliteSerializer : IDbSerializer
    {
        private readonly SqliteRepositoryContext _connection;
        public IRepositoryContext<DbConnection> Context => _connection;

        public SqliteSerializer(string path)
        {
            bool createDb = CreateFile(path);
            path = ModifyToConnectionString(path);
            _connection = new SqliteRepositoryContext(path);
            if (createDb)
            {
                _connection.CreateDb();
                InitTables();
            }
        }

        private void InitTables()
        {
            var values = Enum.GetValues(typeof(Project.EType));

            foreach (Project.EType value in values)
            {
                var project = new Project {ProjectType = (int) value};
                AddRecord(project);
            }

            var user = new User {Name = "User"};
            AddRecord(user);
        }

        private string ModifyToConnectionString(string path)
        {
            return $"Data Source={path}";
        }

        private static bool CreateFile(string path)
        {
            bool createDb = false;
            if (!File.Exists(path))
            {
                var justPath = Path.GetDirectoryName(path);

                if (string.IsNullOrEmpty(justPath))
                {
                    return false;
                }

                if (!Directory.Exists(justPath))
                    Directory.CreateDirectory(justPath);

                using (File.Create(path))
                {
                    createDb = true;
                }
            }

            return createDb;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public int AddRecord<T>(T doc) where T : IIdRecord, new()
        {
            var activity = doc as Activity;
            if (activity != null)
            {
                return new ActivitySerializer(this).AddRecord(activity);
            }

            var project = doc as Project;
            if (project != null)
            {
                return new ProjectSerializer(this).AddRecord(project);
            }

            var user = doc as User;
            if (user != null)
            {
                return new UserSerializer(this).AddRecord(user);
            }

            return -1;
        }

        public int DeleteRecord<T>(T doc) where T : IIdRecord, new()
        {
            var activity = doc as Activity;
            if (activity != null)
            {
                return new ActivitySerializer(this).DeleteRecord(activity);
            }

            var project = doc as Project;
            if (project != null)
            {
                return new ProjectSerializer(this).DeleteRecord(project);
            }

            var user = doc as User;
            if (user != null)
            {
                return new UserSerializer(this).DeleteRecord(user);
            }
            return -1;
        }

        public IEnumerable<T> GetRecords<T>(int id = 0) where T : IIdRecord, new()
        {
            if (typeof(T) == typeof(Activity))
            {
                return new ActivitySerializer(this).GetRecords(id).OfType<T>();
            }

            if (typeof(T) == typeof(Project))
            {
                return new ProjectSerializer(this).GetRecords(id).OfType<T>();
            }

            if (typeof(T) == typeof(User))
            {
                return new UserSerializer(this).GetRecords(id).OfType<T>();
            }

            return Enumerable.Empty<T>();
        }

        public int UpdateRecord<T>(T doc) where T : IIdRecord, new()
        {
            var activity = doc as Activity;
            if (activity != null)
            {
                return new ActivitySerializer(this).UpdateRecord(activity);
            }

            var project = doc as Project;
            if (project != null)
            {
                return new ProjectSerializer(this).UpdateRecord(project);
            }

            var user = doc as User;
            if (user != null)
            {
                return new UserSerializer(this).UpdateRecord(user);
            }
            return -1;
        }
    }
}
