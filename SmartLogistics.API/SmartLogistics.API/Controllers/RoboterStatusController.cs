using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;
using SmartLogistics.API.DomainModels.UpdateDomainModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Email;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class RoboterStatusController : Controller
    {
        private readonly IMqttRepository mqttRepository;
        private readonly IMapper mapper;

        public RoboterStatusController(IMqttRepository mqttRepository) 
        { 
            this.mqttRepository = mqttRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetBatterieStatusAsync()
        {
            var batterieStatus = mqttRepository.BatteryLevel;


            return Ok(batterieStatus);
        }

    }
}
