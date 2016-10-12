using Storage.Interfaces;

namespace Storage.Serializable
{
	public class Draft : IIdRecord
	{
		public string Desc { get; set; } = string.Empty;
		public string TableName => "Drafts";
		public int Id { get; set; }
	}
}
