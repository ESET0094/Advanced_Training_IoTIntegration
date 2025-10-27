using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;

namespace MQTT_Pub_Sub
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new MqttFactory();
            var mqtt = factory.CreateManagedMqttClient();

            var options = new MqttClientOptionsBuilder()
                 .WithClientId("abcd")
                 .WithCredentials("user1","new")
                 .WithTcpServer("localhost", 1883)
                 .WithCleanSession(false)
                 .Build();
            var mangagedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(options)
                .Build();
         
            mqtt.ApplicationMessageReceivedAsync += async e =>
            {
                Console.WriteLine($"Received: {e.ApplicationMessage.Topic} - {e.ApplicationMessage.ConvertPayloadToString()}");


            };
            await mqtt.StartAsync(mangagedOptions);

            await mqtt.SubscribeAsync(new[]
            {
                new MqttTopicFilterBuilder()
                .WithTopic("test/temperature")
                .WithAtLeastOnceQoS()
                .Build(),
            });
            
            var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test/temperature")
                    .WithPayload($"Test Message")
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)

                    .Build();
                Console.WriteLine($"{message}");
                await mqtt.EnqueueAsync(message);
           
          
          

            while (true);

       

        }
        }
    }

