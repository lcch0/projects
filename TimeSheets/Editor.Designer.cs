namespace TimeSheets
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
			this._grpEdit = new System.Windows.Forms.GroupBox();
			this._dateEdit = new DevExpress.XtraEditors.DateEdit();
			this._btnApply = new DevExpress.XtraEditors.SimpleButton();
			this._spnDays = new DevExpress.XtraEditors.SpinEdit();
			this._memoDesc = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this._cmbProject = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this._pnlEditor.SuspendLayout();
			this._grpEdit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._dateEdit.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._dateEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._spnDays.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._memoDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._cmbProject.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// _pnlEditor
			// 
			this._pnlEditor.Controls.Add(this._grpEdit);
			this._pnlEditor.Controls.Add(this._btnApply);
			this._pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pnlEditor.Location = new System.Drawing.Point(0, 0);
			this._pnlEditor.Name = "_pnlEditor";
			this._pnlEditor.Size = new System.Drawing.Size(957, 168);
			this._pnlEditor.TabIndex = 1;
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
			this._dateEdit.EditValue = null;
			this._dateEdit.Location = new System.Drawing.Point(112, 19);
			this._dateEdit.Name = "_dateEdit";
			this._dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this._dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this._dateEdit.Size = new System.Drawing.Size(132, 20);
			this._dateEdit.TabIndex = 11;
			// 
			// _btnApply
			// 
			this._btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._btnApply.AutoWidthInLayoutControl = true;
			this._btnApply.Location = new System.Drawing.Point(3, 138);
			this._btnApply.Name = "_btnApply";
			this._btnApply.Size = new System.Drawing.Size(127, 27);
			this._btnApply.TabIndex = 10;
			this._btnApply.Text = "Apply";
			// 
			// _spnDays
			// 
			this._spnDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this._spnDays.Location = new System.Drawing.Point(591, 19);
			this._spnDays.Name = "_spnDays";
			this._spnDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
			this._spnDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this._spnDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this._spnDays.Size = new System.Drawing.Size(49, 20);
			this._spnDays.TabIndex = 7;
			// 
			// _memoDesc
			// 
			this._memoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._memoDesc.Location = new System.Drawing.Point(3, 45);
			this._memoDesc.Name = "_memoDesc";
			this._memoDesc.Properties.Appearance.Options.UseTextOptions = true;
			this._memoDesc.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this._memoDesc.Size = new System.Drawing.Size(944, 87);
			this._memoDesc.TabIndex = 9;
			this._memoDesc.EditValueChanged += new System.EventHandler(this._memoDesc_EditValueChanged);
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
			this.labelControl3.Location = new System.Drawing.Point(533, 22);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(52, 13);
			this.labelControl3.TabIndex = 5;
			this.labelControl3.Text = "Time, days";
			// 
			// _cmbProject
			// 
			this._cmbProject.Location = new System.Drawing.Point(307, 19);
			this._cmbProject.Name = "_cmbProject";
			this._cmbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this._cmbProject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this._cmbProject.Size = new System.Drawing.Size(206, 20);
			this._cmbProject.TabIndex = 3;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(267, 22);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(34, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Project";
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
			((System.ComponentModel.ISupportInitialize)(this._dateEdit.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._dateEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._spnDays.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._memoDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._cmbProject.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel _pnlEditor;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SpinEdit _spnDays;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ComboBoxEdit _cmbProject;
		private DevExpress.XtraEditors.MemoEdit _memoDesc;
		private System.Windows.Forms.GroupBox _grpEdit;
		private DevExpress.XtraEditors.SimpleButton _btnApply;
		private DevExpress.XtraEditors.DateEdit _dateEdit;
	}
}
