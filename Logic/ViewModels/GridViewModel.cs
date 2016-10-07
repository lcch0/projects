using System.Collections.Generic;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;

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
	}
}
