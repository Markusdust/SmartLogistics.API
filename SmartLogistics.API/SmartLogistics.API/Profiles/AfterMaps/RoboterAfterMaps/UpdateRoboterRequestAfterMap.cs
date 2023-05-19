using AutoMapper;
using SmartLogistics.API.DomainModels.UpdateDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.RoboterAfterMaps
{
    public class UpdateRoboterRequestAfterMap : IMappingAction<UpdateRoboterRequest, DataModels.Roboter>
    {
        public void Process(UpdateRoboterRequest source, DataModels.Roboter destination, ResolutionContext context)
        {
        }
    }
}
