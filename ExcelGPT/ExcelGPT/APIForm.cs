/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2023/8/15
 * 时间: 11:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;
using ExcelDna.Integration;

namespace ExcelGPT
{
	/// <summary>
	/// Description of APIForm.
	/// </summary>
	public partial class APIForm : UIForm
	{
		public APIForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			  string s = Path.GetDirectoryName(ExcelDnaUtil.XllPath);
			  
			string[] sk= File.ReadAllText(s+@"\api.txt").Split('\n');
			if (sk[0]!="") {
				textBox1.Text=sk[0];
				textBox2.Text=sk[1];
			}
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			  string s = Path.GetDirectoryName(ExcelDnaUtil.XllPath);
			  
			string txt=textBox1.Text.Trim()+"\n"+textBox2.Text.Trim();
			File.WriteAllText(s+@"\api.txt",txt);
			
			this.uiButton1.FillColor=System.Drawing.Color.Pink;
			
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/chatanywhere/GPT_API_free");
			textBox1.Text="";
			textBox2.Text="https://api.chatanywhere.com.cn/v1/chat/completions";
		}
		
		void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			textBox1.Text="pk-this-is-a-real-free-pool-token-for-everyone";
			textBox2.Text="https://ai.fakeopen.com/v1/chat/completions";
			string s = Path.GetDirectoryName(ExcelDnaUtil.XllPath);  
			string txt=textBox1.Text.Trim()+"\n"+textBox2.Text.Trim();
			File.WriteAllText(s+@"\api.txt",txt);
		}
	}
}
