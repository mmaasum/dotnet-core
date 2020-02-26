using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentGriglieCampiUtenti
    {
        public int TntgcuId { get; set; }
        public string TntgcuTntgcNomeCampo { get; set; }
        public string TntgcuUteId { get; set; }
        public string TntgcuCliId { get; set; }
        public string TntgcuTntfontNomeFont { get; set; }
        public int? TntgcuTntszFontDimensione { get; set; }
        public int? TntgcuOrdineVis { get; set; }
        public string TntgcuAllineamento { get; set; }
        public int? TntgcuMinSize { get; set; }
        public int? TntgcuMaxSize { get; set; }
        public string TntgcuAutoSize { get; set; }

        public virtual Utenti Tntgcu { get; set; }
        public virtual TalentFontNomi TntgcuTntfontNomeFontNavigation { get; set; }
        public virtual TalentFontDimensioni TntgcuTntszFontDimensioneNavigation { get; set; }
    }
}
