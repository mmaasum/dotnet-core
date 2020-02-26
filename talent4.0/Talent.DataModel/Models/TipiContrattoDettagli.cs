using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiContrattoDettagli
    {
        public TipiContrattoDettagli()
        {
            RisorseContrattiRetribuzione = new HashSet<RisorseContrattiRetribuzione>();
        }

        public int TipcontrdettId { get; set; }
        public string TipcontrdettTipoContratto { get; set; }
        public string TipcontrdettDescrizione { get; set; }
        public string TipcontrdettObbligatorio { get; set; }
        public string TipcontrdettNumerico { get; set; }
        public string TipcontrdettUnmis { get; set; }
        public string TipcontrdettCalcStip { get; set; }
        public string TipcontrdettNetto { get; set; }
        public DateTime TipcontrdettInsTimestamp { get; set; }
        public string TipcontrdettInsUteId { get; set; }
        public DateTime TipcontrdettModTimestamp { get; set; }
        public string TipcontrdettModUteId { get; set; }
        public string TipcontrdettCliId { get; set; }

        public virtual Utenti Tipcontrdett { get; set; }
        public virtual TipiContratto Tipcontrdett1 { get; set; }
        public virtual UnitaMisura Tipcontrdett2 { get; set; }
        public virtual Clienti TipcontrdettCli { get; set; }
        public virtual Utenti TipcontrdettNavigation { get; set; }
        public virtual ICollection<RisorseContrattiRetribuzione> RisorseContrattiRetribuzione { get; set; }
    }
}
