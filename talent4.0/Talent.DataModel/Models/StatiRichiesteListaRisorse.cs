using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatiRichiesteListaRisorse
    {
        public StatiRichiesteListaRisorse()
        {
            RichiesteListaRisorse = new HashSet<RichiesteListaRisorse>();
            StatiRichiesteListaRisorseDescr = new HashSet<StatiRichiesteListaRisorseDescr>();
        }

        public string StarichlistStato { get; set; }
        public DateTime StarichlistInsTimestamp { get; set; }
        public DateTime StarichlistModTimestamp { get; set; }
        public int? StarichlistWf { get; set; }

        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorse { get; set; }
        public virtual ICollection<StatiRichiesteListaRisorseDescr> StatiRichiesteListaRisorseDescr { get; set; }
    }
}
