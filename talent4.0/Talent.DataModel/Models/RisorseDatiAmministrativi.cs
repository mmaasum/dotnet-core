using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseDatiAmministrativi
    {
        public int RisdammId { get; set; }
        public int RisdammRisId { get; set; }
        public string RisdammCodiceFiscale { get; set; }
        public string RisdammPartitaIva { get; set; }
        public string RisdammResidenza { get; set; }
        public string RisdammDomicilio { get; set; }
        public string RisdammBeniAssegnati { get; set; }
        public DateTime RisdammInsTimestamp { get; set; }
        public string RisdammInsUteId { get; set; }
        public DateTime RisdammModTimestamp { get; set; }
        public string RisdammModUteId { get; set; }
        public string RisdammCliId { get; set; }

        public virtual Utenti Risdamm { get; set; }
        public virtual Risorse Risdamm1 { get; set; }
        public virtual Clienti RisdammCli { get; set; }
        public virtual Utenti RisdammNavigation { get; set; }
    }
}
