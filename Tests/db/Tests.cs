using NUnit.Framework;
using SQLAccessor.Contexts;

using SQLAccessor.Mappings;

namespace Tests.db
{
	[TestFixture]
	class Tests
	{
		[SetUp]
		public void Init()
		{
		}

		[TearDown]
		public void Clear()
		{
		}

		[Test]
		public void TestSqliteContext()
		{
			using (var context = new SqliteDbContext("SqliteDbContext"))
			{
				var user = context.User.Add(new User {Name = "dss"});
			}
		}
	}
	
}
