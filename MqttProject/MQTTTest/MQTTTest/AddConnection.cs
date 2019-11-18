using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MQTTTest.MQTTNet;

namespace MQTTTest
{
    public partial class AddConnection : Telerik.WinControls.UI.RadForm
    {
        private MqttNetClient mqttNetClient;
        private System.Timers.Timer timer;
        private int waitConnectTime;

        public AddConnection()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            Init();
            EventHandlers();
        }

        private void Init()
        {
            mqttNetClient = new MqttNetClient();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;

            this.tb_hostname.Text = "2u7682m628.wicp.vip";
            this.tb_port.Text = "51425";
        }


        private void EventHandlers()
        {
            this.Load += AddConnection_Load;
            this.btn_connect.Click += Btn_connect_Click;
            this.btn_disConnect.Click += Btn_disConnect_Click;
            this.timer.Elapsed += Timer_Elapsed;
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
            mqttNetClient.StartConnection(mqttNetClient);

            while (true)
            {
                if (mqttNetClient.IsConnectionSuccess)
                {
                    Broker broker = new Broker(mqttNetClient);
                    broker.ShowDialog();
                    break;
                }
                else
                {
                    timer.Start();
                    if (waitConnectTime == 5)
                    {
                        timer.Enabled = false;
                        waitConnectTime = 0;
                        timer.Stop();
                        break;
                    }
                }
            }
        }

        private void AddConnection_Load(object sender, EventArgs e)
        {
            
        }
    }
}
