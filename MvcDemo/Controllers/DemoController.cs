using NetDimension.OpenAuth.Sina;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
	public class DemoController : Controller
	{
		//
		// GET: /Demo/

		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// 封装一个方法来初始化OpenAuth客户端
		/// </summary>
		/// <returns></returns>
		private SinaWeiboClient GetOpenAuthClient()
		{
			var accessToken = Session["access_token"] == null ? string.Empty : (string)Session["access_token"];
			var uid = Request.Cookies["uid"] == null ? string.Empty : Request.Cookies["uid"].Value;

			var settings = ConfigurationManager.AppSettings;
			var client = new SinaWeiboClient(settings["appKey"], settings["appSecret"], settings["callbackUrl"], accessToken, uid);

			return client;
		}

		/// <summary>
		/// 授权认证
		/// </summary>
		/// <param name="code">新浪返回的code</param>
		/// <returns></returns>
		public ActionResult Authorized(string code)
		{
			if (string.IsNullOrEmpty(code))
			{
				return RedirectToAction("Index");
			}


			var client = GetOpenAuthClient();

			client.GetAccessTokenByCode(code);

			if (client.IsAuthorized)
			{
				//用session记录access token
				Session["access_token"] = client.AccessToken;
				//用cookie记录uid
				Response.AppendCookie(new HttpCookie("uid", client.UID) { Expires = DateTime.Now.AddDays(7) });
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index");
			}

		}

		/// <summary>
		/// 获取最新微博
		/// </summary>
		/// <returns></returns>
		public ActionResult GetPublicTimeline()
		{
			var client = GetOpenAuthClient();

			if (!client.IsAuthorized)
			{
				return Json(new
				{
					authorized = false,
				});
			}
			// 调用获取当前登录用户及其所关注用户的最新微博api
			// 参考：http://open.weibo.com/wiki/2/statuses/friends_timeline
			var response = client.HttpGet("statuses/friends_timeline.json");

			return Content(response.Content.ReadAsStringAsync().Result, "application/json");


		}
		/// <summary>
		/// 获取用户信息
		/// </summary>
		/// <returns></returns>
		public ActionResult GetUserState()
		{
			var client = GetOpenAuthClient();

			if (!client.IsAuthorized)
			{
				return Json(new
				{
					authorized = false,
					url = client.GetAuthorizationUrl()
				});
			}

			// 调用获取获取用户信息api
			// 参考：http://open.weibo.com/wiki/2/users/show
			var response = client.HttpGet("users/show.json", new
			{
				uid = client.UID
			});

			if (response.IsSuccessStatusCode)
			{
				var json = new JObject();
				json["authorized"] = true;
				json["data"] = JObject.Parse(response.Content.ReadAsStringAsync().Result);
				return Content(json.ToString(Formatting.None), "application/json");
			}
			else
			{
				var json = new JObject();
				json["authorized"] = false;
				json["data"] = JObject.Parse(response.Content.ReadAsStringAsync().Result);

				json["authorized"] = true;
				return Content(json.ToString(Formatting.None), "application/json");
			}
		}
		/// <summary>
		/// 发微博
		/// </summary>
		/// <param name="status"></param>
		/// <param name="img"></param>
		/// <returns></returns>
		public ActionResult PostStatus(string status, string img)
		{
			var imgFile = new FileInfo(Server.MapPath(string.Format("~/tmp/{0}", img)));

			var client = GetOpenAuthClient();

			if (!client.IsAuthorized)
			{
				return Json(false);
			}

			if (imgFile.Exists)
			{
				// 调用发图片微博api
				// 参考：http://open.weibo.com/wiki/2/statuses/upload
				var response = client.HttpPost("statuses/upload.json", new
				{
					status = status,
					pic = imgFile //imgFile: 对于文件上传，这里可以直接传FileInfo对象
				});

				if (response.IsSuccessStatusCode)
				{
					return Json(true);
				}
				else
				{
					return Json(false);
				}


			}
			else
			{
				// 调用发微博api
				// 参考：http://open.weibo.com/wiki/2/statuses/update
				var response = client.HttpPost("statuses/update.json", new
				{
					status = status
				});

				if (response.IsSuccessStatusCode)
				{
					return Json(true);
				}
				else
				{
					return Json(false);
				}
			}
		}


		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public ActionResult UploadImage(HttpPostedFileBase file)
		{

			try
			{
				var img = new Bitmap(file.InputStream);

				var fileName = string.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, file.FileName.Substring(file.FileName.LastIndexOf('.')));

				file.SaveAs(Server.MapPath(string.Format("~/tmp/{0}", fileName)));

				return Json(new { success = true, fileName = fileName });
			}
			catch
			{
				return Json(new { success = false });
			}

		}



	}



}
