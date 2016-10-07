using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using SQLAccessor.Serializable;
using SQLAccessor.Serializers;

namespace Logic.ViewModels
{
	public class MainFormViewModel : BaseViewModel
	{
		public ICommand LoadSettingsCommand { get; set; }
		public ICommand LoadDBCommand { get; set; }
		public ICommand StartTimersCommand { get; set; }

		public MainFormViewModel(TimeSheetsModel model) : base(model)
		{
			LoadDBCommand = new RelayCommand<MainFormViewModel>(LoadDB);
			StartTimersCommand = new RelayCommand<MainFormViewModel>(StartTimers);
			LoadSettingsCommand = new RelayCommand<string>(LoadSettings);
		}

		private void LoadSettings(string path)
		{
			var settingsViewModel = new SettingsViewModel(Model);
			settingsViewModel.LoadSettingsCommand.Execute(path);
		}

		private void StartTimers(MainFormViewModel obj)
		{
			
		}

		private void LoadDB(MainFormViewModel obj)
		{
			if (Model.Settings == null)
			{
				DummyLoad();
				return;
			}

			Model.Activities = new List<ActivityModel>();

			using (var context = new LiteDbSerializer(Model.Settings.ConnectionStr))
			{
				LoadProjects(context);
				LoadUsers(context);
				LoadActivities(context);
			}

			if (Model.Activities.Count > 0)
			{
				Model.Activities = Model.Activities.OrderByDescending(e => e.Date).ToList();
				Model.SelectedActivity = Model.Activities[0];
			}
		}

		private void LoadProjects(LiteDbSerializer context)
		{
			var projects = context.GetRecords<Project>();
			foreach (var project in projects)
			{
				var model = new ProjectModel(project);
				Model.Projects.Add(model);
			}
		}

		private void LoadUsers(LiteDbSerializer context)
		{
			var users = context.GetRecords<User>();
			foreach (var user in users)
			{
				var model = new UserModel(user);
				Model.Users.Add(model);
			}
		}

		private void LoadActivities(LiteDbSerializer context)
		{
			var collection = context.GetCollection<Activity>();
			collection = collection.Include(x => x.Project).Include(x => x.User);
			var activities = context.GetRecords(-1, collection);

			foreach (var activity in activities)
			{
				var model = new ActivityModel(activity);
				Model.Activities.Add(model);
			}
		}
		
		private void DummyLoad()
		{
			var e = new Activity
			{
				Project = new Project {Type = Project.ProjectType.Design},
				User = new User {Name = "No user"},
				Date = DateTime.Now - TimeSpan.FromDays(7),
				Days = 5
			};

			Model.Activities.Add(new ActivityModel(e));
		}
	}
}
