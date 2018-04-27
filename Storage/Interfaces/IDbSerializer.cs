using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Storage.Interfaces
{
    public interface IDbSerializer : IDisposable 
    {
        IRepositoryContext<DbConnection> Context { get; }

        int AddRecord<T>(T doc) where T : IIdRecord, new();
        int DeleteRecord<T>(T doc) where T : IIdRecord, new();
        IEnumerable<T> GetRecords<T>(int id = 0) where T : IIdRecord, new();
        int UpdateRecord<T>(T doc) where T : IIdRecord, new();
    }
}