using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Storage.Serializable;

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
			ProjectType = ProjectModel.GetProjectType(activity.Project?.ProjectType);
			UserName = activity.User?.Name ?? "No user";
		}

		public ActivityModel()
		{
			
		}

		public DateTime Date { get; set; }
		public float Days { get; set; }
		public string Description { get; set; }
		public List<DraftModel> Drafts { get; set; }

		public int Week
			=> CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

		public ProjectModel.eType ProjectType { get; set; }

		public string ProjectDesc => ProjectModel.GetProjectDesc(ProjectType);

		public string UserName { get; set; }
	}
}
