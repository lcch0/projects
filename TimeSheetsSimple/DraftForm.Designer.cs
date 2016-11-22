namespace TimeSheetsSimple
{
	partial class DraftForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._memo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _memo
			// 
			this._memo.Dock = System.Windows.Forms.DockStyle.Fill;
			this._memo.Location = new System.Drawing.Point(0, 0);
			this._memo.Multiline = true;
			this._memo.Name = "_memo";
			this._memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._memo.Size = new System.Drawing.Size(463, 85);
			this._memo.TabIndex = 0;
			// 
			// DraftForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 85);
			this.Controls.Add(this._memo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "DraftForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Time sheets - draft";
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.DraftForm_Deactivate);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _memo;
	}
}