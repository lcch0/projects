using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private SettingsViewModel Model { get; set; }

        public void InitializeModel(TimeSheetsModel model)
        {
            Model = new SettingsViewModel(model);

            _txtUsr.Text = Model.UserName;
            _txtPwd.Text = Model.Password;
            _txtConn.Text = Model.DbPath;
            _txtProj.Text = Model.Project;

            SetTimer(timerUserControl1, 0);
            SetTimer(timerUserControl2, 1);
            SetTimer(timerUserControl3, 2);
        }

        private void SetTimer(TimerUserControl cnt, int number)
        {
            DayTimer timer;

            switch (number)
            {
                case 0:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.MORNING;
                    break;
                case 1:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.NOON;
                    break;
                case 2:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.EVENING;
                    break;
                default:
                    return;
            }

            cnt.Time = timer.TimeSet;
            cnt.Started = timer.Enabled > 0;
        }

        private void GetTimer(TimerUserControl cnt, int number)
        {
            DayTimer timer;

            switch (number)
            {
                case 0:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.MORNING;
                    break;
                case 1:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.NOON;
                    break;
                case 2:
                    timer = Model.DayTimers.Count > number ? Model.DayTimers[number] : DayTimer.EVENING;
                    break;
                default:
                    return;
            }

            timer.TimeSet = cnt.Time;
            timer.Enabled = cnt.Started ? 1 : 0;
        }

        private void OnOkClick(object sender, EventArgs e)
        {
            Model.UserName = _txtUsr.Text;
            Model.Password = _txtPwd.Text;
            Model.DbPath = _txtConn.Text;
            Model.Project = _txtProj.Text;

            GetTimer(timerUserControl1, 0);
            GetTimer(timerUserControl2, 1);
            GetTimer(timerUserControl3, 2);

            Model.SaveSettingsCommand.Execute(Model.Settings);
            Close();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Close();
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
    }
}