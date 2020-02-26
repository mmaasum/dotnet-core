using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAppuntamento
    {
        public string TipoAppuntamento { get; set; }
        public DateTime TipoappInsTimestamp { get; set; }
        public string TipoappInsUteId { get; set; }
        public DateTime TipoappModTimestamp { get; set; }
        public string TipoappModUteId { get; set; }
        public string TipoappCliId { get; set; }

        public virtual Utenti Tipoapp { get; set; }
        public virtual Clienti TipoappCli { get; set; }
        public virtual Utenti TipoappNavigation { get; set; }
    }
}
