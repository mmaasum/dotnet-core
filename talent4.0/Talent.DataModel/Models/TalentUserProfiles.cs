using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentUserProfiles
    {
        public string TauseUteId { get; set; }
        public string TauseDefaultLanguage { get; set; }
        public string TauseLandingPage { get; set; }
        public DateTime TauseInsTimestamp { get; set; }
        public string TauseInsUteId { get; set; }
        public DateTime TauseModTimestamp { get; set; }
        public string TauseModUteId { get; set; }
        public string TauseCliId { get; set; }

        public virtual Utenti Tause { get; set; }
        public virtual Clienti TauseCli { get; set; }
        public virtual Utenti TauseNavigation { get; set; }
    }
}
