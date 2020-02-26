using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatiRichiesta
    {
        public int StatrichId { get; set; }
        public string StatrichStato { get; set; }
        public DateTime StatrichInsTimestamp { get; set; }
        public string StatrichInsUteId { get; set; }
        public DateTime StatrichModTimestamp { get; set; }
        public string StatrichModUteId { get; set; }
        public string StatrichCliId { get; set; }

        public virtual Utenti Statrich { get; set; }
        public virtual Clienti StatrichCli { get; set; }
        public virtual Utenti StatrichNavigation { get; set; }
    }
}
