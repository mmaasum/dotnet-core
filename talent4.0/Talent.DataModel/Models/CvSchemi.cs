using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvSchemi
    {
        public CvSchemi()
        {
            CvSchemiIdentificatori = new HashSet<CvSchemiIdentificatori>();
            CvSostituzioni = new HashSet<CvSostituzioni>();
            RisorseCvSchemi = new HashSet<RisorseCvSchemi>();
        }

        public string CvschemCodice { get; set; }
        public string CvschemDescrizione { get; set; }
        public int CvschemOrdine { get; set; }
        public string CvschemNote { get; set; }
        public string CvschemCvlinCodice { get; set; }
        public long? CvschemStatNumCvAnalizzati { get; set; }
        public long? CvschemStatNumCvRilevati { get; set; }
        public DateTime? CvschemStatUltimoAggiornamento { get; set; }
        public decimal? CvschemStatFrequenzaPerc { get; set; }
        public string CvschemStatNote { get; set; }
        public DateTime CvschemInsTimestamp { get; set; }
        public string CvschemInsUteId { get; set; }
        public DateTime CvschemModTimestamp { get; set; }
        public string CvschemModUteId { get; set; }
        public string CvschemSito { get; set; }
        public string CvschemCliId { get; set; }

        public virtual Utenti Cvschem { get; set; }
        public virtual CvLingue CvschemC { get; set; }
        public virtual Clienti CvschemCli { get; set; }
        public virtual Utenti CvschemNavigation { get; set; }
        public virtual ICollection<CvSchemiIdentificatori> CvSchemiIdentificatori { get; set; }
        public virtual ICollection<CvSostituzioni> CvSostituzioni { get; set; }
        public virtual ICollection<RisorseCvSchemi> RisorseCvSchemi { get; set; }
    }
}
