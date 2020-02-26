using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SoftskillsCompetenze
    {
        public SoftskillsCompetenze()
        {
            SoftskillsCompetenzeDescr = new HashSet<SoftskillsCompetenzeDescr>();
        }

        public string SskcompCompetenza { get; set; }
        public int SskcompIdPlay { get; set; }
        public DateTime SskcompInsTimestamp { get; set; }
        public DateTime SskcompModTimestamp { get; set; }
        public string SskcompVariabilePlay { get; set; }
        public string SskcompLivello { get; set; }

        public virtual ICollection<SoftskillsCompetenzeDescr> SoftskillsCompetenzeDescr { get; set; }
    }
}
