using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps.KundeAfterMaps
{
    public class AddKundeRequestAfterMap : IMappingAction<AddKundeRequest, Kunde>
    {
        public void Process(AddKundeRequest source, Kunde destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Adresse = new Adresse()
            {
                Id = Guid.NewGuid(),
                Strasse = source.Strasse,
                Hausnummer = source.Hausnummer,
                OrtId = source.OrtId
            };

        }
    }
}
