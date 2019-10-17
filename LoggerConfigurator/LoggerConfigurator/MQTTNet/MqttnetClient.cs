using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using MQTTnet;
using CommonUtils.Logger;

namespace LoggerConfigurator.MQTTNet
{
    public class MqttnetClient
    {
        private static IMqttClient mqttClient;

        public MqttnetClient()
        {

        }
        public static async Task StartRunAsync()
        {
            try
            {
                var factory = new MqttFactory();
                mqttClient = factory.CreateMqttClient();
                var clientOptions = new MqttClientOptions
                {
                    ClientId = "abc001",
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        Server = "127.0.0.1"
                    }
                };

                //接受消息
                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
                {
                    LogHelper.Log.Info("### RECEIVED APPLICATION MESSAGE ###");
                    LogHelper.Log.Info($"+ Topic = {e.ApplicationMessage.Topic}");
                    LogHelper.Log.Info($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    LogHelper.Log.Info($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    LogHelper.Log.Info($"+ Retain = {e.ApplicationMessage.Retain}");
                });

                //连接
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(async e =>
                {
                    LogHelper.Log.Info("###【成功连接服务】 CONNECTED WITH SERVER ###");
                    //订阅所有
                    //await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("#").Build());

                    //LogHelper.Log.Info("### SUBSCRIBED ###");
                });

                //断开连接
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(async e =>
                {
                    LogHelper.Log.Info("### DISCONNECTED FROM SERVER ###");
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    try
                    {
                        await mqttClient.ConnectAsync(clientOptions);
                        LogHelper.Log.Info("### START RECONNECTING SERVER...");
                    }
                    catch
                    {
                        LogHelper.Log.Info("### RECONNECTING FAILED ###");
                    }
                });

                try
                {
                    await mqttClient.ConnectAsync(clientOptions);
                }
                catch (Exception exception)
                {
                    LogHelper.Log.Info("### CONNECTING SERVER FAILED ###" + Environment.NewLine + exception);
                }

                LogHelper.Log.Info("### WAITING FOR APPLICATION MESSAGES ###");
            }
            catch (Exception exception)
            {
                LogHelper.Log.Info(exception);
            }
        }

        async public static void SubscribeMessage(string topic)
        {
            await mqttClient.SubscribeAsync(new TopicFilter {
                Topic = topic, QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce
            });
        }

        async public static void PushMessage(string topic,string payload)
        {
            var appMsg = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(payload).WithAtLeastOnceQoS().Build();

            await mqttClient.PublishAsync(appMsg);
        }
    }
}
