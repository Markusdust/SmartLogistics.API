using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.DomainModels.AddDomainModels;
using SmartLogistics.API.DomainModels.UpdateDomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class ProduktController : Controller
    {
        private readonly IProdukteRepository produktRepository;
        private readonly IMapper mapper;

        public ProduktController(IProdukteRepository produktRepository, IMapper mapper)
        {
            this.produktRepository = produktRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllProdukteAsync()
        {
            var produkteList = await produktRepository.GetProdukteAsync();

            if (produkteList == null || !produkteList.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<ProduktDto>>(produkteList));
        }

        [HttpGet]
        [Route("[controller]/{produktId:guid}"), ActionName("GetProduktAsync")]
        public async Task<IActionResult> GetProduktAsync([FromRoute] Guid produktId)
        {
            //Fetch Produkte Details
            var produkt = await produktRepository.GetProduktAsync(produktId);

            //Return
            if (produkt == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ProduktDto>(produkt));
        }

        [HttpPut]
        [Route("[controller]/{produktId:guid}")]
        public async Task<IActionResult> UpdateProduktAsync([FromRoute] Guid produktId, [FromBody] UpdateProduktRequest request)
        {
            if (await produktRepository.Exists(produktId))
            {
                //update Details
                var updateProdukt = await produktRepository.UpdateProdukte(produktId, mapper.Map<Produkt>(request));

                if (updateProdukt != null)
                {
                    return Ok(mapper.Map<ProduktDto>(updateProdukt));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{produktId:guid}")]
        public async Task<IActionResult> DeleteProduktAsysnc([FromRoute] Guid produktId)
        {
            if (await produktRepository.Exists(produktId))
            {
                var produkt = await produktRepository.DeleteProdukt(produktId);
                return Ok(mapper.Map<ProduktDto>(produkt));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddProduktAsync([FromBody] AddProduktRequest request)
        {
            var produkt = await produktRepository.AddProdukt(mapper.Map<Produkt>(request));
            return CreatedAtAction(nameof(GetProduktAsync), new { produktId = produkt.Id },
                mapper.Map<ProduktDto>(produkt));
        }
    }
}
