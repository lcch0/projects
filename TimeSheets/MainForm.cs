﻿using System;
using System.Windows.Forms;
using Logic.ViewModels;

namespace TimeSheets
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
			if (_draftForm == null)
			{
				_draftForm = new DraftForm();
				_draftForm.Disposed += (o, args) => _draftForm = null;
			}

			_draftForm.Show(this);
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
	}
}
