using AutoMapper;
using DataModels = SmartLogistics.API.DataModels;
using SmartLogistics.API.DomainModels;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.Profiles.AfterMaps.KundeAfterMaps;
using SmartLogistics.API.Profiles.AfterMaps.GeschlechtAfterMaps;

namespace SmartLogistics.API.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        {
            CreateMap<DataModels.Kunde, KundeDto>()
                .ReverseMap();

            CreateMap<DataModels.Adresse, AdresseDto>()
                .ReverseMap();

            CreateMap<DataModels.Ort, OrtDto>()
                .ReverseMap();

            CreateMap<DataModels.Geschlecht, GeschlechtDto>()
                .ReverseMap();

            CreateMap<DataModels.Bestellung, BestellungDto>()
                .ReverseMap();

            CreateMap<DataModels.Lieferung, LieferungDto>()
                .ReverseMap();

            CreateMap<DataModels.Produkt, ProduktDto>()
                .ReverseMap();

            CreateMap<DataModels.Roboter, RoboterDto>()
                .ReverseMap();

            CreateMap<UpdateKundeRequest, Kunde>()
                .AfterMap<UpdateKundeRequestAfterMap>();

            CreateMap<AddKundeRequest, DataModels.Kunde>()
                .AfterMap<AddKundeRequestAfterMap>();

            CreateMap<AddGeschlechtRequest, DataModels.Geschlecht>()
                .AfterMap<AddGeschlechtRequestAfterMap>();

            CreateMap<UpdateGeschlechtRequest, Geschlecht>()
                .AfterMap<UpdateGeschlechtRequestAfterMap>();

        }
    }
}
