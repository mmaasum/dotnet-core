using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class UnitaMisura
    {
        public UnitaMisura()
        {
            TipiContrattoDettagli = new HashSet<TipiContrattoDettagli>();
        }

        public string Unmis { get; set; }
        public string UnmisDescr { get; set; }
        public DateTime UnmisInsTimestamp { get; set; }
        public string UnmisInsUteId { get; set; }
        public DateTime UnmisModTimestamp { get; set; }
        public string UnmisModUteId { get; set; }
        public string UnmisCliId { get; set; }

        public virtual Clienti UnmisCli { get; set; }
        public virtual ICollection<TipiContrattoDettagli> TipiContrattoDettagli { get; set; }
    }
}
