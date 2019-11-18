namespace MQTTTest
{
    partial class Broker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_subscribe = new Telerik.WinControls.UI.RadTextBox();
            this.cb_subscribe_level = new System.Windows.Forms.ComboBox();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.btn_subscribe = new Telerik.WinControls.UI.RadButton();
            this.btn_publish = new Telerik.WinControls.UI.RadButton();
            this.cb_publish_level = new System.Windows.Forms.ComboBox();
            this.tb_publishTopic = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.tb_publishMessage = new Telerik.WinControls.UI.RadTextBox();
            this.tb_publishPath = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.btn_openFile = new Telerik.WinControls.UI.RadButton();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radCollapsiblePanel1 = new Telerik.WinControls.UI.RadCollapsiblePanel();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subscribe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_subscribe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_publish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishTopic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_openFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).BeginInit();
            this.radCollapsiblePanel1.PanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(97, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Connection：";
            this.radLabel1.ThemeName = "Material";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(115, 12);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(68, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "mybroker";
            this.radLabel3.ThemeName = "Material";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 53);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(72, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Subscribe";
            this.radLabel2.ThemeName = "Material";
            // 
            // tb_subscribe
            // 
            this.tb_subscribe.Location = new System.Drawing.Point(12, 80);
            this.tb_subscribe.Name = "tb_subscribe";
            this.tb_subscribe.Size = new System.Drawing.Size(504, 36);
            this.tb_subscribe.TabIndex = 4;
            this.tb_subscribe.Text = "#";
            this.tb_subscribe.ThemeName = "Material";
            // 
            // cb_subscribe_level
            // 
            this.cb_subscribe_level.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_subscribe_level.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_subscribe_level.FormattingEnabled = true;
            this.cb_subscribe_level.ItemHeight = 25;
            this.cb_subscribe_level.Location = new System.Drawing.Point(522, 83);
            this.cb_subscribe_level.Name = "cb_subscribe_level";
            this.cb_subscribe_level.Size = new System.Drawing.Size(151, 33);
            this.cb_subscribe_level.TabIndex = 5;
            // 
            // btn_subscribe
            // 
            this.btn_subscribe.Location = new System.Drawing.Point(679, 83);
            this.btn_subscribe.Name = "btn_subscribe";
            this.btn_subscribe.Size = new System.Drawing.Size(92, 33);
            this.btn_subscribe.TabIndex = 6;
            this.btn_subscribe.Text = "SUBSCRIBE";
            this.btn_subscribe.ThemeName = "Breeze";
            // 
            // btn_publish
            // 
            this.btn_publish.Location = new System.Drawing.Point(679, 170);
            this.btn_publish.Name = "btn_publish";
            this.btn_publish.Size = new System.Drawing.Size(92, 33);
            this.btn_publish.TabIndex = 10;
            this.btn_publish.Text = "PUBLISH";
            this.btn_publish.ThemeName = "Breeze";
            // 
            // cb_publish_level
            // 
            this.cb_publish_level.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_publish_level.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_publish_level.FormattingEnabled = true;
            this.cb_publish_level.ItemHeight = 25;
            this.cb_publish_level.Location = new System.Drawing.Point(522, 170);
            this.cb_publish_level.Name = "cb_publish_level";
            this.cb_publish_level.Size = new System.Drawing.Size(151, 33);
            this.cb_publish_level.TabIndex = 9;
            // 
            // tb_publishTopic
            // 
            this.tb_publishTopic.Location = new System.Drawing.Point(12, 167);
            this.tb_publishTopic.Name = "tb_publishTopic";
            this.tb_publishTopic.Size = new System.Drawing.Size(504, 36);
            this.tb_publishTopic.TabIndex = 8;
            this.tb_publishTopic.Text = "topic";
            this.tb_publishTopic.ThemeName = "Material";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 140);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(55, 21);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Publish";
            this.radLabel4.ThemeName = "Material";
            // 
            // tb_publishMessage
            // 
            this.tb_publishMessage.AutoScroll = true;
            this.tb_publishMessage.Location = new System.Drawing.Point(12, 313);
            this.tb_publishMessage.Multiline = true;
            this.tb_publishMessage.Name = "tb_publishMessage";
            // 
            // 
            // 
            this.tb_publishMessage.RootElement.StretchVertically = true;
            this.tb_publishMessage.Size = new System.Drawing.Size(759, 138);
            this.tb_publishMessage.TabIndex = 11;
            this.tb_publishMessage.Text = "message";
            this.tb_publishMessage.ThemeName = "Material";
            // 
            // tb_publishPath
            // 
            this.tb_publishPath.Location = new System.Drawing.Point(12, 257);
            this.tb_publishPath.Name = "tb_publishPath";
            this.tb_publishPath.Size = new System.Drawing.Size(661, 36);
            this.tb_publishPath.TabIndex = 14;
            this.tb_publishPath.Text = "path";
            this.tb_publishPath.ThemeName = "Material";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(12, 230);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(64, 21);
            this.radLabel5.TabIndex = 13;
            this.radLabel5.Text = "File Path";
            this.radLabel5.ThemeName = "Material";
            // 
            // btn_openFile
            // 
            this.btn_openFile.Location = new System.Drawing.Point(679, 260);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(92, 33);
            this.btn_openFile.TabIndex = 15;
            this.btn_openFile.Text = "OpenFile";
            this.btn_openFile.ThemeName = "Breeze";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(12, 471);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(79, 21);
            this.radLabel6.TabIndex = 16;
            this.radLabel6.Text = "Subscribes";
            this.radLabel6.ThemeName = "Material";
            // 
            // radCollapsiblePanel1
            // 
            this.radCollapsiblePanel1.Location = new System.Drawing.Point(12, 498);
            this.radCollapsiblePanel1.Name = "radCollapsiblePanel1";
            // 
            // radCollapsiblePanel1.PanelContainer
            // 
            this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radTextBox1);
            this.radCollapsiblePanel1.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radCollapsiblePanel1.PanelContainer.Size = new System.Drawing.Size(759, 87);
            this.radCollapsiblePanel1.Size = new System.Drawing.Size(759, 110);
            this.radCollapsiblePanel1.TabIndex = 1;
            this.radCollapsiblePanel1.ThemeName = "Material";
            // 
            // radTextBox1
            // 
            this.radTextBox1.AutoScroll = true;
            this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBox1.Location = new System.Drawing.Point(0, 0);
            this.radTextBox1.Multiline = true;
            this.radTextBox1.Name = "radTextBox1";
            // 
            // 
            // 
            this.radTextBox1.RootElement.StretchVertically = true;
            this.radTextBox1.Size = new System.Drawing.Size(759, 87);
            this.radTextBox1.TabIndex = 12;
            this.radTextBox1.Text = "message";
            this.radTextBox1.ThemeName = "Material";
            // 
            // Broker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(781, 648);
            this.Controls.Add(this.radCollapsiblePanel1);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.tb_publishPath);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.tb_publishMessage);
            this.Controls.Add(this.btn_publish);
            this.Controls.Add(this.cb_publish_level);
            this.Controls.Add(this.tb_publishTopic);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.btn_subscribe);
            this.Controls.Add(this.cb_subscribe_level);
            this.Controls.Add(this.tb_subscribe);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Name = "Broker";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Broker";
            this.ThemeName = "Material";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subscribe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_subscribe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_publish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishTopic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_publishPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_openFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.radCollapsiblePanel1.PanelContainer.ResumeLayout(false);
            this.radCollapsiblePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tb_subscribe;
        private System.Windows.Forms.ComboBox cb_subscribe_level;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton btn_subscribe;
        private Telerik.WinControls.UI.RadButton btn_publish;
        private System.Windows.Forms.ComboBox cb_publish_level;
        private Telerik.WinControls.UI.RadTextBox tb_publishTopic;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox tb_publishMessage;
        private Telerik.WinControls.UI.RadTextBox tb_publishPath;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadButton btn_openFile;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadCollapsiblePanel radCollapsiblePanel1;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadTextBox radTextBox1;
    }
}
