using Storage.Interfaces;

namespace Storage.Serializable
{
	public class Project : IIdRecord
	{
		public int Id { get; set; }
		public string TableName => "Projects";
		public int ProjectType { get; set; }
	}
}