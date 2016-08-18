using System.Xml.Serialization;

namespace Logic.Models
{
	public class DayTimer
	{
		[XmlElement("Year")]
		public int Year { get; set; }
		[XmlElement("Month")]
		public int Month { get; set; }
		[XmlElement("Day")]
		public int Day { get; set; }
		[XmlElement("Hour")]
		public int Hour { get; set; }
	}
}
