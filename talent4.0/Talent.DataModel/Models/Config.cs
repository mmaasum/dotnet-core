using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Config
    {
        public int ConfigId { get; set; }
        public string ConfigParamName { get; set; }
        public string ConfigParam { get; set; }
        public string ConfigNoteParam { get; set; }
        public string ConfigInsUteId { get; set; }
        public DateTime ConfigInsTimestamp { get; set; }
        public string ConfigModUteId { get; set; }
        public DateTime ConfigModTimestamp { get; set; }
        public string ConfigCliId { get; set; }

        public virtual Utenti Config1 { get; set; }
        public virtual Clienti ConfigCli { get; set; }
        public virtual Utenti ConfigNavigation { get; set; }
    }
}
