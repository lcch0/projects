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
		public Action OnQuit { get; set; }
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
					var user = Model.Users.Find(u => u.Name.Equals(Model.SelectedActivity.UserName, StringComparison.OrdinalIgnoreCase));
					if (user != null)
						Model.SelectedUser = user;

					var project = Model.Projects.Find(u => u.ProjectType == Model.SelectedActivity.ProjectType);
					if (project != null)
						Model.SelectedProject = project;
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
				GenerateDefaultProjects(context);

			Model.SelectedProject = Model.Projects[0];

			foreach (var item in Model.Projects)
			{
				if(item.ProjectDesc.Contains(Model.Settings.Project))
				{
					Model.SelectedProject = item;
					break;
				}
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

			if(Model.Users.Count == 0)
			{
				var user = new UserModel { Id = 1, Name = Model.Settings.UserName };
				Model.Users.Add(user);
				context.AddRecord(user.GetStorageObject());
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
			using (var context = new LiteDbSerializer(Model.Settings.ConnectionStr))
			{ 
				GenerateDefaultProjects(context); 

				foreach (var model in Model.Projects)
				{
					model.Id = context.AddRecord(model.GetStorageObject());
				}

				var umodel = new UserModel { Id = 1, Name = "No user" };
				Model.Users.Add(umodel);

				foreach (var model in Model.Users)
				{
					model.Id = context.AddRecord(model.GetStorageObject());
				}

				var a = new ActivityModel
				{
					Id = 1,
					Date = DateTime.Now,
					Days = 0,
					Description = string.Empty,
					ProjectType = ProjectModel.eType.Design,
					UserName = umodel.Name
				};

				foreach (var model in Model.Activities)
				{
					model.Id = context.AddRecord(model.GetStorageObject());
				}
			}
		}

		private void GenerateDefaultProjects(LiteDbSerializer context)
		{
			var pmodel = new ProjectModel { Id = 1, ProjectType = ProjectModel.eType.Design };
			Model.Projects.Add(pmodel);
			context.AddRecord(pmodel.GetStorageObject());

			pmodel = new ProjectModel { Id = 2, ProjectType = ProjectModel.eType.Mobile };
			Model.Projects.Add(pmodel);
			context.AddRecord(pmodel.GetStorageObject());

			pmodel = new ProjectModel { Id = 3, ProjectType = ProjectModel.eType.Unity };
			Model.Projects.Add(pmodel);
			context.AddRecord(pmodel.GetStorageObject());
		}
	}
}
