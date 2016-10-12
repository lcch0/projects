using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.mvvm;

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

		public ICommand ApplyChangesCommand { get; set; }

		public EditorViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			if (Model.SelectedActivity == null)
				Model.SelectedActivity = Model.Activities.LastOrDefault();

			ApplyChangesCommand = new RelayCommand<EditorViewModel>(ApplyChanges);
		}

		private void ApplyChanges(EditorViewModel obj)
		{
			//SelectedActivity.ProjectType = SelectedProject.ProjectType;
			//SelectedActivity.Days = obj.Days;
			//SelectedActivity.Description = obj.Description;
			//SelectedActivity.Date = obj.Date;
			//Model.RaisePropertyChanged(this, () => Model.SelectedActivity);
		}

		protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(sender != this && e.PropertyName == PropertySupport.ExtractPropertyName(()=>Model.SelectedActivity))
				base.OnModelPropertyChanged(sender, e);
		}
	}
}
