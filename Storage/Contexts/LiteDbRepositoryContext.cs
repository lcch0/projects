using LiteDB;
using Storage.Interfaces;
using Storage.Serializable;

namespace Storage.Contexts
{
	public class LiteDbRepositoryContext : IRepositoryContext<LiteDatabase>
	{
		private readonly LiteDatabase _connection;

		public LiteDatabase Connection => _connection;
		
		public LiteDbRepositoryContext(string path)
		{
			_connection = new LiteDatabase(path);

			BsonMapper.Global.Entity<Activity>().Id(x => x.Id);
			BsonMapper.Global.Entity<Project>().Id(x => x.Id);
			BsonMapper.Global.Entity<User>().Id(x => x.Id);
			BsonMapper.Global.Entity<Draft>().Id(x => x.Id);

			BsonMapper.Global.Entity<Activity>().DbRef(x => x.Project, new Project().TableName);
			BsonMapper.Global.Entity<Activity>().DbRef(x => x.User, new User().TableName);

		}

		public void Dispose()
		{
			_connection?.Dispose();
		}
	}
}