using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SQLAccessor.Serializable;

namespace Logic.Models
{
	public class ActivityModel
	{
		public ActivityModel(Activity activity)
		{
			Date = activity.Date;
			Days = activity.Days;
			Description = activity.Desc;
			Drafts = activity.Drafts?.Select(d => new DraftModel(d)).ToList();
			ProjectType = activity.Project?.Type ?? Project.ProjectType.Design;
			UserName = activity.User?.Name ?? "No user";
		}

		public DateTime Date { get; set; }
		public float Days { get; set; }
		public string Description { get; set; }
		public List<DraftModel> Drafts { get; set; }

		public int Week
			=> CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

		public Project.ProjectType ProjectType { get; set; }

		public string ProjectDesc
		{
			get
			{
				switch (ProjectType)
				{
					case Project.ProjectType.Design:
						return "Design";
					case Project.ProjectType.Mobile:
						return "Mobile";
					case Project.ProjectType.Unity:
						return "Unity";
					default:
						return "Design";
				}
			}
		}

		public string UserName { get; set; }
	}
}
