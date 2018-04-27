using System.Collections.Generic;
using LiteDB;
using Storage.Contexts;
using Storage.Interfaces;

namespace Storage.Serializers
{
    /// <summary>
    /// </summary>
    internal class LiteDbSerializer : IDbSerializer
    {
        private readonly IRepositoryContext<LiteDatabase> _context;

        internal LiteDbSerializer(string path)
        {
            _context = new LiteDbRepositoryContext(path);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<T> GetRecords<T>(int id = 0) where T : IIdRecord, new()
        {
            return GetRecords<T>(id, null);
        }

        public IEnumerable<T> GetRecords<T>(int id, DbCollection<T> collection) where T : IIdRecord, new()
        {
           var liteCollection = ValidateCollection(collection);

            return id > 0 ? new List<T> {liteCollection.FindById(id)} : liteCollection.FindAll();
        }

        private LiteCollection<T> ValidateCollection<T>(DbCollection<T> collection) where T : IIdRecord, new()
        {
            if (collection == null)
                collection = new DbCollection<T>(GetCollection<T>().NoSqlCollection);
            else if (collection.NoSqlCollection == null)
                collection.NoSqlCollection = GetCollection<T>().NoSqlCollection;

            return collection.NoSqlCollection;
        }

        public DbCollection<T> GetCollection<T>() where T : IIdRecord, new()
        {
            var t = new T();
            return new DbCollection<T>(_context.Connection.GetCollection<T>(t.TableName));
        }

        public LiteCollection<T> IncludeFunc<T>(LiteCollection<T> collection) where T : IIdRecord, new()
        {
            return collection.Include(x => x.TableName);
        }

        public int AddRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            if (collection == null)
                collection = GetCollection<T>();

            collection.NoSqlCollection?.Insert(doc);
            return doc.Id;
        }

        public int UpdateRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            if (collection == null)
                collection = GetCollection<T>();

            collection.NoSqlCollection?.Update(doc);
            return doc.Id;
        }

        public int DeleteRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new()
        {
            if (collection == null)
                collection = GetCollection<T>();

            collection.NoSqlCollection?.Delete(doc.Id);
            return doc.Id;
        }
    }
}