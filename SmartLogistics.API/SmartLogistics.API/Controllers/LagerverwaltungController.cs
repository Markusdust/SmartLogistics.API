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
    public class LagerverwaltungController : Controller
    {
        private readonly ILagerverwaltungRepository lagerverwaltungRepository;
        private readonly IMapper mapper;

        public LagerverwaltungController(ILagerverwaltungRepository lagerverwaltungRepository, IMapper mapper)
        {
            this.lagerverwaltungRepository = lagerverwaltungRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllLagerverwaltungAsync()
        {
            var lagerverwaltung = await lagerverwaltungRepository.GetAllLagerverwaltungAsync();

            return Ok(mapper.Map<List<LagerverwaltungDto>>(lagerverwaltung));
        }

        [HttpGet]
        [Route("[controller]/{lagerverwaltungId:guid}"), ActionName("GetLagerverwaltungAsync")]
        public async Task<IActionResult> GetLagerverwaltungAsync([FromRoute] Guid lagerverwaltungId)
        {
            //Fetch Lagerverwaltung Details
            var lagerverwaltung = await lagerverwaltungRepository.GetLagerverwaltungAsync(lagerverwaltungId);

            //Return
            if (lagerverwaltung == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LagerverwaltungDto>(lagerverwaltung));
        }

        [HttpPut]
        [Route("[controller]/{lagerverwaltungId:guid}")]
        public async Task<IActionResult> UpdateLagerverwaltungAsync([FromRoute] Guid lagerverwaltungId, [FromBody] UpdateLagerverwaltungRequest request)
        {
            if (await lagerverwaltungRepository.Exists(lagerverwaltungId))
            {
                //update Details
                var updateLagerverwaltung = await lagerverwaltungRepository.UpdateLaberverwaltung(lagerverwaltungId, mapper.Map<Lagerverwaltung>(request));

                if (updateLagerverwaltung != null)
                {
                    return Ok(mapper.Map<LagerverwaltungDto>(updateLagerverwaltung));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{lagerverwaltungId:guid}")]
        public async Task<IActionResult> DeleteLagerverwaltungAsysnc([FromRoute] Guid lagerverwaltungId)
        {
            if (await lagerverwaltungRepository.Exists(lagerverwaltungId))
            {
                var lagerverwaltung = await lagerverwaltungRepository.DeleteLagerverwaltung(lagerverwaltungId);
                return Ok(mapper.Map<LagerverwaltungDto>(lagerverwaltung));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddLagerverwaltungAsync([FromBody] AddLagerverwaltungRequest request)
        {
            var lagerverwaltung = await lagerverwaltungRepository.AddLagerverwaltung(mapper.Map<Lagerverwaltung>(request));
            return CreatedAtAction(nameof(GetLagerverwaltungAsync), new { lagerverwaltungId = lagerverwaltung.Id },
                mapper.Map<LagerverwaltungDto>(lagerverwaltung));
        }
    }
}
