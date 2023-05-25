using AutoMapper;
using SmartLogistics.API.DomainModels.UpdateDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.LagerverwaltungAfterMaps
{
    public class UpdateLagerverwaltungRequestAfterMap : IMappingAction<UpdateLagerverwaltungRequest, DataModels.Lagerverwaltung>
    {
        public void Process(UpdateLagerverwaltungRequest source, DataModels.Lagerverwaltung destination, ResolutionContext context)
        {
        }
    }
}
