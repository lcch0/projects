using System.Collections.Generic;
using Logic.Models.mvvm;

namespace Logic.Models
{
    public class TimeSheetsModel : ObservableObject
    {
        private List<ActivityModel> _activities = new List<ActivityModel>();
        private List<ProjectModel> _projects = new List<ProjectModel>();
        private ActivityModel _selectedActivity;
        private ProjectModel _selectedProject;
        private UserModel _selectedUser;
        private Settings _settings = new Settings();
        private List<UserModel> _users = new List<UserModel>();
        private List<ActivityModel> _selectedActivities = new List<ActivityModel>();

        public ProjectModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (value == _selectedProject)
                    return;

                _selectedProject = value;
                RaisePropertyChanged(this, () => SelectedProject);
            }
        }

        public List<ProjectModel> Projects
        {
            get => _projects;
            set
            {
                if (value == _projects)
                    return;

                _projects = value;
                RaisePropertyChanged(this, () => Projects);
            }
        }

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (value == _selectedUser)
                    return;

                _selectedUser = value;
                RaisePropertyChanged(this, () => SelectedUser);
            }
        }

        public List<UserModel> Users
        {
            get => _users;
            set
            {
                if (value == _users)
                    return;

                _users = value;
                RaisePropertyChanged(this, () => Users);
            }
        }

        public ActivityModel SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                if (value == _selectedActivity)
                    return;

                _selectedActivity = value;
                RaisePropertyChanged(this, () => SelectedActivity);
            }
        }

        public List<ActivityModel> SelectedActivities
        {
            get => _selectedActivities;
            set
            {
                if (value.Count == _selectedActivities.Count)
                    return;

                _selectedActivities = value;
                //RaisePropertyChanged(this, () => SelectedActivities);
            }
        }

        public List<ActivityModel> Activities
        {
            get => _activities;
            set
            {
                if (value == _activities)
                    return;

                _activities = value;
                RaisePropertyChanged(this, () => Activities);
            }
        }

        public Settings Settings
        {
            get => _settings;
            set
            {
                if (value == _settings)
                    return;

                _settings = value;
                RaisePropertyChanged(this, () => Settings);
            }
        }
    }
}