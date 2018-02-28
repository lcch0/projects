using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
    public partial class MainForm : Form
    {
        private DraftForm _draftForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private MainFormViewModel Model { get; set; }

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
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void OnQuit(object sender, EventArgs e)
        {
            Model.OnQuit?.Invoke();
        }

        private void OnExportAsCsv(object sender, EventArgs e)
        {
            Model.GenerateCsvCommand?.Execute(Model.SettingsPath);
            if (File.Exists(Model.ReportFullPath))
                Process.Start(Model.ReportFullPath);
        }

        private void OnMerge(object sender, EventArgs e)
        {
            Model.MergeActivitiesCommand?.Execute("merge");
        }

        private void OnArchive(object sender, EventArgs e)
        {
            Model.ArchiveCommand?.Execute(-1);
        }
    }
}