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
    public class BestellungController : Controller
    {
        private readonly IMqttRepository mqttRepository;
        private readonly IBestellungRepository bestellungRepository;
        private readonly IMapper mapper;

        public BestellungController(IMqttRepository mqttRepository, IBestellungRepository bestellungRepository, IMapper mapper)
        {
            this.mqttRepository = mqttRepository;
            this.bestellungRepository = bestellungRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllBestellungenAsync()
        {
            var bestellungsList = await bestellungRepository.GetBestellungenAsync();

            if (bestellungsList == null || !bestellungsList.Any())
            {
                return null;
            }


            var emailService = new sendEmail();
            await emailService.SendEmailToClientAsync();


            return Ok(mapper.Map<List<BestellungDto>>(bestellungsList));
        }

        [HttpGet]
        [Route("[controller]/{bestellungId:guid}"), ActionName("GetBestellungAsync")]
        public async Task<IActionResult> GetBestellungAsync([FromRoute] Guid bestellungId)
        {
            //Fetch bestellungen Details
            var bestellung = await bestellungRepository.GetBestellungAsync(bestellungId);

            //Return
            if (bestellung == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BestellungDto>(bestellung));


        }

        [HttpGet]
        [Route("[controller]/lieferungstarten")]
        public async Task<IActionResult> LieferungStarten()
        {
            //////////MQTT TEST
            ///WIRD HIER GEMACHT WEIL  DAS VON BUTTON AUSGELÖST WIRD
            ///


            //var emailsender = new sendEmail();

            var bestellungsList = await bestellungRepository.GetBestellungenAsync();

            string stringbestellung = "";

            foreach (var item in bestellungsList)
            {
                stringbestellung += item.Id + "/";
                stringbestellung += item.KundeId + "/";
                stringbestellung += item.ProduktId + "/";
                stringbestellung += item.Prioritaet + "/";
                stringbestellung += item.Lieferart;
                stringbestellung += ";";
            }

            //foreach (var item in bestellungsList)
            //{
            //    await emailsender.SendEmailToClientAsync();
            //}

            //var showme = stringbestellung;
            await Client.Publish_Application_Message(mqttRepository, stringbestellung);

            return Ok();
        }

        [HttpPut]
        [Route("[controller]/{bestellungId:guid}")]
        public async Task<IActionResult> UpdateBestellungAsync([FromRoute] Guid bestellungId, [FromBody] UpdateBestellungRequest request)
        {
            if (await bestellungRepository.Exists(bestellungId))
            {
                //update Details
                var updateBestellung = await bestellungRepository.UpdateBestellung(bestellungId, mapper.Map<Bestellung>(request));

                if (updateBestellung != null)
                {
                    return Ok(mapper.Map<BestellungDto>(updateBestellung));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{bestellungId:guid}")]
        public async Task<IActionResult> DeleteBestellungAsysnc([FromRoute] Guid bestellungId)
        {
            if (await bestellungRepository.Exists(bestellungId))
            {
                var bestellung = await bestellungRepository.DeleteBestellung(bestellungId);
                return Ok(mapper.Map<BestellungDto>(bestellung));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddBestellungAsync([FromBody] AddBestellungRequest request)
        {
            var bestellung = await bestellungRepository.AddBestellung(mapper.Map<Bestellung>(request));
            return CreatedAtAction(nameof(GetBestellungAsync), new { bestellungId = bestellung.Id },
                mapper.Map<BestellungDto>(bestellung));
        }

    }
}
