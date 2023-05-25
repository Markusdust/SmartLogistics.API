using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.LagerverwaltungAfterMaps
{
    public class AddLagerverwaltungRequestAfterMap : IMappingAction<AddLagerverwaltungRequest, Lagerverwaltung>
    {
        public void Process(AddLagerverwaltungRequest source, Lagerverwaltung destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
