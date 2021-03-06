﻿using System;
using System.Xml.Serialization;

namespace Logic.Models
{
    public class DayTimer
    {
        public static readonly DayTimer MORNING = new DayTimer {Hour = 10, Minute = 0};
        public static readonly DayTimer NOON = new DayTimer {Hour = 13, Minute = 0};
        public static readonly DayTimer EVENING = new DayTimer {Hour = 17, Minute = 0};

        [XmlElement("Hour")] public int Hour { get; set; }

        [XmlElement("Minute")] public int Minute { get; set; }

        [XmlElement("Started")] public int Started { get; set; }

        [XmlElement("Enabled")] public int Enabled { get; set; }

        [XmlIgnore]
        public DateTime TimeSet
        {
            get
            {
                var now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day, Hour, Minute, 0);
            }
            set
            {
                Hour = value.Hour;
                Minute = value.Minute;
            }
        }
    }
}