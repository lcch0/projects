﻿namespace TutorMapping
{
	public class Project
	{
		public enum ProjectType
		{
			Design = 0,
			Mobile,
			Unity
		}

		public int Id { get; set; }
		public ProjectType Type { get; set; }
	}
}
