using System.Windows.Forms;

namespace TimeSheetsSimple
{
	partial class Editor
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._pnlEditor = new System.Windows.Forms.Panel();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnEdit = new System.Windows.Forms.Button();
			this._btnAdd = new System.Windows.Forms.Button();
			this._grpEdit = new System.Windows.Forms.GroupBox();
			this._dateEdit = new System.Windows.Forms.DateTimePicker();
			this._spnDays = new System.Windows.Forms.NumericUpDown();
			this._memoDesc = new System.Windows.Forms.TextBox();
			this.labelControl1 = new System.Windows.Forms.Label();
			this.labelControl3 = new System.Windows.Forms.Label();
			this._cmbProject = new System.Windows.Forms.ComboBox();
			this.labelControl2 = new System.Windows.Forms.Label();
			this._btnApply = new System.Windows.Forms.Button();
			this._pnlEditor.SuspendLayout();
			this._grpEdit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._spnDays)).BeginInit();
			this.SuspendLayout();
			// 
			// _pnlEditor
			// 
			this._pnlEditor.Controls.Add(this._btnCancel);
			this._pnlEditor.Controls.Add(this._btnEdit);
			this._pnlEditor.Controls.Add(this._btnAdd);
			this._pnlEditor.Controls.Add(this._grpEdit);
			this._pnlEditor.Controls.Add(this._btnApply);
			this._pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pnlEditor.Location = new System.Drawing.Point(0, 0);
			this._pnlEditor.Name = "_pnlEditor";
			this._pnlEditor.Size = new System.Drawing.Size(957, 168);
			this._pnlEditor.TabIndex = 1;
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.Location = new System.Drawing.Point(687, 139);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(127, 25);
			this._btnCancel.TabIndex = 13;
			this._btnCancel.Text = "Cancel";
			// 
			// _btnEdit
			// 
			this._btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._btnEdit.Location = new System.Drawing.Point(7, 139);
			this._btnEdit.Name = "_btnEdit";
			this._btnEdit.Size = new System.Drawing.Size(127, 25);
			this._btnEdit.TabIndex = 12;
			this._btnEdit.Text = "Edit";
			this._btnEdit.Click += new System.EventHandler(this.OnRecordChangeClick);
			// 
			// _btnAdd
			// 
			this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._btnAdd.Location = new System.Drawing.Point(140, 139);
			this._btnAdd.Name = "_btnAdd";
			this._btnAdd.Size = new System.Drawing.Size(127, 25);
			this._btnAdd.TabIndex = 11;
			this._btnAdd.Text = "Add new";
			this._btnAdd.Click += new System.EventHandler(this.OnRecordChangeClick);
			// 
			// _grpEdit
			// 
			this._grpEdit.Controls.Add(this._dateEdit);
			this._grpEdit.Controls.Add(this._spnDays);
			this._grpEdit.Controls.Add(this._memoDesc);
			this._grpEdit.Controls.Add(this.labelControl1);
			this._grpEdit.Controls.Add(this.labelControl3);
			this._grpEdit.Controls.Add(this._cmbProject);
			this._grpEdit.Controls.Add(this.labelControl2);
			this._grpEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this._grpEdit.Location = new System.Drawing.Point(0, 0);
			this._grpEdit.Name = "_grpEdit";
			this._grpEdit.Size = new System.Drawing.Size(957, 138);
			this._grpEdit.TabIndex = 10;
			this._grpEdit.TabStop = false;
			// 
			// _dateEdit
			// 
			this._dateEdit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this._dateEdit.Location = new System.Drawing.Point(112, 19);
			this._dateEdit.Name = "_dateEdit";
			this._dateEdit.Size = new System.Drawing.Size(99, 20);
			this._dateEdit.TabIndex = 11;
			// 
			// _spnDays
			// 
			this._spnDays.Location = new System.Drawing.Point(474, 19);
			this._spnDays.Name = "_spnDays";
			this._spnDays.Size = new System.Drawing.Size(49, 20);
			this._spnDays.TabIndex = 7;
			// 
			// _memoDesc
			// 
			this._memoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._memoDesc.Location = new System.Drawing.Point(3, 45);
			this._memoDesc.Multiline = true;
			this._memoDesc.Name = "_memoDesc";
			this._memoDesc.Size = new System.Drawing.Size(944, 87);
			this._memoDesc.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(7, 22);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(99, 13);
			this.labelControl1.TabIndex = 2;
			this.labelControl1.Text = "Start date(monday):";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(411, 22);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(62, 13);
			this.labelControl3.TabIndex = 5;
			this.labelControl3.Text = "Time, days";
			// 
			// _cmbProject
			// 
			this._cmbProject.Location = new System.Drawing.Point(263, 19);
			this._cmbProject.Name = "_cmbProject";
			this._cmbProject.Size = new System.Drawing.Size(142, 21);
			this._cmbProject.TabIndex = 3;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(215, 22);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(51, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Project";
			// 
			// _btnApply
			// 
			this._btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._btnApply.Location = new System.Drawing.Point(820, 139);
			this._btnApply.Name = "_btnApply";
			this._btnApply.Size = new System.Drawing.Size(127, 25);
			this._btnApply.TabIndex = 10;
			this._btnApply.Text = "Apply";
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._pnlEditor);
			this.Name = "Editor";
			this.Size = new System.Drawing.Size(957, 168);
			this._pnlEditor.ResumeLayout(false);
			this._grpEdit.ResumeLayout(false);
			this._grpEdit.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._spnDays)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private Panel _pnlEditor;
		private Label labelControl1;
		private NumericUpDown _spnDays;
		private Label labelControl3;
		private Label labelControl2;
		private ComboBox _cmbProject;
		private TextBox _memoDesc;
		private GroupBox _grpEdit;
		private Button _btnApply;
		private DateTimePicker _dateEdit;
		private Button _btnEdit;
		private Button _btnAdd;
		private Button _btnCancel;
	}
}
