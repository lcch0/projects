namespace TimeSheets
{
	partial class TimeSheetGrid
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
			this._gridControl = new DevExpress.XtraGrid.GridControl();
			this._gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this._gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// _gridControl
			// 
			this._gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridControl.Location = new System.Drawing.Point(0, 0);
			this._gridControl.MainView = this._gridView;
			this._gridControl.Name = "_gridControl";
			this._gridControl.Size = new System.Drawing.Size(1042, 388);
			this._gridControl.TabIndex = 0;
			this._gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gridView});
			// 
			// _gridView
			// 
			this._gridView.GridControl = this._gridControl;
			this._gridView.Name = "_gridView";
			this._gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
			this._gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this._gridView.OptionsBehavior.Editable = false;
			this._gridView.OptionsCustomization.AllowGroup = false;
			this._gridView.OptionsCustomization.AllowQuickHideColumns = false;
			this._gridView.OptionsView.ShowGroupPanel = false;
			this._gridView.RowCellClick += _gridView_RowCellClick;
			// 
			// TimeSheetGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._gridControl);
			this.Name = "TimeSheetGrid";
			this.Size = new System.Drawing.Size(1042, 388);
			((System.ComponentModel.ISupportInitialize)(this._gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl _gridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView _gridView;
	}
}
