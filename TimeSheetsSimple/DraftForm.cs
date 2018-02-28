using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
    public partial class DraftForm : Form
    {
        public DraftForm()
        {
            InitializeComponent();
        }

        private DraftViewModel Model { get; set; }

        public Action OnClose { get; set; }

        public void InitializeModel(TimeSheetsModel model)
        {
            Model = new DraftViewModel(model);
        }

        private void DraftForm_Deactivate(object sender, EventArgs e)
        {
            Model.AddNewDraft.Execute(_memo.Text);
            OnClose?.Invoke();
            Close();
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