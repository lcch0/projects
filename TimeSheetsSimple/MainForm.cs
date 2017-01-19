using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
	public partial class MainForm : Form
	{
		private DraftForm _draftForm;
		private MainFormViewModel Model { get; set; }

		public MainForm()
		{
			InitializeComponent();
		}

		public void InitializeModel(MainFormViewModel model)
		{
			Model = model;
			
			_editor.InitializeModel(model.Model);
			_timeSheetGrid.InitializeModel(model.Model);
		}

		private void lastDraftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DraftForm.ShowDraftForm(this, Model.Model, ref _draftForm, (o, args) => _draftForm = null);
		}

		private void OnSettingsMenu(object sender, EventArgs e)
		{
			using (var dlg = new SettingsForm())
			{
				dlg.InitializeModel(Model.Model);
				dlg.ShowDialog(this);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		private void quitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Model.OnQuit?.Invoke();
		}
	}
}
