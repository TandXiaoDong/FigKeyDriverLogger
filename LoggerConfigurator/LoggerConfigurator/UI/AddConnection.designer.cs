namespace LoggerConfigurator.UI
{
    partial class AddConnection
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
            this.tb_connectName = new Telerik.WinControls.UI.RadTextBox();
            this.tb_hostname = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_port = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tb_username = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.tb_password = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.btn_connect = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.btn_disConnect = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_connectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_hostname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_disConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(30, 47);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(121, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Connection name";
            this.radLabel1.ThemeName = "Material";
            // 
            // tb_connectName
            // 
            this.tb_connectName.BackColor = System.Drawing.Color.White;
            this.tb_connectName.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_connectName.Location = new System.Drawing.Point(30, 74);
            this.tb_connectName.Name = "tb_connectName";
            // 
            // 
            // 
            this.tb_connectName.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tb_connectName.Size = new System.Drawing.Size(554, 38);
            this.tb_connectName.TabIndex = 2;
            this.tb_connectName.Text = "mybroker";
            this.tb_connectName.ThemeName = "Material";
            // 
            // tb_hostname
            // 
            this.tb_hostname.BackColor = System.Drawing.Color.White;
            this.tb_hostname.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_hostname.Location = new System.Drawing.Point(31, 185);
            this.tb_hostname.Name = "tb_hostname";
            // 
            // 
            // 
            this.tb_hostname.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tb_hostname.Size = new System.Drawing.Size(268, 38);
            this.tb_hostname.TabIndex = 4;
            this.tb_hostname.Text = "127.0.0.1";
            this.tb_hostname.ThemeName = "Material";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(31, 158);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(74, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Hostname";
            this.radLabel2.ThemeName = "Material";
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.White;
            this.tb_port.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_port.Location = new System.Drawing.Point(305, 186);
            this.tb_port.Name = "tb_port";
            // 
            // 
            // 
            this.tb_port.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tb_port.Size = new System.Drawing.Size(279, 38);
            this.tb_port.TabIndex = 7;
            this.tb_port.Text = "61613";
            this.tb_port.ThemeName = "Material";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(305, 158);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(34, 21);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Port";
            this.radLabel3.ThemeName = "Material";
            // 
            // tb_username
            // 
            this.tb_username.BackColor = System.Drawing.Color.White;
            this.tb_username.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_username.Location = new System.Drawing.Point(30, 303);
            this.tb_username.Name = "tb_username";
            // 
            // 
            // 
            this.tb_username.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tb_username.Size = new System.Drawing.Size(268, 38);
            this.tb_username.TabIndex = 11;
            this.tb_username.Text = "admin";
            this.tb_username.ThemeName = "Material";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(30, 276);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(73, 21);
            this.radLabel5.TabIndex = 10;
            this.radLabel5.Text = "Username";
            this.radLabel5.ThemeName = "Material";
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.White;
            this.tb_password.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_password.Location = new System.Drawing.Point(304, 303);
            this.tb_password.Name = "tb_password";
            // 
            // 
            // 
            this.tb_password.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tb_password.Size = new System.Drawing.Size(279, 38);
            this.tb_password.TabIndex = 13;
            this.tb_password.Text = "password";
            this.tb_password.ThemeName = "Material";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(304, 276);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(71, 21);
            this.radLabel6.TabIndex = 12;
            this.radLabel6.Text = "Password";
            this.radLabel6.ThemeName = "Material";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(282, 393);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(133, 33);
            this.btn_connect.TabIndex = 14;
            this.btn_connect.Text = "Create Connection";
            this.btn_connect.ThemeName = "Breeze";
            // 
            // btn_disConnect
            // 
            this.btn_disConnect.Location = new System.Drawing.Point(31, 393);
            this.btn_disConnect.Name = "btn_disConnect";
            this.btn_disConnect.Size = new System.Drawing.Size(133, 33);
            this.btn_disConnect.TabIndex = 15;
            this.btn_disConnect.Text = "DisConnection";
            this.btn_disConnect.ThemeName = "Breeze";
            this.btn_disConnect.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(451, 393);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(133, 33);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "Cancel Connection";
            this.btn_cancel.ThemeName = "Breeze";
            // 
            // AddConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(594, 445);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_disConnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.tb_hostname);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.tb_connectName);
            this.Controls.Add(this.radLabel1);
            this.Name = "AddConnection";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "AddConnection";
            this.ThemeName = "Material";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_connectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_hostname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_disConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tb_connectName;
        private Telerik.WinControls.UI.RadTextBox tb_hostname;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tb_port;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tb_username;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox tb_password;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadButton btn_connect;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton btn_disConnect;
        private Telerik.WinControls.UI.RadButton btn_cancel;
    }
}
