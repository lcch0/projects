using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
	public partial class SettingsForm : Form
	{
		private SettingsViewModel Model { get; set; }

		public SettingsForm()
		{
			InitializeComponent();
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new SettingsViewModel(model);

			_txtUsr.Text = Model.UserName;
			_txtPwd.Text = Model.Password;
			_txtConn.Text = Model.DbPath;
			_txtProj.Text = Model.Project;

			timerUserControl1.Time = Model.DayTimers.Count > 0 ? Model.DayTimers[0].TimeSet : DayTimer.Morning.TimeSet;
			timerUserControl2.Time = Model.DayTimers.Count > 1 ? Model.DayTimers[1].TimeSet : DayTimer.Noon.TimeSet;
			timerUserControl3.Time = Model.DayTimers.Count > 2 ? Model.DayTimers[2].TimeSet : DayTimer.Evening.TimeSet;
		}

		private void OnOkClick(object sender, EventArgs e)
		{
			Model.UserName = _txtUsr.Text;
			Model.Password = _txtPwd.Text;
			Model.DbPath = _txtConn.Text;
			Model.Project = _txtProj.Text;

			Model.DayTimers[0].TimeSet = timerUserControl1.Time;
			Model.DayTimers[1].TimeSet = timerUserControl2.Time;
			Model.DayTimers[2].TimeSet = timerUserControl3.Time;
			
			Model.SaveSettingsCommand.Execute(Model.Settings);	
			Close();
		}

		private void OnCancelClick(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
