using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Repositories;
using System.Runtime.InteropServices;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class MqttController : Controller
    {
        private readonly IMqttRepository mqttRepository;
        private readonly IMapper mapper;

        public MqttController(IMqttRepository mqttRepository, IMapper mapper)
        {
            this.mqttRepository = mqttRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/{roboterId:guid}/battery"), ActionName("GetRoboterBatteryAsync")]
        public async Task<IActionResult> GetRoboterBatteryAsync(Guid roboterId)
        {

            //Wenn einmal schon auf id abboniert muss das nicht wieder gemacht werden.
            ClientSubscribe.Handle_Received_Application_Message(mqttRepository, roboterId);


            ////Idee: einmal auf Roboter abonnieren Topic => RoboterIdXY1234/*
            ///wenn auf alles von robo abonniert dann kann man ja easy nur noch properties auslesen

            var battery = mqttRepository.BatteryLevel;


            return Ok(battery);
        }

        [HttpGet]
        [Route("[controller]/{roboterId:guid}/positionstatus"), ActionName("GetRoboterPositionStatusAsync")]
        public async Task<IActionResult> GetRoboterPositionStatusAsync(Guid roboterId)
        {
            //getPositionStatusbyId()
            ///blabla bla
            //RS = Ruhestation
            //VZ = Verteilzentrum1
            //R1 = Routenabschnitt 1

            var posStatus = "VZ";
            return Ok(posStatus);
        }

        [HttpGet]
        [Route("[controller]/{auftragsId:guid}"), ActionName("GetAuftragsstatusAsync")]
        public async Task<IActionResult> GetAuftragsstatusAsync(Guid auftragsid)
        {
            //getAuftragsstatusById()
            ///blabla bla

            //E = Empfangen
            //B = Beladen
            //N = Paket wird in Kürze Eintreffen
            //A = Ausgeliefert


            string status = "Empfangen";
            return Ok(status);
        }
    }
}
