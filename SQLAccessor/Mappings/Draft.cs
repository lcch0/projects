using System.ComponentModel.DataAnnotations.Schema;

namespace SQLAccessor.Mappings
{
	[Table("drafts")]
	public class Draft
	{
		[Column("draftid")]
		public int Id { get; set; }
		[Column("desc")]
		public string Desc { get; set; }

		public virtual Activity Activity { get; set; }
	}
}
