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
		}

		private void OnOkClick(object sender, EventArgs e)
		{
			Model.UserName = _txtUsr.Text;
			Model.Password = _txtPwd.Text;
			Model.DbPath = _txtConn.Text;
			Model.Project = _txtProj.Text;

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
