using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LoggerConfigurator.MQTTNet;

namespace LoggerConfigurator.UI
{
    public partial class AddConnection : Telerik.WinControls.UI.RadForm
    {
        private MqttNetClient mqttNetClient;
        private System.Timers.Timer timer;
        private int waitConnectTime;

        public AddConnection(MqttNetClient mqttNet)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.mqttNetClient = mqttNet;
            Init();
            EventHandlers();
        }

        private void Init()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;

            this.tb_hostname.Text = "127.0.0.1";
            this.tb_port.Text = "61613";
            this.tb_password.PasswordChar = '*';
        }


        private void EventHandlers()
        {
            this.Load += AddConnection_Load;
            this.btn_connect.Click += Btn_connect_Click;
            this.btn_disConnect.Click += Btn_disConnect_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.timer.Elapsed += Timer_Elapsed;
            this.mqttNetClient.deleteSendMsgEvent += MqttNetClient_deleteSendMsgEvent;
            this.FormClosed += AddConnection_FormClosed;
        }

        private void AddConnection_FormClosed(object sender, FormClosedEventArgs e)
        {
            mqttNetClient.IsPublishMessage = false;
        }

        private void MqttNetClient_deleteSendMsgEvent(string str)
        {
            if (mqttNetClient.IsConnectionSuccess)
            {
                if (mqttNetClient.IsPublishMessage)
                {
                    Broker broker = new Broker(mqttNetClient);
                    broker.ShowDialog();
                    return;
                }
                if (MessageBox.Show("是否进入订阅主题页面？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    Broker broker = new Broker(mqttNetClient);
                    broker.ShowDialog();
                }
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            waitConnectTime++;
        }

        private void Btn_disConnect_Click(object sender, EventArgs e)
        {
            mqttNetClient.StopConnection();
        }

        private void Btn_connect_Click(object sender, EventArgs e)
        {
            if (mqttNetClient.IsConnectionSuccess)
            {
                if (this.tb_hostname.Text != mqttNetClient.ServerUrl)
                {
                    this.tb_hostname.Text = "";
                    this.tb_hostname.Focus();
                    return;
                }
                if (this.tb_port.Text != mqttNetClient.Port.ToString())
                {
                    this.tb_port.Text = "";
                    this.tb_port.Focus();
                    return;
                }
                if (this.tb_username.Text != mqttNetClient.UserID)
                {
                    this.tb_username.Text = "";
                    this.tb_username.Focus();
                    return;
                }
                if (this.tb_password.Text != mqttNetClient.PassWord)
                {
                    this.tb_password.Text = "";
                    this.tb_password.Focus();
                    return;
                }
            }
            mqttNetClient.ServerUrl = this.tb_hostname.Text;
            int port;
            if (!int.TryParse(this.tb_port.Text, out port))
            {
                MessageBox.Show("端口号格式错误！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            mqttNetClient.Port = port;
            mqttNetClient.UserID = this.tb_username.Text;
            mqttNetClient.PassWord = this.tb_password.Text;
            mqttNetClient.ServerName = this.tb_connectName.Text;

            mqttNetClient.StartConnection(mqttNetClient);
        }

        private void AddConnection_Load(object sender, EventArgs e)
        {
            
        }
    }
}
