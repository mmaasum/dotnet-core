using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentLingueDescr
    {
        public string TlngdescrTlngLingua { get; set; }
        public string TlngdescrDescrizione { get; set; }
        public string TlngdescrLingua { get; set; }
        public DateTime TlngdescrInsTimestamp { get; set; }
        public DateTime TipoabilitModTimestamp { get; set; }

        public virtual TalentLingue TlngdescrLinguaNavigation { get; set; }
        public virtual TalentLingue TlngdescrTlngLinguaNavigation { get; set; }
    }
}
