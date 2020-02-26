using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiContratto
    {
        public TipiContratto()
        {
            RisorseContratti = new HashSet<RisorseContratti>();
            TipiContrattoDettagli = new HashSet<TipiContrattoDettagli>();
        }

        public string TipoContratto { get; set; }
        public string TipcontrDescrizione { get; set; }
        public string TipcontrNote { get; set; }
        public DateTime TipcontrInsTimestamp { get; set; }
        public string TipcontrInsUteId { get; set; }
        public DateTime TipcontrModTimestamp { get; set; }
        public string TipcontrModUteId { get; set; }
        public string TipcontrDescrizioneBreve { get; set; }
        public string TipcontrUsoInterno { get; set; }
        public string TipcontrCliId { get; set; }

        public virtual Utenti Tipcontr { get; set; }
        public virtual Clienti TipcontrCli { get; set; }
        public virtual Utenti TipcontrNavigation { get; set; }
        public virtual ICollection<RisorseContratti> RisorseContratti { get; set; }
        public virtual ICollection<TipiContrattoDettagli> TipiContrattoDettagli { get; set; }
    }
}
