using MQTTnet;
using MQTTnet.Core;
using MQTTnet.Core.Client;
using MQTTnet.Core.Packets;
using MQTTnet.Core.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MqttClientWin
{
    public partial class FmMqttClient : Form
    {
        private MqttClient mqttClient = null;

        public FmMqttClient()
        {
            InitializeComponent();
            Task.Run(async () => { await ConnectMqttServerAsync(); });
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        private async Task ConnectMqttServerAsync()
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttClientFactory().CreateMqttClient() as MqttClient;
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;

            }
            try
            {
                var options = new MqttClientTcpOptions
                {
                    Server = "127.0.0.1",
                    //Server = "172.16.30.77",
                    ClientId = "c001",// Guid.NewGuid().ToString().Substring(0, 5),
                    UserName = "u001",
                    Password = "p001",
                    Port = 1883,
                    CleanSession = true
                };

                await mqttClient.ConnectAsync(options);
             
            }
            catch (Exception ex)
            {
                Invoke((new Action(() =>
                {
                    txtReceiveMessage.AppendText($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
                })));
            }
        }

        /// <summary>
        /// 服务器连接成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MqttClient_Connected(object sender, EventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText("已连接到MQTT服务器！" + Environment.NewLine);
            })));
        }

        /// <summary>
        /// 断开服务器连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText("已断开MQTT连接！" + Environment.NewLine);
            })));
        }

        /// <summary>
        /// 接收到消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText($">> {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}{Environment.NewLine}");
            })));
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubscribe_ClickAsync(object sender, EventArgs e)
        {
            string topic = txtSubTopic.Text.Trim();

            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("订阅主题不能为空！");
                return;
            }

            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT客户端尚未连接！");
                return;
            }

            mqttClient.SubscribeAsync(new List<TopicFilter> {
                new TopicFilter(topic, MqttQualityOfServiceLevel.AtMostOnce)
            });

            txtReceiveMessage.AppendText($"已订阅[{topic}]主题" + Environment.NewLine);
            txtSubTopic.Enabled = false;
            btnSubscribe.Enabled = false;
        }

        /// <summary>
        /// 发布主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string topic = txtPubTopic.Text.Trim();

            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("发布主题不能为空！");
                return;
            }

            string inputString = txtSendMessage.Text.Trim();
            var appMsg = new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(inputString), MqttQualityOfServiceLevel.AtMostOnce, false);
            mqttClient.PublishAsync(appMsg);
        }

        private void FmMqttClient_Load(object sender, EventArgs e)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("ClientId", "123");
            //dic.Add("Topic", "ttt");
            //dic.Add("Value", "ggyy");
            //dic.Add("ServiceLevel", "1");
            //TopicLogic.SaveTopic(dic);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mqttClient.DisconnectAsync();
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            await ConnectMqttServerAsync();
        }
    }
}