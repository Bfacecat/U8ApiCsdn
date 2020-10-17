namespace U8ApiCsdn
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetLogin
            // 
            this.btnGetLogin.Location = new System.Drawing.Point(24, 12);
            this.btnGetLogin.Name = "btnGetLogin";
            this.btnGetLogin.Size = new System.Drawing.Size(146, 42);
            this.btnGetLogin.TabIndex = 0;
            this.btnGetLogin.Text = "获取u8登录信息";
            this.btnGetLogin.UseVisualStyleBackColor = true;
            this.btnGetLogin.Click += new System.EventHandler(this.btnGetLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 279);
            this.Controls.Add(this.btnGetLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetLogin;
    }
}

