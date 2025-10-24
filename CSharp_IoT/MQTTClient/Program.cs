using MQTTnet;
using MQTTnet.Client;
using System.Text;

using MQTTnet.Extensions.ManagedClient;
using System.Threading.Tasks;
using System.Transactions;
namespace MQTTClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new MqttFactory();
            var mqtt = factory.CreateManagedMqttClient();
           
            var options = new MqttClientOptionsBuilder()
                .WithClientId("defc")
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(false)
                .Build();
            var mangagedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(options)
                
                .Build();
            Random random = new Random();
            // Console.WriteLine("Enter message to be sent");
            // Log Connection 
            mqtt.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected");
            };
            //await mqtt.StartAsync(mangagedOptions);
            await mqtt.StartAsync(mangagedOptions);

            // Send random temperatrure between 30 and 40 every 5 seconds
            while (true)
            {

                var payload = (random.Next(30, 40));
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test/r1/r2/temperature")
                    .WithPayload($"{payload}")
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)

                    .Build();
                Console.WriteLine($"{message}");
                await mqtt.EnqueueAsync(message);
                

                await Task.Delay(3000);
                //Log Disconnected events
                mqtt.DisconnectedAsync += async e =>
                {
                    Console.WriteLine("Disconnected");
                };
                 

            }

        }

    }
}
