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

        public Settings()
        {
            ConnectionStr = GetDefaultDbPath(Environment.CurrentDirectory);
        }

        //some settings to load model from db
        [XmlIgnore] public string Path { get; set; }

        [XmlElement("UserName")] public string UserName { get; set; } = "DSN";

        [XmlElement("Project")] public string Project { get; set; } = "Design";

        [XmlElement("Password")] public string Password { get; set; } = "";

        [XmlElement("ConnectionStr")] public string ConnectionStr { get; set; }

        [XmlArrayItem("Timer", typeof(DayTimer))]
        [XmlArray("Timers")]
        public List<DayTimer> Timers { get; set; } = new List<DayTimer>();

        public void CopyTo(Settings settings)
        {
            settings.UserName = UserName;
            settings.Project = Project;
            settings.Password = Password;
            settings.ConnectionStr = ConnectionStr;
            settings.Timers = Timers;
        }

        public static Settings GetDefaultSettings()
        {
            var settings = new Settings {Path = GetDefaultPath(Environment.CurrentDirectory)};
            settings.Timers.Add(DayTimer.MORNING);
            settings.Timers.Add(DayTimer.NOON);
            settings.Timers.Add(DayTimer.EVENING);
            return settings;
        }

        private static string GetDefaultDbPath(string root)
        {
            return $"{root}\\{DEFAULT_DBFILENAME}";
        }

        public static string GetDefaultPath(string root)
        {
            return $"{root}\\{DEFAULT_FILENAME}";
        }
    }
}