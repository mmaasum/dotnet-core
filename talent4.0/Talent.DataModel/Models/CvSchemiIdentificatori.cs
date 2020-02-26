using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvSchemiIdentificatori
    {
        public string CvschemideId { get; set; }
        public string CvschemideCvschemCodice { get; set; }
        public int CvschemideOrdine { get; set; }
        public string CvschemideNote { get; set; }
        public long? CvschemideStatNumCvAnalizzati { get; set; }
        public long? CvschemideStatNumCvRilevati { get; set; }
        public DateTime? CvschemideStatUltimoAggiornamento { get; set; }
        public decimal? CvschemideStatFrequenzaPerc { get; set; }
        public string CvschemideStatNote { get; set; }
        public DateTime CvschemideInsTimestamp { get; set; }
        public string CvschemideInsUteId { get; set; }
        public DateTime CvschemideModTimestamp { get; set; }
        public string CvschemideModUteId { get; set; }
        public string CvschemideCliId { get; set; }

        public virtual Utenti Cvschemide { get; set; }
        public virtual CvSchemi CvschemideC { get; set; }
        public virtual Clienti CvschemideCli { get; set; }
        public virtual Utenti CvschemideNavigation { get; set; }
    }
}
