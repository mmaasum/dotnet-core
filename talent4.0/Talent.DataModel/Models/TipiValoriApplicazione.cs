using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiValoriApplicazione
    {
        public TipiValoriApplicazione()
        {
            TipiValoriApplicazioneDescr = new HashSet<TipiValoriApplicazioneDescr>();
        }

        public string TipappMenu { get; set; }
        public string TipappValore { get; set; }
        public int TipappOrdine { get; set; }
        public DateTime TipappInsTimestamp { get; set; }
        public DateTime TipappModTimestamp { get; set; }

        public virtual ICollection<TipiValoriApplicazioneDescr> TipiValoriApplicazioneDescr { get; set; }
    }
}
