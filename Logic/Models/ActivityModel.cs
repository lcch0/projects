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

        public ProjectModel.EType ProjectType { get; set; } = ProjectModel.EType.Design;

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
                User = new User{Name = UserName},
                Project = new Project{ProjectType = (int)ProjectType},
                Drafts = Drafts.Select(d => new Draft {Id = d.Order, Desc = d.Text}).ToList()
            };
        }

        public string GetDescription(bool isFull)
        {
            if (!isFull)
                return Description;

            var sb = new StringBuilder();

            var strDesc = Description;
            strDesc = strDesc.Trim('\r', '\n');
            if (!string.IsNullOrEmpty(strDesc))
                sb.AppendLine(strDesc);

            foreach (var draft in Drafts)
            {
                var str = draft.Text;
                str = str.Trim('\r', '\n');
                if (!string.IsNullOrEmpty(str))
                    sb.AppendLine(str);
            }

            return sb.ToString();
        }

        public string MergeDrafts()
        {
            Description = GetDescription(true);
            Drafts.Clear();
            return Description;
        }
    }
}