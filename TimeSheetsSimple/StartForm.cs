using System;
using System.Windows.Forms;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheetsSimple
{
	public partial class StartForm : Form
	{
		private readonly Timer _timer = new Timer();//this is to show start form for 500 ms and then close
		private MainForm _mainForm;
		private MainFormViewModel Model { get; set; }
		private TaskViewModel TaskViewModel { get; set; }

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
			try
			{
				var model = new TimeSheetsModel();

				Model = new MainFormViewModel(model) {OnQuit = CloseApp};

				Model.LoadSettingsCommand.Execute(Settings.GetDefaultPath(Environment.CurrentDirectory));
				Model.LoadDBCommand.Execute(Model);

				TaskViewModel = new TaskViewModel(Model.Model.Settings)
				{
					OnTaskCompleted = OnCompleted,
					OnTimeReached = OnTimeReached
				};
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_timer.Start();
			TaskViewModel.StartTaskCommand.Execute(TaskViewModel);
		}

		private bool OnTimeReached(DateTime? dateTime)
		{
			DraftForm df = null;
			Invoke((MethodInvoker) delegate { DraftForm.ShowDraftForm(null, Model.Model, ref df, null); });
			return true;
		}

		private bool OnCompleted(DateTime? dateTime)
		{
			return true;
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
			CreateMainForm();
			_mainForm.InitializeModel(Model);
			_mainForm.Show();
		}

		private void CreateMainForm()
		{
			if (_mainForm == null)
			{
				_mainForm = new MainForm();
				_mainForm.Disposed += (sender, args) => { _mainForm = null; };
			}
		}

		private void _showMenu_Click(object sender, EventArgs e)
		{
			ShowMainForm();
		}

		private void _exitMenu_Click(object sender, EventArgs e)
		{
			CloseApp();
		}

		private void CloseApp()
		{
			_mainForm?.Dispose();
			TaskViewModel?.StopTaskCommand.Execute(TaskViewModel);
			Close();
		}
	}
}
