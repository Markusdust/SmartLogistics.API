using AutoMapper;
using DataModels = SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps
{
    public class UpdateKundeRequestAfterMap : IMappingAction<UpdateKundeRequest, DataModels.Kunde>
    {
        public void Process(UpdateKundeRequest source, DataModels.Kunde destination, ResolutionContext context)
        {
            destination.Adresse = new DataModels.Adresse()
            {
                Strasse = source.Strasse,
                Hausnummer = source.Hausnummer
            };
        }
    }
}
