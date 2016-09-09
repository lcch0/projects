using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace TutorMapping
{
	[Table("activities")]
	public class Activity : BaseActiveRecord<Activity>, IIdRecord
	{
		[PrimaryKey, AutoIncrement, Column("activityid")]
		public int Id { get; set; } = 1;
		[Column("date")]
		public DateTime Date { get; set; }
		[MaxLength(1024), Column("desc")]
		public string Desc { get; set; }
		[Column("projectid")]
		public int ParentId { get; set; }
	}
}
