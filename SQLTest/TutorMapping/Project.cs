using System.Collections.Generic;
using SQLite;

namespace TutorMapping
{
	[Table("projects")]
	public class Project : IActiveRecord<Project>
	{
		public enum ProjectType
		{
			Design = 0,
			Mobile,
			Unity
		}

		[PrimaryKey, AutoIncrement, Column("projectid")]
		public int Id { get; set; }
		[Column("type")]
		public int Type { get; set; }

		public IEnumerable<Activity> Activities { get; set; }

		public IEnumerable<Project> GetRecord(int id, ISqliteContext context)
		{
			IEnumerable<Project> projects = null;
			if (id < 0)
			{
				projects = context.Connection.Table<Project>();
			}
			else
			{
				projects = context.Connection.Table<Project>().Where(p => p.Id == id);
			}

			var emptyActivity = new Activity();
			foreach (var project in projects)
			{

				project.Activities = emptyActivity.GetRecord()
			}
		}

		public int AddRecord(Project record, ISqliteContext context)
		{
			return context.Connection.Insert(record);
		}
	}
}
