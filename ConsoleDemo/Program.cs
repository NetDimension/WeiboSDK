using NetDimension.OpenAuth;
using NetDimension.OpenAuth.Sina;
using NetDimension.OpenAuth.Tencent;
using NetDimension.OpenAuth.Winform;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{

	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{


			var act = new Func<object>(() =>
			{
				return "test";
			});

			console.key("WeiboSDK_V3 Console 示例");
			console.key("版权所有 (C) NetDimension Studio 保留全部权利。");
			var loop = true;
			while (loop)
			{
				console.tip("1. 新浪微博测试");
				console.tip("2. 腾讯开发平台测试");
				console.tip("3. 退出");

				Console.Write("选择一个项目:");




				var key = Console.ReadKey();
				console.log();

				switch (key.Key)
				{
					case ConsoleKey.D1:
						var sina = new SinaWeiboTest();
						break;
					case ConsoleKey.D2:
						var tencent = new QQConnectTest();
						break;
					case ConsoleKey.D3:
						loop = false;
						break;
				}

				//var sinaWeibo = new SinaWeiboTest();

			}


		}






	}


	public static class console
	{
		public static void log()
		{
			Console.WriteLine();

		}

		public static void log(string msg, params object[] args)
		{
			if (args.Length > 0)
			{
				Console.WriteLine(msg, args);
			}
			else
			{
				Console.WriteLine(msg);
			}

		}
		public static void warn(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			log(msg, args);

			Console.ResetColor();
		}

		public static void error(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			log(msg, args);
			Console.ResetColor();
		}

		public static void info(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			log(msg, args);
			Console.ResetColor();
		}

		public static void tip(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			log(msg, args);
			Console.ResetColor();
		}

		public static void attention(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			log(msg, args);
			Console.ResetColor();
		}

		public static void key(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.White;
			log(msg, args);
			Console.ResetColor();
		}

		public static void data(string msg, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			log(msg, args);
			Console.ResetColor();
		}
	}
}
