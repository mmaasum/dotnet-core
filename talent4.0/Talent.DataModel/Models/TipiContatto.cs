using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiContatto
    {
        public TipiContatto()
        {
            Contatti = new HashSet<Contatti>();
        }

        public string TipoContatto { get; set; }
        public DateTime TipcontInsTimestamp { get; set; }
        public string TipcontInsUteId { get; set; }
        public DateTime TipcontModTimestamp { get; set; }
        public string TipcontModUteId { get; set; }
        public string TipcontCliId { get; set; }

        public virtual Utenti Tipcont { get; set; }
        public virtual Clienti TipcontCli { get; set; }
        public virtual Utenti TipcontNavigation { get; set; }
        public virtual ICollection<Contatti> Contatti { get; set; }
    }
}
