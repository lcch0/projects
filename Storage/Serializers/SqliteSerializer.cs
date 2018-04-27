using System;
using System.Collections.Generic;
using System.IO;
using Storage.Contexts;
using Storage.Interfaces;

namespace Storage.Serializers
{
    public class SqliteSerializer : IDbSerializer
    {
        private readonly SqliteRepositoryContext _connection;

        public SqliteSerializer(string path)
        {
            bool createDb = false;
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    createDb = true;
                }
            }
            _connection = new SqliteRepositoryContext(path);
            if(createDb)
                _connection.CreateDb();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public int AddRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }

        public int DeleteRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }

        public DbCollection<T> GetCollection<T>() where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRecords<T>(int id = 0) where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRecords<T>(int id, DbCollection<T> collection) where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }

        public int UpdateRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            throw new NotImplementedException();
        }
    }
}
