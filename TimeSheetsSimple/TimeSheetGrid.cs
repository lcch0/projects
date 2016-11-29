using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
	public partial class TimeSheetGrid : UserControl
	{
		private GridViewModel Model { get; set; }

		public TimeSheetGrid()
		{
			InitializeComponent();
			_gridControl.AllowUserToAddRows = false;
			_gridControl.AllowUserToDeleteRows = false;
			_gridControl.ReadOnly = true;
			_gridControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			_gridControl.RowStateChanged += _gridControl_RowStateChanged;
		}

		private void _gridControl_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if(e.StateChanged == DataGridViewElementStates.Selected)
			{
				var row = e.Row.DataBoundItem as ActivityModel;
				if (row != null)
				{
					Model.SelectionChangedCommand.Execute(row);
				}
			}
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new GridViewModel(model);

			_gridControl.DataSource = Model.EditEntries;
			Model.Subscribe(UpdateUI);
			UpdateUI();
		}

		private void UpdateUI()
		{
			_gridControl.DataSource = typeof(System.Collections.IList);
			_gridControl.DataSource = Model.EditEntries;
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
	}
}
