
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLAccessor.Mappings
{
	[Table("users")]
	public class User
	{
		[Column("userid")]
		public int UserId { get; set; }
		[Column("name")]
		public string Name { get; set; }
		public virtual ICollection<Activity> Activities { get; set; }
	}
}
