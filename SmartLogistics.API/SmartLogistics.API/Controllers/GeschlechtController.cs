using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.Repositories;

namespace SmartLogistics.API.Controllers
{
    [ApiController]
    public class GeschlechtController : Controller
    {
        public readonly IKundenRepository kundenReposiotry;
        public readonly IMapper mapper;

        public GeschlechtController (IKundenRepository kundenReposiotry, IMapper mapper)
        {
            this.kundenReposiotry = kundenReposiotry;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGeschlechtAsync()
        {
            var geschlechtList = await kundenReposiotry.GetGeschlechterAsync();

            if (geschlechtList == null || !geschlechtList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<GeschlechtDto>>(geschlechtList));
        }
    }
}
