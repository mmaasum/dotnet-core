using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentTipiAbilitazioneDescr
    {
        public string TabildescrProcedura { get; set; }
        public string TabildescrDescrizione { get; set; }
        public string TabildescrLingua { get; set; }
        public DateTime TabildescrInsTimestamp { get; set; }
        public DateTime TipoabilitModTimestamp { get; set; }

        public virtual TalentTipiAbilitazione TabildescrProceduraNavigation { get; set; }
    }
}
