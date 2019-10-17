namespace WinTest.cs
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_topic = new System.Windows.Forms.TextBox();
            this.tb_psContent = new System.Windows.Forms.TextBox();
            this.tb_pushTopic = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "订阅";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "发布";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_topic
            // 
            this.tb_topic.Location = new System.Drawing.Point(241, 130);
            this.tb_topic.Name = "tb_topic";
            this.tb_topic.Size = new System.Drawing.Size(100, 21);
            this.tb_topic.TabIndex = 2;
            // 
            // tb_psContent
            // 
            this.tb_psContent.Location = new System.Drawing.Point(241, 234);
            this.tb_psContent.Multiline = true;
            this.tb_psContent.Name = "tb_psContent";
            this.tb_psContent.Size = new System.Drawing.Size(205, 104);
            this.tb_psContent.TabIndex = 3;
            // 
            // tb_pushTopic
            // 
            this.tb_pushTopic.Location = new System.Drawing.Point(241, 201);
            this.tb_pushTopic.Name = "tb_pushTopic";
            this.tb_pushTopic.Size = new System.Drawing.Size(100, 21);
            this.tb_pushTopic.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(371, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb_pushTopic);
            this.Controls.Add(this.tb_psContent);
            this.Controls.Add(this.tb_topic);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb_topic;
        private System.Windows.Forms.TextBox tb_psContent;
        private System.Windows.Forms.TextBox tb_pushTopic;
        private System.Windows.Forms.Button button3;
    }
}

