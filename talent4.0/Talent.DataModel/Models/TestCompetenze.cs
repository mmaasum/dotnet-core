using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TestCompetenze
    {
        public int TscompId { get; set; }
        public string TscompTest { get; set; }
        public string TscompCompetenza { get; set; }
        public DateTime TscompInsTimestamp { get; set; }
        public string TscompInsUteId { get; set; }
        public DateTime TscompModTimestamp { get; set; }
        public string TscompModUteId { get; set; }
        public string TscompCliId { get; set; }

        public virtual TestValutazione Tscomp { get; set; }
        public virtual Clienti TscompCli { get; set; }
    }
}
