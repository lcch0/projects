using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;
using Logic.Models.mvvm;

namespace Logic.ViewModels
{
	public class GridViewModel : BaseViewModel
	{
		public List<ActivityModel> EditEntries
		{
			get { return Model.Activities; }
			set
			{
				Model.Activities = value;
			}
		}

		public ICommand SelectionChangedCommand { get; set; }

		public GridViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			SelectionChangedCommand = new RelayCommand<ActivityModel>(SelectionChanged);
		}

		private void SelectionChanged(ActivityModel obj)
		{
			Model.SelectedActivity = obj;
		}

		protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender != this && e.PropertyName == PropertySupport.ExtractPropertyName(() => Model.Activities))
				base.OnModelPropertyChanged(sender, e);
		}
	}
}
