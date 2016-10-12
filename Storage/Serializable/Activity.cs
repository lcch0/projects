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
	}
}
