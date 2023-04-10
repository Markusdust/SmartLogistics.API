using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class KundenController : Controller
    {
        private readonly IKundenRepository kundenRepository;

        public KundenController(IKundenRepository kundenRepository)
        {
            this.kundenRepository = kundenRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllKunden()
        {
            var kunden = (kundenRepository.GetKunden());

            var domainModelKunden = new List<KundeDto>();

            foreach (var kunde in kunden)
            {
                domainModelKunden.Add(new KundeDto
                {
                    Id = kunde.Id,
                    Vorname = kunde.Vorname,
                    Nachname = kunde.Nachname,
                    Geburtsdatum = kunde.Geburtsdatum,
                    Email = kunde.Email,
                    Telefon = kunde.Telefon,
                    GeschlechtId = kunde.GeschlechtId,
                    Adresse = new AdresseDto()
                    {
                        Id = kunde.Adresse.Id,
                        Strasse = kunde.Adresse.Strasse,
                        Hausnummer = kunde.Adresse.Hausnummer,
                        OrtId = kunde.Adresse.OrtId
                    },
                    Geschlecht = new GeschlechtDto()
                    {
                        Id = kunde.Geschlecht.Id,
                        Beschreibung = kunde.Geschlecht.Beschreibung
                    }

                });
            }

            return Ok(domainModelKunden);

        }
    }
}
