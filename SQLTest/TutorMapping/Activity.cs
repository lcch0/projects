using System;
using System.Collections.Generic;
using SQLite;

namespace TutorMapping
{
	[Table("activities")]
	public class Activity : IActiveRecord<Activity>
	{
		[PrimaryKey, AutoIncrement, Column("activityid")]
		public int Id { get; set; }
		[Column("date")]
		public DateTime Date { get; set; }
		[MaxLength(1024), Column("desc")]
		public string Desc { get; set; }

		public IEnumerable<Activity> GetRecord(int id, ISqliteContext context)
		{
			throw new NotImplementedException();
		}

		public int AddRecord(Activity record, ISqliteContext context)
		{
			throw new NotImplementedException();
		}
	}
}
