using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class UtentiImpostazioniGriglie
    {
        public int UteimpgridId { get; set; }
        public string UteimpgridUtente { get; set; }
        public string UteimpgridNomeGriglia { get; set; }
        public string UteimpgridNomeColonna { get; set; }
        public int? UteimpgridColonnaIndex { get; set; }
        public bool? UteimpgridColonnaVisible { get; set; }
        public int? UteimpgridColonnaLarghezza { get; set; }
        public DateTime? UteimpgridInsTimestamp { get; set; }
        public string UteimpgridInsUteId { get; set; }
        public DateTime? UteimpgridModTimestamp { get; set; }
        public string UteimpgridModUteId { get; set; }
        public string UteimpgridCliId { get; set; }

        public virtual Utenti Uteimpgr { get; set; }
        public virtual Utenti Uteimpgr1 { get; set; }
        public virtual Utenti UteimpgrNavigation { get; set; }
        public virtual Clienti UteimpgridCli { get; set; }
    }
}
