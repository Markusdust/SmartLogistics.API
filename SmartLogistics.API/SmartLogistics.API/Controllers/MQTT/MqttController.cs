using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MQTT;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers.MQTT
{
    [ApiController]
    public class MqttController : Controller
    {
        private readonly IMqttRepository mqttRepository;

        public MqttController(IMqttRepository mqttRepository)
        {
            this.mqttRepository = mqttRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetBatteryStatusAsync()
        {
            var batterystatus = "45";

            if (batterystatus == null)
            {
                return NotFound();
            }
            return Ok(batterystatus);
        }
    }
}
 