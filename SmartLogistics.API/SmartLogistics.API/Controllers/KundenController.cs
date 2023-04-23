using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class KundenController : Controller
    {
        private readonly IKundenRepository kundenRepository;
        private readonly IMapper mapper;

        public KundenController(IKundenRepository kundenRepository, IMapper mapper)
        {
            this.kundenRepository = kundenRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllKundenAsync()
        {
            var kunden = await kundenRepository.GetKundenAsync();

            return Ok(mapper.Map<List<KundeDto>>(kunden));

        }

        [HttpGet]
        [Route("[controller]/{kundeId:guid}"), ActionName("GetKundeAsync")]
        public async Task<IActionResult> GetKundeAsync([FromRoute] Guid kundeId)
        {
            //Fetch Kunden Details
            var kunde = await kundenRepository.GetKundeAsync(kundeId);

            //Return
            if (kunde == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<KundeDto>(kunde));
        }

        [HttpPut]
        [Route("[controller]/{kundeId:guid}")]
        public async Task<IActionResult> UpdateKundeAsync([FromRoute] Guid kundeId, [FromBody] UpdateKundeRequest request)
        {
            if (await kundenRepository.Exists(kundeId))
            {
                //update Details
                var updateKunde = await kundenRepository.UpdateKunde(kundeId, mapper.Map<Kunde>(request));

                if (updateKunde != null)
                {
                    return Ok(mapper.Map<KundeDto>(updateKunde));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{kundeId:guid}")]
        public async Task<IActionResult> DeleteKundeAsysnc([FromRoute] Guid kundeId)
        {
            if (await kundenRepository.Exists(kundeId))
            {
                var kunde = await kundenRepository.DeleteKunde(kundeId);
                return Ok(mapper.Map<KundeDto>(kunde));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddKundeAsync([FromBody] AddKundeRequest request)
        {
            var kunde= await kundenRepository.AddKunde(mapper.Map<Kunde>(request));
            return CreatedAtAction(nameof(GetKundeAsync), new { kundeId = kunde.Id },
                mapper.Map<KundeDto>(kunde));
        }
    }
}
