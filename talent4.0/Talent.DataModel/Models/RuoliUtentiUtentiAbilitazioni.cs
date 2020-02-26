using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RuoliUtentiUtentiAbilitazioni
    {
        public int RuoluteabId { get; set; }
        public string RuoluteabRuolo { get; set; }
        public string RuoluteabUteabProcedura { get; set; }
        public string RuoluteabUteabAbilitato { get; set; }
        public DateTime RuoluteabUteabInsTimestamp { get; set; }
        public string RuoluteabCliId { get; set; }

        public virtual RuoliUtenti Ruoluteab { get; set; }
        public virtual Clienti RuoluteabCli { get; set; }
    }
}
