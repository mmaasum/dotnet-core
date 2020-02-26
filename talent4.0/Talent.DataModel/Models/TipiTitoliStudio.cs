using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiTitoliStudio
    {
        public string TiptitstudId { get; set; }
        public string TiptitstudDescrizione { get; set; }
        public string TiptitstudAttivo { get; set; }
        public int TiptitstudOrdine { get; set; }
        public DateTime TiptitstudInsTimestamp { get; set; }
        public string TiptitstudInsUteId { get; set; }
        public DateTime TiptitstudModTimestamp { get; set; }
        public string TiptitstudModUteId { get; set; }
        public string TiptitstudCliId { get; set; }

        public virtual Utenti Tiptitstud { get; set; }
        public virtual Clienti TiptitstudCli { get; set; }
        public virtual Utenti TiptitstudNavigation { get; set; }
    }
}
