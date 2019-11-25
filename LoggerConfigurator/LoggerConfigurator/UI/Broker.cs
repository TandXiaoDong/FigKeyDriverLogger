using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using LoggerConfigurator.MQTTNet;
using MQTTnet.Protocol;
using Telerik.WinControls.UI;
using CommonUtils.Logger;
using CommonUtils.FileHelper;
using System.IO;

namespace LoggerConfigurator.UI
{
    public partial class Broker : Telerik.WinControls.UI.RadForm
    {
        private MqttNetClient mqttNetClient;
        private const string PUBLISH_TOPIC_CONFIG_DEFAULT = "topic/logger/config/defaultCFile";
        private const string PUBLISH_TOPIC_CONFIG_JSON = "topic/logger/config/jsonFile";
        private const string PUBLISH_TOPIC_CONFIG_INI = "topic/logger/config/iniFile";

        private event EventHandler receiveMsgEvent;

        public Broker(MqttNetClient mqttNetClient)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.mqttNetClient = mqttNetClient;
            EventHandlers();
        }

        private void EventHandlers()
        {
            this.Load += Broker_Load;
            this.btn_subscribe.Click += Btn_subscribe_Click;
            this.btn_publish.Click += Btn_publish_Click;
            this.btn_openFile.Click += Btn_openFile_Click;
        }

        private void Btn_openFile_Click(object sender, EventArgs e)
        {
            
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
            if(!mqttNetClient.SubscribeMessage())
                return;
        }

        private void Broker_Load(object sender, EventArgs e)
        {
            Init();
            AnalysisConfig();
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

            this.tb_publishTopic.MultiColumnComboBoxElement.Columns.Add("column1");
            this.tb_publishTopic.EditorControl.Rows.Add(PUBLISH_TOPIC_CONFIG_DEFAULT);
            this.tb_publishTopic.EditorControl.Rows.Add(PUBLISH_TOPIC_CONFIG_INI);
            this.tb_publishTopic.EditorControl.Rows.Add(PUBLISH_TOPIC_CONFIG_JSON);
            this.tb_publishTopic.SelectedIndex = 0;
            this.tb_publishTopic.EditorControl.ShowColumnHeaders = false;
            this.tb_publishTopic.AutoSizeDropDownToBestFit = true;

            if (mqttNetClient.PushFilePath == "")
                return;
            this.tb_publishPath.Text = mqttNetClient.PushFilePath;
        }

        private void AnalysisConfig()
        {
            if (!mqttNetClient.IsPublishMessage)
                return;
            //read file to show this text
            if (this.tb_publishTopic.SelectedIndex == 0)
            {
                //publish default c file
                ReadLoggerConfig();
            }
            else if (this.tb_publishTopic.SelectedIndex == 1)
            {
                //publish ini file

            }
            else if (this.tb_publishTopic.SelectedIndex == 2)
            {
                //publish json file

            }
        }

        private void ReadLoggerConfig()
        {
            if (mqttNetClient.PushFilePath == "")
                return;
            this.tb_publishMessage.Clear();
            using (FileStream fs = new FileStream(mqttNetClient.PushFilePath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        this.tb_publishMessage.Text += sr.ReadLine() + "\r\n";
                    }
                }
            }
        }

        public void Receive(string str)
        {
            //if (tb_receive.InvokeRequired)
            //{
            //    MqttNetClient.MyDeleteMsg myDeleteMsg = Receive;
            //    this.tb_receive.Invoke(myDeleteMsg, str);
            //}
            //else
            //{
            //    MqttNetClient.MyDeleteMsg myDeleteMsg = Receive;
            //    this.tb_receive.Invoke(myDeleteMsg, str);
            //}
        }
    }
}
