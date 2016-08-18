using System.Collections.Generic;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;

namespace Logic.ViewModels
{
	public class GridViewModel : BaseViewModel
	{
		public List<EditEntry> EditEntries
		{
			get { return Model.Entries; }
			set
			{
				Model.Entries = value;
			}
		}

		public ICommand SelectionChangedCommand { get; set; }

		public GridViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			SelectionChangedCommand = new RelayCommand<EditEntry>(SelectionChanged);
		}

		private void SelectionChanged(EditEntry obj)
		{
			Model.SelectedEntry = obj;
		}
	}
}
