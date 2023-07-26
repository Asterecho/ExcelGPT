using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Web.WebView2;

namespace ExcelGPT
{
    /// <summary>
    /// 任务窗格使用的自定义窗体控件
    /// </summary>
    [ComVisible(true)]    
    public class CTPControls : UserControl
    {
        //所有的CTP都用同一个字典记录User,在ServerManager中的DicClientIDName

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SplitContainer splitContainer1;
         
        public CTPControls()
        {
            InitializeComponent();

            this.Disposed += CTPControls_Disposed;
        }

        private void CTPControls_Disposed(object sender, EventArgs e)
        {
            
        }


//        private void DelegateOutputMessage(string Message,bool newline=true)
//        {
//            Invoke(new MethodInvoker(delegate ()
//            {
//                if (RtbMsg != null && RtbMsg.IsHandleCreated)
//                {
//                    if (newline) Message += Environment.NewLine;
//                    RtbMsg.AppendText(Message);                    
//                    RtbMsg.ScrollToCaret();
//                }
//            }));
//        }

        private void InitializeComponent()
        {
            
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
			this.SuspendLayout();
            // 
			// webView21
			// 
			this.webView21.AllowExternalDrop = true;
			this.webView21.CreationProperties = null;
			this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
			this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView21.Location = new System.Drawing.Point(0, 0);
			this.webView21.Name = "webView21";
			this.webView21.Size = new System.Drawing.Size(569, 329);
			this.webView21.Source = new System.Uri("http://localhost:8888", System.UriKind.Absolute);
			this.webView21.TabIndex = 0;
			this.webView21.ZoomFactor = 1D;
			this.webView21.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView21CoreWebView2InitializationCompleted);
             
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			this.splitContainer1.Size = new System.Drawing.Size(518, 32);
			this.splitContainer1.SplitterDistance = 448;
			this.splitContainer1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(66, 32);
			this.button1.TabIndex = 2;
			this.button1.Text = "Go";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(448, 29);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "http://localhost:8888";
			// 
			// webView21
			// 
//			this.webView21.AllowExternalDrop = true;
//			this.webView21.CreationProperties = null;
//			this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
//			this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
//			this.webView21.Location = new System.Drawing.Point(0, 32);
//			this.webView21.Name = "webView21";
//			this.webView21.Size = new System.Drawing.Size(518, 274);
//			this.webView21.TabIndex = 3;
//			this.webView21.ZoomFactor = 1D;
            // 
            // CTPControls
            // 
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.splitContainer1);
             ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
			this.ResumeLayout(false);
			
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			
            this.Name = "CTPControls";
            this.Size = new System.Drawing.Size(258, 600);
            this.ResumeLayout(false);
            this.PerformLayout();
           

        }
        //https://stackoverflow.com/questions/71145934/embedding-webview2-dll-into-wpf-portable-executable
        private void CoreWebView2_NewWindowRequested(object sender,Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
             e.NewWindow = webView21.CoreWebView2;
//            webView21.Source = new Uri(e.Uri.ToString());
//            e.Handled = true;//禁止弹窗  两种方法均可
 
        }
		void WebView21CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
		{
			 webView21.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (webView21 != null && webView21.CoreWebView2 != null)
		    {
				webView21.CoreWebView2.Navigate(textBox1.Text.Trim());
		    }
		}
    }
}
