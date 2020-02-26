using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class UtentiMenuDmo
    {
        public int TntmenuId { get; set; }
        public string TntmenuNome { get; set; }
        public byte? TntmenuLivello { get; set; }
        public string TntmenuRouterlink { get; set; }
        public int? TntmenuParentid { get; set; }
        public string TntmenuLingua { get; set; }

        public bool? TntmenuHasubmenu { get; set; }
        public bool? TntmenuIsdefault { get; set; }
        public bool? TntmenuAttivo { get; set; }
        public byte? TntmenuOrdinamento { get; set; }

        public string TntmenuUteabProcedura { get; set; }
        public string TntmenuTntfilPaginaCodice { get; set; }
    }
}
