using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class StatiTermineDescr
    {
        public string SterdescrSterStato { get; set; }
        public string SterdescrLingua { get; set; }
        public string SterdescrDescrizione { get; set; }
        public DateTime SterdescrInsTimestamp { get; set; }
        public DateTime SterdescrModTimestamp { get; set; }

        public virtual StatiTermine SterdescrSterStatoNavigation { get; set; }
    }
}
