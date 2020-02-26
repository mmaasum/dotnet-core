using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatiRichiesteListaRisorseDescr
    {
        public string StarichlistdescrStato { get; set; }
        public string StarichlistdescrLingua { get; set; }
        public string StarichlistdescrDescrizione { get; set; }
        public DateTime StarichlistdescrInsTimestamp { get; set; }
        public DateTime StarichlistModTimestamp { get; set; }

        public virtual StatiRichiesteListaRisorse StarichlistdescrStatoNavigation { get; set; }
    }
}
