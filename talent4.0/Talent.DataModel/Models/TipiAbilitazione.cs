using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAbilitazione
    {
        public TipiAbilitazione()
        {
            RuoliTipiAbilitazione = new HashSet<RuoliTipiAbilitazione>();
            TipiAbilitazioneDescr = new HashSet<TipiAbilitazioneDescr>();
        }

        public string TipoabilitProcedura { get; set; }
        public DateTime TipoabilitInsTimestamp { get; set; }
        public DateTime TipoabilitModTimestamp { get; set; }

        public virtual ICollection<RuoliTipiAbilitazione> RuoliTipiAbilitazione { get; set; }
        public virtual ICollection<TipiAbilitazioneDescr> TipiAbilitazioneDescr { get; set; }
    }
}
