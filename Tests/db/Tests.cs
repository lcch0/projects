using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TutorMapping;

namespace Tests.db
{
	[TestFixture]
	class Tests
	{
		private ISqliteContext _context = null;
		private const string DBPath = @"K:\mine\sources\winphone\desk\TimeSheets\test.db";
		[SetUp]
		public void Init()
		{
			if(File.Exists(DBPath))
				File.Delete(DBPath);

			_context = new TutorMappingContext(@"K:\mine\sources\winphone\desk\TimeSheets\test.db");
			_context.CreateDb();
		}

		[TearDown]
		public void Clear()
		{
			_context.Dispose();
			_context = null;
		}

		[Test]
		public void TestSqliteAdd()
		{
			var proj = new Project
			{
				Type = (int)Project.ProjectType.Design,
				Activities = new List<Activity> { new Activity { Date = DateTime.Now, Desc = "Test" } }
			};

			var pid = proj.AddRecord(_context);
			var pid1 = proj.AddRecord(_context);

			var np = new Project().GetRecord(_context, pid);
			Assert.IsNotEmpty(np);

			var np1 = new Project().GetRecord(_context, pid1);
			Assert.IsNotEmpty(np1);
		}

		[Test]
		public void TestSqliteUpdate()
		{
			var proj = new Project
			{
				Type = (int)Project.ProjectType.Design,
				Activities = new List<Activity> { new Activity { Date = DateTime.Now, Desc = "Test" } }
			};

			proj.Id = proj.AddRecord(_context);
			proj.Type = (int)Project.ProjectType.Mobile;
			proj.UpdateRecord(_context);

			var np = new Project().GetRecord(_context, proj.Id);
			Assert.IsNotEmpty(np);

			var p = np.FirstOrDefault();
			Assert.IsTrue(p.Type == (int)Project.ProjectType.Mobile);
		}
	}
	
}
