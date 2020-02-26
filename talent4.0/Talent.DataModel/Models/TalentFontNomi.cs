using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentFontNomi
    {
        public TalentFontNomi()
        {
            TalentGriglieCampiUtenti = new HashSet<TalentGriglieCampiUtenti>();
            TalentGriglieUtenti = new HashSet<TalentGriglieUtenti>();
        }

        public string TntfontNomeFont { get; set; }
        public DateTime TntfontInsTimestamp { get; set; }
        public DateTime TntfontModTimestamp { get; set; }

        public virtual ICollection<TalentGriglieCampiUtenti> TalentGriglieCampiUtenti { get; set; }
        public virtual ICollection<TalentGriglieUtenti> TalentGriglieUtenti { get; set; }
    }
}
