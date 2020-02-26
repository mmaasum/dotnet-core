using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvSostituzioni
    {
        public int CvsostId { get; set; }
        public string CvsostCvlinCodice { get; set; }
        public string CvsostDaSostituireTipo { get; set; }
        public string CvsostDaSostituire { get; set; }
        public string CvsostSostituitoTipo { get; set; }
        public string CvsostSostituto { get; set; }
        public long CvsostOrdine { get; set; }
        public string CvsostNote { get; set; }
        public DateTime CvsostInsTimestamp { get; set; }
        public string CvsostInsUteId { get; set; }
        public DateTime CvsostModTimestamp { get; set; }
        public string CvsostModUteId { get; set; }
        public string CvsostCvschemCodice { get; set; }
        public string CvsostCliId { get; set; }

        public virtual Utenti Cvsost { get; set; }
        public virtual CvLingue CvsostC { get; set; }
        public virtual CvSchemi CvsostCNavigation { get; set; }
        public virtual Clienti CvsostCli { get; set; }
        public virtual Utenti CvsostNavigation { get; set; }
    }
}
