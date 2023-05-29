using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.BestellungAfterMaps
{
    public class AddBestellungRequestAfterMap: IMappingAction<AddBestellungRequest, Bestellung>
    {
        public void Process(AddBestellungRequest source, Bestellung destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
