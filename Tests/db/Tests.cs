using System;
using System.Collections.Generic;
using System.Data.Entity;
using NUnit.Framework;
using TutorMapping;

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
			using (var context = new TutorMappingContext(@"K:\mine\sources\winphone\desk\TimeSheets\test.db"))
			{
				var proj = new Project {Type = (int)Project.ProjectType.Design};

				proj.Activities = new List<Activity> {new Activity {Date = DateTime.Now, Desc = "Test"}};

				var r = context.AddProject(proj);
				
				context.Project.Attach(r);
				context.Entry(proj).State = EntityState.Added;
				var res = context.SaveChanges();

				var found = context.Project.Find(res);
			}
		}
	}
	
}
