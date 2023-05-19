using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;
using SmartLogistics.API.DomainModels.UpdateDomainModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class LagerplatzController : Controller
    {
        private readonly ILagerplatzRepository lagerplatzRepository;
        private readonly IMapper mapper;

        public LagerplatzController(ILagerplatzRepository lagerplatzRepository, IMapper mapper)
        {
            this.lagerplatzRepository = lagerplatzRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllLagerplatzAsync()
        {
            var lagerplatz = await lagerplatzRepository.GetAllLagerplatzAsync();

            return Ok(mapper.Map<List<LagerplatzDto>>(lagerplatz));
        }

        [HttpGet]
        [Route("[controller]/{lagerplatzId:guid}"), ActionName("GetLagerplatzAsync")]
        public async Task<IActionResult> GetLagerplatzAsync([FromRoute] Guid lagerplatzId)
        {
            //Fetch Lagerplatz Details
            var lagerplatz = await lagerplatzRepository.GetLagerplatzAsync(lagerplatzId);

            //Return
            if (lagerplatz == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LagerplatzDto>(lagerplatz));
        }

        [HttpPut]
        [Route("[controller]/{lagerplatzId:guid}")]
        public async Task<IActionResult> UpdateLagerplatzAsync([FromRoute] Guid lagerplatzId, [FromBody] UpdateLagerplatzRequest request)
        {
            if (await lagerplatzRepository.Exists(lagerplatzId))
            {
                //update Details
                var updateLagerplatz = await lagerplatzRepository.UpdateLagerplatz(lagerplatzId, mapper.Map<Lagerplatz>(request));

                if (updateLagerplatz != null)
                {
                    return Ok(mapper.Map<LagerplatzDto>(updateLagerplatz));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{lagerplatzId:guid}")]
        public async Task<IActionResult> DeleteLagerplatzAsysnc([FromRoute] Guid lagerplatzId)
        {
            if (await lagerplatzRepository.Exists(lagerplatzId))
            {
                var lagerplatz = await lagerplatzRepository.DeleteLagerplatz(lagerplatzId);
                return Ok(mapper.Map<LagerplatzDto>(lagerplatz));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddLagerplatzAsync([FromBody] AddLagerplatzRequest request)
        {
            var lagerplatz = await lagerplatzRepository.AddLagerplatz(mapper.Map<Lagerplatz>(request));
            return CreatedAtAction(nameof(GetLagerplatzAsync), new { lagerplatzId = lagerplatz.Id },
                mapper.Map<LagerplatzDto>(lagerplatz));
        }
    }
}
