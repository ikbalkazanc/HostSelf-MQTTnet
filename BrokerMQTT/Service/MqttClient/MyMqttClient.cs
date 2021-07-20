using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Service.MqttClient
{
    public class MyMqttClient
    {
        private IMqttFactory mqttFactory;
        private IMqttClient mqttClient;
        public MyMqttClient()
        {
            var options = new MqttClientOptionsBuilder()
    .WithClientId(Guid.NewGuid().ToString())
    .WithTcpServer("localhost",1883)
    .WithCredentials("bud", "%spencer%")
    .WithCleanSession()
    .Build();

            mqttFactory = new MqttFactory();
            mqttClient = mqttFactory.CreateMqttClient();

            mqttClient.ConnectAsync(options, CancellationToken.None);
        }


    }
}
