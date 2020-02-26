using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentLingue
    {
        public TalentLingue()
        {
            RuoliUtentiDescr = new HashSet<RuoliUtentiDescr>();
            TalentLingueClienti = new HashSet<TalentLingueClienti>();
            TalentLingueDescrTlngdescrLinguaNavigation = new HashSet<TalentLingueDescr>();
            TalentLingueDescrTlngdescrTlngLinguaNavigation = new HashSet<TalentLingueDescr>();
            Termini = new HashSet<Termini>();
        }

        public string TlngLingua { get; set; }
        public DateTime TlngInsTimestamp { get; set; }
        public DateTime TlngModTimestamp { get; set; }

        public virtual ICollection<RuoliUtentiDescr> RuoliUtentiDescr { get; set; }
        public virtual ICollection<TalentLingueClienti> TalentLingueClienti { get; set; }
        public virtual ICollection<TalentLingueDescr> TalentLingueDescrTlngdescrLinguaNavigation { get; set; }
        public virtual ICollection<TalentLingueDescr> TalentLingueDescrTlngdescrTlngLinguaNavigation { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
    }
}
