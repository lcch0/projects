using SQLAccessor.Interfaces;

namespace SQLAccessor.Serializable
{
	public class Draft : IIdRecord
	{
		public string Desc { get; set; } = string.Empty;
		public string TableName => "Drafts";
		public int Id { get; set; }
	}
}
