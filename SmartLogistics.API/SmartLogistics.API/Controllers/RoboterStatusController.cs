using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class RoboterStatusController : Controller
    {
        private readonly IMqttRepository mqttRepository;
        private readonly IBestellungRepository bestellungRepository;
        private readonly IMapper mapper;

        public RoboterStatusController(IMqttRepository mqttRepository, IBestellungRepository bestellungRepository)
        {
            this.mqttRepository = mqttRepository;
            this.mapper = mapper;
            this.bestellungRepository = bestellungRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetBatterieStatusAsync()
        {
            // Guid auftragsIdGUID = Guid.Parse("d08d3cca-6a39-424e-8123-abc80b473305");
            //bestellungRepository.CheckBestellungChangeStatus(auftragsIdGUID, "nicht geliefert");

            var roboterId = mqttRepository.RoboterId;
            var batterieStatus = mqttRepository.Batteriestatus;
            var auftragsId = mqttRepository.AuftragsId;
            var auftragsstatus = mqttRepository.Auftragsstatus;
            var positionsstatus = mqttRepository.Positionsstatus;
            var angemeldet = mqttRepository.Angemeldet;

            return Ok("RoboterId: " + roboterId + "\r\n"
                        + "Batteriestatus: " + batterieStatus + "%" + "\r\n"
                        + "AuftragsId: " + auftragsId + "\r\n"
                        + "Auftragsstatus: " + auftragsstatus + "\r\n"
                        + "Positionsstatus: " + positionsstatus + "\r\n"
                        + "angemeldet: " + angemeldet + "\r\n"
                        );
        }
    }
}
