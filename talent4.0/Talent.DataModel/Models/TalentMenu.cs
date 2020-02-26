using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentMenu
    {
        public TalentMenu()
        {
            TalentMenuDescr = new HashSet<TalentMenuDescr>();
        }

        public int TntmenuId { get; set; }
        public string TntmenuTntfilPaginaCodice { get; set; }
        public string TntmenuDescrizione { get; set; }
        public byte? TntmenuLivello { get; set; }
        public int? TntmenuParentid { get; set; }
        public bool? TntmenuHasubmenu { get; set; }
        public bool? TntmenuIsdefault { get; set; }
        public bool? TntmenuAttivo { get; set; }
        public byte? TntmenuOrdinamento { get; set; }
        public string TntmenuCliId { get; set; }

        public virtual TalentPagine TntmenuTntfilPaginaCodiceNavigation { get; set; }
        public virtual ICollection<TalentMenuDescr> TalentMenuDescr { get; set; }
    }
}
