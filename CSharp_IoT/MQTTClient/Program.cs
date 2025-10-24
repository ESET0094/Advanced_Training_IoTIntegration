using MQTTnet;
using MQTTnet.Client;
using System.Text;

using MQTTnet.Extensions.ManagedClient;
using System.Threading.Tasks;
namespace MQTTClient
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
            Random random = new Random();
            // Console.WriteLine("Enter message to be sent");
            await mqtt.StartAsync(mangagedOptions);
            mqtt.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected");
            };
            while (true)
            {
                var payload = (random.Next(30, 40));
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test/temperature")
                    .WithPayload($"{payload}")
                    
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithRetainFlag(true)
                    .Build();

                await mqtt.EnqueueAsync(message);
                Console.WriteLine(message);
                await Task.Delay(3000);

                // await mqtt.StopAsync();

            }

        }

    }
}
