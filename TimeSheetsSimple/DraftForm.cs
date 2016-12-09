using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
	public partial class DraftForm : Form
	{
		private DraftViewModel Model { get; set; }

		public Action OnClose { get; set; }

		public DraftForm()
		{
			InitializeComponent();
		}

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
	}
}
