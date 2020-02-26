using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SitiSocieta
    {
        public SitiSocieta()
        {
            Siti = new HashSet<Siti>();
            SitiAnnunci = new HashSet<SitiAnnunci>();
        }

        public string SitiSocId { get; set; }
        public string SitiSocRagSociale { get; set; }
        public string SitiSocDescrizione { get; set; }
        public string SitiSocFormCodAnn { get; set; }
        public DateTime SitiSocInsTimestamp { get; set; }
        public string SitiSocInsUteId { get; set; }
        public DateTime SitiSocModTimestamp { get; set; }
        public string SitiSocModUteId { get; set; }
        public string SitiSocCliId { get; set; }

        public virtual Utenti SitiSoc { get; set; }
        public virtual Clienti SitiSocCli { get; set; }
        public virtual Utenti SitiSocNavigation { get; set; }
        public virtual ICollection<Siti> Siti { get; set; }
        public virtual ICollection<SitiAnnunci> SitiAnnunci { get; set; }
    }
}
