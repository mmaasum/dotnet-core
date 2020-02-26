using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiLingue
    {
        public string TiplingId { get; set; }
        public string TiplingDescrizione { get; set; }
        public string TiplingAttivo { get; set; }
        public int TiplingOrdine { get; set; }
        public DateTime TiplingInsTimestamp { get; set; }
        public string TiplingInsUteId { get; set; }
        public DateTime TiplingModTimestamp { get; set; }
        public string TiplingModUteId { get; set; }
        public string TiplingCliId { get; set; }

        public virtual Utenti Tipling { get; set; }
        public virtual Clienti TiplingCli { get; set; }
        public virtual Utenti TiplingNavigation { get; set; }
    }
}
