using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.ViewModels.StorageOperations;

namespace Logic.ViewModels
{
    public class DraftViewModel : BaseViewModel
    {
        public DraftViewModel(TimeSheetsModel model) : base(model)
        {
            Model = model;
            AddNewDraft = new RelayCommand<Tuple<string, ProjectModel>>(OnAddNewDraft);
        }

        public List<ActivityModel> Activities => Model.Activities;

        public string Text { get; set; }

        public ICommand AddNewDraft { get; set; }
        public List<ProjectModel> Projects => Model.Projects;
        public ProjectModel SelectedProject
        {
            get => Model.SelectedProject;
            set => Model.SelectedProject = value;
        }

        private void OnAddNewDraft(Tuple<string, ProjectModel> pair)
        {
            if (string.IsNullOrEmpty(pair.Item1))
                return;

            Text = pair.Item1;
            var now = DateTime.Now;
            var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            var foundActivity = Activities.Find(a => a.Week == week && a.ProjectType == pair.Item2.ProjectType);
            
            if(foundActivity == null)
                foundActivity = CreateNewActivity(pair.Item2);

            var draft = new DraftModel(null) {Text = Text};
            foundActivity.Drafts.Add(draft);

            var s = new DraftViewModelSerializer(Model);
            s.SaveActivity(foundActivity);
        }

        private ActivityModel CreateNewActivity(ProjectModel pairItem2)
        {
            var a = new ActivityModel
            {
                Date = DateTime.Now,
                Drafts = new List<DraftModel>(),
                Days = 5,
                ProjectType = pairItem2?.ProjectType ?? Model.SelectedProject.ProjectType,
                UserName = Model.Settings?.UserName
            };

            Activities.Add(a);

            return a;
        }
        
        internal static DateTime GetWeekDay(DateTime date, int day)
        {
            var shift = day - (int) date.DayOfWeek;
            var ts = new TimeSpan(shift, 0, 0, 0);
            return date + ts;
        }
    }
}