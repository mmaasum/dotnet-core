using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvCampi
    {
        public string CvcamCodice { get; set; }
        public string CvcamDescrizione { get; set; }
        public string CvcamTipo { get; set; }
        public string CvcamEsempi { get; set; }
        public string CvcamNote { get; set; }
        public string CvcamValidazione { get; set; }
        public DateTime CvcamInsTimestamp { get; set; }
        public string CvcamInsUteId { get; set; }
        public DateTime CvcamModTimestamp { get; set; }
        public string CvcamModUteId { get; set; }
        public string CvcamCliId { get; set; }

        public virtual Utenti Cvcam { get; set; }
        public virtual Clienti CvcamCli { get; set; }
        public virtual Utenti CvcamNavigation { get; set; }
    }
}
