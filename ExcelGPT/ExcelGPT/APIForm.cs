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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string txt=textBox1.Text.Trim()+"\n"+textBox2.Text.Trim();
			File.WriteAllText(@"C:\Program Files\api.txt",txt);
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/chatanywhere/GPT_API_free");
		}
	}
}
