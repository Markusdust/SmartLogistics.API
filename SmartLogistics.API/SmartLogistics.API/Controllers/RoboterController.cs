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
    public class RoboterController : Controller
    {
        private readonly IRoboterRepository roboterRepository;
        private readonly IMapper mapper;

        public RoboterController(IRoboterRepository roboterRepository, IMapper mapper)
        {
            this.roboterRepository = roboterRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllRoboterAsync()
        {
            var roboter = await roboterRepository.GetAllRoboterAsync();

            return Ok(mapper.Map<List<RoboterDto>>(roboter));
        }

        [HttpGet]
        [Route("[controller]/{roboterId:guid}"), ActionName("GetRoboterAsync")]
        public async Task<IActionResult> GetRoboterAsync([FromRoute] Guid roboterId)
        {
            //Fetch Roboter Details
            var roboter = await roboterRepository.GetRoboterAsync(roboterId);

            //Return
            if (roboter == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RoboterDto>(roboter));
        }

        [HttpPut]
        [Route("[controller]/{roboterId:guid}")]
        public async Task<IActionResult> UpdateRoboterAsync([FromRoute] Guid roboterId, [FromBody] UpdateRoboterRequest request)
        {
            if (await roboterRepository.Exists(roboterId))
            {
                //update Details
                var updateRoboter = await roboterRepository.UpdateRoboter(roboterId, mapper.Map<Roboter>(request));

                if (updateRoboter != null)
                {
                    return Ok(mapper.Map<RoboterDto>(updateRoboter));
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("[controller]/{roboterId:guid}")]
        public async Task<IActionResult> DeleteRoboterAsysnc([FromRoute] Guid roboterId)
        {
            if (await roboterRepository.Exists(roboterId))
            {
                var roboter = await roboterRepository.DeleteRoboter(roboterId);
                return Ok(mapper.Map<RoboterDto>(roboter));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddRoboterAsync([FromBody] AddRoboterRequest request)
        {
            var roboter = await roboterRepository.AddRoboter(mapper.Map<Roboter>(request));
            return CreatedAtAction(nameof(GetRoboterAsync), new { roboterId = roboter.Id },
                mapper.Map<RoboterDto>(roboter));
        }
    }
}
