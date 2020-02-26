using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatiTermine
    {
        public StatiTermine()
        {
            StatiTermineDescr = new HashSet<StatiTermineDescr>();
            Termini = new HashSet<Termini>();
        }

        public string SterStato { get; set; }
        public string SterDescrizione { get; set; }
        public DateTime SterInsTimestamp { get; set; }
        public DateTime SterModTimestamp { get; set; }

        public virtual ICollection<StatiTermineDescr> StatiTermineDescr { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
    }
}
