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
                .WithWillTopic("test/temperature")
                .WithWillPayload("Connection Died")
                .Build();
            var mangagedOptions = new ManagedMqttClientOptionsBuilder()
                .WithClientOptions(options)
                
                .Build();
            Random random = new Random();
            string FilePath = @"D:\Advanced_Training\CSharp_IoT\MQTTClient\MQTTLogs.txt";
            string logMessage;
            // Console.WriteLine("Enter message to be sent");
            // Log Connection 
            mqtt.ConnectedAsync += async e =>
            {
                try
                {
                    logMessage = $"{DateTime.Now}, Connection Established";
                    File.AppendAllText(FilePath, logMessage + Environment.NewLine);
                    Console.WriteLine("Connected");
                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"Failed to Log : {ex.Message}");

                }
            };
            //await mqtt.StartAsync(mangagedOptions);
            await mqtt.StartAsync(mangagedOptions);

            // Send random temperatrure between 30 and 40 every 5 seconds
            while (true)
            {

                var payload = (random.Next(30, 40));
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test/temperature")
                    .WithPayload($"{payload}")
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)

                    .Build();
                Console.WriteLine($"{message}");
                await mqtt.EnqueueAsync(message);
                

                await Task.Delay(3000);
                //Log Disconnected events
                mqtt.DisconnectedAsync += async e =>
                {
                    try
                    {
                        logMessage = $"{DateTime.Now}, Disconnected";
                        File.AppendAllText(FilePath, logMessage + Environment.NewLine);
                        Console.WriteLine("Disconnected");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to Log : {ex.Message}");

                    }
                    
                };
                await mqtt.StopAsync();
                 

            }

        }

    }
}
