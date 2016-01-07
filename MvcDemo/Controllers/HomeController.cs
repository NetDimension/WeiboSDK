using NetDimension.OpenAuth;
using NetDimension.OpenAuth.Sina;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		public ActionResult Index()
		{


			return View();
		}


		public ActionResult GetAuthorizationState()
		{
			var settings = ConfigurationManager.AppSettings;

			var oauth = new SinaWeiboClient(settings["appKey"], settings["appSecret"], settings["callbackUrl"]);


			if (Request.Cookies["access_token"] == null || string.IsNullOrEmpty(Request.Cookies["access_token"].Value))
			{
				return Json(new
				{
					authorized = false
				}, JsonRequestBehavior.AllowGet);
			}



			var accessToken = Request.Cookies["access_token"].Value;
			var uid = Request.Cookies["uid"].Value;

			oauth.AccessToken = accessToken;
			oauth.UID = uid;

			//较v2版的sdk，新的v3版sdk移除了所有的本地化api接口，因为新浪的接口变来变去，踩着滑板鞋也追不着他们魔鬼的步伐。
			//因此v3版的调用方式改为直接填写官方api名称和传递官方文档中要求的参数的方式来调用，返回结果需要自行使用json接卸器解析。
			var response = oauth.HttpGet("user/show.json", new
			{
				uid = uid
			});


			return Json(response.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);

		}

	}
}
