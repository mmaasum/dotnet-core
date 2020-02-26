using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class UtentiAbilitazioni
    {
        public int UteabId { get; set; }
        public string UteabUteId { get; set; }
        public string UteabProcedura { get; set; }
        public string UteabAbilitato { get; set; }
        public DateTime UteabInsTimestamp { get; set; }
        public string UteabInsUteId { get; set; }
        public DateTime UteabModTimestamp { get; set; }
        public string UteabModUteId { get; set; }
        public string UteabCliId { get; set; }

        public virtual Utenti Uteab { get; set; }
        public virtual Utenti Uteab1 { get; set; }
        public virtual Clienti UteabCli { get; set; }
        public virtual Utenti UteabNavigation { get; set; }
        public virtual TalentTipiAbilitazione UteabProceduraNavigation { get; set; }
    }
}
