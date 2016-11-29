using System;
using System.Windows.Forms;

namespace TimeSheetsSimple
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
			this._gridControl = new DataGridView();
			((System.ComponentModel.ISupportInitialize)(this._gridControl)).BeginInit();
			this.SuspendLayout();
			// 
			// _gridControl
			// 
			this._gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridControl.Location = new System.Drawing.Point(0, 0);
			this._gridControl.Name = "_gridControl";
			this._gridControl.Size = new System.Drawing.Size(1042, 388);
			this._gridControl.TabIndex = 0;
			// 
			// TimeSheetGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._gridControl);
			this.Name = "TimeSheetGrid";
			this.Size = new System.Drawing.Size(1042, 388);
			((System.ComponentModel.ISupportInitialize)(this._gridControl)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridView _gridControl;
	}
}
