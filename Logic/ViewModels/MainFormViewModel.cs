using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Storage.Serializable;
using Storage.Serializers;

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
				GenerateSettings();
				GenerateDefaultData();
				return;
			}

			Model.Activities = new List<ActivityModel>();

			try
			{
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
			catch (Exception ex)
			{
				GenerateDefaultData();
				throw;
			}
		}

		private void GenerateSettings()
		{
			Model.Settings = new Settings();
		}

		private void LoadProjects(LiteDbSerializer context)
		{
			var projects = context.GetRecords<Project>();
			foreach (var project in projects)
			{
				var model = new ProjectModel(project);
				Model.Projects.Add(model);
			}

			if (Model.Projects.Count < 1)
				GenerateDefaultProjects();

		}

		private void LoadUsers(LiteDbSerializer context)
		{
			var users = context.GetRecords<User>();
			foreach (var user in users)
			{
				var model = new UserModel(user);
				Model.Users.Add(model);
			}

			Model.SelectedUser = Model.Users.Find(u => u.Name.Equals(Model.Settings.UserName, StringComparison.OrdinalIgnoreCase));
			if(Model.SelectedUser == null)
				Model.SelectedUser = new UserModel {Name = Model.Settings?.UserName ?? "No user"};
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
		
		private void GenerateDefaultData()
		{
			var p = GenerateDefaultProjects();

			var user = new User {Name = "No user"};
			var umodel = new UserModel(user);
			Model.Users.Add(umodel);

			var e = new Activity
			{
				Project = p,
				User = user,
				Date = DateTime.Now,
				Days = 5
			};

			Model.Activities.Add(new ActivityModel(e));

			using (var context = new LiteDbSerializer(Model.Settings.ConnectionStr))
			{
				foreach (var model in Model.Projects)
				{
					context.AddRecord(model.GetStorageObject());
				}

				foreach (var model in Model.Users)
				{
					context.AddRecord(model.GetStorageObject());
				}

				foreach (var model in Model.Activities)
				{
					context.AddRecord(model.GetStorageObject());
				}
			}
		}

		private Project GenerateDefaultProjects()
		{
			Project result = null;
			var p = new Project {ProjectType = (int) ProjectModel.eType.Design};
			var pmodel = new ProjectModel(p);
			Model.Projects.Add(pmodel);

			result = p;

			p = new Project {ProjectType = (int) ProjectModel.eType.Mobile};
			pmodel = new ProjectModel(p);
			Model.Projects.Add(pmodel);

			p = new Project {ProjectType = (int) ProjectModel.eType.Unity};
			pmodel = new ProjectModel(p);
			Model.Projects.Add(pmodel);

			return result;
		}
	}
}
