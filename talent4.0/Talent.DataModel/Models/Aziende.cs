using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Aziende
    {
        public Aziende()
        {
            AziendeClientiFinali = new HashSet<AziendeClientiFinali>();
            Contatti = new HashSet<Contatti>();
            RichiesteLuoghiLavoro = new HashSet<RichiesteLuoghiLavoro>();
            SediAziende = new HashSet<SediAziende>();
        }

        public int AzId { get; set; }
        public string AzRagSociale { get; set; }
        public string AzDescrizione { get; set; }
        public string AzIndirizzo { get; set; }
        public string AzCitta { get; set; }
        public string AzSitoWeb { get; set; }
        public string AzEmail1 { get; set; }
        public string AzEmail2 { get; set; }
        public string AzTelefono1 { get; set; }
        public string AzTelefono2 { get; set; }
        public DateTime AzInsTimestamp { get; set; }
        public string AzInsUteId { get; set; }
        public DateTime AzModTimestamp { get; set; }
        public string AzModUteId { get; set; }
        public string AzSiglaRichiesta { get; set; }
        public string AzCap { get; set; }
        public string AzTipoAzienda { get; set; }
        public string AzAttiva { get; set; }
        public string AzCvIniziali { get; set; }
        public string AzUteIdComm { get; set; }
        public string AzCollLuogo1 { get; set; }
        public string AzCollLuogo1Indic { get; set; }
        public string AzCollLuogo2 { get; set; }
        public string AzCollLuogo2Indic { get; set; }
        public string AzCollLuogo3 { get; set; }
        public string AzCollLuogo3Indic { get; set; }
        public string AzNote { get; set; }
        public int AzPriormin { get; set; }
        public int AzPriormax { get; set; }
        public string AzCliId { get; set; }
        public decimal? AzLocationLat { get; set; }
        public decimal? AzLocationLong { get; set; }

        public virtual Utenti Az { get; set; }
        public virtual Utenti Az1 { get; set; }
        public virtual Clienti AzCli { get; set; }
        public virtual Utenti AzNavigation { get; set; }
        public virtual ICollection<AziendeClientiFinali> AziendeClientiFinali { get; set; }
        public virtual ICollection<Contatti> Contatti { get; set; }
        public virtual ICollection<RichiesteLuoghiLavoro> RichiesteLuoghiLavoro { get; set; }
        public virtual ICollection<SediAziende> SediAziende { get; set; }
    }
}
