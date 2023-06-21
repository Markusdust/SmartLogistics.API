using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    public class MqttController : Controller
    {
        private readonly IMqttRepository mqttRepository;

        private readonly IMapper mapper;

        public MqttController(IMqttRepository mqttRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.mqttRepository = mqttRepository;
        }

        [HttpGet]
        [Route("[controller]/abonnierenAufTopicTEST")]
        public async Task<IActionResult> AbonnierAufTopic()
        {


            try
            {

                var mqttClient = new Client(mqttRepository);

                //var myTask = new Task(async () => { await mqttClient.Handle_Received_Application_Message(); });
                //myTask.Start();
                await mqttClient.Handle_Received_Application_Message();
                //TEST auf topic SmartLogistics/Roboter/1234 subscriben für MQTT
                //Client.Handle_Received_Application_Message(mqttRepository);
                return Ok();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Abonieren auf Topic hat nicht funktioniertn" + "\r\n" + ex);
                return NotFound();
            }
        }
    }
}
