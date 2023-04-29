using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps
{
    public class AddGeschlechtRequestAfterMap : IMappingAction<AddGeschlechtRequest, DataModels.Geschlecht>
    {
        public void Process(AddGeschlechtRequest source, Geschlecht destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
        }
    }
}
