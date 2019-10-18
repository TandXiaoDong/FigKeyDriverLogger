using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoggerConfigurator.MQTTNet;

namespace WinTest.cs
{
    public partial class Form1 : Form
    {
        private MqttNetClient mqttNetClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tb_topic.Text = "China/Hunan/Yiyang/Nanxian";
            this.tb_pushTopic.Text = "China/Hunan/Yiyang/Nanxian";
            this.tb_psContent.Text = "this.if.config";
            mqttNetClient = new MqttNetClient();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //订阅
            //MqttNetClientHelper.Publish();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //发布
            mqttNetClient.StartClient();
            mqttNetClient.Publish();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mqttNetClient.SubscribeMessage();
        }
    }
}
