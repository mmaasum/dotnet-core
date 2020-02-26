using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzienda
    {
        public string TipoAzienda { get; set; }
        public DateTime TipazInsTimestamp { get; set; }
        public string TipazInsUteId { get; set; }
        public DateTime TipazModTimestamp { get; set; }
        public string TipazModUteId { get; set; }
        public string TipazCliId { get; set; }

        public virtual Utenti Tipaz { get; set; }
        public virtual Clienti TipazCli { get; set; }
        public virtual Utenti TipazNavigation { get; set; }
    }
}
