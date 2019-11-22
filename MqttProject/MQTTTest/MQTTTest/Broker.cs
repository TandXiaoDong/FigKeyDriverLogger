using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MQTTTest.MQTTNet;
using MQTTnet.Protocol;
using Telerik.WinControls.UI;
using CommonUtils.Logger;

namespace MQTTTest
{
    public partial class Broker : Telerik.WinControls.UI.RadForm
    {
        private MqttNetClient mqttNetClient;

        private event EventHandler receiveMsgEvent;

        public Broker(MqttNetClient mqttNetClient)
        {
            InitializeComponent();
            
            this.mqttNetClient = mqttNetClient;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            EventHandlers();
        }

        private void EventHandlers()
        {
            this.Load += Broker_Load;
            this.btn_subscribe.Click += Btn_subscribe_Click;
            this.btn_publish.Click += Btn_publish_Click;
        }

        private void Btn_publish_Click(object sender, EventArgs e)
        {
            var publishTopic = this.tb_publishTopic.Text.Trim();
            var publishMessage = this.tb_publishMessage.Text.Trim();
            mqttNetClient.Publish(publishTopic,publishMessage);
        }

        private void Btn_subscribe_Click(object sender, EventArgs e)
        {
            var subscribe = this.tb_subscribe.Text;
            var subscribeLevel = this.cb_subscribe_level.Text;
            MqttQualityOfServiceLevel levelEnum;
            Enum.TryParse(this.cb_subscribe_level.SelectedIndex.ToString(),out levelEnum);
            mqttNetClient.Topic = new List<string>();
            mqttNetClient.Topic.Add(subscribe);
            mqttNetClient.MqttQualityLevel = levelEnum;
        }

        private void Broker_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            ////AtMostOnce/AtLeastOnce/ExactlyOnce
            this.cb_subscribe_level.MultiColumnComboBoxElement.Columns.Add("data");
            this.cb_subscribe_level.EditorControl.Rows.Add("0-AtMostOnce");
            this.cb_subscribe_level.EditorControl.Rows.Add("1-AtLeastOnce");
            this.cb_subscribe_level.EditorControl.Rows.Add("2-ExactlyOnce");
            this.cb_subscribe_level.SelectedIndex = 0;
            this.cb_subscribe_level.EditorControl.ShowColumnHeaders = false;
            this.cb_subscribe_level.BestFitColumns();

            this.cb_publish_level.MultiColumnComboBoxElement.Columns.Add("data");
            this.cb_publish_level.EditorControl.Rows.Add("0-AtMostOnce");
            this.cb_publish_level.EditorControl.Rows.Add("1-AtLeastOnce");
            this.cb_publish_level.EditorControl.Rows.Add("2-ExactlyOnce");
            this.cb_publish_level.SelectedIndex = 0;
            this.cb_publish_level.EditorControl.ShowColumnHeaders = false;
            this.cb_publish_level.BestFitColumns();
        }

        public void Receive(string str)
        {
            if (tb_receiveMsg.InvokeRequired)
            {
                MqttNetClient.MyDeleteMsg myDeleteMsg = Receive;
                this.tb_receiveMsg.Invoke(myDeleteMsg,str);
            }
            else
            {
                MqttNetClient.MyDeleteMsg myDeleteMsg = Receive;
                this.tb_receiveMsg.Invoke(myDeleteMsg, str);
            }
        }
    }
}
