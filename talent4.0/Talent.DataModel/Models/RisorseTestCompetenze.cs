using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseTestCompetenze
    {
        public int RisId { get; set; }
        public string RisNome { get; set; }
        public string RisCognome { get; set; }
        public string RisCliId { get; set; }

        public virtual Clienti RisCli { get; set; }
    }
}
