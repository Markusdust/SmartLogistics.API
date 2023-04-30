using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.ProduktAfterMaps
{
    public class AddProduktRequestAfterMap : IMappingAction<AddProduktRequest, Produkt>
    {
        public void Process(AddProduktRequest source, Produkt destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
