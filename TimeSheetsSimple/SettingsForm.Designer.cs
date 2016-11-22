using System.Windows.Forms;

namespace TimeSheetsSimple
{
	partial class SettingsForm
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
			this._txtUsr = new TextBox();
			this._txtPwd = new TextBox();
			this._txtConn = new TextBox();
			this.labelControl1 = new Label();
			this.labelControl2 = new Label();
			this.labelControl3 = new Label();
			this._btnOk = new Button();
			this._btnCancel = new Button();
			((System.ComponentModel.ISupportInitialize)(this._txtUsr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtPwd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtConn)).BeginInit();
			this.SuspendLayout();
			// 
			// _txtUsr
			// 
			this._txtUsr.Location = new System.Drawing.Point(103, 10);
			this._txtUsr.Name = "_txtUsr";
			this._txtUsr.Size = new System.Drawing.Size(497, 20);
			this._txtUsr.TabIndex = 0;
			// 
			// _txtPwd
			// 
			this._txtPwd.Location = new System.Drawing.Point(103, 40);
			this._txtPwd.Name = "_txtPwd";
			this._txtPwd.Size = new System.Drawing.Size(497, 20);
			this._txtPwd.TabIndex = 1;
			// 
			// _txtConn
			// 
			this._txtConn.Location = new System.Drawing.Point(103, 70);
			this._txtConn.Name = "_txtConn";
			this._txtConn.Size = new System.Drawing.Size(497, 20);
			this._txtConn.TabIndex = 2;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(13, 13);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(51, 13);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "User name";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(13, 43);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(46, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Password";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(13, 73);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(84, 13);
			this.labelControl3.TabIndex = 5;
			this.labelControl3.Text = "Connection string";
			// 
			// _btnOk
			// 
			this._btnOk.Location = new System.Drawing.Point(13, 103);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 23);
			this._btnOk.TabIndex = 6;
			this._btnOk.Text = "OK";
			this._btnOk.Click += new System.EventHandler(this.OnOkClick);
			// 
			// _btnCancel
			// 
			this._btnCancel.Location = new System.Drawing.Point(525, 103);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 7;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.Click += new System.EventHandler(this.OnCancelClick);
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(607, 132);
			this.ControlBox = false;
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this._txtConn);
			this.Controls.Add(this._txtPwd);
			this.Controls.Add(this._txtUsr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SettingsForm";
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this._txtUsr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtPwd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtConn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox _txtUsr;
		private TextBox _txtPwd;
		private TextBox _txtConn;
		private Label labelControl1;
		private Label labelControl2;
		private Label labelControl3;
		private Button _btnOk;
		private Button _btnCancel;
	}
}