/*
 * 由SharpDevelop创建。
 * 用户： ifwz
 * 日期: 2023/5/13
 * 时间: 13:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using ExcelDna.Integration;
using System.IO;
using System.Reflection;
using System.Linq;


namespace ExcelGPT
{
	/// <summary>
	/// Description of XllAddIn.
	/// </summary>
	public class XllAddIn :IExcelAddIn
	{
		  public void AutoOpen()
        {
		   //	ExtractAPITXT();
          //  Console.Beep(1000, 200);
            
           // ExtractWebDLLFromAssembly();
        }
		  
		public void AutoClose()
        {
           Console.Beep(1000, 200);           
        }
		
		//释放api.txt
		 public void ExtractAPITXT(){
			//MessageBox.Show(gettxtbyname("api.txt"));
			 string s = Path.GetDirectoryName(ExcelDnaUtil.XllPath);
			 
			File.WriteAllText(s+@"\api.txt",gettxtbyname("api.txt"));
         }
		public string gettxtbyname(string name){
         	Assembly assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetName().Name.ToString() + "."+name;
			 
			 StreamReader reader = new StreamReader( assembly.GetManifestResourceStream(resourceName));
			 
			return	 reader.ReadToEnd();
         }
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
