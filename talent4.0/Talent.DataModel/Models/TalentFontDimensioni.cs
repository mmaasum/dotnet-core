using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentFontDimensioni
    {
        public TalentFontDimensioni()
        {
            TalentGriglieCampiUtenti = new HashSet<TalentGriglieCampiUtenti>();
            TalentGriglieUtenti = new HashSet<TalentGriglieUtenti>();
        }

        public int TntszFontDimensione { get; set; }
        public DateTime TntszInsTimestamp { get; set; }
        public DateTime TntszModTimestamp { get; set; }

        public virtual ICollection<TalentGriglieCampiUtenti> TalentGriglieCampiUtenti { get; set; }
        public virtual ICollection<TalentGriglieUtenti> TalentGriglieUtenti { get; set; }
    }
}
