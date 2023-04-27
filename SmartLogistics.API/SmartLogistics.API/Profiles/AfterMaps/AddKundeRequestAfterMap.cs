using AutoMapper;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;

namespace SmartLogistics.API.Profiles.AfterMaps
{
    public class AddKundeRequestAfterMap : IMappingAction<AddKundeRequest, DataModels.Kunde>
    {
        public void Process(AddKundeRequest source, Kunde destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Adresse = new DataModels.Adresse()
            {
                Id = Guid.NewGuid(),
                Strasse = source.Strasse,
                Hausnummer = source.Hausnummer,
                Ort= new DataModels.Ort()
                {
                    Id= Guid.NewGuid(),
                    Postleitzahl= source.Postleitzahl,
                    Ortschaft= source.Ortschaft
                }
            };
        }
    }
}
