using System;
using System.Collections.Generic;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Storage.Serializable;
using Storage.Serializers;

namespace Logic.ViewModels
{
	public class DraftViewModel : BaseViewModel
	{
		private List<ActivityModel> Activities => Model.Activities;

		public string Text { get; set; }

		public ICommand AddNewDraft { get; set; }

		public DraftViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			AddNewDraft = new RelayCommand<string>(OnAddNewDraft);
		}

		private void OnAddNewDraft(string text)
		{
			if (string.IsNullOrEmpty(text))
				return;

			Text = text;
			var now = DateTime.Now;
			DateTime weekStart = GetWeekDay(now, 1);
			DateTime weekEnd = GetWeekDay(now, 5);
			var foundActivity = Activities.Find(a => a.Date >= weekStart && a.Date <= weekEnd) ?? CreateNewActivity();

			var draft = new DraftModel(null) {Text = Text};
			foundActivity.Drafts.Add(draft);

			SaveActivity(foundActivity);
		}

		private void SaveActivity(ActivityModel activityModel)
		{
			Activity activity = GetActivity(activityModel);
			if (activity == null)
				return;

			using (var context = new LiteDbSerializer(Model.Settings.ConnectionStr))
			{
				if (activity.Project.Id == 0)
				{
					context.AddRecord(activity.Project, context.GetCollection<Project>());
				}

				if (activity.User.Id == 0)
				{
					context.AddRecord(activity.User, context.GetCollection<User>());
				}

				var collection = context.GetCollection<Activity>();
				collection = collection.Include(x => x.Project).Include(x => x.User);
				if (activity.Id == 0)
				{
					activityModel.Id = context.AddRecord(activity, collection);
					Model.RaisePropertyChanged(this, () => Model.Activities);
				}
				else
				{
					context.UpdateRecord(activity, collection);
				}
			}
		}

		private Activity GetActivity(ActivityModel activity)
		{
			var a = activity.GetStorageObject();
			a.Project = Model.SelectedProject.GetStorageObject();
			a.User = Model.SelectedUser.GetStorageObject();

			return a;
		}

		private ActivityModel CreateNewActivity()
		{
			var a = new ActivityModel
			{
				Date = DateTime.Now,
				Drafts = new List<DraftModel>(),
				Days = 5,
				ProjectType = GetDefaultProject(),
				UserName = Model.Settings?.UserName
			};

			Activities.Add(a);

			return a;
		}

		private ProjectModel.eType GetDefaultProject()
		{
			var projStr = Model.Settings.Project;
			if(string.IsNullOrEmpty(projStr))
				return ProjectModel.eType.Design;

			if(ProjectModel.eType.Design.ToString().Equals(projStr, StringComparison.OrdinalIgnoreCase))
				return ProjectModel.eType.Design;

			if (ProjectModel.eType.Mobile.ToString().Equals(projStr, StringComparison.OrdinalIgnoreCase))
				return ProjectModel.eType.Mobile;

			if (ProjectModel.eType.Unity.ToString().Equals(projStr, StringComparison.OrdinalIgnoreCase))
				return ProjectModel.eType.Unity;

			return ProjectModel.eType.Design;
		}

		private DateTime GetWeekDay(DateTime date, int day)
		{
			var shift = day - (int)date.DayOfWeek;
			TimeSpan ts = new TimeSpan(shift, 0, 0, 0);
			return date + ts;
		}
	}
}
