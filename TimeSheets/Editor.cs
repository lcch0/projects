﻿using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
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

			_cmbProject.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
			_btnApply.Click += OnApplyClick;
			_btnCancel.Click += OnApplyClick;
			_cmbProject.SelectedValueChanged += OnProjectChanged;
		}

		private void SetEditMode()
		{
			_memoDesc.ReadOnly = !Model.IsInEditMode;
		}

		private void OnApplyClick(object sender, System.EventArgs e)
		{
			try
			{
				if (sender == _btnCancel)
				{
					Model.EditActivity = null;
					return;
				}

				Model.EditActivity.Days = (int) _spnDays.Value;
				Model.EditActivity.Description = _memoDesc.Text;
				Model.EditActivity.Date = _dateEdit.DateTime;
				Model.EditActivity.ProjectType = Model.SelectedProject?.ProjectType ?? ProjectModel.eType.Design;
				Model.EditActivity.UserName = Model.SelectedUser?.Name ?? "No user";

				Model.ApplyActivityChangedCommand.Execute(Model.EditActivity);
			}
			finally
			{
				SetEditMode();
			}
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new EditorViewModel(model);
			Model.Subscribe(UpdateUI);
			UpdateUI();
		}

		private void UpdateUI()
		{
			UpdateProjects(Model.Projects);
			UpdateActivity(Model.SelectedActivity);
		}

		private void UpdateActivity(ActivityModel selectedActivity)
		{
			if (selectedActivity != null)
			{
				_dateEdit.DateTime = selectedActivity.Date;
				_spnDays.Text = selectedActivity.Days.ToString(CultureInfo.InvariantCulture);
				_memoDesc.Text = selectedActivity.Description;

				var proj = Model.Projects.Find(p => p.ProjectType == selectedActivity.ProjectType);
				_cmbProject.SelectedItem = proj;
				Model.SelectedProject = proj;
			}

			SetEditMode();
		}

		private void UpdateProjects(List<ProjectModel> projects)
		{
			if (projects != null)
			{
				try
				{
					_cmbProject.Properties.Items.Clear();
					foreach (var project in projects)
					{
						_cmbProject.Properties.Items.Add(project);
					}

					_cmbProject.SelectedItem = Model.SelectedProject;
					if (_cmbProject.SelectedItem == null && projects.Count > 0)
						_cmbProject.SelectedItem = projects[0];
				}
				catch (System.Exception ex)
				{
					MessageBox.Show(this, ex.Message);
				}
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

		private void OnProjectChanged(object sender, System.EventArgs e)
		{
			var item = _cmbProject.SelectedItem as ProjectModel;
			Model.SelectedProject = item;
		}

		private void OnRecordChangeClick(object sender, System.EventArgs e)
		{
			Model.EditActivity = 
				sender == _btnAdd 
				? Model.CreateNewActivity() 
				: (Model.SelectedActivity ?? Model.CreateNewActivity());
			UpdateActivity(Model.EditActivity);
		}
	}
}
