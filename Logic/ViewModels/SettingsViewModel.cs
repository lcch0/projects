using System;
using System.IO;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.XmlSerializers;

namespace Logic.ViewModels
{
	public class SettingsViewModel : BaseViewModel
	{
		public Settings Settings
		{
			get { return Model.Settings; }
			set { Model.Settings = value; }
		}

		public string UserName
		{
			get { return Model.Settings.UserName; }
			set
			{
				if (Model.Settings.UserName == value)
					return;

				Model.Settings.UserName = value;
			}
		}

		public string Password
		{
			get { return Model.Settings.Password; }
			set
			{
				if (Model.Settings.Password == value)
					return;

				Model.Settings.Password = value;
			}
		}

		public string DbPath
		{
			get { return Model.Settings.Path; }
			set
			{
				if (Model.Settings.Path == value)
					return;

				Model.Settings.Path = value;
			}
		}

		public string Project
		{
			get { return Model.Settings.Project; }
			set
			{
				if (Model.Settings.Project == value)
					return;

				Model.Settings.Project = value;
			}
		}

		public ICommand SaveSettingsCommand { get; set; }
		public ICommand LoadSettingsCommand { get; set; }

		public SettingsViewModel(TimeSheetsModel model) : base(model)
		{
			SaveSettingsCommand = new RelayCommand<Settings>(SaveSettings);
			LoadSettingsCommand = new RelayCommand<string>(LoadSettings);
		}

		private void SaveSettings(Settings obj)
		{
			Exception ex;
			SingleFileSerializer<Settings>.Save(obj, obj.Path, out ex);
			Model.RaisePropertyChanged(this, () => Model.Settings);
		}

		private void LoadSettings(string path)
		{
			if (File.Exists(path))
			{
				Exception ex;
				Settings = SingleFileSerializer<Settings>.Load(path, out ex);
				if (ex == null && Settings != null)
				{
					Settings.Path = path;
					Model.RaisePropertyChanged(this, () => Model.Settings);
					return;
				}
			}

			Settings = Settings.GetDefaultSettings();
		}
	}
}
