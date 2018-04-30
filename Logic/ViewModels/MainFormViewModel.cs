using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.ViewModels.StorageOperations;

namespace Logic.ViewModels
{
    public class MainFormViewModel : BaseViewModel
    {
        private const string ReportName = "report.txt";

        public MainFormViewModel(TimeSheetsModel model) : base(model)
        {
            LoadDBCommand = new RelayCommand<MainFormViewModel>(LoadDB);
            LoadSettingsCommand = new RelayCommand<string>(LoadSettings);
            MergeActivitiesCommand = new RelayCommand<string>(MergeActivities);
            GenerateCsvCommand = new RelayCommand<string>(GenerateCsvFile);
            ArchiveCommand = new RelayCommand<List<ActivityModel>>(Archive);
        }

        public string ReportFullPath { get; set; } = string.Empty;
        public string SettingsPath => Model?.Settings?.Path;

        public Action OnQuit { get; set; }
        public ICommand LoadSettingsCommand { get; set; }
        public ICommand LoadDBCommand { get; set; }
        public ICommand MergeActivitiesCommand { get; set; }
        public ICommand GenerateCsvCommand { get; set; }
        public ICommand ArchiveCommand { get; set; }

        private void LoadSettings(string path)
        {
            var settingsViewModel = new SettingsViewModel(Model);
            settingsViewModel.LoadSettingsCommand.Execute(path);
        }

        private void LoadDB(MainFormViewModel obj)
        {
            var s = new MainFormViewSerializer(Model);

            Model.Activities = new List<ActivityModel>();

            s.LoadTo();

            if (Model.Activities.Count > 0)
            {
                Model.Activities = Model.Activities.OrderByDescending(e => e.Date).ToList();
                Model.SelectedActivity = Model.Activities[0];
                var user = Model.Users.Find(u =>
                    u.Name.Equals(Model.SelectedActivity.UserName, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                    Model.SelectedUser = user;

                var project = Model.Projects.Find(u => u.ProjectType == Model.SelectedActivity.ProjectType);
                if (project != null)
                    Model.SelectedProject = project;
            }
        }

        private void MergeActivities(string stub)
        {
            var serializer = new EditorViewModelSerializer(Model);

            foreach (var project in Model.Projects)
            {
                var pactivities = Model.Activities.FindAll(a => a.ProjectType == project.ProjectType);
                if (pactivities.Count < 1)
                    continue;

                var mergedActivities = new Dictionary<int, List<ActivityModel>>();
                foreach (var pactivity in pactivities)
                {
                    if (!mergedActivities.ContainsKey(pactivity.Week))
                    {
                        mergedActivities.Add(pactivity.Week, new List<ActivityModel>{pactivity});
                    }
                    else
                    {
                        mergedActivities[pactivity.Week].Add(pactivity);
                    }
                }

                foreach (var mergedActivity in mergedActivities)
                {
                    var mainActivity = mergedActivity.Value[0];
                    var bld = new StringBuilder(mainActivity.Description);
                    
                    for (int i = 1; i < mergedActivity.Value.Count; i++)
                    {
                        var activity = mergedActivity.Value[i];
                        var desc = activity.GetDescription(true);
                        bld.AppendLine(desc);
                        serializer.DeleteActivity(activity.GetStorageObject(), false);
                    }

                    mainActivity.Description = bld.ToString();
                    serializer.SaveActivity(mainActivity.GetStorageObject(), true);
                }
            }

            LoadDB(this);
        }

        private void GenerateCsvFile(string path)
        {
            ReportFullPath = string.Empty;
            var folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
                return;

            folder = Path.Combine(folder, ReportName);
            var bld = new StringBuilder();

            var activities = Model.Activities.OrderByDescending(a => a.Date);

            foreach (var activity in activities)
            {
                activity.MergeDrafts();
                var start = DraftViewModel.GetWeekDay(activity.Date, 1);
                var end = DraftViewModel.GetWeekDay(activity.Date, 5);
                bld.Append($"{GetDateString(start)} - {GetDateString(end)};");
                bld.Append($"{activity.ProjectType};");
                bld.AppendLine($"{activity.Days} days;");
                bld.AppendLine($"{activity.Description};");
                bld.AppendLine();
            }

            if (bld.Length > 0)
            {
                File.WriteAllText(folder, bld.ToString());
                ReportFullPath = folder;
            }
        }

        private string GetDateString(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }

        private void Archive(List<ActivityModel> activityModels)
        {
            var currentPath = Model.Settings.ConnectionStr;
            var arcPath = Path.GetDirectoryName(currentPath);
            if (arcPath != null)
            {
                arcPath = Path.Combine(arcPath, DateTime.Now.Year.ToString());
                if (!Directory.Exists(arcPath))
                    Directory.CreateDirectory(arcPath);

                arcPath = $"{Path.Combine(arcPath, Settings.DEFAULT_DBFILENAME)}_{DateTime.Now.ToShortDateString()}";
                File.Copy(currentPath, arcPath, true);

                var serializer = new EditorViewModelSerializer(Model);
                foreach (var activity in activityModels)
                {
                    serializer.DeleteActivity(activity.GetStorageObject(), false);
                }

                LoadDB(this);
            }
        }
    }
}