using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseContrattiRetribuzione
    {
        public int RiscontrretrId { get; set; }
        public string RiscontrretrRiscontrId { get; set; }
        public int RiscontrretrTipcontrdettId { get; set; }
        public DateTime RiscontrretrDataInizio { get; set; }
        public DateTime? RiscontrretrDataFine { get; set; }
        public decimal RiscontrretrImporto { get; set; }
        public DateTime RiscontrretrInsTimestamp { get; set; }
        public string RiscontrretrInsUteId { get; set; }
        public DateTime RiscontrretrModTimestamp { get; set; }
        public string RiscontrretrModUteId { get; set; }
        public string RiscontrretrCliId { get; set; }

        public virtual Utenti Riscontrretr { get; set; }
        public virtual RisorseContratti Riscontrretr1 { get; set; }
        public virtual TipiContrattoDettagli Riscontrretr2 { get; set; }
        public virtual Clienti RiscontrretrCli { get; set; }
        public virtual Utenti RiscontrretrNavigation { get; set; }
    }
}
