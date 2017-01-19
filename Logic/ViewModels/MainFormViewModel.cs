using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.DbSerializer.LiteDb;
using Logic.Models;

namespace Logic.ViewModels
{
	public class MainFormViewModel : BaseViewModel
	{
		public Action OnQuit { get; set; }
		public ICommand LoadSettingsCommand { get; set; }
		public ICommand LoadDBCommand { get; set; }

		public MainFormViewModel(TimeSheetsModel model) : base(model)
		{
			LoadDBCommand = new RelayCommand<MainFormViewModel>(LoadDB);
			LoadSettingsCommand = new RelayCommand<string>(LoadSettings);
		}

		private void LoadSettings(string path)
		{
			var settingsViewModel = new SettingsViewModel(Model);
			settingsViewModel.LoadSettingsCommand.Execute(path);
		}

		private void LoadDB(MainFormViewModel obj)
		{
			var s = new MainFormViewSerializer(Model);

			if (Model.Settings == null)
			{
				GenerateSettings();
				s.GenerateDefaultData();
				return;
			}

			Model.Activities = new List<ActivityModel>();

			try
			{
				s.LoadTo();

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
			catch (Exception)
			{
				s.GenerateDefaultData();
				throw;
			}
		}

		private void GenerateSettings()
		{
			Model.Settings = new Settings();
		}
	}
}
