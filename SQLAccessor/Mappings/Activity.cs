using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLAccessor.Mappings
{
	[Table("activities")]
	public class Activity
	{
		[Column("activityid")]
		public int Id { get; set; }
		[Column("date")]
		public DateTime Date { get; set; }
		[Column("desc")]
		public string Desc { get; set; }

		public virtual Project Project { get; set; }
		public virtual User User { get; set; }
		public virtual Draft Draft { get; set; }
	}
}
