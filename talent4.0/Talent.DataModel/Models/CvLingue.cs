using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvLingue
    {
        public CvLingue()
        {
            CvSchemi = new HashSet<CvSchemi>();
            CvSostituzioni = new HashSet<CvSostituzioni>();
        }

        public string CvlinCodice { get; set; }
        public string CvlinDescrizione { get; set; }
        public int CvlinOrdineRicerca { get; set; }
        public string CvlinNote { get; set; }
        public DateTime CvlinInsTimestamp { get; set; }
        public string CvlinInsUteId { get; set; }
        public DateTime CvlinModTimestamp { get; set; }
        public string CvlinModUteId { get; set; }
        public string CvlinCliId { get; set; }

        public virtual Utenti Cvlin { get; set; }
        public virtual Clienti CvlinCli { get; set; }
        public virtual Utenti CvlinNavigation { get; set; }
        public virtual ICollection<CvSchemi> CvSchemi { get; set; }
        public virtual ICollection<CvSostituzioni> CvSostituzioni { get; set; }
    }
}
