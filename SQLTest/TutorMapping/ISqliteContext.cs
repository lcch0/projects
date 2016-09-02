using System;
using SQLite;

namespace TutorMapping
{
	public interface ISqliteContext : IDisposable
	{
		SQLiteConnection Connection { get; }
	}
}