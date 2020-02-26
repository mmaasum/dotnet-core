using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiTermine
    {
        public TipiTermine()
        {
            Termini = new HashSet<Termini>();
            TipiTermineDescr = new HashSet<TipiTermineDescr>();
        }

        public string TipoTermine { get; set; }
        public DateTime TipterInsTimestamp { get; set; }
        public string TipterInsUteId { get; set; }
        public DateTime TipterModTimestamp { get; set; }
        public string TipterModUteId { get; set; }
        public string TipterCliId { get; set; }

        public virtual Utenti Tipter { get; set; }
        public virtual Clienti TipterCli { get; set; }
        public virtual Utenti TipterNavigation { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
        public virtual ICollection<TipiTermineDescr> TipiTermineDescr { get; set; }
    }
}
