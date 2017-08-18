namespace TimeSheetsSimple
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._pnlEditor = new System.Windows.Forms.Panel();
            this._editor = new TimeSheetsSimple.Editor();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commaSeparatedFileCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSExcelXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.draftsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastDraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlGrid = new System.Windows.Forms.Panel();
            this._timeSheetGrid = new TimeSheetsSimple.TimeSheetGrid();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlEditor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this._pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlEditor
            // 
            this._pnlEditor.Controls.Add(this._editor);
            this._pnlEditor.Controls.Add(this.menuStrip1);
            this._pnlEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlEditor.Location = new System.Drawing.Point(0, 0);
            this._pnlEditor.Name = "_pnlEditor";
            this._pnlEditor.Size = new System.Drawing.Size(1225, 189);
            this._pnlEditor.TabIndex = 0;
            // 
            // _editor
            // 
            this._editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editor.Location = new System.Drawing.Point(0, 24);
            this._editor.Name = "_editor";
            this._editor.Size = new System.Drawing.Size(1225, 165);
            this._editor.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.draftsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingsMenuItem,
            this.archiveToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.quitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // _settingsMenuItem
            // 
            this._settingsMenuItem.Name = "_settingsMenuItem";
            this._settingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this._settingsMenuItem.Text = "Settings";
            this._settingsMenuItem.Click += new System.EventHandler(this.OnSettingsMenu);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mergeToolStripMenuItem.Text = "Merge";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.OnMerge);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commaSeparatedFileCsvToolStripMenuItem,
            this.mSExcelXlsxToolStripMenuItem});
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Export";
            // 
            // commaSeparatedFileCsvToolStripMenuItem
            // 
            this.commaSeparatedFileCsvToolStripMenuItem.Name = "commaSeparatedFileCsvToolStripMenuItem";
            this.commaSeparatedFileCsvToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.commaSeparatedFileCsvToolStripMenuItem.Text = "Comma separated file, csv";
            this.commaSeparatedFileCsvToolStripMenuItem.Click += new System.EventHandler(this.OnExportAsCsv);
            // 
            // mSExcelXlsxToolStripMenuItem
            // 
            this.mSExcelXlsxToolStripMenuItem.Name = "mSExcelXlsxToolStripMenuItem";
            this.mSExcelXlsxToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.mSExcelXlsxToolStripMenuItem.Text = "MS Excel, xlsx";
            // 
            // quitToolStripMenuItem1
            // 
            this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
            this.quitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem1.Text = "Quit";
            this.quitToolStripMenuItem1.Click += new System.EventHandler(this.OnQuit);
            // 
            // draftsToolStripMenuItem
            // 
            this.draftsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastDraftToolStripMenuItem});
            this.draftsToolStripMenuItem.Name = "draftsToolStripMenuItem";
            this.draftsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.draftsToolStripMenuItem.Text = "Drafts";
            // 
            // lastDraftToolStripMenuItem
            // 
            this.lastDraftToolStripMenuItem.Name = "lastDraftToolStripMenuItem";
            this.lastDraftToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.lastDraftToolStripMenuItem.Text = "Last draft";
            this.lastDraftToolStripMenuItem.Click += new System.EventHandler(this.lastDraftToolStripMenuItem_Click);
            // 
            // _pnlGrid
            // 
            this._pnlGrid.Controls.Add(this._timeSheetGrid);
            this._pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlGrid.Location = new System.Drawing.Point(0, 189);
            this._pnlGrid.Name = "_pnlGrid";
            this._pnlGrid.Size = new System.Drawing.Size(1225, 489);
            this._pnlGrid.TabIndex = 1;
            // 
            // _timeSheetGrid
            // 
            this._timeSheetGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._timeSheetGrid.Location = new System.Drawing.Point(0, 0);
            this._timeSheetGrid.Name = "_timeSheetGrid";
            this._timeSheetGrid.Size = new System.Drawing.Size(1225, 489);
            this._timeSheetGrid.TabIndex = 0;
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.archiveToolStripMenuItem.Text = "Archive";
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.OnArchive);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 678);
            this.Controls.Add(this._pnlGrid);
            this.Controls.Add(this._pnlEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Time sheets";
            this._pnlEditor.ResumeLayout(false);
            this._pnlEditor.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel _pnlEditor;
		private System.Windows.Forms.Panel _pnlGrid;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _settingsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem commaSeparatedFileCsvToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mSExcelXlsxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem draftsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastDraftToolStripMenuItem;
		private TimeSheetGrid _timeSheetGrid;
		private Editor _editor;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
    }
}

