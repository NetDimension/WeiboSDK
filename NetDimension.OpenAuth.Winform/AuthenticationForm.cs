using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.OpenAuth.Winform
{
	public partial class AuthenticationForm : Form
	{
		OpenAuthenticationClientBase OpenAuth;


		public string Code
		{
			get;
			private set;
		}
		public AuthenticationForm(OpenAuthenticationClientBase openAuth)
		{
			InitializeComponent();
			OpenAuth = openAuth;
		}

		private void frmAuthentication_Shown(object sender, EventArgs e)
		{
			browser.Navigate(OpenAuth.GetAuthorizationUrl());
		}

		private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{

			//Console.WriteLine(e.Url);

			var pattern = @"code=([\d|a-zA-Z]*)";
			if (Regex.IsMatch(e.Url.Query, pattern))
			{
				panelMask.Visible = true;
				panelMask.BringToFront();
				var code = Regex.Match(e.Url.Query, pattern).Groups[1].Value;

				Task.Factory.StartNew(() =>
				{
					OpenAuth.GetAccessTokenByCode(code);
					UpdateUI(() =>
					{
						if (OpenAuth.IsAuthorized)
						{

							Code = code;
							this.DialogResult = System.Windows.Forms.DialogResult.OK;
							this.Close();

						}
						else
						{

							this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
							this.Close();
						}
					});
				});
			}
		}

		private void UpdateUI(Action uiAction)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(uiAction));
			}
			else
			{
				uiAction();
			}
		}

	}
}
