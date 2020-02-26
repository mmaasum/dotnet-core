using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvSottosezioni
    {
        public string CvsotsezCodice { get; set; }
        public string CvsotsezDescrizione { get; set; }
        public string CvsotsezNote { get; set; }
        public string CvsotsezEsempi { get; set; }
        public DateTime CvsotsezInsTimestamp { get; set; }
        public string CvsotsezInsUteId { get; set; }
        public DateTime CvsotsezModTimestamp { get; set; }
        public string CvsotsezModUteId { get; set; }
        public string CvsotsezCliId { get; set; }

        public virtual Utenti Cvsotsez { get; set; }
        public virtual Clienti CvsotsezCli { get; set; }
        public virtual Utenti CvsotsezNavigation { get; set; }
    }
}
