using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RuoliTipiAbilitazione
    {
        public string RuoltipabRuolo { get; set; }
        public string RuoltipabUteabProcedura { get; set; }
        public DateTime RuoltipabUteabInsTimestamp { get; set; }
        public DateTime RuoltipabUteabModTimestamp { get; set; }
        public string RuoltipabCliId { get; set; }

        public virtual RuoliUtenti Ruoltipab { get; set; }
        public virtual Clienti RuoltipabCli { get; set; }
        public virtual TipiAbilitazione RuoltipabUteabProceduraNavigation { get; set; }
    }
}
