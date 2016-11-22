namespace TimeSheetsSimple
{
	partial class StartForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
			this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this._notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._exitMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._showMenu = new System.Windows.Forms.ToolStripMenuItem();
			this._notifyMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// _notifyIcon
			// 
			this._notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this._notifyIcon.BalloonTipText = "Time sheets";
			this._notifyIcon.ContextMenuStrip = this._notifyMenu;
			this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
			this._notifyIcon.Text = "Time sheets";
			this._notifyIcon.Visible = true;
			this._notifyIcon.DoubleClick += new System.EventHandler(this._notifyIcon_DoubleClick);
			// 
			// _notifyMenu
			// 
			this._notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showMenu,
            this._exitMenu});
			this._notifyMenu.Name = "_notifyMenu";
			this._notifyMenu.Size = new System.Drawing.Size(170, 48);
			// 
			// _exitMenu
			// 
			this._exitMenu.Name = "_exitMenu";
			this._exitMenu.Size = new System.Drawing.Size(169, 22);
			this._exitMenu.Text = "Quit";
			this._exitMenu.Click += new System.EventHandler(this._exitMenu_Click);
			// 
			// _showMenu
			// 
			this._showMenu.Name = "_showMenu";
			this._showMenu.Size = new System.Drawing.Size(169, 22);
			this._showMenu.Text = "Show Time sheets";
			this._showMenu.Click += new System.EventHandler(this._showMenu_Click);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(144, 144);
			this.ControlBox = false;
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StartForm";
			this.ShowIcon = false;
			this._notifyMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon _notifyIcon;
		private System.Windows.Forms.ContextMenuStrip _notifyMenu;
		private System.Windows.Forms.ToolStripMenuItem _showMenu;
		private System.Windows.Forms.ToolStripMenuItem _exitMenu;
	}
}