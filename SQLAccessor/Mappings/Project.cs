
using System.Collections.Generic;
using System.Linq;
using SQLAccessor.Interfaces;
using SQLite;

namespace SQLAccessor.Mappings
{
	[System.ComponentModel.DataAnnotations.Schema.Table("projects")]
	public class Project : BaseActiveRecord<Project>, IIdRecord
	{
		public enum ProjectType
		{
			Design = 0,
			Mobile,
			Unity
		}

		[PrimaryKey, AutoIncrement, System.ComponentModel.DataAnnotations.Schema.Column("projectid")]
		public int Id { get; set; } = 1;
		[Ignore]
		public int ParentId { get; set; } = -1;
		[System.ComponentModel.DataAnnotations.Schema.Column("type")]
		public int Type { get; set; }
		[Ignore]
		public IEnumerable<Activity> Activities { get; set; }

		public override IEnumerable<Project> GetRecord(ISqliteContext context, int id = -1, int parentid = -1)
		{
			var projects = base.GetRecord(context, id, parentid);

			var list = projects.ToList();
			foreach (var project in list)
			{
				project.Activities = new Activity().GetRecord(context, -1, project.Id);
			}

			return list;
		}

		public override int AddRecord(ISqliteContext context)
		{
			int pid = base.AddRecord(context);

			foreach (var activity in Activities)
			{
				activity.ParentId = pid;
				activity.AddRecord(context);
			}

			return pid;
		}
	}
}
