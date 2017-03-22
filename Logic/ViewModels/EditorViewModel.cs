using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.DbSerializer.LiteDb;
using Logic.Models;
using Logic.Models.mvvm;
using Storage.Serializable;

namespace Logic.ViewModels
{
	public class EditorViewModel : BaseViewModel
	{
		public ActivityModel SelectedActivity
		{
			get
			{
				return Model.SelectedActivity;
			}
			set
			{
				Model.SelectedActivity = value;
			}
		}

		public ActivityModel EditActivity { get; set; }

		public bool IsInEditMode => EditActivity != null;

		public ProjectModel SelectedProject
		{
			get
			{
				return Model.SelectedProject;
			}
			set
			{
				Model.SelectedProject = value;
			}
		}

		public UserModel SelectedUser => Model.SelectedUser;

		public List<ProjectModel> Projects
		{
			get
			{
				return Model.Projects;
			}
			set
			{
				Model.Projects = value;
			}
		}

		public ICommand ApplyActivityChangedCommand { get; set; }

		public EditorViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			if (Model.SelectedActivity == null)
				Model.SelectedActivity = Model.Activities.LastOrDefault();

			ApplyActivityChangedCommand = new RelayCommand<ActivityModel>(ApplyChanges);
		}

		public string GetDescription()
		{
			if (SelectedActivity == null)
				return string.Empty;

			return SelectedActivity.GetDescription(!IsInEditMode);
		}

		private void ApplyChanges(ActivityModel model)
		{
			Activity activity = GetActivity(model);
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
			if(sender != this && e.PropertyName == PropertySupport.ExtractPropertyName(()=>Model.SelectedActivity))
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
