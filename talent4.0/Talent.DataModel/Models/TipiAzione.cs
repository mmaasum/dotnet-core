using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzione
    {
        public TipiAzione()
        {
            Azioni = new HashSet<Azioni>();
            TipiAzioneDescr = new HashSet<TipiAzioneDescr>();
        }

        public string TipazioneTipoAzione { get; set; }
        public DateTime TipazioneInsTimestamp { get; set; }
        public DateTime TipazioneModTimestamp { get; set; }
        public string TipazioneTipazionecatCodice { get; set; }

        public virtual TipiAzioneCategoria TipazioneTipazionecatCodiceNavigation { get; set; }
        public virtual ICollection<Azioni> Azioni { get; set; }
        public virtual ICollection<TipiAzioneDescr> TipiAzioneDescr { get; set; }
    }
}
