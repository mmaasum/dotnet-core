using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Lingue
    {
        public Lingue()
        {
            RisorseAltriDati = new HashSet<RisorseAltriDati>();
            RisorseLingue = new HashSet<RisorseLingue>();
        }

        public string Lingua { get; set; }
        public int LinguaOrdine { get; set; }
        public DateTime? LinguaInsTimestamp { get; set; }
        public string LinguaInsUteId { get; set; }
        public DateTime LinguaModTimestamp { get; set; }
        public string LinguaModUteId { get; set; }
        public string LinguaCliId { get; set; }

        public virtual Utenti Lingua1 { get; set; }
        public virtual Clienti LinguaCli { get; set; }
        public virtual Utenti LinguaNavigation { get; set; }
        public virtual ICollection<RisorseAltriDati> RisorseAltriDati { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingue { get; set; }
    }
}
