using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Logic.Models
{
	[XmlRoot("Settings")]
	public class Settings
	{
		public const string DEFAULT_FILENAME = "settings.xml";
		public const string DEFAULT_DBFILENAME = "timesheets.db";

		//some settings to load model from db
		[XmlIgnore]
		public string Path { get; set; }
		[XmlElement("UserName")]
		public string UserName { get; set; } = "DSN";
		[XmlElement("Password")]
		public string Password { get; set; } = "";
		[XmlElement("ConnectionStr")]
		public string ConnectionStr { get; set; }

		[XmlArrayItem("Timer", typeof(DayTimer))]
		[XmlArray("Timers")]
		public List<DayTimer> Timers { get; set; }

		public Settings()
		{
			ConnectionStr = GetDefaultDbPath(Environment.CurrentDirectory);
		}

		public void CopyTo(Settings settings)
		{
			settings.UserName = UserName;
			settings.Password = Password;
			settings.ConnectionStr = ConnectionStr;
			settings.Timers = Timers;
		}

		public static Settings GetDefaultSettings()
		{
			return new Settings {Path = GetDefaultPath(Environment.CurrentDirectory) };
		}

		private static string GetDefaultDbPath(string root)
		{
			return string.Format($"{root}\\{DEFAULT_DBFILENAME}");
		}

		public static string GetDefaultPath(string root)
		{
			return string.Format($"{root}\\{DEFAULT_FILENAME}");
		}
	}
}
