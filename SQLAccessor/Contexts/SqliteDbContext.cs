using System.IO;
using SQLAccessor.Interfaces;
using SQLAccessor.Mappings;

namespace SQLAccessor.Contexts
{//https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
	public class SqliteDbContext : ISqliteContext
	{
		private readonly SQLiteConnection _connection;

		public SqliteDbContext(string path)
		{
			_connection = new SQLiteConnection(path);
			CreateDb();
			//if (!File.Exists(path))
			//{
			//	_connection = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
			//	CreateDb();
			//}
			//else
			//{
			//	_connection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite);
			//}
		}

		public void Dispose()
		{
			_connection?.Close();
			_connection?.Dispose();
		}

		public SQLiteConnection Connection => _connection;
		public void CreateDb()
		{
			_connection.CreateTable<Project>();
			_connection.CreateTable<User>();
			_connection.CreateTable<Activity>();
			_connection.CreateTable<Draft>();
		}

		public void ClearTables()
		{
			_connection.DeleteAll<Project>();
			_connection.DeleteAll<User>();
			_connection.DeleteAll<Activity>();
			_connection.DeleteAll<Draft>();
		}
	}
}
