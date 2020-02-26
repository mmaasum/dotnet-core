using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAllegato
    {
        public int TipallId { get; set; }
        public string TipallGestione { get; set; }
        public string TipallDescrizione { get; set; }
        public int TipallOrdinamento { get; set; }
        public DateTime TipallInsTimestamp { get; set; }
        public string TipallInsUteId { get; set; }
        public DateTime TipallModTimestamp { get; set; }
        public string TipallModUteId { get; set; }
        public string TipallCliId { get; set; }

        public virtual Utenti Tipall { get; set; }
        public virtual Clienti TipallCli { get; set; }
        public virtual Utenti TipallNavigation { get; set; }
    }
}
