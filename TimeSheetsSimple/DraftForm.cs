using System;
using System.Linq;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
    public partial class DraftForm : Form
    {
        private bool _closedByEnter;
        public DraftForm()
        {
            InitializeComponent();
        }

        private DraftViewModel Model { get; set; }

        public Action OnClose { get; set; }

        public void InitializeModel(TimeSheetsModel model)
        {
            Model = new DraftViewModel(model);
            UpdateProjects();
            UpdateTooltip();
        }

        private void UpdateTooltip()
        {
            var lastActivity = Model.Activities.OrderByDescending(a => a.Date).FirstOrDefault();
            if (lastActivity != null)
            {
                draftTooltip.SetToolTip(view, lastActivity.Description);
            }
        }

        private void _memo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                _closedByEnter = true;
                CloseDraftForm();
            }
        }

        private void DraftForm_Deactivate(object sender, EventArgs e)
        {
            if(!_closedByEnter)
                CloseDraftForm();
        }

        private void CloseDraftForm()
        {
            if (_cmbProjects.SelectedItem is ProjectModel selectedProject)
                Model.SelectedProject = selectedProject;

            Model.AddNewDraft.Execute(new Tuple<string, ProjectModel>(_memo.Text, Model.SelectedProject));
            OnClose?.Invoke();
            Close();
        }

        private void UpdateProjects()
        {
            try
            {
                _cmbProjects.DropDownStyle = ComboBoxStyle.DropDownList;
                _cmbProjects.Items.Clear();
                foreach (var project in Model.Projects) 
                    _cmbProjects.Items.Add(project);

                _cmbProjects.SelectedItem = Model.SelectedProject ?? Model.Projects[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        internal static void ShowDraftForm(IWin32Window parent, TimeSheetsModel model, ref DraftForm draftForm,
            EventHandler onDispose)
        {
            if (draftForm == null)
            {
                draftForm = new DraftForm();
                draftForm.InitializeModel(model);
                if (onDispose != null)
                    draftForm.Disposed += onDispose;
            }

            draftForm.Show(parent);
        }
    }
}