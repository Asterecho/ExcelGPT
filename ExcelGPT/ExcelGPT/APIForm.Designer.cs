/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2023/8/15
 * 时间: 11:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace ExcelGPT
{
	partial class APIForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private Sunny.UI.UIButton uiButton1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		
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
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uiButton1 = new Sunny.UI.UIButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(1, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 22);
			this.label2.TabIndex = 9;
			this.label2.Text = "代理";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(80, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(316, 21);
			this.textBox2.TabIndex = 8;
			this.textBox2.Text = "https://openai.api2d.net/v1/chat/completions";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(1, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 22);
			this.label1.TabIndex = 7;
			this.label1.Text = "API Key";
			// 
			// button1
			// 
			this.uiButton1.Location = new System.Drawing.Point(131, 120);
			this.uiButton1.Name = "button1";
			this.uiButton1.Size = new System.Drawing.Size(120, 35);
			this.uiButton1.TabIndex = 6;
			this.uiButton1.Text = "提交";
			 
			this.uiButton1.Click += new System.EventHandler(this.Button1Click);
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point(10, 120);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(75, 29);
			this.linkLabel2.TabIndex = 10;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "pandora";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2LinkClicked);
			
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 15);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(316, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "fk186214-zJDvkFCBInfcc6p9VBQfF6rq7iGSAYsm|ck265-cddc746";
			this.toolTip1.SetToolTip(this.textBox1, "这是测试key，如果不能用，请点击右下角，注册github账号，申请免费api key\r\n");
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(314, 120);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(79, 29);
			this.linkLabel1.TabIndex = 10;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "申请key";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
			// 
			// APIForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 180);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.uiButton1);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "APIForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "输入密钥和代理";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
