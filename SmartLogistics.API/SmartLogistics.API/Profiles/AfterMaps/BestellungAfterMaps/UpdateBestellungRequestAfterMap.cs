using AutoMapper;
using SmartLogistics.API.DomainModels.UpdateDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.BestellungAfterMaps
{
    public class UpdateBestellungRequestAfterMap : IMappingAction<UpdateBestellungRequest, DataModels.Bestellung>
    {
        public void Process(UpdateBestellungRequest source, DataModels.Bestellung destination, ResolutionContext context)
        {
           
        }
    }
}
