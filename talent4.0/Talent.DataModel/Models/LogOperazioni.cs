using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class LogOperazioni
    {
        public int LogId { get; set; }
        public DateTime LogTimestamp { get; set; }
        public string LogUteId { get; set; }
        public string LogDescr { get; set; }
        public string LogDettaglio { get; set; }
        public string LogAccAccountEmail { get; set; }
        public string LogCliId { get; set; }

        public virtual Utenti Log { get; set; }
        public virtual Clienti LogCli { get; set; }
    }
}
