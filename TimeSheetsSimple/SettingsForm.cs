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
			
			_txtUsr.DataBindings.Add("EditValue", Model.Settings, "UserName", true, DataSourceUpdateMode.OnPropertyChanged);
			_txtPwd.DataBindings.Add("EditValue", Model.Settings, "Password", true, DataSourceUpdateMode.OnPropertyChanged);
			_txtConn.DataBindings.Add("EditValue", Model.Settings, "ConnectionStr", true, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void OnOkClick(object sender, EventArgs e)
		{
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
