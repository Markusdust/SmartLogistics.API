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
    public class GeschlechtController : Controller
    {
        private readonly IGeschlechtRepsitory geschlechtRepsitory;
        public readonly IMapper mapper;

        public GeschlechtController(IGeschlechtRepsitory geschlechtRepsitory, IMapper mapper)
        {

            this.geschlechtRepsitory = geschlechtRepsitory;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGeschlechtAsync()
        {
            var geschlechtList = await geschlechtRepsitory.GetGeschlechterAsync();

            if (geschlechtList == null || !geschlechtList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<GeschlechtDto>>(geschlechtList));
        }

        [HttpGet]
        [Route("[controller]/{geschlechtId:guid}"), ActionName("GetGeschlechtAsync")]
        public async Task<IActionResult> GetGeschlechtAsync([FromRoute] Guid geschlechtId)
        {
            //Fetch Geschlecht Details
            var geschlecht = await geschlechtRepsitory.GetGeschlechtAsync(geschlechtId);

            //Return
            if (geschlecht == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<GeschlechtDto>(geschlecht));
        }

        [HttpPut]
        [Route("[controller]/{geschlechtId:guid}")]
        public async Task<IActionResult> UpdateGeschlechtAsync([FromRoute] Guid geschlechtId, [FromBody] UpdateGeschlechtRequest request)
        {
            if (await geschlechtRepsitory.Exists(geschlechtId))
            {
                //update Details
                var updateGeschlecht = await geschlechtRepsitory.UpdateGeschlecht(geschlechtId, mapper.Map<Geschlecht>(request));

                if (updateGeschlecht != null)
                {
                    return Ok(mapper.Map<GeschlechtDto>(updateGeschlecht));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{geschlechtId:guid}")]
        public async Task<IActionResult> DeleteGeschlechtAsysnc([FromRoute] Guid geschlechtId)
        {
            if (await geschlechtRepsitory.Exists(geschlechtId))
            {
                var geschlecht = await geschlechtRepsitory.DeletGeschlecht(geschlechtId);
                return Ok(mapper.Map<GeschlechtDto>(geschlecht));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddGeschlechtAsync([FromBody] AddGeschlechtRequest request)
        {
            var geschlecht = await geschlechtRepsitory.AddGeschlecht(mapper.Map<Geschlecht>(request));
            return CreatedAtAction(nameof(GetGeschlechtAsync), new { geschlechtId = geschlecht.Id },
                mapper.Map<GeschlechtDto>(geschlecht));
        }
    }
}
