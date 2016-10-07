using System.Collections.Generic;
using Logic.Models.mvvm;
using SQLAccessor.Serializable;

namespace Logic.Models
{
	public class TimeSheetsModel : ObservableObject
	{
		private ActivityModel _selectedActivity;
		private List<ActivityModel> _activities = new List<ActivityModel>();
		private ProjectModel _selectedProject;
		private List<ProjectModel> _projects = new List<ProjectModel>();
		private UserModel _selectedUser;
		private List<UserModel> _users = new List<UserModel>();
		private Settings _settings = new Settings();

		public ProjectModel SelectedProject
		{
			get
			{
				return _selectedProject;
			}
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
			get
			{
				return _projects;
			}
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
			get
			{
				return _selectedUser;
			}
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
			get
			{
				return _users;
			}
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
			get
			{
				return _selectedActivity;
			}
			set
			{
				if (value == _selectedActivity)
					return;

				_selectedActivity = value;
				RaisePropertyChanged(this, () => SelectedActivity);
			}
		}

		public List<ActivityModel> Activities
		{
			get { return _activities; }
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
			get { return _settings; }
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
