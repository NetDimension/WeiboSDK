using NetDimension.OpenAuth.Tencent;
using NetDimension.OpenAuth.Winform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
	class QQConnectTest
	{
		public QQConnectTest()
		{
			var openAuth = new QQConnectClient("101194847", "2904a4765f7d449918aceedc66600eec", "http://dev.ohtrip.cn");
			var form = openAuth.GetAuthenticationForm();




			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				console.info("用户授权成功！");
				console.data("AccessToken={0}\tOpenId={1}", openAuth.AccessToken, openAuth.OpenId);
				StartTest(openAuth);
			}
			else
			{
				console.error("用户授权失败！");
			}


		}

		private void StartTest(QQConnectClient openAuth)
		{

			console.attention("按任意键获取用户信息");
			Console.ReadKey(true);
			GetUserInfo(openAuth);

			console.attention("按任意键发布一条图片微博");
			Console.ReadKey(true);
			PostImageStatus(openAuth);

			console.attention("按任意键发布一条文字微博");
			Console.ReadKey(true);
			PostStatus(openAuth);
		}

		private void GetUserInfo(QQConnectClient openAuth)
		{
			var response = openAuth.HttpGet("user/get_user_info");

			if (response.IsSuccessStatusCode)
			{
				console.data(response.Content.ReadAsStringAsync().Result);
			}
		}

		private void PostStatus(QQConnectClient openAuth)
		{
			console.info("发布一条微博...");


			var result = openAuth.HttpPost("t/add_t", new Dictionary<string, object>
			{
				{"content",  string.Format("发布自WeiboSDK_V3@{0:HH:mm:ss}", DateTime.Now)}
			});


			if (result.IsSuccessStatusCode)
			{

				console.data(result.Content.ReadAsStringAsync().Result);
				console.info("发布成功！");
			}
		}

		private void PostImageStatus(QQConnectClient openAuth)
		{
			console.info("发布一条图片微博...");

			var imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MrJSON-Production.png");

			var buff = File.ReadAllBytes(imgPath);

			var result = openAuth.HttpPost("t/add_pic_t", new Dictionary<string, object> {
			
				{"content" , string.Format("SDK TEST {0:HH:mm:ss}", DateTime.Now)},
				{"pic" , buff}
			});



			if (result.IsSuccessStatusCode)
			{

				console.data(result.Content.ReadAsStringAsync().Result);
				console.info("发布成功！");
			}
		}

	}
}
