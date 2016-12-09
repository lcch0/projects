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
			_memo.Leave += _memo_Leave;
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new DraftViewModel(model);
		}

		private void _memo_Leave(object sender, EventArgs e)
		{
			Model.AddNewDraft.Execute(_memo.Text);
		}

		private void DraftForm_Deactivate(object sender, EventArgs e)
		{
			OnClose?.Invoke();
			Close();
		}
	}
}
