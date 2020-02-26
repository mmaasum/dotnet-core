using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Candidature
    {
        public int CandId { get; set; }
        public int CandRisId { get; set; }
        public DateTime CandData { get; set; }
        public string CandSito { get; set; }
        public string CandAnnId { get; set; }
        public DateTime CandInsTimestamp { get; set; }
        public string CandInsUteId { get; set; }
        public DateTime CandModTimestamp { get; set; }
        public string CandModUteId { get; set; }
        public string CandCliId { get; set; }

        public virtual Utenti Cand { get; set; }
        public virtual Risorse Cand1 { get; set; }
        public virtual Clienti CandCli { get; set; }
        public virtual Utenti CandNavigation { get; set; }
    }
}
