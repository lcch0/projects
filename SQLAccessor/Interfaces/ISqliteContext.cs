using System;
using SQLite;

namespace SQLAccessor.Interfaces
{
	public interface ISqliteContext : IDisposable
	{
		SQLiteConnection Connection { get; }
		void CreateDb();
		void ClearTables();
	}
}