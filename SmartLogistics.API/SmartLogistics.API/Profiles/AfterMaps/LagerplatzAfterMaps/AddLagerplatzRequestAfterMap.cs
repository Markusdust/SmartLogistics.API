using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.LagerplatzAfterMaps
{
    public class AddLagerplatzRequestAfterMap : IMappingAction<AddLagerplatzRequest, Lagerplatz>
    {
        public void Process(AddLagerplatzRequest source, Lagerplatz destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
