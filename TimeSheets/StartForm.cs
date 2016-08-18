using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheets
{
	public partial class StartForm : Form
	{
		private readonly Timer _timer = new Timer();
		private MainForm _mainForm;
		private MainFormViewModel Model { get; set; }

		public StartForm()
		{
			InitializeComponent();
			InitializeModel();
			
			_timer.Tick += OnTimerTick;
			_timer.Interval = 500;

			StartPosition = FormStartPosition.CenterScreen;
		}

		private void InitializeModel()
		{
			var model = new TimeSheetsModel();

			Model = new MainFormViewModel(model);
			Model.LoadSettingsCommand.Execute(Settings.GetDefaultPath(Environment.CurrentDirectory));
			Model.LoadDBCommand.Execute(Model);
			Model.StartTimersCommand.Execute(Model);
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_timer.Start();
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			_timer.Stop();
			Visible = false;
		}

		private void _notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			ShowMainForm();
		}

		private void ShowMainForm()
		{
			if (_mainForm == null)
			{
				_mainForm = new MainForm();
				_mainForm.Disposed += (sender, args) => { _mainForm = null; };
			}

			_mainForm.InitializeModel(Model);

			_mainForm.Show();
		}
		
		private void _showMenu_Click(object sender, EventArgs e)
		{
			ShowMainForm();
		}

		private void _exitMenu_Click(object sender, EventArgs e)
		{
			_mainForm?.Dispose();
			Close();
		}
	}
}
