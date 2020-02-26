using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentTipiAbilitazione
    {
        public TalentTipiAbilitazione()
        {
            TalentRuoliTipiAbilitazione = new HashSet<TalentRuoliTipiAbilitazione>();
            TalentTipiAbilitazioneDescr = new HashSet<TalentTipiAbilitazioneDescr>();
            UtentiAbilitazioni = new HashSet<UtentiAbilitazioni>();
        }

        public string TipoabilitProcedura { get; set; }
        public DateTime TipoabilitInsTimestamp { get; set; }
        public DateTime TipoabilitModTimestamp { get; set; }

        public virtual ICollection<TalentRuoliTipiAbilitazione> TalentRuoliTipiAbilitazione { get; set; }
        public virtual ICollection<TalentTipiAbilitazioneDescr> TalentTipiAbilitazioneDescr { get; set; }
        public virtual ICollection<UtentiAbilitazioni> UtentiAbilitazioni { get; set; }
    }
}
