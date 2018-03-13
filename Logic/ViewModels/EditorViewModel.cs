using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.DbSerializer.LiteDb;
using Logic.Models;

namespace Logic.ViewModels
{
    public class EditorViewModel : BaseViewModel
    {
        public EditorViewModel(TimeSheetsModel model) : base(model)
        {
            Model = model;
            if (Model.SelectedActivity == null)
                Model.SelectedActivity = Model.Activities.LastOrDefault();

            ApplyActivityChangedCommand = new RelayCommand<ActivityModel>(ApplyChanges);
        }

        public ActivityModel SelectedActivity
        {
            get => Model.SelectedActivity;
            set => Model.SelectedActivity = value;
        }

        public ActivityModel EditActivity { get; set; }

        public bool IsInEditMode => EditActivity != null;

        public ProjectModel SelectedProject
        {
            get => Model.SelectedProject;
            set => Model.SelectedProject = value;
        }

        public UserModel SelectedUser => Model.SelectedUser;

        public List<ProjectModel> Projects
        {
            get => Model.Projects;
            set => Model.Projects = value;
        }

        public ICommand ApplyActivityChangedCommand { get; set; }

        public string GetDescription()
        {
            if (SelectedActivity == null)
                return string.Empty;

            return SelectedActivity.GetDescription(!IsInEditMode);
        }

        private void ApplyChanges(ActivityModel model)
        {
            var activity = GetActivity(model);
            if (activity == null)
                return;

            var s = new EditorViewModelSerializer(Model);
            try
            {
                model.Id = s.SaveActivity(activity, true);
                SelectedActivity = model;
            }
            finally
            {
                EditActivity = null;
            }
        }

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender != this && e.PropertyName == nameof(Model.SelectedActivity))
                base.OnModelPropertyChanged(sender, e);
        }

        public ActivityModel CreateNewActivity()
        {
            var newActivity = new ActivityModel();
            SelectedActivity?.CopyTo(newActivity);
            return newActivity;
        }
    }
}