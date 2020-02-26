using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewTalentGriglieCampiUtenti
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
        
        public string TntgcTntgridNomeGriglia { get; set; }
        public string TntgcDescrizione { get; set; }
        public string TntgcNomeCampoDb { get; set; }
        public string TntgcFromList { get; set; }
        public string TntgcJoinWhereCondition { get; set; }

        public bool isActive { get; set; }
        public string TntgcuFieldLabelDescription { get; set; }
    }
}
