using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.mvvm;
using Storage.Serializable;
using Storage.Serializers;

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

		private void ApplyChanges(ActivityModel obj)
		{
			Activity activity = GetActivity();
			if (activity == null)
				return;

			try
			{
				using (var context = new LiteDbSerializer(Model.Settings.ConnectionStr))
				{
					if (activity.Project.Id == 0)
					{
						context.AddRecord(activity.Project, context.GetCollection<Project>());
					}

					if (activity.User.Id == 0)
					{
						context.AddRecord(activity.User, context.GetCollection<User>());
					}

					var collection = context.GetCollection<Activity>();
					collection = collection.Include(x => x.Project).Include(x => x.User);
					if (activity.Id == 0)
					{
						EditActivity.Id = context.AddRecord(activity, collection);
						Model.Activities.Add(EditActivity);
						Model.RaisePropertyChanged(this, () => Model.Activities);
					}
					else
					{
						EditActivity.Id = context.UpdateRecord(activity, collection);
					} 
				}

				SelectedActivity = EditActivity;
				Model.RaisePropertyChanged(this, () => Model.SelectedActivity);
			}
			finally
			{
				EditActivity = null;
			}
		}

		private Activity GetActivity()
		{
			if (EditActivity == null)
				return null;

			var a = EditActivity.GetStorageObject();
			a.Project = SelectedProject.GetStorageObject();
			a.User = Model.SelectedUser.GetStorageObject();

			return a;
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
