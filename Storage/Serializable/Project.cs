using Storage.Interfaces;

namespace Storage.Serializable
{
	public class Project : IIdRecord
	{
	    public enum EType
	    {
	        Design = 1,
	        Mobile = 2,
	        Unity = 3,
            Corning = 4,
            Internal = 5,
            Ftth = 6,
            NonDev = 7,
            Training = 8,
            Vakation = -1,
	    }
		public int Id { get; set; }
		public string TableName => "Projects";
		public int ProjectType { get; set; }
	}
}