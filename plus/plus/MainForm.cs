/*
 * 由SharpDevelop创建。
 * 用户： ifwz
 * 日期: 2023/5/14
 * 时间: 16:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Aspose.Cells;
using Markdig;
using Sunny.UI;
using System.Reflection;
using Microsoft.Web.WebView2;
  
namespace plus
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : UIForm
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			 
			InitializeAsync();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		async void InitializeAsync()
		{
		   await webView21.EnsureCoreWebView2Async(null);
		   webView21.NavigateToString("<h1>hello world！</h1>");
		}
		

		public static string Agent="";
        public static string Api="";
		#region Post请求
		 /// <summary>
		 /// http Post请求
		 /// </summary>
		 /// <param name="parameterData">参数</param>
		 /// <param name="serviceUrl">访问地址</param>
		 /// <param name="ContentType">默认 application/json , application/x-www-form-urlencoded,multipart/form-data,raw,binary </param>
		 /// <param name="Accept">默认application/json</param>
		 /// <returns></returns>
		 public static string Post(string parameterData, string serviceUrl, string ContentType = "application/json", string Accept = "application/json")
		 {
		 	ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; 
		 	
		    //创建Web访问对象
		    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
		    //把用户传过来的数据转成“UTF-8”的字节流
		    byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(parameterData);
		
		    myRequest.Method = "POST";
		    //myRequest.Accept = "application/json";
		    //myRequest.ContentType = "application/json";  // //Content-Type: application/x-www-form-urlencoded 
		    myRequest.AutomaticDecompression = DecompressionMethods.GZip;
		    myRequest.Accept = Accept;
		    //myRequest.ContentType = ContentType;
		    myRequest.ContentType = "application/json; charset=UTF-8";
		   // myRequest.Headers.Add("Authorization","Bearer pk-this-is-a-real-free-pool-token-for-everyone");
		    myRequest.Headers.Add("Authorization","Bearer "+ Api);
		    
		    myRequest.ContentLength = buf.Length;
		    myRequest.MaximumAutomaticRedirections = 1;
		    myRequest.AllowAutoRedirect = true;
		    
		    //发送请求
		    Stream stream = myRequest.GetRequestStream();
		    stream.Write(buf, 0, buf.Length);
		    stream.Close();
		
		    //通过Web访问对象获取响应内容
		    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
		    //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
		    StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
		    //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
		    string returnData = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
		
		    reader.Close();
		    myResponse.Close();
		
		    return returnData;
		}
		 #endregion
		 
		 public string md="";
		void UiButton1Click(object sender, EventArgs e)
		{
			 if (!File.Exists(@"C:\Program Files\api.txt")) //非初次安装，而是仅替换，不会释放api.txt，故创建个空文件
			{
        	 	File.WriteAllText(@"C:\Program Files\api.txt","");
			} 
        		
        	string[] sk=File.ReadAllText(@"C:\Program Files\api.txt").Split('\n');
        	if (sk[0]=="") {
        		MessageBox.Show("请输入API KEY");
        	}else{
        	Api=sk[0];
        	Agent=sk[1];
			}
        	
			string json="{\"model\": \"gpt-3.5-turbo\",\"messages\": [{\"role\": \"user\",\"content\": \""+textBox1.Text.Trim()+md+"\"}]}";
			string txt=Post(json,Agent);
			
        	string[] split =txt.Split(new string[] { "content\":\"", "\"},\"finish_reason" }, StringSplitOptions.RemoveEmptyEntries);
        	//Clipboard.SetText(split[1]);
//			string json="{\"prompt\":\""+textBox1.Text.Trim()+md+"\",\"options\":{},\"systemMessage\":\"You are ChatGPT, a large language model trained by OpenAI. Follow the user's instructions carefully. Respond using markdown.\",\"temperature\":0.8,\"top_p\":1,\"model\":\"chinchilla\",\"user\":null}";
//			string txt=Post(json,"https://1.b88.asia/api/chat-process");
//        	string[] split =txt.Split(new string[] { "content\":\"", "\"},\"finish_reason" }, StringSplitOptions.RemoveEmptyEntries);
//			
        	 
        	string temp="<head><link rel=\"stylesheet\"href=\"https://cdn.jsdelivr.net/npm/normalize.css@8.0.1/normalize.css\"><link rel=\"stylesheet\"href=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/themes/prism-coy.min.css\"><link rel=\"stylesheet\"href=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/toolbar/prism-toolbar.min.css\"><link rel=\"stylesheet\"href=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/line-numbers/prism-line-numbers.min.css\"></head><body><!--prism核心js(用于渲染代码块)--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/prism.min.js\"></script><!--显示代码块行号--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/line-numbers/prism-line-numbers.min.js\"></script><!--工具栏(一些插件的前置依赖)--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/toolbar/prism-toolbar.min.js\"></script><!--代码块显示语言名称--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/show-language/prism-show-language.min.js\"></script><!--复制代码--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/copy-to-clipboard/prism-copy-to-clipboard.min.js\"></script><!--自动去cdn加载对应语言的代码高亮js--><script src=\"https://cdn.jsdelivr.net/npm/prismjs@1.27.0/plugins/autoloader/prism-autoloader.min.js\"></script>$Markdown$</body>";
 			//string html= Markdown.ToHtml(split[1].Replace("\\n","\r\n"));
 			string html= Markdown.ToHtml(split[1].Replace("\\n","\r\n"));
 			html=temp.Replace("$Markdown$",html);
			webView21.CoreWebView2.NavigateToString(html);
		}
		

		 
		
		
	}
}
