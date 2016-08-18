using System;
using System.Windows.Forms;

namespace TimeSheets
{
	public partial class DraftForm : Form
	{
		public Action OnClose { get; set; }

		public DraftForm()
		{
			InitializeComponent();
		}

		private void memoEdit1_EditValueChanged(object sender, EventArgs e)
		{

		}

		private void DraftForm_Deactivate(object sender, EventArgs e)
		{
			OnClose?.Invoke();
			Close();
		}
	}
}
