using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Logic.Models;
using Logic.ViewModels;

namespace TimeSheets
{
	public partial class Editor : UserControl
	{
		private EditorViewModel Model { get; set; }
		private bool _isEdit;

		public Editor()
		{
			InitializeComponent();

			_cmbProject.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
			_btnApply.Click += OnApplyClick;
			_btnCancel.Click += OnApplyClick;
			SetEditMode(false);
		}

		private void SetEditMode(bool isEdit)
		{
			_isEdit = isEdit;

			_memoDesc.ReadOnly = !_isEdit;
		}

		private void OnApplyClick(object sender, System.EventArgs e)
		{
			try
			{
				if (sender == _btnCancel)
				{
					return;
				}

				var aModel = new ActivityModel
				{
					Days = (int) _spnDays.Value,
					Description = _memoDesc.Text,
					Date = _dateEdit.DateTime
				};

				var item = _cmbProject.SelectedItem as ProjectModel;
				aModel.ProjectType = item?.ProjectType ?? ProjectModel.eType.Design;

				//if()

				Model.SelectedActivity = aModel;

				//Model.ApplyChangesCommand.Execute(obj);

			}
			finally
			{
				SetEditMode(false);
			}
		}

		public void InitializeModel(TimeSheetsModel model)
		{
			Model = new EditorViewModel(model);
			Model.Subscribe(UpdateUI);
			UpdateUI();
		}

		private void UpdateUI()
		{
			UpdateProjects();
			UpdateActivity();
		}

		private void UpdateActivity()
		{
			if (Model.SelectedActivity != null)
			{
				_dateEdit.DateTime = Model.SelectedActivity.Date;
				_spnDays.Text = Model.SelectedActivity.Days.ToString(CultureInfo.InvariantCulture);
				_memoDesc.Text = Model.SelectedActivity.Description;

				var proj = Model.Projects.Find(p => p.ProjectType == Model.SelectedActivity.ProjectType);
				_cmbProject.SelectedItem = proj;
			}
		}

		private void UpdateProjects()
		{
			if (Model.Projects != null)
			{
				try
				{
					_cmbProject.Properties.Items.Clear();
					foreach (var project in Model.Projects)
					{
						_cmbProject.Properties.Items.Add(project);
					}

					_cmbProject.SelectedItem = Model.SelectedProject;
				}
				catch (System.Exception ex)
				{
					MessageBox.Show(this, ex.Message);
				}
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				Model.Unsubscribe(UpdateUI);
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void _memoDesc_EditValueChanged(object sender, System.EventArgs e)
		{

		}
		
		private void OnRecordChangeClick(object sender, System.EventArgs e)
		{
			SetEditMode(true);

		}
	}
}
