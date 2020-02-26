using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RpCommesse
    {
        public string RpcommCodice { get; set; }
        public string RpcommDescrizione { get; set; }
        public string RpcommNote { get; set; }
        public DateTime RpcommInsTimestamp { get; set; }
        public string RpcommInsUteId { get; set; }
        public DateTime RpcommModTimestamp { get; set; }
        public string RpcommModUteId { get; set; }
        public string RpcommCliId { get; set; }

        public virtual Utenti Rpcomm { get; set; }
        public virtual Clienti RpcommCli { get; set; }
        public virtual Utenti RpcommNavigation { get; set; }
    }
}
