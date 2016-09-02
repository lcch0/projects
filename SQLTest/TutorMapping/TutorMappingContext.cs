using SQLite;

namespace TutorMapping
{//https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
	public class TutorMappingContext : ISqliteContext
	{
		private readonly SQLiteConnection _connection;

		public TutorMappingContext(string path)
		{
			_connection = new SQLiteConnection(path);
			CreateOrOpenDb();
		}

		private void CreateOrOpenDb()
		{
			_connection.CreateTable<Project>();
			_connection.CreateTable<Activity>();
		}

		public void Dispose()
		{
			_connection?.Dispose();
		}

		public SQLiteConnection Connection =>_connection;
	}
}
