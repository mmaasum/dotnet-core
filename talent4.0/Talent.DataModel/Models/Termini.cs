using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Termini
    {
        public string Termine { get; set; }
        public string TerTipoTermine { get; set; }
        public string TerSinonimo1 { get; set; }
        public string TerSinonimo2 { get; set; }
        public string TerSinonimo3 { get; set; }
        public string TerSinonimo4 { get; set; }
        public string TerSinonimo5 { get; set; }
        public string TerSinonimo6 { get; set; }
        public string TerSinonimo7 { get; set; }
        public string TerSinonimo8 { get; set; }
        public string TerNote { get; set; }
        public DateTime TerInsTimestamp { get; set; }
        public string TerInsUteId { get; set; }
        public DateTime TerModTimestamp { get; set; }
        public string TerModUteId { get; set; }
        public string TerDescrizione { get; set; }
        public string TerLink { get; set; }
        public string TerCliId { get; set; }
        public string TerStato { get; set; }
        public int? TerFrequenza { get; set; }
        public string TerLingua { get; set; }

        public virtual Utenti Ter { get; set; }
        public virtual TipiTermine Ter1 { get; set; }
        public virtual Clienti TerCli { get; set; }
        public virtual TalentLingue TerLinguaNavigation { get; set; }
        public virtual Utenti TerNavigation { get; set; }
        public virtual StatiTermine TerStatoNavigation { get; set; }
    }
}
