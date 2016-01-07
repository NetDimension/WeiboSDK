using NetDimension.OpenAuth.Sina;
using NetDimension.OpenAuth.Winform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
	class SinaWeiboTest
	{
		public SinaWeiboTest()
		{
			console.info("等待用户授权...");



			var openAuth = new SinaWeiboClient("1402038860", "62e1ddd4f6bc33077c796d5129047ca2", "http://qcyn.sina.com.cn");

			var form = openAuth.GetAuthenticationForm();



			



			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				console.info("用户授权成功！");
				console.data("AccessToken={0}", openAuth.AccessToken);


				StartTest(openAuth);

			}
			else
			{
				console.error("用户授权失败！");
			}
		}

		private void StartTest(SinaWeiboClient openAuth)
		{
			console.attention("按任意键发布一条文字微博");
			Console.ReadKey(true);
			PostStatus(openAuth);

			console.attention("按任意键发布一条图片微博");
			Console.ReadKey(true);
			PostImageStatus(openAuth);

			console.attention("按任意键获取最新微博");
			Console.ReadKey(true);
			GetFrindTimeline(openAuth);
		}

		private void GetFrindTimeline(SinaWeiboClient openAuth)
		{
			console.info("获取当前登录用户及其所关注用户的最新微博...");


			var result = openAuth.HttpGet("statuses/friends_timeline.json", new Dictionary<string, object>
			{
				{"count", 5},
				{"page", 1},
				{"base_app" , 0}
			});
			console.attention("{0}", result);

			if (result.IsSuccessStatusCode)
			{

				console.data(result.Content.ReadAsStringAsync().Result);
				console.info("获取成功！");
			}

		}

		private void PostImageStatus(SinaWeiboClient openAuth)
		{
			console.info("发布一条图片微博...");

			var imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MrJSON-Production.png");
			var result = openAuth.HttpPost("statuses/upload.json", new Dictionary<string, object> {

				{"status" , string.Format("发布自SinaWeiboSDK_V3@{0:HH:mm:ss}", DateTime.Now)},
				{"pic" , new FileInfo(imgPath)}
			});

			console.attention("{0}", result);


			if (result.IsSuccessStatusCode)
			{

				console.data(result.Content.ReadAsStringAsync().Result);
				console.info("发布成功！");
			}
		}

		private void PostStatus(SinaWeiboClient openAuth)
		{
			console.info("发布一条微博...");


			var result = openAuth.HttpPost("statuses/update.json", new Dictionary<string, object>
			{
				{"status" , string.Format("发布自SinaWeiboSDK_V3@{0:HH:mm:ss}", DateTime.Now)}
			});

			console.attention("{0}", result);
			if (result.IsSuccessStatusCode)
			{

				console.data(result.Content.ReadAsStringAsync().Result);
				console.info("发布成功！");
			}
		}
	}
}
