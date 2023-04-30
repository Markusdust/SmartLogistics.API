using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.ProduktAfterMaps
{
    public class UpdateProduktRequestAfterMap : IMappingAction<UpdateProduktRequest, DataModels.Produkt>
    {
        public void Process(UpdateProduktRequest source, DataModels.Produkt destination, ResolutionContext context)
        {
        }
    }
}
