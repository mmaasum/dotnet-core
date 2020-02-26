using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiTermineDescr
    {
        public string TipterdescrTipoTermine { get; set; }
        public string TipterdescrDescrizione { get; set; }
        public string TipterdescrLingua { get; set; }
        public DateTime TipterdescrInsTimestamp { get; set; }
        public string TipterdescrInsUteId { get; set; }
        public DateTime TipterdescrModTimestamp { get; set; }
        public string TipterdescrModUteId { get; set; }
        public string TipterdescrTipterCliId { get; set; }

        public virtual TipiTermine TipterdescrTip { get; set; }
    }
}
