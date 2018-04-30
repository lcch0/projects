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
            this.components = new System.ComponentModel.Container();
            this._memo = new System.Windows.Forms.TextBox();
            this._cmbProjects = new System.Windows.Forms.ComboBox();
            this.memoPanel = new System.Windows.Forms.Panel();
            this.cmdPanel = new System.Windows.Forms.Panel();
            this.view = new System.Windows.Forms.Label();
            this.draftTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.memoPanel.SuspendLayout();
            this.cmdPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _memo
            // 
            this._memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._memo.Location = new System.Drawing.Point(0, 0);
            this._memo.Multiline = true;
            this._memo.Name = "_memo";
            this._memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._memo.Size = new System.Drawing.Size(463, 88);
            this._memo.TabIndex = 0;
            this._memo.KeyPress += _memo_KeyPress;
            // 
            // comboBox1
            // 
            this._cmbProjects.FormattingEnabled = true;
            this._cmbProjects.Location = new System.Drawing.Point(3, 1);
            this._cmbProjects.Name = "_cmbProjects";
            this._cmbProjects.Size = new System.Drawing.Size(175, 21);
            this._cmbProjects.TabIndex = 1;
            // 
            // memoPanel
            // 
            this.memoPanel.Controls.Add(this._memo);
            this.memoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoPanel.Location = new System.Drawing.Point(0, 24);
            this.memoPanel.Name = "memoPanel";
            this.memoPanel.Size = new System.Drawing.Size(463, 88);
            this.memoPanel.TabIndex = 2;
            // 
            // cmdPanel
            // 
            this.cmdPanel.Controls.Add(this.view);
            this.cmdPanel.Controls.Add(this._cmbProjects);
            this.cmdPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdPanel.Location = new System.Drawing.Point(0, 0);
            this.cmdPanel.Name = "cmdPanel";
            this.cmdPanel.Size = new System.Drawing.Size(463, 24);
            this.cmdPanel.TabIndex = 3;
            // 
            // view
            // 
            this.view.AutoSize = true;
            this.view.Location = new System.Drawing.Point(438, 4);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(19, 13);
            this.view.TabIndex = 2;
            this.view.Text = ">>";
            // 
            // DraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 112);
            this.Controls.Add(this.memoPanel);
            this.Controls.Add(this.cmdPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "DraftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time sheets - draft";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.DraftForm_Deactivate);
            this.memoPanel.ResumeLayout(false);
            this.memoPanel.PerformLayout();
            this.cmdPanel.ResumeLayout(false);
            this.cmdPanel.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TextBox _memo;
        private System.Windows.Forms.ComboBox _cmbProjects;
        private System.Windows.Forms.Panel memoPanel;
        private System.Windows.Forms.Panel cmdPanel;
        private System.Windows.Forms.Label view;
        private System.Windows.Forms.ToolTip draftTooltip;
    }
}