using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class GeschlechtController : Controller
    {
        private readonly IGeschlechtRepsitory geschlechtRepsitory;
        public readonly IMapper mapper;

        public GeschlechtController (IGeschlechtRepsitory geschlechtRepsitory, IMapper mapper)
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
