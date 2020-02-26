using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvSezioni
    {
        public string CvsezCodice { get; set; }
        public string CvsezDescrizione { get; set; }
        public string CvsezNote { get; set; }
        public DateTime CvsezInsTimestamp { get; set; }
        public string CvsezInsUteId { get; set; }
        public DateTime CvsezModTimestamp { get; set; }
        public string CvsezModUteId { get; set; }
        public string CvsezCliId { get; set; }

        public virtual Utenti Cvsez { get; set; }
        public virtual Clienti CvsezCli { get; set; }
        public virtual Utenti CvsezNavigation { get; set; }
    }
}
