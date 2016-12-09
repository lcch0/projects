using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Storage.Serializable;

namespace Logic.Models
{
	public class ActivityModel
	{
		public ActivityModel(Activity activity)
		{
			Id = activity.Id;
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

		public int Id { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public float Days { get; set; }
		public string Description { get; set; } = string.Empty;

		public List<DraftModel> Drafts { get; set; } = new List<DraftModel>();

		public int Week
			=> CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

		public ProjectModel.eType ProjectType { get; set; } = ProjectModel.eType.Design;

		public string ProjectDesc => ProjectModel.GetProjectDesc(ProjectType);

		public string UserName { get; set; } = string.Empty;

		public void CopyTo(ActivityModel newActivity)
		{
			newActivity.Date = Date;
			newActivity.Days = Days;
			newActivity.Description = Description;
			newActivity.Drafts = new List<DraftModel>(Drafts);
			newActivity.ProjectType = ProjectType;
			newActivity.UserName = UserName;
		}

		public Activity GetStorageObject()
		{
			return new Activity
			{
				Id = Id,
				Date = Date,
				Days = Days,
				Desc = Description,
				Drafts = Drafts.Select(d => new Draft {Id = d.Order, Desc = d.Text}).ToList()
			};
		}

		public string GetDescription(bool isFull)
		{
			if (!isFull)
				return Description;

			var sb = new StringBuilder($"{Description}{Environment.NewLine}{Environment.NewLine}");

			foreach (var draft in Drafts)
			{
				sb.AppendLine(draft.Text);
			}

			return sb.ToString();
		}
	}
}
