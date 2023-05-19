using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.RoboterAfterMaps
{
    public class AddRoboterRequestAfterMap : IMappingAction<AddRoboterRequest, Roboter>
    {
        public void Process(AddRoboterRequest source, Roboter destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
