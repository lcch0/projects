using System;
using System.Collections.Generic;
using LiteDB;
using Storage.Contexts;
using Storage.Interfaces;

namespace Storage.Serializers
{
	/// <summary>
	/// 
	/// </summary>
	public class LiteDbSerializer : IDisposable// where T : class, IIdRecord, new()
	{
		private readonly IRepositoryContext<LiteDatabase> _context;

		public LiteDbSerializer(string path)
		{
			_context = new LiteDbRepositoryContext(path);
		}

		public IEnumerable<T> GetRecords<T>(int id = -1) where T : IIdRecord, new()
		{
			return GetRecords<T>(id, null);
		}

		public IEnumerable<T> GetRecords<T>(int id, LiteCollection<T> collection) where T : IIdRecord, new()
		{
			if (collection == null)
				collection = GetCollection<T>();

			if (id > -1)
			{
				return new List<T> { collection.FindById(id) };
			}

			return collection.FindAll();
		}

		public LiteCollection<T> GetCollection<T>() where T : IIdRecord, new()
		{
			var t = new T();
			return _context.Connection.GetCollection<T>(t.TableName);
		}

		public LiteCollection<T> IncludeFunc<T>(LiteCollection<T> collection) where T : IIdRecord, new()
		{
			return collection.Include(x => x.TableName);
		}

		public int AddRecord<T>(T doc) where T : IIdRecord, new()
		{
			var c = _context.Connection.GetCollection<T>(doc.TableName);
			c.Insert(doc);
			return doc.Id;
		}

		public int UpdateRecord<T>(T doc) where T : IIdRecord, new()
		{
			var c = _context.Connection.GetCollection<T>(doc.TableName);
			c.Update(doc);
			return doc.Id;
		}

		public int DeleteRecord<T>(T doc) where T : IIdRecord, new()
		{
			var c = _context.Connection.GetCollection<T>(doc.TableName);
			c.Delete(doc.Id);
			return doc.Id;
		}

		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
