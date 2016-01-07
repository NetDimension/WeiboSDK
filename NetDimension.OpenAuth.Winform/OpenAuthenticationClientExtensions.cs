using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.OpenAuth.Winform
{
	public static class OpenAuthenticationClientExtensions
	{

		public static AuthenticationForm GetAuthenticationForm(this OpenAuthenticationClientBase oauth)
		{
			var openAuthForm = new AuthenticationForm(oauth);

			return openAuthForm;
		}

	}
}
