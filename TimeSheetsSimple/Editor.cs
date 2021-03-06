﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
    public partial class Editor : UserControl
    {
        private const string MergeDrafts = "Merge drafts";
        private const string AddEntity = "Add new";

        public Editor()
        {
            InitializeComponent();

            _btnApply.Click += OnApplyClick;
            _btnCancel.Click += OnApplyClick;
            _cmbProject.SelectedValueChanged += OnProjectChanged;
        }

        private EditorViewModel Model { get; set; }

        private void SetEditMode()
        {
            _memoDesc.ReadOnly = !Model.IsInEditMode;
            _cmbProject.Enabled = Model.IsInEditMode;
            _dateEdit.Enabled = Model.IsInEditMode;
            _spnDays.ReadOnly = !Model.IsInEditMode;
            _btnAdd.Text = Model.IsInEditMode ? MergeDrafts : AddEntity;
        }

        private void OnApplyClick(object sender, EventArgs e)
        {
            if (!Model.IsInEditMode)
                return;

            try
            {
                if (sender == _btnCancel)
                {
                    Model.EditActivity = null;
                    return;
                }

                Model.EditActivity.Days = (int) _spnDays.Value;
                Model.EditActivity.Description = _memoDesc.Text;
                Model.EditActivity.Date = _dateEdit.Value;
                Model.EditActivity.ProjectType = Model.SelectedProject?.ProjectType ?? ProjectModel.EType.Design;
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
                _dateEdit.Value = selectedActivity.Date;
                _spnDays.Text = selectedActivity.Days.ToString(CultureInfo.InvariantCulture);
                _memoDesc.Text = Model.GetDescription();

                var proj = Model.Projects.Find(p => p.ProjectType == selectedActivity.ProjectType);
                _cmbProject.SelectedItem = proj;
                Model.SelectedProject = proj;
            }

            SetEditMode();
        }

        private void UpdateProjects(List<ProjectModel> projects)
        {
            if (projects != null)
                try
                {
                    _cmbProject.Items.Clear();
                    foreach (var project in projects) _cmbProject.Items.Add(project);

                    _cmbProject.SelectedItem = Model.SelectedProject;
                    if (_cmbProject.SelectedItem == null && projects.Count > 0)
                        _cmbProject.SelectedItem = projects[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                Model.Unsubscribe(UpdateUI);
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            var item = _cmbProject.SelectedItem as ProjectModel;
            Model.SelectedProject = item;
        }

        private void OnRecordChangeClick(object sender, EventArgs e)
        {
            if (sender == _btnAdd)
                if (_btnAdd.Text == AddEntity)
                {
                    Model.EditActivity = Model.CreateNewActivity();
                    UpdateActivity(Model.EditActivity);
                }
                else if (_btnAdd.Text == MergeDrafts)
                {
                    _memoDesc.Text = Model.EditActivity.MergeDrafts();
                }

            if (sender == _btnEdit)
            {
                Model.EditActivity = Model.SelectedActivity ?? Model.CreateNewActivity();
                UpdateActivity(Model.EditActivity);
                _btnAdd.Text = MergeDrafts;
            }
        }
    }
}