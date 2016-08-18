using System.Collections.Generic;
using Logic.Models.mvvm;

namespace Logic.Models
{
	public class TimeSheetsModel : ObservableObject
	{
		private EditEntry _selectedEntry;
		private List<EditEntry> _entries = new List<EditEntry>();
		private Settings _settings = new Settings();

		public EditEntry SelectedEntry
		{
			get
			{
				return _selectedEntry;
			}
			set
			{
				if (value == _selectedEntry)
					return;

				_selectedEntry = value;
				RaisePropertyChanged(this, () => SelectedEntry);
			}
		}

		public List<EditEntry> Entries
		{
			get { return _entries; }
			set
			{
				if (value == _entries)
					return;

				_entries = value;
				RaisePropertyChanged(this, () => Entries);
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
