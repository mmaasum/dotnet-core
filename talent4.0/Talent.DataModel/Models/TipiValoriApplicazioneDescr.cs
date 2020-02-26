using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiValoriApplicazioneDescr
    {
        public string TipappdescrMenu { get; set; }
        public string TipappdescrValore { get; set; }
        public int TipappdescrOrdine { get; set; }
        public string TipappdescrLingua { get; set; }
        public DateTime TipappdescrInsTimestamp { get; set; }
        public DateTime TipappdescrModTimestamp { get; set; }

        public virtual TipiValoriApplicazione Tipappdescr { get; set; }
    }
}
