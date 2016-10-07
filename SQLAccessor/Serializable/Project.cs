using SQLAccessor.Interfaces;

namespace SQLAccessor.Serializable
{
	public class Project : IIdRecord
	{
		public enum ProjectType
		{
			Design = 0,
			Mobile,
			Unity
		}

		public int Id { get; set; }
		public string TableName => "Projects";
		public ProjectType Type { get; set; }
	}
}