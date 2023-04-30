using AutoMapper;
using DataModels = SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.GeschlechtAfterMaps
{
    public class UpdateGeschlechtRequestAfterMap : IMappingAction<UpdateGeschlechtRequest, DataModels.Geschlecht>
    {
        public void Process(UpdateGeschlechtRequest source, DataModels.Geschlecht destination, ResolutionContext context)
        {

        }
    }
}
