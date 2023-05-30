﻿using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.DomainModels
{
    public class BestellungDto
    {
        public Guid Id { get; set; }
        public Guid ProduktId { get; set; }
        public DateTime Erfassdatum { get; set; }
        public DateTime LieferungStart { get; set; }
        public DateTime LieferungEnde { get; set; }
        public Guid KundeId { get; set; }
        public string Prioritaet { get; set; }
        public string Lieferart { get; set; }
        public string Status { get; set; }
        public Produkt Produkt { get; set; }
        public Kunde Kunde { get; set; }
    }
}
