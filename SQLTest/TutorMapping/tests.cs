using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using NUnit.Framework;

namespace TutorMapping
{
	[TestFixture]
	class Tests
	{
		[Test]
		public void testAdd()
		{
			var p = new Project {Type = Project.ProjectType.Mobile};

			var u = new User { Name = "DSN" };

			var a = new Activity
			{
				Date = DateTime.Now,
				Desc = "Time sheet activity",
				Project = p,
				User = u
			};

			using (var db = new LiteDatabase(@"k:\mine\sources\winphone\desk\TimeSheets\nosql.db"))
			{
				BsonMapper.Global.Entity<Activity>().DbRef(x => x.Project, "projects");
				BsonMapper.Global.Entity<Activity>().DbRef(x => x.User, "users");

				var projects = db.GetCollection<Project>("projects");
				projects.Insert(p);

				var users = db.GetCollection<User>("users");
				users.Insert(u);

				var activities = db.GetCollection<Activity>("activities");
				activities.Insert(a);
			}

			using (var db = new LiteDatabase(@"k:\mine\sources\winphone\desk\TimeSheets\nosql.db"))
			{
				BsonMapper.Global.Entity<Activity>().DbRef(x => x.Project, "projects");
				BsonMapper.Global.Entity<Activity>().DbRef(x => x.User, "users");

				var collection = db.GetCollection<Activity>("activities");
				var activities = collection.Include(x => x.Project).Include(x => x.User);
				var list = activities.Find(x => x.User.Id == 1);

				//var list1 = db
				//	.GetCollection<Activity>("activities")
				//	.Include(x => x.Project)
				//	.Include(x => x.User).Find(x => x.User.Name.Equals("DSN", StringComparison.OrdinalIgnoreCase));

				var aList1 = activities.FindAll().ToList();
				var aList = list.ToList();
				
			}
		}
	}
}
