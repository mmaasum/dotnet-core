using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class UtentiUtentiAbilitazioni
    {
        public int UteuteabId { get; set; }
        public string UteuteabUteId { get; set; }
        public string UteuteabProcedura { get; set; }
        public string UteuteabUteabAbilitato { get; set; }
        public string UteuteabCliId { get; set; }

        public virtual Utenti Uteuteab { get; set; }
        public virtual Clienti UteuteabCli { get; set; }
    }
}
