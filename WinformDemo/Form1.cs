using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemo
{
	public partial class Form1 : Form
	{

		#region 微博列表的模板
		const string htmlPattern = @"<!DOCTYPE html>
<html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
	<title></title>
	<style type=""text/css"">
		html, body {
			font-size: 12px;
			cursor: default;
			padding: 5px;
			margin: 0;
			font-family:微软雅黑,Tahoma;
		}

		div.status {
			padding-left: 60px;
			position: relative;
			margin-bottom: 10px;
			min-height:80px;
			_height:80px;
		}

			div.status p {
				margin: 0 0 5px 0;
				line-height: 1.5;
				padding: 0;
			}

				div.status p span.name {
					color: #369;
				}

				div.status p.status-content {
					color: #333;
				}

				div.status p.status-count {
					color:#999;
				}

			div.status .face {
				position: absolute;
				left: 0;
				top: 0;
			}

			div.status div.repost {
				border: solid 1px #ACD;
				background: #F0FAFF;
				padding: 10px 10px 0 10px;
			}

		div.repost p.repost-content {
			color: #666 !important;
		}
	</style>
</head>
<body>
<!--StatusesList-->
</body>
</html>";
		const string imageParttern = @"<img src=""{0}"" alt=""图片"" class=""inner-pic"" />";
		const string statusPattern = @"	<div class=""status"">
		<img src=""{0}"" alt=""{1}"" class=""face"" />
		<p class=""status-content""><span class=""name"">{1}</span>：{2}</p>
		{3}
		<p class=""status-count"">转发({4}) 评论({5})</p>
	</div>
";
		const string repostPattern = @"	<div class=""status"">
		<img src=""{0}"" alt=""{1}"" class=""face"" />
		<p class=""status-content""><span class=""name"">{1}</span>：{2}</p>
		<div class=""repost"">
			<p class=""repost-cotent""><span class=""name"">@{3}</span>：{4}</p>
			{5}
			<p class=""status-count"">转发({6}) 评论({7})</p>
		</div>
		<p class=""status-count"">转发({8}) 评论({9})</p>
	</div>
";
		#endregion


		private NetDimension.OpenAuth.Sina.SinaWeiboClient openAuth;


		bool statusIsOutOfRange;

		FileInfo imageFile = null;

		public Form1(NetDimension.OpenAuth.Sina.SinaWeiboClient client)
		{
			InitializeComponent();
			this.openAuth = client;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			GetUserInfo();
			lblCharCount.Text = GetContentLengthString(txtStatus.Text, out statusIsOutOfRange);
			GetFriendTimeline();
		}
		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <returns></returns>
		private void GetUserInfo()
		{
			// 调用获取获取用户信息api
			// 参考：http://open.weibo.com/wiki/2/users/show
			var response = openAuth.HttpGet("users/show.json", new
			{
				//可以传入一个Dictionary<string,object>类型的对象，也可以直接传入一个匿名类。参数与官方api文档中的参数相对应
				uid = openAuth.UID
			});


			Debug.WriteLine(response);

			if (response.IsSuccessStatusCode)
			{
				response.Content.ReadAsStringAsync().ContinueWith((task) =>
				{
					var json = JObject.Parse(task.Result);
					Debug.WriteLine(json);


					UpdateUI(() =>
					{
						picAvatar.ImageLocation = json.Value<string>("avatar_large");

						lblName.Text = json.Value<string>("screen_name");

						lblState.Text = string.Format("关注({0}) 粉丝({1})", json["friends_count"], json["followers_count"]);

						lblLocation.Text = json.Value<string>("location");

						var g = Graphics.FromHwnd(this.Handle);

						var matrix = g.MeasureString(lblName.Text, lblName.Font);



						g.Dispose();

						lblLocation.Left = lblName.Left + (int)matrix.Width;

						lblDescription.Text = json.Value<string>("description");
					});





				});
			}
			else
			{
				Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
			}

		}
		/// <summary>
		/// 获取最新微博
		/// </summary>
		/// <returns></returns>
		private void GetFriendTimeline()
		{
			// 调用获取当前登录用户及其所关注用户的最新微博api
			// 参考：http://open.weibo.com/wiki/2/statuses/friends_timeline
			openAuth.HttpGetAsync("statuses/home_timeline.json", new Dictionary<string, object>
			{	
				//可以传入一个Dictionary<string,object>类型的对象，也可以直接传入一个匿名类。参数与官方api文档中的参数相对应
				{"count",10}
			}).ContinueWith(task =>
			{

				if (task.Result.IsSuccessStatusCode)
				{
					StringBuilder statusBuilder = new StringBuilder();

					//解析微博开放平台返回的json数据
					var json = JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
					Debug.WriteLine(json);

					foreach (JObject status in json.Value<JArray>("statuses"))
					{
						if (status["user"] == null)
							continue;

						if (status["retweeted_status"] != null && status["retweeted_status"]["user"] != null)
						{
							statusBuilder.AppendFormat(repostPattern,
								status["user"]["profile_image_url"],
								status["user"]["screen_name"],
								status["text"],
								status["retweeted_status"]["user"]["screen_name"],
								status["retweeted_status"]["text"],
								status["retweeted_status"]["thumbnail_pic"] == null ? "" : string.Format(imageParttern, status["retweeted_status"]["thumbnail_pic"]),
								status["retweeted_status"]["reposts_count"],
								status["retweeted_status"]["comments_count"],
								status["reposts_count"],
								status["comments_count"]);
						}
						else
						{
							statusBuilder.AppendFormat(statusPattern,
								status["user"]["profile_image_url"],
								status["user"]["screen_name"],
								status["text"],
								status["thumbnail_pic"] == null ? "" : string.Format(imageParttern, status["thumbnail_pic"]),
								status["reposts_count"],
								status["comments_count"]);
						}

					}

					var html = htmlPattern.Replace("<!--StatusesList-->", statusBuilder.ToString());

					UpdateUI(() =>
					{

						webBrowser1.DocumentText = html;

					});

				}
				else
				{
					var reason = task.Result.Content.ReadAsStringAsync().Result;
					Debug.WriteLine(reason);

					webBrowser1.DocumentText = reason;
				}

			});


		}

		//多线程环境下修改主线程里面的控件需要用到此方法，如果用.net 4.5的await/async特性则无需此方法，具体请自己狗哥
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

		private void picAvatar_Click(object sender, EventArgs e)
		{
			GetUserInfo();
		}

		//和官方一致的微博内容字数算法
		private string GetContentLengthString(string text, out bool isOutOfRange)
		{
			text = text.Trim();
			text = Regex.Replace(text, "\r\n", "\n");
			int textLength = 0;
			if (text.Length > 0)
			{
				int min = 41, max = 140, urlLen = 20;
				var n = text;
				var r = Regex.Matches(text, @"http://[a-zA-Z0-9]+(\.[a-zA-Z0-9]+)+([-A-Z0-9a-z_$.+!*()/\\\,:;@&=?~#%]*)*");
				var total = 0;
				for (int m = 0, p = r.Count; m < p; m++)
				{
					var url = r[m].Value;
					var byteLen = url.Length + Regex.Matches(url, @"[^\x00-\x80]").Count;
					if (Regex.IsMatch(url, @"^(http://t.cn)"))
					{
						continue;
					}
					else if (Regex.IsMatch(url, @"^(http:\/\/)+(weibo.com|weibo.cn)"))
					{
						total += byteLen <= min ? byteLen : (byteLen <= max ? urlLen : (byteLen - max + urlLen));
					}
					else
					{
						total += byteLen <= max ? urlLen : (byteLen - max + urlLen);
					}
					n = n.Replace(url, "");
				}
				textLength = (int)Math.Ceiling((total + n.Length + Regex.Matches(n, @"[^\x00-\x80]").Count) / 2.00d);
			}

			int textRemainLength = 140 - textLength;
			string template = string.Empty;
			if (textRemainLength >= 0)
			{
				template = "还可以输入{0:N0}个字";
				if (textLength == 0)
				{
					isOutOfRange = false;
				}
				else
				{
					isOutOfRange = true;
				}

			}
			else
			{
				template = "已经超过了{0:N0}个字";

				isOutOfRange = true;
			}
			return string.Format(template, Math.Abs(textRemainLength));
		}

		private void txtStatus_TextChanged(object sender, EventArgs e)
		{
			lblCharCount.Text = GetContentLengthString(txtStatus.Text, out statusIsOutOfRange);

			btnPost.Enabled = statusIsOutOfRange;

		}

		private void txtStatus_Enter(object sender, EventArgs e)
		{
			EnsureStatusPanelHeight();
		}

		private void txtStatus_Leave(object sender, EventArgs e)
		{
			EnsureStatusPanelHeight();
		}

		private void EnsureStatusPanelHeight()
		{


		}

		private void btnCloseStatusPanel_Click(object sender, EventArgs e)
		{

			statusPanel.Visible = false;
			imageFile = null;
			txtStatus.Text = string.Empty;

		}

		private void btnShowStatusPanel_Click(object sender, EventArgs e)
		{
			statusPanel.BringToFront();
			statusPanel.Visible = true;
			txtStatus.Focus();

		}

		private void btnAddImage_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog
			{
				Filter = "支持的图片文件|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
			};

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				imageFile = new FileInfo(dlg.FileName);
			}
		}



		private void btnPost_Click(object sender, EventArgs e)
		{

			statusPanel.Enabled = false;

			//发微博


			//带图的情况
			if (imageFile != null)
			{
				// 调用发图片微博api
				// 参考：http://open.weibo.com/wiki/2/statuses/upload
				openAuth.HttpPostAsync("statuses/upload.json", new Dictionary<string, object> 
				//当然，这里用匿名类也是可以的
				/*
					匿名类传参方式：
				 * new { status = txtStatus.Text, pic = imageFile }
				 */
				{
					
					{"status" ,txtStatus.Text},
					{"pic" , imageFile} //imgFile: 对于文件上传，这里可以直接传FileInfo对象
				}).ContinueWith(task =>
				{
					//这里用了个异步方法，发微博不阻塞主线程，任务完成后调用处理方法
					StatusPosted(task);
				});



			}
			else
			{
				// 调用发微博api
				// 参考：http://open.weibo.com/wiki/2/statuses/update
				openAuth.HttpPostAsync("statuses/update.json", new
				{
					status = txtStatus.Text
				}).ContinueWith(task =>
				{
					StatusPosted(task);
				});
			}
		}

		//处理微博发送后的一些事情
		private void StatusPosted(Task<HttpResponseMessage> task)
		{
			var result = task.Result;
			Debug.WriteLine(result);

			if (result.IsSuccessStatusCode)
			{
				//刷新微博内容
				GetFriendTimeline();

				//因为是异步，所以调用UpdateUI刷新界面
				UpdateUI(() =>
				{

					imageFile = null;
					txtStatus.Text = string.Empty;

					statusPanel.Enabled = true;
					statusPanel.Visible = false;
				});
			}
			else
			{
				UpdateUI(() =>
				{
					MessageBox.Show(this, string.Format("发布失败：\r\n{0}", result.Content.ReadAsStringAsync().Result), "发布失败", MessageBoxButtons.OK);
					statusPanel.Enabled = true;
				});
			}
		}


	}
}
