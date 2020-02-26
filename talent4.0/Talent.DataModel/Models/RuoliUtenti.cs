using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RuoliUtenti
    {
        public RuoliUtenti()
        {
            RuoliUtentiDescr = new HashSet<RuoliUtentiDescr>();
            TalentRuoliTipiAbilitazione = new HashSet<TalentRuoliTipiAbilitazione>();
            Utenti = new HashSet<Utenti>();
        }

        public string Ruolo { get; set; }
        public DateTime RuoloInsTimestamp { get; set; }
        public string RuoloInsUteId { get; set; }
        public DateTime RuoloModTimestamp { get; set; }
        public string RuoloModUteId { get; set; }
        public string RuoloCliId { get; set; }
        public string RuoloAbilitato { get; set; }
        public string RuoloSystem { get; set; }

        public virtual Utenti Ruolo1 { get; set; }
        public virtual Clienti RuoloCli { get; set; }
        public virtual Utenti RuoloNavigation { get; set; }
        public virtual ICollection<RuoliUtentiDescr> RuoliUtentiDescr { get; set; }
        public virtual ICollection<TalentRuoliTipiAbilitazione> TalentRuoliTipiAbilitazione { get; set; }
        public virtual ICollection<Utenti> Utenti { get; set; }
    }
}
