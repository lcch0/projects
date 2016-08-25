
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLAccessor.Mappings
{
	[Table("projects")]
	public class Project
	{
		public enum ProjectType
		{
			Design = 0,
			Mobile,
			Unity
		}

		[Column("projectid")]
		public int Id { get; set; }
		[Column("type")]
		public int Type { get; set; }

		public virtual ICollection<Activity> Activities { get; set; }
	}
}
