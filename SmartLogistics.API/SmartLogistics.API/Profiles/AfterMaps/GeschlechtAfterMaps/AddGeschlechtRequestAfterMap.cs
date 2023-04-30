using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels.AddDomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.GeschlechtAfterMaps
{
    public class AddGeschlechtRequestAfterMap : IMappingAction<AddGeschlechtRequest, Geschlecht>
    {
        public void Process(AddGeschlechtRequest source, Geschlecht destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
