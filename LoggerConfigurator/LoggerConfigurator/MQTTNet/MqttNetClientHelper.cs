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
    public class MqttNetClientHelper
    {
        private static MqttClient mqttClient = null;
        private static IMqttClientOptions options = null;
        private static bool runState = false;
        private static bool running = false;

        /// <summary>
        /// 服务器IP
        /// </summary>
        private static string ServerUrl = "192.168.0.110";
        /// <summary>
        /// 服务器端口
        /// </summary>
        private static int Port = 1883;
        /// <summary>
        /// 选项 - 开启登录 - 密码
        /// </summary>
        private static string Password = "admin";
        /// <summary>
        /// 选项 - 开启登录 - 用户名
        /// </summary>
        private static string UserId = "admin";
        /// <summary>
        /// 主题
        /// <para>China/Hunan/Yiyang/Nanxian</para>
        /// <para>Hotel/Room01/Tv</para>
        /// <para>Hospital/Dept01/Room001/Bed001</para>
        /// <para>Hospital/#</para>
        /// </summary>
        private static string Topic = "China/Hunan/Yiyang/Nanxian";
        /// <summary>
        /// 保留
        /// </summary>
        private static bool Retained = false;
        /// <summary>
        /// 服务质量
        /// <para>0 - 至多一次</para>
        /// <para>1 - 至少一次</para>
        /// <para>2 - 刚好一次</para>
        /// </summary>
        private static int QualityOfServiceLevel = 0;

        public static void Stop()
        {
            runState = false;
        }

        public static bool IsRun()
        {
            return (runState && running);
        }
        /// <summary>
        /// 启动客户端
        /// </summary>
        public static void Start()
        {
            try
            {
                runState = true;
                Thread thread = new Thread(new ThreadStart(Work));
                thread.Start();
            }
            catch (Exception exp)
            {
                LogHelper.Log.Info(exp.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private static void Work()
        {
            running = true;
            LogHelper.Log.Info("Work >>Begin");
            try
            {
                var factory = new MqttFactory();
                mqttClient = factory.CreateMqttClient() as MqttClient;

                options = new MqttClientOptionsBuilder()
                    .WithTcpServer(ServerUrl, Port)
                    .WithCredentials(UserId, Password)
                    .WithClientId(Guid.NewGuid().ToString().Substring(0, 5))
                    .Build();

                mqttClient.ConnectAsync(options);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(new Func<MqttClientConnectedEventArgs, Task>(Connected));
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(new Func<MqttClientDisconnectedEventArgs, Task>(Disconnected));
                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(MqttApplicationMessageReceived));
                while (runState)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
            Console.WriteLine("Work >>End");
            running = false;
            runState = false;
        }

        public static void StartMain()
        {
            try
            {
                var factory = new MqttFactory();

                var mqttClient = factory.CreateMqttClient();

                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer(ServerUrl, Port)
                    .WithCredentials(UserId, Password)
                    .WithClientId(Guid.NewGuid().ToString().Substring(0, 5))
                    .Build();

                mqttClient.ConnectAsync(options);

                mqttClient.UseConnectedHandler(async e =>
                {
                    Console.WriteLine("Connected >>Success");
                    // Subscribe to a topic
                    var topicFilterBulder = new TopicFilterBuilder().WithTopic(Topic).Build();
                    await mqttClient.SubscribeAsync(topicFilterBulder);
                    Console.WriteLine("Subscribe >>" + Topic);
                });

                mqttClient.UseDisconnectedHandler(async e =>
                {
                    Console.WriteLine("Disconnected >>Disconnected Server");
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    try
                    {
                        await mqttClient.ConnectAsync(options);
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Disconnected >>Exception" + exp.Message);
                    }
                });

                mqttClient.UseApplicationMessageReceivedHandler(e =>
                {
                    Console.WriteLine("MessageReceived >>" + Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                });
                Console.WriteLine(mqttClient.IsConnected.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine("MessageReceived >>" + exp.Message);
            }
        }

        /// <summary>
        /// 发布
        /// <paramref name="QoS"/>
        /// <para>0 - 最多一次</para>
        /// <para>1 - 至少一次</para>
        /// <para>2 - 仅一次</para>
        /// </summary>
        /// <param name="Topic">发布主题</param>
        /// <param name="Message">发布内容</param>
        /// <returns></returns>
        public static void Publish(string Topic, string Message)
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

                LogHelper.Log.Info("Publish >>Topic: " + Topic + "; QoS: " + QualityOfServiceLevel + "; Retained: " + Retained + ";");
                LogHelper.Log.Info("Publish >>Message: " + Message);
                MqttApplicationMessageBuilder mamb = new MqttApplicationMessageBuilder()
                 .WithTopic(Topic)
                 .WithPayload(Message).WithRetainFlag(Retained);
                if (QualityOfServiceLevel == 0)
                {
                    mamb = mamb.WithAtMostOnceQoS();
                }
                else if (QualityOfServiceLevel == 1)
                {
                    mamb = mamb.WithAtLeastOnceQoS();
                }
                else if (QualityOfServiceLevel == 2)
                {
                    mamb = mamb.WithExactlyOnceQoS();
                }

                mqttClient.PublishAsync(mamb.Build());
            }
            catch (Exception exp)
            {
                LogHelper.Log.Error("Publish >>" + exp.Message);
            }
        }

        /// <summary>
        /// 连接服务器并按标题订阅内容
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static async Task Connected(MqttClientConnectedEventArgs e)
        {
            try
            {
                List<TopicFilter> listTopic = new List<TopicFilter>();
                if (listTopic.Count() <= 0)
                {
                    var topicFilterBulder = new TopicFilterBuilder().WithTopic(Topic).Build();
                    listTopic.Add(topicFilterBulder);
                    LogHelper.Log.Info("Connected >>Subscribe " + Topic);
                }
                await mqttClient.SubscribeAsync(listTopic.ToArray());
                LogHelper.Log.Info("Connected >>Subscribe Success");
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
        private static void MqttApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
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
