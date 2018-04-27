using System;
using System.Collections.Generic;
using Storage.Interfaces;

namespace Storage.Serializable
{
	public class Activity : IIdRecord
	{
		public int Id { get; set; }
		public string TableName => "Activities";
		public DateTime Date { get; set; } = DateTime.Now;
		public string Desc { get; set; } = string.Empty;
		public float Days { get; set; }
		public Project Project { get; set; } = new Project();
		public User User { get; set; } = new User();
		public List<Draft> Drafts { get; set; } = new List<Draft>();

	    public string GetDate()
	    {
	        return $"{Date.Day}-{Date.Month}-{Date.Year}";
	    }

	    public void SetDate(string s)
	    {
	        var arr = s.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

	        Date = DateTime.Now;
	        if (arr.Length < 3)
	        {
	            return;
	        }

	        if(int.TryParse(arr[0], out var day))
                if(int.TryParse(arr[1], out var month))
                    if(int.TryParse(arr[2], out var year))
                        Date = new DateTime(year, month, day);

	    }
	}
}
