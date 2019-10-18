using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Connecting;
using CommonUtils.Logger;


namespace LoggerConfigurator.MQTTNet
{
    public class MqttNetClient
    {
        #region mqtt 参数
        private static MqttClient mqttClient = null;
        private static IMqttClientOptions options = null;

        /// <summary>
        /// 服务器IP
        /// </summary>
        private string serverUrl = "192.168.0.110";
        /// <summary>
        /// 服务器端口
        /// </summary>
        private int port = 61613;//1883;
        /// <summary>
        /// 选项 - 开启登录 - 密码
        /// </summary>
        private string passWord = "admin";
        /// <summary>
        /// 选项 - 开启登录 - 用户名
        /// </summary>
        private string userId = "admin";
        /// <summary>
        /// 主题
        /// </summary>
        private List<string> topic;
        /// <summary>
        /// 保留
        /// </summary>
        private bool retained = false;
        /// <summary>
        /// 服务质量
        /// <para>0 - 至多一次</para>
        /// <para>1 - 至少一次</para>
        /// <para>2 - 刚好一次</para>
        /// </summary>
        private MqttQualityOfServiceLevel mqttQualityLevel =  MqttQualityOfServiceLevel.AtMostOnce;

        private string mqttServerTopicDirectory = "public/logger/server/deviceID/directory";
        private string mqttServerTopicConfigFile = "public/logger/server/deviceID/sourchFile";

        private string mqttClientTopicCommand = "public/logger/client/deviceID/command";
        private string mqttClientTopicDirectory = "public/logger/client/deviceID/directory";
        private string mqttClientTopicConfigFile = "public/logger/client/deviceID/sourchFile";


        public string ServerUrl
        {
            get { return this.serverUrl; }
            set { this.serverUrl = value; }
        }

        public int Port
        {
            get { return this.port; }
            set { this.port = value; }
        }

        public string PassWord
        {
            get { return this.passWord; }
            set { this.passWord = value; }
        }

        public string UserID
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public List<string> Topic
        {
            get { return this.topic; }
            set { this.topic = value; }
        }

        public MqttQualityOfServiceLevel MqttQualityLevel
        {
            get { return this.mqttQualityLevel; }
            set { this.mqttQualityLevel = value; }
        }

        public bool Remain
        {
            get { return this.retained; }
            set { this.retained = value; }
        }

        /// <summary>
        /// 字符串消息
        /// </summary>
        public string PushMessageString { get; set; }

        /// <summary>
        /// byte消息
        /// </summary>
        public byte[] PushMessageByte { get; set; }
        #endregion

        /// <summary>
        /// 启动客户端，连接服务
        /// </summary>
        public void StartClient()
        {
            LogHelper.Log.Info("Work >>Begin");
            try
            {
                var factory = new MqttFactory();
                mqttClient = factory.CreateMqttClient() as MqttClient;

                options = new MqttClientOptionsBuilder()
                    .WithTcpServer(ServerUrl, Port)
                    .WithCredentials(UserID, PassWord)
                    .WithClientId(Guid.NewGuid().ToString().Substring(0, 5))
                    .Build();

                mqttClient.ConnectAsync(options);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(new Func<MqttClientConnectedEventArgs, Task>(Connected));
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(new Func<MqttClientDisconnectedEventArgs, Task>(Disconnected));
                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(MqttApplicationMessageReceived));
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error(exp.Message);
            }
            LogHelper.Log.Info("Work >>End");
        }

        /// <summary>
        /// 发布消息-字符串
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        async public void Publish(string topic, string message)
        {
            try
            {
                if (mqttClient == null) return;
                if (mqttClient.IsConnected == false)
                    await mqttClient.ConnectAsync(options);

                if (mqttClient.IsConnected == false)
                {
                    LogHelper.Log.Info("Publish >>Connected Failed! ");
                    return;
                }

                if (MqttQualityLevel == MqttQualityOfServiceLevel.AtMostOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(topic)
                        .WithPayload(message)
                        .WithRetainFlag(Remain)
                        .WithAtMostOnceQoS()
                        .Build();
                    await mqttClient.PublishAsync(mamb);
                }
                else if (MqttQualityLevel == MqttQualityOfServiceLevel.AtLeastOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(topic)
                        .WithPayload(message)
                        .WithRetainFlag(Remain)
                        .WithAtLeastOnceQoS()
                        .Build();
                    mqttClient.PublishAsync(mamb);
                }
                else if (MqttQualityLevel == MqttQualityOfServiceLevel.ExactlyOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(topic)
                        .WithPayload(message)
                        .WithRetainFlag(retained)
                        .WithExactlyOnceQoS()
                        .Build();
                    mqttClient.PublishAsync(mamb);
                }
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error("Publish >>" + exp.Message);
            }
        }

        /// <summary>
        /// 发布消息-二进制
        /// </summary>
        /// <param name="Topic"></param>
        /// <param name="byteMsg"></param>
        async public void Publish(string Topic, byte[] byteMsg)
        {
            try
            {
                if (mqttClient == null) return;
                if (mqttClient.IsConnected == false)
                    mqttClient.ConnectAsync(options);

                if (mqttClient.IsConnected == false)
                {
                    LogHelper.Log.Info("Publish >>Connected Failed! ");
                    return;
                }
                if (MqttQualityLevel == MqttQualityOfServiceLevel.AtMostOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(Topic)
                        .WithPayload(byteMsg)
                        .WithRetainFlag(Remain)
                        .WithAtMostOnceQoS()
                        .Build();
                    mqttClient.PublishAsync(mamb);
                }
                else if (MqttQualityLevel ==  MqttQualityOfServiceLevel.AtLeastOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(Topic)
                        .WithPayload(byteMsg)
                        .WithRetainFlag(Remain)
                        .WithAtLeastOnceQoS()
                        .Build();
                    mqttClient.PublishAsync(mamb);
                }
                else if (MqttQualityLevel == MqttQualityOfServiceLevel.ExactlyOnce)
                {
                    var mamb = new MqttApplicationMessageBuilder()
                        .WithTopic(Topic)
                        .WithPayload(byteMsg)
                        .WithRetainFlag(Remain)
                        .WithExactlyOnceQoS()
                        .Build();
                    mqttClient.PublishAsync(mamb);
                }
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error("Publish >>" + exp.Message);
            }
        }
        
        /// <summary>
        /// 订阅主题
        /// </summary>
        /// <param name="topic"></param>
        async public void SubscribeMessage()
        {
            try
            {
                if (mqttClient == null)
                    return;
                if (mqttClient.IsConnected == false)
                    await mqttClient.ConnectAsync(options);

                if (mqttClient.IsConnected == false)
                {
                    LogHelper.Log.Info("Publish >>Connected Failed! ");
                    return;
                }
                List<TopicFilter> listTopic = new List<TopicFilter>();
                if (Topic.Count() > 0)
                {
                    foreach (var topic in Topic)
                    {
                        if (MqttQualityLevel ==  MqttQualityOfServiceLevel.AtMostOnce)
                        {
                            var topicFilterBuilder = new TopicFilterBuilder().WithTopic(topic)
                                .WithAtMostOnceQoS().Build();
                            listTopic.Add(topicFilterBuilder);
                        }
                        else if (MqttQualityLevel ==  MqttQualityOfServiceLevel.AtLeastOnce)
                        {
                            var topicFilterBuilder = new TopicFilterBuilder().WithTopic(topic)
                                .WithAtLeastOnceQoS().Build();
                            listTopic.Add(topicFilterBuilder);
                        }
                        else if (MqttQualityLevel ==  MqttQualityOfServiceLevel.ExactlyOnce)
                        {
                            var topicFilterBuilder = new TopicFilterBuilder().WithTopic(topic)
                                .WithExactlyOnceQoS().Build();
                            listTopic.Add(topicFilterBuilder);
                        }
                    }
                }
                await mqttClient.SubscribeAsync(listTopic.ToArray());
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error("Subscrible >>" + exp.Message);
            }
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static async Task Connected(MqttClientConnectedEventArgs e)
        {
            try
            {
                LogHelper.Log.Info("Connected >>Success");
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error(exp.Message);
            }
        }

        /// <summary>
        /// 失去连接触发事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static async Task Disconnected(MqttClientDisconnectedEventArgs e)
        {
            try
            {
                LogHelper.Log.Info("Disconnected >>Disconnected Server");
                await Task.Delay(TimeSpan.FromSeconds(5));
                try
                {
                    await mqttClient.ConnectAsync(options);
                }
                catch (Exception exp)
                {
                    LogHelper.Log.Error("Disconnected >>Exception " + exp.Message);
                }
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error(exp.Message);
            }
        }

        /// <summary>
        /// 接收消息触发事件
        /// </summary>
        /// <param name="e"></param>
        private void MqttApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                string text = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string Topic = e.ApplicationMessage.Topic;
                string QoS = e.ApplicationMessage.QualityOfServiceLevel.ToString();
                string Retained = e.ApplicationMessage.Retain.ToString();
                LogHelper.Log.Info("MessageReceived >>Topic:" + Topic + "; QoS: " + QoS + "; Retained: " + Retained + ";");
                LogHelper.Log.Info("MessageReceived >>Msg: " + text);
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error(exp.Message);
            }
        }


        /*
         * 1）上位机接受来自设备消息
         * 2）上位机发送给各个设备消息
         * topic定义：
         * 1）上位机
         *  接收消息：需订阅设备主题，设备端主题格式-设备ID/config,
         *  如：
         *  public/logger/configurator/deviceID/directory  接受来自设备发送的目录内容
         *  public/logger/configurator/deviceID/sourchFile 接收来自设备发送的配置文件内容
         *  发送消息：主题格式-clientID(固定ID)，
         *  如：
         *  public/logger/configurator/#+deviceID/params  + 参数内容   要修改某一设备的参数
         *  public/logger/configurator/#+deviceID/directory + 空内容   要获取某一设备的配置文件目录
         *  public/logger/configurator/#+deviceID/sourchFile + 路径    要获取某一设备下某一路径的配置文件内容
         * 2）设备：
         *  接受消息：
         *  发送消息：
         */ 
    }
}
