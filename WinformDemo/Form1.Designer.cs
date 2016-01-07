namespace WinformDemo
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.picAvatar = new System.Windows.Forms.PictureBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblLocation = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.statusPanel = new System.Windows.Forms.Panel();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.lblCharCount = new System.Windows.Forms.Label();
			this.btnAddImage = new System.Windows.Forms.Button();
			this.btnCloseStatusPanel = new System.Windows.Forms.Button();
			this.btnPost = new System.Windows.Forms.Button();
			this.btnShowStatusPanel = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.lblState = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
			this.statusPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// picAvatar
			// 
			this.picAvatar.BackColor = System.Drawing.Color.Transparent;
			this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picAvatar.Location = new System.Drawing.Point(12, 12);
			this.picAvatar.Name = "picAvatar";
			this.picAvatar.Size = new System.Drawing.Size(100, 100);
			this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picAvatar.TabIndex = 0;
			this.picAvatar.TabStop = false;
			this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			this.lblName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblName.ForeColor = System.Drawing.Color.White;
			this.lblName.Location = new System.Drawing.Point(125, 12);
			this.lblName.Margin = new System.Windows.Forms.Padding(10, 0, 3, 10);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(103, 25);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "正在加载...";
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = true;
			this.lblLocation.BackColor = System.Drawing.Color.Transparent;
			this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
			this.lblLocation.Location = new System.Drawing.Point(234, 18);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(56, 17);
			this.lblLocation.TabIndex = 2;
			this.lblLocation.Text = "正在加载";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.BackColor = System.Drawing.Color.Transparent;
			this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(230)))), ((int)(((byte)(243)))));
			this.lblDescription.Location = new System.Drawing.Point(127, 58);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(219, 54);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "正在加载";
			// 
			// statusPanel
			// 
			this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statusPanel.BackColor = System.Drawing.Color.White;
			this.statusPanel.Controls.Add(this.txtStatus);
			this.statusPanel.Controls.Add(this.lblCharCount);
			this.statusPanel.Controls.Add(this.btnAddImage);
			this.statusPanel.Controls.Add(this.btnCloseStatusPanel);
			this.statusPanel.Controls.Add(this.btnPost);
			this.statusPanel.Location = new System.Drawing.Point(12, 12);
			this.statusPanel.Name = "statusPanel";
			this.statusPanel.Size = new System.Drawing.Size(440, 100);
			this.statusPanel.TabIndex = 3;
			this.statusPanel.Visible = false;
			// 
			// txtStatus
			// 
			this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtStatus.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtStatus.Location = new System.Drawing.Point(3, 3);
			this.txtStatus.Multiline = true;
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(434, 53);
			this.txtStatus.TabIndex = 0;
			this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
			this.txtStatus.Enter += new System.EventHandler(this.txtStatus_Enter);
			this.txtStatus.Leave += new System.EventHandler(this.txtStatus_Leave);
			// 
			// lblCharCount
			// 
			this.lblCharCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCharCount.BackColor = System.Drawing.Color.Transparent;
			this.lblCharCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCharCount.ForeColor = System.Drawing.Color.DarkGray;
			this.lblCharCount.Location = new System.Drawing.Point(44, 62);
			this.lblCharCount.Name = "lblCharCount";
			this.lblCharCount.Size = new System.Drawing.Size(226, 30);
			this.lblCharCount.TabIndex = 3;
			this.lblCharCount.Text = "还可以输入140字";
			this.lblCharCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAddImage
			// 
			this.btnAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddImage.Image = global::WinformDemo.Properties.Resources.image_add;
			this.btnAddImage.Location = new System.Drawing.Point(8, 62);
			this.btnAddImage.Name = "btnAddImage";
			this.btnAddImage.Size = new System.Drawing.Size(30, 30);
			this.btnAddImage.TabIndex = 2;
			this.btnAddImage.UseMnemonic = false;
			this.btnAddImage.UseVisualStyleBackColor = false;
			this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
			// 
			// btnCloseStatusPanel
			// 
			this.btnCloseStatusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCloseStatusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
			this.btnCloseStatusPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCloseStatusPanel.ForeColor = System.Drawing.Color.White;
			this.btnCloseStatusPanel.Location = new System.Drawing.Point(357, 62);
			this.btnCloseStatusPanel.Name = "btnCloseStatusPanel";
			this.btnCloseStatusPanel.Size = new System.Drawing.Size(75, 30);
			this.btnCloseStatusPanel.TabIndex = 1;
			this.btnCloseStatusPanel.Text = "关闭";
			this.btnCloseStatusPanel.UseMnemonic = false;
			this.btnCloseStatusPanel.UseVisualStyleBackColor = false;
			this.btnCloseStatusPanel.Click += new System.EventHandler(this.btnCloseStatusPanel_Click);
			// 
			// btnPost
			// 
			this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(159)))));
			this.btnPost.Enabled = false;
			this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPost.ForeColor = System.Drawing.Color.White;
			this.btnPost.Location = new System.Drawing.Point(276, 62);
			this.btnPost.Name = "btnPost";
			this.btnPost.Size = new System.Drawing.Size(75, 30);
			this.btnPost.TabIndex = 1;
			this.btnPost.Text = "发布";
			this.btnPost.UseMnemonic = false;
			this.btnPost.UseVisualStyleBackColor = false;
			this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
			// 
			// btnShowStatusPanel
			// 
			this.btnShowStatusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShowStatusPanel.BackColor = System.Drawing.Color.Transparent;
			this.btnShowStatusPanel.FlatAppearance.BorderSize = 0;
			this.btnShowStatusPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnShowStatusPanel.Image = global::WinformDemo.Properties.Resources.paperfly;
			this.btnShowStatusPanel.Location = new System.Drawing.Point(352, 12);
			this.btnShowStatusPanel.Name = "btnShowStatusPanel";
			this.btnShowStatusPanel.Size = new System.Drawing.Size(100, 100);
			this.btnShowStatusPanel.TabIndex = 4;
			this.btnShowStatusPanel.UseVisualStyleBackColor = false;
			this.btnShowStatusPanel.Click += new System.EventHandler(this.btnShowStatusPanel_Click);
			// 
			// webBrowser1
			// 
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new System.Drawing.Point(12, 118);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.Size = new System.Drawing.Size(440, 551);
			this.webBrowser1.TabIndex = 5;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			// 
			// lblState
			// 
			this.lblState.AutoSize = true;
			this.lblState.BackColor = System.Drawing.Color.Transparent;
			this.lblState.ForeColor = System.Drawing.Color.DimGray;
			this.lblState.Location = new System.Drawing.Point(127, 36);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(0, 17);
			this.lblState.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(218)))), ((int)(((byte)(239)))));
			this.BackgroundImage = global::WinformDemo.Properties.Resources.body_bg;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(464, 681);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblLocation);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.picAvatar);
			this.Controls.Add(this.btnShowStatusPanel);
			this.Controls.Add(this.statusPanel);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 2880);
			this.MinimumSize = new System.Drawing.Size(480, 720);
			this.Name = "Form1";
			this.Text = "微博DEMO";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
			this.statusPanel.ResumeLayout(false);
			this.statusPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picAvatar;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Panel statusPanel;
		private System.Windows.Forms.Button btnAddImage;
		private System.Windows.Forms.Button btnPost;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Label lblCharCount;
		private System.Windows.Forms.Button btnShowStatusPanel;
		private System.Windows.Forms.Button btnCloseStatusPanel;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Label lblState;

	}
}

