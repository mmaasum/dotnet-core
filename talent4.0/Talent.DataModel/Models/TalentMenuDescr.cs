using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentMenuDescr
    {
        public int TntmenudescrTntmenuId { get; set; }
        public string TntmenudescrDescrizione { get; set; }
        public string TntmenudescrLingua { get; set; }
        public DateTime TntmenudescrInsTimestamp { get; set; }
        public DateTime TipoabilitModTimestamp { get; set; }
        public string TntmenudescrTntmenuCliId { get; set; }

        public virtual TalentMenu TntmenudescrTntmenu { get; set; }
    }
}
