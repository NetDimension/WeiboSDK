# WeiboSDK
## 新浪微博SDK v3 源码和示例

### 前言
时间过得飞快，距离上次SDK更新已经3年有余。随着官方的不断跟新，老版SDK的部分接口已经不能正常使用。因此在QQ群里来吐槽的、来谩骂的朋友也开始多了起来。随着时代的发展，微博已经彻底的被微信甩开，因此对它的兴趣已经丧失；同时对我自己来说，那么几年在行业里面为了生存而奔波，日子越混越差，已经无暇再与新浪官方同步更新SDK，因此自从13年以后就再也没有更新过V2版的SDK。虽然微博大势已去，但是依然有很多朋友通过新浪开放平台的页面下载了我发布的这个SDK，可以说，由于长时间的不更新，老版本已经严重误导了新来的朋友，这也是我开发了新版SDK的另外一个重要原因。
第三版SDK的一些说明
* 与老版本不兼容
* 不再支持.NET 4.0以下的版本
* 没有封装官方API，但新版接口调用规范遵循新浪官方API的参数风格，具体请看示例
其他提示
* 第三版SDK基于微软的HTTP Client Libraries，并且不再内部封装JSON.Net，新建项目请自行Nuget。
* 由于新浪的限制，第三版SDK不再提供模拟登录接口，Winform或者控制台项目请引用NetDimension.OpenAuth.Winform库，里面封装了一个授权窗口，具体请看示例。

### 使用方法
第一步，初始化客户端

如果用户还未进行授权的情况

使用微博开放平台后台中提供的appkey，appsecret以及回调地址callback_url来初始化客户端。

	var openAuth = new SinaWeiboClient("<appkey>", "<appsecret>", "<callback_url>");

然后取得授权页面地址，并访问该地址进行授权，并获得Authorization_Code

	var url = openAuth.GetAuthorizationUrl();

根据返回的Code换取AccessToken


	openAuth.GetAccessTokenByCode("[CODE]");
	if(openAuth.IsAuthorized)
	{
		var accessToken = openAuth.AccessToken;
		var uid = openAuth.UID;
	}

重要!!!获得了AccessToken和UID后请保存好这两个数据，以后的接口调用直接使用这两个参数，就不用每次都执行第一步和第二步。

下面，就可以跳转到第二步来调用官方的API了。

当然，如果之前已经进行过授权，并且已获得AccessToken和UID，使用下面的方法来初始化客户端。

	var openAuth = new SinaWeiboClient("<appkey>", "<appsecret>", "<access_token>", "<uid>");

之后就可以直接跳转到第二步来调用API了。

第二步，调用接口

这里提供了Get和Post两个方法来调用官方的API，同时提供了异步的支持。使用的时候根据官方文档的要求来选择使用Get还是Post来调用API（官方的文档中已经明确说明了调用方式）。

调用接口传参的方式有两个，一种是传一个Dictionary<string,object>类型的参数组进去，另外一个是new一个匿名类传进去，个人觉得用匿名类才会显得非常科学。

例如，调用获取当前登录用户最新微博的API

	var result = openAuth.HttpGet("statuses/friends_timeline.json", 
	new Dictionary<string, object>
	{
		{"count", 5},
		{"page", 1},
		{"base_app" , 0}
	}); //这里可以使用字典或者匿名类的方式传递参数，参数名称、大小写、参数顺序和规范请参照官方api文档

	if (result.IsSuccessStatusCode)
	{
		Console.WriteLine(result.Content.ReadAsStringAsync().Result);
	}

另外，如果需要异步调用请参考下面的例子。

	// 调用获取获取用户信息api
	// 参考：http://open.weibo.com/wiki/2/users/show
	var response = openAuth.HttpGetAsync("users/show.json", 
	//可以传入一个Dictionary<string,object>类型的对象，也可以直接传入一个匿名类。参数与官方api文档中的参数相对应
	new {
		uid = openAuth.UID
	});

	response.ContinueWith(task =>{
		//异步处理结果
	});

如果使用.net4.5的话，是可以直接使用async和await关键字来简化上面的操作的。

另外，因为现在新浪官方的限制搞出了个登录验证码，所以新版的SDK就不再提供以前版本的模拟登录来获取授权（ClientLogin）方式。针对Winform和Console应用，可以引用NetDimension.OpenAuth.Winform这个类，其中提供了一个扩展方法可以在上述两种项目类型中弹出授权窗口，并在用户授权后自动获得Authorization_Code，具体操作请查看Winform和Console的示例代码。

	using NetDimension.OpenAuth.Winform;

	...

	var form = openAuth.GetAuthenticationForm();
	if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
	{
		Console.WriteLine("用户授权成功！");
		var accessToken = openAuth.AccessToken;
		var uid = openAuth.UID;
		//其他操作
		//...

	}
	else
	{
		Console.WriteLine("用户授权失败！");
	}

执行上面的代码，将弹出下图所示的窗口。

![Alt text](http://images2015.cnblogs.com/blog/352785/201601/352785-20160108134821887-1788493591.png)

用户完成登录后，SDK会使用正则表达式从回调地址中获取Authorization_Code。

### 关于源代码中的示例

示例没啥好说的，源码中有三个示例，分别是一个MVC的网页示例，两个桌面的控制台和WinForm示例。

示例里面明文写了一套APPKey和对应的Secret及回调地址，不改的话示例应该是可以正常运行的，如果改成自己的Key以后出错，那么就请自行Google如何设置回调地址。

MVC的示例设置稍微复杂点，要去改下IIS Express的配置，让网站能通过127.0.0.1或者192.168.0.100这样的IP地址访问到，不然回调的时候无法访问到，MVC示例的首页上有修改教程，如果示例运行不起来请打开Views\Home\Index.cshtml看如果修改。

Winform示例运行截图

![Alt text](http://images2015.cnblogs.com/blog/352785/201601/352785-20160108140114825-1445128404.png)

![Alt text](http://images2015.cnblogs.com/blog/352785/201601/352785-20160108140236090-1811530950.png)

网站示例运行截图
![Alt text](http://images2015.cnblogs.com/blog/352785/201601/352785-20160108142916137-435905462.png)
另外需要注意的是，如果使用的是VS2015，IIS Express的配置文件applicationhost.config地址已经不再是“文档\IIS Express\”，而是在项目地址下的.vs目录下，该目录是个隐藏目录，直接地址栏里面输入路径来访问。

控制台示例运行截图
![Alt text](http://images2015.cnblogs.com/blog/352785/201601/352785-20160108140527496-201039245.png)
示例中有调用腾讯微博的例子，但是腾讯的要求很严，申请app需要网站验证，因为我用朋友的网站，所以请有需要的朋友还是自行注册app（腾讯微博的开发者平台dev.t.qq.com的api文档服务器是不是挂了？反正我是上不去了。）。另外，腾讯的例子里有个发图片微博的方法，严格按照腾讯api文档来写的，但是不能正常使用，如果有朋友知道原因还请告知。写腾讯的例子，只是为了展示新版的SDK通过继承，很容易就可以拓展到其他诸如微信开放平台、人人等平台。具体要怎么用，大家自行发掘。

示例的代码已经包含在源代码里，具体请自行参考代码。

 

以上，就是新版本的所有内容。

正如开篇所说的，新浪微博感觉大势已去，所以这个微博SDK也不会再更新新版本。第三版的这个SDK将最为最终版本，只做维护和BUG修正，不再增加和更新新内容。如果有朋友对新浪开发平台继续保持着兴趣，请自行GitHub去Clone代码，按自己的需求去扩展功能。

最后，感谢QQ群里面的所有朋友这么几年以来的支持和鼓舞，谢谢。

新朋友欢迎进群讨论，群号：241088256