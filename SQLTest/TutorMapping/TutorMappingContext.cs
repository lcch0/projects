using SQLite;

namespace TutorMapping
{//https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
	public class TutorMappingContext : ISqliteContext
	{
		private readonly SQLiteConnection _connection;

		public TutorMappingContext(string path)
		{
			_connection = new SQLiteConnection(path);
		}

		public void Dispose()
		{
			_connection?.Close();
			_connection?.Dispose();
		}

		public SQLiteConnection Connection =>_connection;
		public void CreateDb()
		{
			_connection.CreateTable<Project>();
			_connection.CreateTable<Activity>();
		}

		public void ClearTables()
		{
			_connection.DeleteAll<Project>();
			_connection.DeleteAll<Activity>();
		}
	}
}
