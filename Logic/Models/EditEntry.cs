using System;
using System.Globalization;

namespace Logic.Models
{
    public class EditEntry
    {
	    public DateTime Date { get; set; } = DateTime.Now;

	    public int Week
	    {
		    get
		    {
			    var day = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstDay,
				    DayOfWeek.Monday);
			    return day;
		    }
	    }

		public string Project { get; set; }
	    public float Days { get; set; }
	    public string Description { get; set; }
	}
}
