using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzioneRichiesta
    {
        public string TipoAzioneRichiesta { get; set; }
        public DateTime TipazrichInsTimestamp { get; set; }
        public string TipazrichInsUteId { get; set; }
        public DateTime TipazrichModTimestamp { get; set; }
        public string TipazrichModUteId { get; set; }
        public string TipazrichCliId { get; set; }

        public virtual Utenti Tipazrich { get; set; }
        public virtual Clienti TipazrichCli { get; set; }
        public virtual Utenti TipazrichNavigation { get; set; }
    }
}
