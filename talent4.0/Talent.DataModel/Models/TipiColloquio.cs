using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiColloquio
    {
        public int TipcollCod { get; set; }
        public string TipcollDescrizione { get; set; }
        public string TipcollCliId { get; set; }

        public virtual Clienti TipcollCli { get; set; }
    }
}
