using System;
using System.Data.Common;

namespace Storage.Interfaces
{
	public interface IRepositoryContext<out T> : IDisposable where T : DbConnection
	{
		T Connection { get; }
	    int ExecuteNonQuery(DbCommand command);
	}
}