using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentGriglieCampi
    {
        public string TntgcNomeCampo { get; set; }
        public string TntgcTntgridNomeGriglia { get; set; }
        public string TntgcDescrizione { get; set; }
        public string TntgcNomeCampoDb { get; set; }
        public DateTime TntgcInsTimestamp { get; set; }
        public DateTime TntgcModTimestamp { get; set; }
        public string TntgcFromList { get; set; }
        public string TntgcJoinWhereCondition { get; set; }
        public string TntgcAttivo { get; set; }

        public virtual TalentGriglie TntgcTntgridNomeGrigliaNavigation { get; set; }
    }
}
