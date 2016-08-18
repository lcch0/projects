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
		public EditEntry SelectedEntry
		{
			get
			{
				return Model.SelectedEntry;
			}
			set
			{
				Model.SelectedEntry = value;
			}
		}

		public ICommand ApplyChangesCommand { get; set; }

		public EditorViewModel(TimeSheetsModel model) : base(model)
		{
			Model = model;
			if (Model.SelectedEntry == null)
				Model.SelectedEntry = Model.Entries.LastOrDefault();

			ApplyChangesCommand = new RelayCommand<EditEntry>(ApplyChanges);
		}

		private void ApplyChanges(EditEntry obj)
		{
			Model.SelectedEntry.Project = obj.Project;
			Model.SelectedEntry.Days = obj.Days;
			Model.SelectedEntry.Description = obj.Description;
			Model.SelectedEntry.Date = obj.Date;
			Model.RaisePropertyChanged(this, () => Model.SelectedEntry);
		}

		protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(sender != this && e.PropertyName == PropertySupport.ExtractPropertyName(()=>Model.SelectedEntry))
				base.OnModelPropertyChanged(sender, e);
		}
	}
}
