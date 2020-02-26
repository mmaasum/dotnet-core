using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentFiltriPagineUtenti
    {
        public long TntfilFiltropaguteId { get; set; }
        public long TntfilFiltropaguteFiltropagId { get; set; }
        public string TntfilFiltropaguteUteId { get; set; }
        public string TntfilFiltropaguteCliId { get; set; }
        public string TntfilFiltropaguteDefault { get; set; }
        public int TntfilFiltropaguteOrdine { get; set; }
        public int TntfilFiltropaguteBottone { get; set; }
        public string TntfilFiltropaguteBottoneLabel { get; set; }
        public DateTime TntfilFiltropaguteInsTimestamp { get; set; }
        public string TntfilFiltropaguteInsUteId { get; set; }
        public DateTime TntfilFiltropaguteModTimestamp { get; set; }
        public string TntfilFiltropaguteModUteId { get; set; }

        public virtual Utenti TntfilFiltropagute { get; set; }
        public virtual Utenti TntfilFiltropagute1 { get; set; }
        public virtual Clienti TntfilFiltropaguteCli { get; set; }
        public virtual TalentFiltriPagine TntfilFiltropaguteFiltropag { get; set; }
        public virtual Utenti TntfilFiltropaguteNavigation { get; set; }
    }
}
