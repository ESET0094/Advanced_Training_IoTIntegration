using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System.Text;

namespace MQTTClient
{
    internal class Program
    {
       
            static async Task Main(string[] args)
            {
                var factory = new MqttFactory();
                //var mqtt = factory.CreateManagedMqttClient();
                var mqtt = factory.CreateMqttClient();

                var options = new MqttClientOptionsBuilder()
                    .WithClientId("defc")

                    .WithTcpServer("172.16.103.90", 1883)
                    .WithCleanSession(false)
                   
                  
                    .Build();
                //var mangagedOptions = new ManagedMqttClientOptionsBuilder()
                //    .WithClientOptions(options)
                await mqtt.ConnectAsync(options);




                //    .Build();
                Random random = new Random();
                string FilePath = @"D:\Advanced_Training\CSharp_IoT\MQTTClient\MQTTLogs.txt";
                string logMessage;
                // Console.WriteLine("Enter message to be sent");
                // Log Connection 

                mqtt.DisconnectedAsync += async e =>
                {
                    try
                    {
                        await Task.Delay(5000);
                        logMessage = $"{DateTime.Now}, Disconnected";
                        File.AppendAllText(FilePath, logMessage + Environment.NewLine);

                        Console.WriteLine("Disconnected");
                        await Task.Delay(1000);
                        await mqtt.ConnectAsync(options);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to Log : {ex.Message}");

                    }

                };
                mqtt.ConnectedAsync += async e =>
                {
                    try
                    {
                        logMessage = $"{DateTime.Now}, Connection Established";
                        File.AppendAllText(FilePath, logMessage + Environment.NewLine);
                        Console.WriteLine("Connected");
                        await mqtt.DisconnectAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to Log : {ex.Message}");

                    }
                };
                //await mqtt.StartAsync(mangagedOptions);
                //await mqtt.StartAsync(mangagedOptions);
                try
                {
                // Send random temperatrure between 30 and 40 every 5 seconds


                string payload = "1.1.1.1.1.1";
                        var message = new MqttApplicationMessageBuilder()
                            .WithTopic("test/temperature")
                            .WithPayload($"{payload}")
                            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)

                            .Build();
                        Console.WriteLine($"{message}");
                        await mqtt.PublishAsync(message);

                        await Task.Delay(5000);


                        //Log Disconnected events

                        //await mqtt.StopAsync();


                    
                }
                catch (Exception e) { Console.WriteLine($"Exceptipon:{e.Message}"); }

            }

        }

    }

