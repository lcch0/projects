using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Logic.Models
{
	[XmlRoot("Settings")]
	public class Settings
	{
		public const string DEFAULT_FILENAME = "settings.xml";

		//some settings to load model from db
		[XmlIgnore]
		public string Path { get; set; }
		[XmlElement("UserName")]
		public string UserName { get; set; } = "Test name";
		[XmlElement("Password")]
		public string Password { get; set; } = "Test pass";
		[XmlElement("ConnectionStr")]
		public string ConnectionStr { get; set; } = "Test conn str";

		[XmlArrayItem("Timer", typeof(DayTimer))]
		[XmlArray("Timers")]
		public List<DayTimer> Timers { get; set; }

		public void CopyTo(Settings settings)
		{
			settings.UserName = UserName;
			settings.Password = Password;
			settings.ConnectionStr = ConnectionStr;
			settings.Timers = Timers;
		}

		public static Settings GetDefaultSettings()
		{
			return new Settings {Path = GetDefaultPath(Environment.CurrentDirectory)};
		}

		public static string GetDefaultPath(string root)
		{
			return string.Format($"{root}\\{DEFAULT_FILENAME}");
		}
	}
}
