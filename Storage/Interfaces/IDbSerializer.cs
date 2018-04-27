using System;
using System.Collections.Generic;
using Storage.Serializers;

namespace Storage.Interfaces
{
    public interface IDbSerializer : IDisposable 
    {
        int AddRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new();
        int DeleteRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new();
        DbCollection<T> GetCollection<T>() where T : IIdRecord, new();
        IEnumerable<T> GetRecords<T>(int id = 0) where T : IIdRecord, new();
        IEnumerable<T> GetRecords<T>(int id, DbCollection<T> collection) where T : IIdRecord, new();
        int UpdateRecord<T>(T doc, DbCollection<T> collection = null) where T : IIdRecord, new();
    }
}