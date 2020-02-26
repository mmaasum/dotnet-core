using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentGriglie
    {
        public TalentGriglie()
        {
            TalentGriglieCampi = new HashSet<TalentGriglieCampi>();
            TalentGriglieUtenti = new HashSet<TalentGriglieUtenti>();
        }

        public string TntgrlNomeGriglia { get; set; }
        public string TntgrlTntfilPaginaCodice { get; set; }
        public DateTime TntgrlModTimestamp { get; set; }
        public DateTime TntgrlInsTimestamp { get; set; }

        public virtual TalentPagine TntgrlTntfilPaginaCodiceNavigation { get; set; }
        public virtual ICollection<TalentGriglieCampi> TalentGriglieCampi { get; set; }
        public virtual ICollection<TalentGriglieUtenti> TalentGriglieUtenti { get; set; }
    }
}
