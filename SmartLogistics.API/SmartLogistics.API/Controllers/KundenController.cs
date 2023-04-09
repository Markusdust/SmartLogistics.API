using Microsoft.AspNetCore.Mvc;
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
            return Ok(kundenRepository.GetKunden());
        }
    }
}
