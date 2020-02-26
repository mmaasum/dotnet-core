using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Abilitazioni
    {
        public int AbilitId { get; set; }
        public string AbilitProcedura { get; set; }
        public string AbilitDescrizioneProcedura { get; set; }
        public DateTime AbilitUteabInsTimestamp { get; set; }
        public string AbilitCliId { get; set; }

        public virtual Clienti AbilitCli { get; set; }
    }
}
