using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.DomainModels.AddDomainModels;
using SmartLogistics.API.DomainModels.UpdateDomainModels;
using SmartLogistics.API.Email;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Repositories;

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


            var emailsender = new sendEmail();

            var bestellungsList = await bestellungRepository.GetBestellungenAsync();

            string stringbestellung = "";

            foreach (var item in bestellungsList)
            {
                string kundeId = "";
                string produktId = "";
                string prioritaet = "";
                string deliveryTyp = "";

                kundeId = createKundeIdForDelivery(item, kundeId);
                produktId = createProduktIdForDelivery(item, produktId);
                prioritaet = createPriorityForDelivery(item, prioritaet);
                deliveryTyp = createDeliveryTypeForDelivery(item, deliveryTyp);

                stringbestellung += item.Id + "/";
                stringbestellung += kundeId + "/";  //item.KundeId + "/";
                stringbestellung += produktId + "/";//item.ProduktId + "/";
                stringbestellung += prioritaet + "/";//item.Prioritaet + "/";
                stringbestellung += deliveryTyp + "/";//item.Lieferart;
                stringbestellung += ";";
            }

            //foreach (var item in bestellungsList)
            //{
            //    await emailsender.SendEmailToClientAsync();
            //}



            var showme = stringbestellung;
            await Client.Publish_Application_Message(mqttRepository, stringbestellung);

            return Ok();
        }

        private static string createDeliveryTypeForDelivery(Bestellung item, string deliveryTyp)
        {
            switch (item.Lieferart)
            {
                case "persoenlich":
                    deliveryTyp = "0";
                    break;
                case "autonom":
                    deliveryTyp = "1";
                    break;
            }

            return deliveryTyp;
        }

        private static string createPriorityForDelivery(Bestellung item, string prioritaet)
        {
            switch (item.Kunde.Nachname)
            {
                case "Fischer":
                    prioritaet = "1";
                    break;
                case "Zwingli":
                    prioritaet = "2";
                    break;
                case "Mueller":
                    prioritaet = "3";
                    break;
                case "Amsler":
                    prioritaet = "4";
                    break;
            }

            return prioritaet;
        }

        private static string createProduktIdForDelivery(Bestellung item, string produktId)
        {
            switch (item.Produkt.Name)
            {
                case "A":
                    produktId = "01";
                    break;
                case "B":
                    produktId = "02";
                    break;
                case "C":
                    produktId = "03";
                    break;
                case "D":
                    produktId = "04";
                    break;
            }

            return produktId;
        }

        private static string createKundeIdForDelivery(Bestellung item, string kundeId)
        {
            switch (item.Kunde.Nachname)
            {
                case "Amsler":
                    kundeId = "01";
                    break;
                case "Fischer":
                    kundeId = "02";
                    break;
                case "Mueller":
                    kundeId = "03";
                    break;
                case "Zwingli":
                    kundeId = "04";
                    break;
            }

            return kundeId;
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

        [HttpPut]
        [Route("[controller]/UpdateLieferstatus")]
        public async Task<IActionResult> UpdateLieferstatusAsync()
        {
            Guid bestellungId = Guid.Parse(mqttRepository.AuftragsId);



            if (await bestellungRepository.Exists(bestellungId))
            {



                var bestellung = await bestellungRepository.GetBestellungAsync(bestellungId);

                var request = new UpdateBestellungRequest
                {
                    ProduktId = bestellung.ProduktId,
                    Erfassdatum = bestellung.Erfassdatum,
                    LieferungStart = bestellung.LieferungStart,
                    LieferungEnde = bestellung.LieferungEnde,
                    KundeId = bestellung.KundeId,
                    Prioritaet = bestellung.Prioritaet,
                    Lieferart = bestellung.Lieferart,
                    Status = mqttRepository.Auftragsstatus
                };

                //update Details
                var updateBestellung = await bestellungRepository.UpdateBestellung(bestellungId, mapper.Map<Bestellung>(request));

                if (updateBestellung != null)
                {
                    return Ok(mapper.Map<BestellungDto>(updateBestellung));
                }

            }
            return NotFound();

        }

    }
}
