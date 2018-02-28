using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.XmlSerializers;

namespace Logic.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel(TimeSheetsModel model) : base(model)
        {
            SaveSettingsCommand = new RelayCommand<Settings>(SaveSettings);
            LoadSettingsCommand = new RelayCommand<string>(LoadSettings);
        }

        public Settings Settings
        {
            get => Model.Settings;
            set => Model.Settings = value;
        }

        public string UserName
        {
            get => Model.Settings.UserName;
            set
            {
                if (Model.Settings.UserName == value)
                    return;

                Model.Settings.UserName = value;
            }
        }

        public string Password
        {
            get => Model.Settings.Password;
            set
            {
                if (Model.Settings.Password == value)
                    return;

                Model.Settings.Password = value;
            }
        }

        public string DbPath
        {
            get => Model.Settings.Path;
            set
            {
                if (Model.Settings.Path == value)
                    return;

                Model.Settings.Path = value;
            }
        }

        public string Project
        {
            get => Model.Settings.Project;
            set
            {
                if (Model.Settings.Project == value)
                    return;

                Model.Settings.Project = value;
            }
        }

        public List<DayTimer> DayTimers => Settings.Timers;

        public ICommand SaveSettingsCommand { get; set; }
        public ICommand LoadSettingsCommand { get; set; }

        private void SaveSettings(Settings obj)
        {
            SingleFileSerializer<Settings>.Save(obj, obj.Path, out _);
            Model.RaisePropertyChanged(this, () => Model.Settings);
        }

        private void LoadSettings(string path)
        {
            if (File.Exists(path))
            {
                Settings = SingleFileSerializer<Settings>.Load(path, out var ex);
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