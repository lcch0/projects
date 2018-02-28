using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Logic.Commands;
using Logic.DbSerializer.LiteDb;
using Logic.Models;
using Storage.Serializable;

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
            ArchiveCommand = new RelayCommand<int>(Archive);
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
                    var user = Model.Users.Find(u =>
                        u.Name.Equals(Model.SelectedActivity.UserName, StringComparison.OrdinalIgnoreCase));
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

        private void MergeActivities(string stub)
        {
            var serializer = new EditorViewModelSerializer(Model);
            var mergedActivities = new Dictionary<int, List<ActivityModel>>();
            foreach (var activity in Model.Activities)
            {
                if (!mergedActivities.ContainsKey(activity.Week))
                    mergedActivities.Add(activity.Week, new List<ActivityModel> {activity});

                var foundActivities = mergedActivities[activity.Week];
                var projectActivity =
                    foundActivities.Find(a => a.ProjectType == activity.ProjectType && a.UserName == activity.UserName);

                if (projectActivity == null)
                {
                    foundActivities.Add(activity);
                }
                else
                {
                    var desc = activity.GetDescription(true);
                    var newDraft = new DraftModel(new Draft {Desc = desc});
                    GenerateAndAddDescIfEmpty(projectActivity, desc);
                    projectActivity.Drafts.Add(newDraft);
                }

                serializer.DeleteActivity(activity.GetStorageObject(), false);
            }

            foreach (var lists in mergedActivities.Values)
            foreach (var model in lists)
            {
                var a = GetActivity(model);
                a.Id = 0;
                serializer.SaveActivity(a, true);
            }

            LoadDB(this);
        }

        private static void GenerateAndAddDescIfEmpty(ActivityModel projectActivity, string desc)
        {
            if (string.IsNullOrEmpty(projectActivity.Description))
            {
                var ind = desc.IndexOf('\r');
                ind = ind < 0 ? desc.IndexOf('\n') : ind;
                if (ind > 0)
                    projectActivity.Description = desc.Substring(0, ind);
            }
        }

        private void GenerateCsvFile(string path)
        {
            ReportFullPath = string.Empty;
            var folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
                return;

            folder = Path.Combine(folder, ReportName);
            var bld = new StringBuilder();

            var activities = Model.Activities.OrderBy(a => a.Date);

            foreach (var activity in activities)
            {
                activity.MergeDrafts();
                var start = DraftViewModel.GetWeekDay(activity.Date, 1);
                var end = DraftViewModel.GetWeekDay(activity.Date, 5);
                bld.Append($"{GetDateString(start)} - {GetDateString(end)};");
                bld.Append($"{activity.ProjectType};");
                bld.AppendLine($"{activity.Description};");
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

        private void Archive(int i)
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
            }
        }
    }
}