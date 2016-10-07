using System;

namespace TutorMapping
{
	public class Activity
	{
		public int Id { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string Desc { get; set; } = string.Empty;
		public Project Project { get; set; } = new Project();
		public User User { get; set; } = new User();
	}
}
