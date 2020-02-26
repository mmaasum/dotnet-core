using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiLivelliLingue
    {
        public string TiplivlingId { get; set; }
        public string TiplivlingDescrizione { get; set; }
        public string TiplivlingDescrizioneEstesa { get; set; }
        public string TiplivlingAttivo { get; set; }
        public int TiplivlingOrdine { get; set; }
        public DateTime TiplivlingInsTimestamp { get; set; }
        public string TiplivlingInsUteId { get; set; }
        public DateTime TiplivlingModTimestamp { get; set; }
        public string TiplivlingModUteId { get; set; }
        public string TiplivlingCliId { get; set; }

        public virtual Utenti Tiplivling { get; set; }
        public virtual Clienti TiplivlingCli { get; set; }
        public virtual Utenti TiplivlingNavigation { get; set; }
    }
}
