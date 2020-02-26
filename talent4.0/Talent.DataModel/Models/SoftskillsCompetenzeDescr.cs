using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SoftskillsCompetenzeDescr
    {
        public string SskcompdescrCompetenza { get; set; }
        public string SskcompdescrDescrizione { get; set; }
        public string SskcompdescrLingua { get; set; }
        public DateTime SskcompdescrInsTimestamp { get; set; }
        public DateTime SskcompdescrModTimestamp { get; set; }

        public virtual SoftskillsCompetenze SskcompdescrCompetenzaNavigation { get; set; }
    }
}
