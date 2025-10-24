using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
namespace MQTTSubscriber
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new MqttFactory();
            var mqtt = factory.CreateManagedMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(false)
                .Build();
            var mangagedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(options)

                .Build();
            // Console.WriteLine("Enter message to be sent");
            // Log Connection 
            mqtt.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected");
            };
            await mqtt.StartAsync(mangagedOptions);
            await Task.Delay(3000);
            //Log Disconnected events
            mqtt.DisconnectedAsync += async e =>
            {
                Console.WriteLine("Disconnected");
            };
            mqtt.ApplicationMessageReceivedAsync += async e =>
            {
                Console.WriteLine($"Received: {e.ApplicationMessage.Topic} - {e.ApplicationMessage.ConvertPayloadToString()}");
                
                
            };
            
            await mqtt.SubscribeAsync(new[]
            {
                new MqttTopicFilterBuilder()
                .WithTopic("test/temperature")
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                
                .Build(),
            });
            await Task.Delay(3000);
            while (true)
            {
            }

            //await mqtt.StopAsync();
        }
    }
}
