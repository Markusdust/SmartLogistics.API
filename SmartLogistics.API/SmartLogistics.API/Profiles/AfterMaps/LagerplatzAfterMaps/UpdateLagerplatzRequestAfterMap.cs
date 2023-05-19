using AutoMapper;
using SmartLogistics.API.DomainModels.UpdateDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.LagerplatzAfterMaps
{
    public class UpdateLagerplatzRequestAfterMap : IMappingAction<UpdateLagerplatzRequest, DataModels.Lagerplatz>
    {
        public void Process(UpdateLagerplatzRequest source, DataModels.Lagerplatz destination, ResolutionContext context)
        {
        }
    }
}
