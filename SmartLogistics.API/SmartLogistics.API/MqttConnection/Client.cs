using MQTTnet.Client;
using MQTTnet;
using SmartLogistics.API.MqttConnection.Helpers;
using System.Text;
using SmartLogistics.API.Repositories;
using Azure;
using Microsoft.IdentityModel.Tokens;
using SmartLogistics.API.Controllers;
using SmartLogistics.API.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace SmartLogistics.API.MqttConnection
{
    public class Client
    {
        private readonly IMqttRepository mqttRepository;
        public Client(IMqttRepository mqttRepository)
        {
            this.mqttRepository= mqttRepository;
        }
        public static async Task Clean_Disconnect()
        {
            /*
             * This sample disconnects in a clean way. This will send a MQTT DISCONNECT packet
             * to the server and close the connection afterwards.
             *
             * See sample _Connect_Client_ for more details.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost")
                //.WithTcpServer("192.168.3.20", 1883)
                //.WithCredentials("mqtt", "Network4zbw")
                .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                // This will send the DISCONNECT packet. Calling _Dispose_ without DisconnectAsync the 
                // connection is closed in a "not clean" way. See MQTT specification for more details.
                await mqttClient.DisconnectAsync(new MqttClientDisconnectOptionsBuilder().WithReason(MqttClientDisconnectOptionsReason.NormalDisconnection).Build());
            }
        }

        public static async Task Connect_Client()
        {
            /*
             * This sample creates a simple MQTT client and connects to a public broker.
             *
             * Always dispose the client when it is no longer used.
             * The default version of MQTT is 3.1.1.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                // Use builder classes where possible in this project.
                var mqttClientOptions = new MqttClientOptionsBuilder()
                  .WithTcpServer("localhost")
                //.WithTcpServer("192.168.3.20", 1883)
                //.WithCredentials("mqtt", "Network4zbw")
                .Build();

                // This will throw an exception if the server is not available.
                // The result from this message returns additional data which was sent 
                // from the server. Please refer to the MQTT protocol specification for details.
                var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                Console.WriteLine("The MQTT client is connected.");

                response.DumpToConsole();

                // Send a clean disconnect to the server by calling _DisconnectAsync_. Without this the TCP connection
                // gets dropped and the server will handle this as a non clean disconnect (see MQTT spec for details).
                //var mqttClientDisconnectOptions = mqttFactory.CreateClientDisconnectOptionsBuilder().Build();

                //await mqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
            }
        }

        public async Task Handle_Received_Application_Message()
        {
            var mqttRepository = this.mqttRepository;
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("localhost")
                    //.WithTcpServer("192.168.3.20", 1883)
                    //.WithCredentials("mqtt", "Network4zbw")
                    .Build();

                mqttClient.ApplicationMessageReceivedAsync += async e =>
                {
                    Console.WriteLine("Received application message.");
                    Console.WriteLine(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));

                    await ValueRoboterToRepoAsync(mqttRepository,  Encoding.UTF8.GetString(e.ApplicationMessage.Payload));

                    await Task.Yield(); // Erlaubt anderen Tasks, fortzufahren
                };

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = new MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter("SmartLogistics/Roboter/1234")
                    .Build();

                await mqttClient.SubscribeAsync(mqttSubscribeOptions);

                Console.WriteLine("MQTT client subscribed to topic.");

                // Warten auf ein Beendigungssignal
                var quitEvent = new ManualResetEventSlim(false);
                Console.CancelKeyPress += (sender, eventArgs) =>
                {
                    eventArgs.Cancel = true;
                    quitEvent.Set();
                };

                quitEvent.Wait();
            }
        }

        private static async Task ValueRoboterToRepoAsync(IMqttRepository mqttRepository, string input)
        {
           //input = "1234/34/01/B/R1/1";
            string[] values = input.Split('/');

            string value1 = values[0];
            string wert2 = values[1];
            string wert3 = values[2];
            string wert4 = values[3];
            string wert5 = values[4];
            string wert6 = values[5];

            mqttRepository.RoboterId= value1;
            mqttRepository.Batteriestatus = wert2;
            mqttRepository.AuftragsId = wert3;
            mqttRepository.Auftragsstatus = wert4;
            mqttRepository.Positionsstatus = wert5;
            mqttRepository.Angemeldet = wert6;

            Guid bestellungId = Guid.Parse(mqttRepository.AuftragsId);

            await mqttRepository.ChangeLieferstatusTest(bestellungId, mqttRepository.Auftragsstatus);
            ///


        }

        public void SomeMethod()
        {
            // Verwenden der Client-Klasse
            
        }

        public static async Task Subscribe_Topic()
        {
            /*
             * This sample subscribes to a topic.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("localhost")
                    //.WithTcpServer("192.168.3.20", 1883)
                    //.WithCredentials("mqtt", "Network4zbw")
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic("SmartLogistics/Roboter/1234");
                        })
                    .Build();

                var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

                Console.WriteLine("MQTT client subscribed to topic.");

                // The response contains additional data sent by the server after subscribing.
                response.DumpToConsole();
            }
        }

        public static async Task Publish_Application_Message(IMqttRepository mqttRepository, string bestellung)
        {
            /*
             * This sample pushes a simple application message including a topic and a payload.
             *
             * Always use builders where they exist. Builders (in this project) are designed to be
             * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
             * supported but the class might change often in future releases where the builder does not
             * or at least provides backward compatibility where possible.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost")
                //.WithTcpServer("192.168.3.20", 1883)
                //.WithCredentials("mqtt", "Network4zbw")
                .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("SmartLogistics/Lieferauftraege")
                    .WithPayload(bestellung)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                //await mqttClient.DisconnectAsync();

                Console.WriteLine("MQTT application message is published.");
            }
        }
    }
}
