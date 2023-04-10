using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllKunden()
        {
            var kunden = (kundenRepository.GetKunden());

            return Ok(mapper.Map<List<KundeDto>>(kunden));

        }
    }
}
