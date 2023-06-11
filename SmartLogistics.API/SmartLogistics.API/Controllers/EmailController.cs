using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Email;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    public class EmailController : Controller
    {
        private readonly IMqttRepository mqttRepository;

        public EmailController(IMqttRepository mqttRepository)
        {
            this.mqttRepository = mqttRepository;
        }

        [HttpGet]
        [Route("[controller]/sendTestEmail")]
        public async Task<IActionResult> sendTestEmail()
        {
            var emailService = new sendEmail();

            try
            {
                await emailService.SendEmailToClientAsync();
            }
            catch (Exception)
            {
                await Console.Out.WriteLineAsync("Email konnte nicht gesendet werden.");
            }
            
           

            return Ok();
        }
    }
}
