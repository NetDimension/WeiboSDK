namespace NetDimension.OpenAuth.Winform
{
	partial class AuthenticationForm
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
			this.browser = new System.Windows.Forms.WebBrowser();
			this.panelMask = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panelMask.SuspendLayout();
			this.SuspendLayout();
			// 
			// browser
			// 
			this.browser.AllowWebBrowserDrop = false;
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.IsWebBrowserContextMenuEnabled = false;
			this.browser.Location = new System.Drawing.Point(0, 0);
			this.browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.browser.Name = "browser";
			this.browser.ScriptErrorsSuppressed = true;
			this.browser.ScrollBarsEnabled = false;
			this.browser.Size = new System.Drawing.Size(704, 461);
			this.browser.TabIndex = 0;
			this.browser.WebBrowserShortcutsEnabled = false;
			this.browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.browser_Navigated);
			// 
			// panelMask
			// 
			this.panelMask.BackColor = System.Drawing.Color.White;
			this.panelMask.Controls.Add(this.label1);
			this.panelMask.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMask.Location = new System.Drawing.Point(0, 0);
			this.panelMask.Name = "panelMask";
			this.panelMask.Size = new System.Drawing.Size(704, 461);
			this.panelMask.TabIndex = 1;
			this.panelMask.Visible = false;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(704, 461);
			this.label1.TabIndex = 0;
			this.label1.Text = "正在验证...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AuthenticationForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(704, 461);
			this.Controls.Add(this.panelMask);
			this.Controls.Add(this.browser);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(720, 500);
			this.Name = "AuthenticationForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "登录授权";
			this.Shown += new System.EventHandler(this.frmAuthentication_Shown);
			this.panelMask.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser browser;
		private System.Windows.Forms.Panel panelMask;
		private System.Windows.Forms.Label label1;
	}
}