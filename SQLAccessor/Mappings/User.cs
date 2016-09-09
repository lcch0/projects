using System.Collections.Generic;
using SQLAccessor.Interfaces;
using SQLite;

namespace SQLAccessor.Mappings
{
	[Table("users")]
	public class User : BaseActiveRecord<Project>, IIdRecord
	{
		[Column("userid")]
		public int Id { get; set; }
		[Column("parentid")]
		public int ParentId { get; set; }

		[Column("name")]
		public string Name { get; set; }
		public virtual ICollection<Activity> Activities { get; set; }
	}
}
