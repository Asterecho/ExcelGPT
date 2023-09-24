/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2023/8/29
 * 时间: 0:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Getkey
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		//	MessageBox.Show(getPublicAPIkey("OpenAI"));
		
		string text = getAgent("free",false);
		if (text != "")
		{
			text = text.Split(new char[]
			{
				'|'
			})[1];
		}
		string key= AesDecrypt(text.Substring(16, text.Length - 16), text.Substring(0, 16));
		
		
		string agent = getAgent("free",false);
					if (agent != "")
					{
						text = agent.Split(new char[]
						{
							'|'
						                   })[0];}
						MessageBox.Show(agent);
		Clipboard.SetText(agent);
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public static string getAgent(string type = "", bool multi = false)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			RestClient restClient = new RestClient("https://api.excel365.net/aiasst_full.php?");
			restClient.Timeout = 10000;
			RestRequest restRequest = new RestRequest(Method.GET);
			restRequest.AddParameter("interface", "getagent");
			if (type == "free")
			{
				restRequest.AddParameter("request_type", "free");
			}
			if (multi)
			{
				restRequest.AddParameter("request_array", "true");
			}
			try
			{
				IRestResponse restResponse = restClient.Execute(restRequest);
				if (restResponse.StatusCode == HttpStatusCode.OK)
				{
					string text = restResponse.Content.ToString().Trim();
					if (!multi)
					{
						return text.Substring(1, text.Length - 1);
					}
					return verifyAgent(text.Substring(1, text.Length - 1), type);
				}
				else
				{
					Console.WriteLine("HTTP 请求失败：" + restResponse.StatusCode);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("HTTP 请求发生异常：" + ex.Message);
			}
			return "";
		}
		
		private static string verifyAgent(string jsontext, string type)
		{
			if (jsontext == "")
			{
				return "";
			}
			string[] array = JsonConvert.DeserializeObject<string[]>(jsontext);
			int i = 0;
			while (i < array.Length)
			{
				string text = array[i];
				string text2 = text.Split(new char[]
				{
					'|'
				})[0];
				string text3 = text.Split(new char[]
				{
					'|'
				})[1];
				text3 = AesDecrypt(text3.Substring(16, text3.Length - 16), text3.Substring(0, 16));
				if (GetCredit(text2, text3) != "")
				{
					if (type == "free")
					{
						return text;
					}
					return text2;
				}
				else
				{
					i++;
				}
			}
			return "";
		}
		private static string GetCredit(string url, string apikey)
		{
			if (url.StartsWith("https"))
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			}
			RestClient restClient = new RestClient(url);
			restClient.Timeout = 5000;
			RestRequest restRequest = new RestRequest("dashboard/billing/credit_grants", Method.GET);
			string result;
			try
			{
				restRequest.AddHeader("Content-Type", "application/json");
				restRequest.AddHeader("Authorization", "Bearer " + apikey);
				IRestResponse restResponse;
				try
				{
					restResponse = restClient.Execute(restRequest);
				}
				catch (Exception)
				{
					return "";
				}
				if (restResponse.StatusCode == HttpStatusCode.OK)
				{
					result = ((JObject)JsonConvert.DeserializeObject(restResponse.Content.ToString())).GetValue("total_available").ToString().Replace("\n\n", "").Trim();
				}
				else
				{
					result = "";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("HTTP 请求发生异常：" + ex.Message);
				result = "";
			}
			return result;
		}
		public static string AesDecrypt(string inputString, string secretKey)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(secretKey);
			byte[] array = Convert.FromBase64String(inputString);
			string @string;
			using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
			{
				rijndaelManaged.Mode = CipherMode.ECB;
				rijndaelManaged.Padding = PaddingMode.PKCS7;
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.BlockSize = 128;
				rijndaelManaged.Key = bytes;
				rijndaelManaged.IV = bytes;
				byte[] bytes2 = rijndaelManaged.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
				@string = Encoding.UTF8.GetString(bytes2);
			}
			return @string;
		}
		
		public static string getPublicAPIkey(string appname)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			RestClient restClient = new RestClient("https://api.excel365.net/aiasst_full.php?");
			restClient.Timeout = 10000;
			RestRequest restRequest = new RestRequest(Method.GET);
			restRequest.AddParameter("interface", "getapikey");
			restRequest.AddParameter("appname", appname);
			IRestResponse restResponse;
			try
			{
				restResponse = restClient.Execute(restRequest);
			}
			catch (Exception)
			{
				return "";
			}
			if (restResponse.StatusCode == HttpStatusCode.OK)
			{
				string text = restResponse.Content.ToString();
				//return Functions.AesDecrypt(text.Substring(17), text.Substring(1, 16));
				return text;
			}
			return "";
		}
	}
}
