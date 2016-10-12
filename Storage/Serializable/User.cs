using Storage.Interfaces;

namespace Storage.Serializable
{
	public class User : IIdRecord
	{
		public int Id { get; set; }
		public string TableName => "Users";
		public string Name { get; set; } = string.Empty;
	}
}
