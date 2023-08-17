/*
 * 由SharpDevelop创建。
 * 用户： ifwz
 * 日期: 2023/5/12
 * 时间: 15:33
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ExcelDna.Integration.CustomUI;
using System.Windows.Forms;
using ExcelDna.Integration;
using donate;
using et=Microsoft.Office.Interop.Excel;
using plus;
using Sunny.UI;

namespace ExcelGPT
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[ComVisible(true)]
    [Guid("05278342-E294-40E1-A687-2DCF6EFADA86"), ProgId("ExcelGPTPro.Ribbon")]
	public class Ribbon : ExcelRibbon
	{
		private static IRibbonUI customRibbon;     //记录IRibbonUI对象 
		/// <summary>
        /// ribbon callback, get IRibbonUI object.
        /// </summary>
        public   void ribbonLoaded(IRibbonUI ribbon)
        {            
            
            customRibbon = ribbon;

   			ExtractWebDLLFromAssembly();
        }

        /// <summary>
        /// read CustomUI.xml, xml file must be UTF-8 encode and Embedded resources.
        /// </summary>
        public  override  string GetCustomUI(string uiName)
        {
            string ribbonxml = string.Empty;
            try
            {  

            	if (ExcelDnaUtil.ExcelVersion >= 14){
            		Assembly assembly = Assembly.GetExecutingAssembly();
					string resourceName = assembly.GetName().Name.ToString() + ".CustomUI14.xml";
					using (Stream stream = assembly.GetManifestResourceStream(resourceName))
					{
					   using (StreamReader sr = new StreamReader(stream))
					   {
					      ribbonxml = sr.ReadToEnd();
					   }
					} //嵌入文件写法 https://www.cnblogs.com/seanyan/p/14333844.html 
            	}
                else
                	MessageBox.Show("您的Excel版本过低，本插件不予支持");
                    //ribbonxml = File.ReadAllText("CustomUI12.xml");  //CustomUI12.xml需要设成嵌入资源。
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
            return ribbonxml;
        }
        
        [ExcelFunction(Category = "AI", Description = "gpt-3.5-turbo(4k)")]
        public static object AI(
            [ExcelArgument(Description = "输入请求")] string inputString
            )
        {
        	 if (!File.Exists(@"C:\Program Files\api.txt")) //非初次安装，而是仅替换，不会释放api.txt，故创建个空文件
			{
        	 	File.WriteAllText(@"C:\Program Files\api.txt","");
			} 
        		
        	string[] sk=File.ReadAllText(@"C:\Program Files\api.txt").Split('\n');
        	if (sk[0]=="") {
        		APIForm api=new APIForm();
                api.Show();
        	}else{
        	Api=sk[0];
        	Agent=sk[1];
			}
             string json="{\"model\": \"gpt-3.5-turbo\",\"messages\": [{\"role\": \"user\",\"content\": \""+inputString+"\"}]}";
			string txt=Post(json,Agent);
        	 string[] split =txt.Split(new string[] { "content\":\"", "\"},\"finish_reason" }, StringSplitOptions.RemoveEmptyEntries);
			
//        	  string json="{\"prompt\":\""+inputString+"\",\"options\":{},\"systemMessage\":\"You are ChatGPT, a large language model trained by OpenAI. Follow the user's instructions carefully. Respond using markdown.\",\"temperature\":0.8,\"top_p\":1,\"model\":\"chinchilla\",\"user\":null}";
//			string txt=Post(json,api);
//        	 string[] split =txt.Split(new string[] { "content\":\"", "\"},\"finish_reason" }, StringSplitOptions.RemoveEmptyEntries);
//			
        	// return txt;
        	 return split[1];
        	
        }
      //  public static string api="https://1.b88.asia/api/chat-process";
//        public void comboBox_Click(IRibbonControl control,string text)
//        {
//        	 
//            switch (text)
//            {
//
//                case "公益1":
//            		MessageBox.Show("切换至公益接口1");
//                    api="https://1.b88.asia/api/chat-process";
//                    break;
//                case "公益2":
//                    MessageBox.Show("切换至公益接口2");
//                    api="https://p3.v50.ltd/api/chat-process";
//                    break;
//                
//                default:
//                    MessageBox.Show("Hello:" + control.Id);
//                    break;
//            }
//        }
        /// <summary>
        /// ribbon callback. 回调
        /// </summary>
         
        public void button_Click(IRibbonControl control)
        {

            switch (control.Id)
            {

                case "About":
                    MessageBox.Show("ExcelGPT Pro \n作者：吃爆米花的小熊\n\n本插件永久免费，禁止商用倒卖贩卖\n\n允许在B站、抖音、头条、快手、知乎、简书等平台分享扩散，但要署名开发者\n不允许说是国外小哥开发的\n\n---致谢名单---\n\nGovert van Drimmelen\nCharltsing(泡泡大龙王)\nnodeman\nyangf85\npandora");
                    break;
                case "APIKEY":
                    APIForm api=new APIForm();
                    api.Show();
                    break;
                case "Ai":
                    //ExcelDnaUtil.XllPath  插件目录
                    Selection2Markdown();
                    plus.MainForm pf=new plus.MainForm(); 
                    pf.md=md;
                    pf.Show();

                    break;
                case "Donate":
                    donate.MainForm f=new donate.MainForm();
                    f.Show();
                    break;
                case "Feedback":
					MessageBox.Show("即将跳转至用户反馈页面");
					System.Diagnostics.Process.Start("https://meta.appinn.net/t/topic/43611");
                    break;
                case "QQ":
                    MessageBox.Show("ExcelGPT官方交流群 585492948");
					System.Diagnostics.Process.Start("https://qm.qq.com/cgi-bin/qm/qr?k=oPeGUrIZxq1TGaqVhvyJtc-Z0Y5YxFLa&jump_from=webapi&authKey=/MVsxGOA9kaNZqW8kjMk81EFn0r6bShyRwl3I17djLcmOY1EyPpqhzhcicCWyIj0");
                    break;
                case "Update":
					MessageBox.Show("----更新计划----\n\n ExcelGPT 初代版本实现函数调用chatgpt3.5接口\n ExcelGPT Plus增加chatgpt交互窗口\n ExcelGPT pro 实现语音输入指令，打造办公界的贾维斯\n ExcelGPT pro max 接入GPT-4.0 实现AI绘制图表 \n ExcelGPT pro max Ultra 还没有想好叠什么buff，尽情期待");
                    break;
                default:
                    MessageBox.Show("Hello:" + control.Id);
                    break;
            }
        }
        public static string md="";
      // [ExcelCommand(MenuName = "测试", MenuText = "Excel选区转Markdown")]
        public static void Selection2Markdown()
        {
            ExcelReference selection = null; ;
            try
            {
                selection = (ExcelReference)XlCall.Excel(XlCall.xlfSelection);
            }
            catch
            {
                return;
            }
            if (selection == null) return;

            dynamic obj = ReferenceToRange(selection);
            //if (!(obj is ExcelPIA.Range)) return;

            // Get the value of the selection
            object selectionContent = selection.GetValue();
            
            if (selectionContent is object[,])
            {
                object[,] values = (object[,])selectionContent;
                int rows = values.GetLength(0);
                int cols = values.GetLength(1);
         
                for (int j = 0; j < cols; j++)
                    {
                    	md+="| ";
                    }
                //md+="|\n";
                md+="|\\n";
                for (int j = 0; j < cols; j++)
                    {
                    	md+="|-";
                    }
                //md+="|\n";
                md+="|\\n";

                // Process the values
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                    	md+="|"+values[i,j];
                    }
                    //md+="|\n";
                    md+="|\\n";
                }
            }
             
            else
            {
            	MessageBox.Show("请选择选区");
              //  result = new object[,] { { "Selection was not a range or a number, but " + selectionContent.ToString() } };
            }
           
            
        }
        /// <summary>
        /// ExcelReference to Range
        /// </summary>
        /// <param name="xlref"></param>
        /// <returns></returns>
        private static dynamic ReferenceToRange(ExcelReference xlref)          //简版的
        {
            dynamic app = ExcelDnaUtil.Application;
            return app.Range[XlCall.Excel(XlCall.xlfReftext, xlref, true)];
        }
        //管用
        public static string GetFileName(){
        	var app = ExcelDnaUtil.Application as
			et.Application;
			if (app != null && app.ActiveWorkbook !=
			null)
			{
			return app.ActiveWorkbook.FullName;
			}
			return null;
			//https://groups.google.com/g/exceldna/c/DUNfSIoDarA			
        }
        //不管用！！！
        [ExcelFunction(IsMacroType=true)]
		public static string CallingFileName()
		{
		ExcelReference reference = (ExcelReference)XlCall.Excel
		(XlCall.xlfCaller);
		string sheetName = (string)XlCall.Excel(XlCall.xlSheetNm,
		reference);
		
		return System.IO.Path.Combine(
		(string)XlCall.Excel(XlCall.xlfGetDocument, 2, sheetName),
		(string)XlCall.Excel(XlCall.xlfGetDocument, 88, sheetName));
		}
        
         public Bitmap GetImage(IRibbonControl Control)
        {
            switch(Control.Id)
            {
                case "About":
            		return new Bitmap(getimgbyname("about.png"));
            	case "Ai":
            		return new Bitmap(getimgbyname("ai.png"));
            	case "QQ":
            		return new Bitmap(getimgbyname("QQ.png"));
            	case "Donate":
            		return new Bitmap(getimgbyname("donate.png"));
            	case "Feedback":
            		return new Bitmap(getimgbyname("feedback.png"));
            	case "Update":
            		return new Bitmap(getimgbyname("update.png"));
            	case "Jupyter":
            		return new Bitmap(getimgbyname("Jupyter.png"));	
            	case "APIKEY":
            		return new Bitmap(getimgbyname("key.png"));
                default :
                    return new Bitmap(System.Drawing.Image.FromFile(""));
            }
        }
         
         public System.Drawing.Image getimgbyname(string name){
         	Assembly assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetName().Name.ToString() + "."+name;
			 
			return	System.Drawing.Image.FromStream(assembly.GetManifestResourceStream(resourceName));
         }
         
         public static string gettxtbyname(string name){
         	Assembly assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetName().Name.ToString() + "."+name;
			 
			 StreamReader reader = new StreamReader( assembly.GetManifestResourceStream(resourceName));
			 
			return	 reader.ReadToEnd();
         }
         #region CustomTaskPane
        public void OnShowCTP(IRibbonControl control)
        {
           // Log.Info("OnShowCTP");
            ShowCTP();
        }        
        private void ShowCTP()
        {
            //Log.Info("CTPManager.ShowCTP");
            int hwnd = GetActivewindowHwnd();
            CTPManager.Instance.ShowCTP(hwnd);
            //Log.Info($"CTPManager.Instance.ShowCTP(hwnd) finished");
        }
        
        

        public void OnDeleteCTP(IRibbonControl control)
        {
            CTPManager.Instance.DeleteCTP(GetActivewindowHwnd());
        }
        private int GetActivewindowHwnd()
        {
            //Log.Info("GetActivewindowHwnd");
            int hwnd = 0;
            if (ExcelDnaUtil.IsET) return hwnd;  //WPS个人版不是SDI。

            //Office 2013 is SDI(single document interface)
            //每个工作簿有一个单独的Window句柄，也有一个单独的CTP。
            //所以，要管理CTP需要借助ActiveWindow.Hwnd
            //通过Hwnd来判断当前的CTP。

            //在本Demo中，因为没有引用Excel或WPS库，所以不能得到ActiveWindow.Hwnd。
            //以下代码屏蔽，待引用Excel或者WPS库之后再加上获取Hwnd的代码。
            if (ExcelDnaUtil.ExcelVersion > 14)     //Excel2013 版本号是15.0
            {                
            //    ExcelPIA.Window activewin = (ExcelDnaUtil.Application as ExcelPIA.Application).ActiveWindow;
            //    if (activewin != null) hwnd = activewin.Hwnd;
            }
            return hwnd;
        }
        #endregion CustomTaskPane
        
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
		
		#region 释放dll
		private byte[] GetAssemblyBytes(string assemblyResource)
		{
		    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(assemblyResource))
		    {
		        return new BinaryReader(stream).ReadBytes((int)stream.Length);
		    }
		}
		
		
		// For Microsoft.Web.WebView2.Core.dll and WebView2Loader.dll
		// Incorporation as embedded resource but need to be extracted
		private void ExtractWebDLLFromAssembly()
		{
		    string[] dllNames = new string[] { "Microsoft.Web.WebView2.Core.dll", "WebView2Loader.dll"};
		    string thisAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
		    foreach (string dllName in dllNames)
		    {
		        string dllFullPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, dllName);
		        try
		        {
		            File.WriteAllBytes(dllFullPath, GetAssemblyBytes(thisAssemblyName + "." + dllName));
		        }
		        catch
		        {
		            // Depending on what you want to do, continue or exit
		        }
		    }
		}
		#endregion
		
		
	}
}