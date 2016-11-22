using System;
using System.Windows.Forms;

namespace TimeSheetsSimple
{
	public partial class DraftForm : Form
	{
		public Action OnClose { get; set; }

		public DraftForm()
		{
			InitializeComponent();
			_memo.Leave += _memo_Leave;
		}

		private void _memo_Leave(object sender, EventArgs e)
		{
			
		}

		private void DraftForm_Deactivate(object sender, EventArgs e)
		{
			OnClose?.Invoke();
			Close();
		}
	}
}
