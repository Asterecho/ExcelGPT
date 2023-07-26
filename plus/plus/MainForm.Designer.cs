/*
 * 由SharpDevelop创建。
 * 用户： ifwz
 * 日期: 2023/5/14
 * 时间: 16:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace plus
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Sunny.UI.UILabel uiLabel1;
		private Sunny.UI.UILabel uiLabel2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox textBox1;
		private Sunny.UI.UIButton uiButton1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
			this.uiLabel1 = new Sunny.UI.UILabel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.uiButton1 = new Sunny.UI.UIButton();
			this.uiLabel2 = new Sunny.UI.UILabel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(2, 36);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.webView21);
			this.splitContainer1.Panel1.Controls.Add(this.uiLabel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Controls.Add(this.uiLabel2);
			this.splitContainer1.Size = new System.Drawing.Size(737, 418);
			this.splitContainer1.SplitterDistance = 302;
			this.splitContainer1.TabIndex = 0;
			// 
			// webView21
			// 
			this.webView21.AllowExternalDrop = true;
			this.webView21.CreationProperties = null;
			this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
			this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView21.Location = new System.Drawing.Point(0, 29);
			this.webView21.Name = "webView21";
			this.webView21.Size = new System.Drawing.Size(737, 273);
			this.webView21.Source = new System.Uri("https://www.bilibili.com/", System.UriKind.Absolute);
			this.webView21.TabIndex = 1;
			this.webView21.ZoomFactor = 1D;
			//this.webView21.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView21CoreWebView2InitializationCompleted);
			// 
			// uiLabel1
			// 
			this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiLabel1.Location = new System.Drawing.Point(0, 0);
			this.uiLabel1.Name = "uiLabel1";
			this.uiLabel1.Size = new System.Drawing.Size(737, 29);
			this.uiLabel1.TabIndex = 0;
			this.uiLabel1.Text = "AI回答";
			this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 39);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.textBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.uiButton1);
			this.splitContainer2.Size = new System.Drawing.Size(737, 73);
			this.splitContainer2.SplitterDistance = 648;
			this.splitContainer2.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(648, 73);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "随机生成数字，用python绘制散点图";
			// 
			// uiButton1
			// 
			this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.uiButton1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiButton1.Location = new System.Drawing.Point(0, 0);
			this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
			this.uiButton1.Name = "uiButton1";
			this.uiButton1.Size = new System.Drawing.Size(85, 73);
			this.uiButton1.TabIndex = 0;
			this.uiButton1.Text = "Ask";
			this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.uiButton1.Click += new System.EventHandler(this.UiButton1Click);
			// 
			// uiLabel2
			// 
			this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.uiLabel2.Location = new System.Drawing.Point(0, 0);
			this.uiLabel2.Name = "uiLabel2";
			this.uiLabel2.Size = new System.Drawing.Size(737, 39);
			this.uiLabel2.TabIndex = 0;
			this.uiLabel2.Text = "提问";
			this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(741, 456);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
			this.ShowDragStretch = true;
			this.ShowInTaskbar = false;
			this.ShowRadius = false;
			this.Text = "AI交互";
			this.TopMost = true;
			this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 708, 321);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
}
}