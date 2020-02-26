using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class LinguaLivelli
    {
        public LinguaLivelli()
        {
            RisorseLingueRislingue3 = new HashSet<RisorseLingue>();
            RisorseLingueRislingue4 = new HashSet<RisorseLingue>();
            RisorseLingueRislingueNavigation = new HashSet<RisorseLingue>();
        }

        public int LinguaLivello { get; set; }
        public string LingualivClass1 { get; set; }
        public string LingualivClass1Descr { get; set; }
        public string LingualivClass2 { get; set; }
        public string LingualivClass2Descr { get; set; }
        public string LingualivClass3 { get; set; }
        public string LingualivClass3Descr { get; set; }
        public DateTime LingualivInsTimestamp { get; set; }
        public string LingualivInsUteId { get; set; }
        public DateTime LingualivModTimestamp { get; set; }
        public string LingualivModUteId { get; set; }
        public string LingualivCliId { get; set; }

        public virtual Utenti Lingualiv { get; set; }
        public virtual Clienti LingualivCli { get; set; }
        public virtual Utenti LingualivNavigation { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingueRislingue3 { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingueRislingue4 { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingueRislingueNavigation { get; set; }
    }
}
