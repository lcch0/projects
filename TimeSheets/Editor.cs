using System.Globalization;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheets
{
	public partial class Editor : UserControl
	{
		private EditorViewModel Model { get; set; }

		public Editor()
		{
			InitializeComponent();
			_btnApply.Click += OnApplyClick;
		}

		private void OnApplyClick(object sender, System.EventArgs e)
		{
			var obj = new EditEntry
			{
				Project = _cmbProject.Text,
				Days = (int) _spnDays.Value,
				Description = _memoDesc.Text,
				Date = _dateEdit.DateTime
			};


			Model.ApplyChangesCommand.Execute(obj);
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new EditorViewModel(model);
			Model.Subscribe(UpdateUI);
			UpdateUI();
		}

		private void UpdateUI()
		{
			if (Model.SelectedEntry != null)
			{
				_dateEdit.DateTime = Model.SelectedEntry.Date;
				_cmbProject.Text = Model.SelectedEntry.Project;
				_spnDays.Text = Model.SelectedEntry.Days.ToString(CultureInfo.InvariantCulture);
				_memoDesc.Text = Model.SelectedEntry.Description;
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				Model.Unsubscribe(UpdateUI);
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void _memoDesc_EditValueChanged(object sender, System.EventArgs e)
		{

		}
	}
}
