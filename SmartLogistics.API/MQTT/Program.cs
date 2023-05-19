// See https://aka.ms/new-console-template for more information
using MQTT;

Console.WriteLine("Hello, World!");


await Client_Subscriber.Connect_Client();
//await Client_Subscriber.Subscribe_Topic();
await Client_Subscriber.Handle_Received_Application_Message();



Console.ReadLine();