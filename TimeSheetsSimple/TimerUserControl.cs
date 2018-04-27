using System;
using System.Windows.Forms;

namespace TimeSheetsSimple
{
	public partial class TimerUserControl : UserControl
	{
		public TimerUserControl()
		{
			InitializeComponent();
		}

		public string TimerName => lblTimer.Text;

		public bool Started
		{
			get => checkBox1.Checked;
		    set => checkBox1.Checked = value;
		}

		public DateTime Time
		{
			get => dateTimePicker1.Value;
		    set => dateTimePicker1.Value = value;
		}
	}
}
