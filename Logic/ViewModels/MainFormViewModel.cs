using System;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;

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
				
			}
			DummyLoad();
		}

		private void DummyLoad()
		{
			var e = new EditEntry();
			e.Date = DateTime.Now - TimeSpan.FromDays(7);
			e.Project = "Test 7";
			e.Description = "Desc 7";
			e.Days = 5;

			Model.Entries.Add(e);

			e = new EditEntry();
			e.Date = DateTime.Now - TimeSpan.FromDays(14);
			e.Project = "Test 14";
			e.Description = "Desc 14";
			e.Days = 5;

			Model.Entries.Add(e);

			e = new EditEntry();
			e.Date = DateTime.Now - TimeSpan.FromDays(21);
			e.Project = "Test 21";
			e.Description = "Desc 21";
			e.Days = 5;

			Model.Entries.Add(e);

			e = new EditEntry();
			e.Date = DateTime.Now - TimeSpan.FromDays(28);
			e.Project = "Test 28";
			e.Description = "Desc 28";
			e.Days = 5;

			Model.Entries.Add(e);
		}
	}
}
