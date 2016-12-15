using System.Xml.Serialization;

namespace Logic.Models
{
	public class DayTimer
	{
		public static readonly DayTimer Morning = new DayTimer {Hour = 10, Second = 0};
		public static readonly DayTimer Noon = new DayTimer { Hour = 13, Second = 0 };
		public static readonly DayTimer Evening = new DayTimer { Hour = 17, Second = 0 };

		[XmlElement("Hour")]
		public int Hour { get; set; }
		[XmlElement("Second")]
		public int Second { get; set; }
		[XmlElement("Started")]
		public int Started { get; set; }
	}
}
