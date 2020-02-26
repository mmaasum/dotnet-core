using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseLingue
    {
        public long RislingueId { get; set; }
        public int RislingueRisId { get; set; }
        public int RislingueOrdine { get; set; }
        public string RislingueLingua { get; set; }
        public string RislingueLettura { get; set; }
        public int? RislingueLetturaLinguaLivello { get; set; }
        public string RislingueScrittura { get; set; }
        public int? RislingueScritturaLinguaLivello { get; set; }
        public string RislingueOrale { get; set; }
        public int? RislingueOraleLinguaLivello { get; set; }
        public DateTime RislingueInsTimestamp { get; set; }
        public string RislingueInsUteId { get; set; }
        public DateTime RislingueModTimestamp { get; set; }
        public string RislingueModUteId { get; set; }
        public string RislingueCliId { get; set; }

        public virtual Utenti Rislingue { get; set; }
        public virtual Lingue Rislingue1 { get; set; }
        public virtual Utenti Rislingue2 { get; set; }
        public virtual LinguaLivelli Rislingue3 { get; set; }
        public virtual LinguaLivelli Rislingue4 { get; set; }
        public virtual Clienti RislingueCli { get; set; }
        public virtual LinguaLivelli RislingueNavigation { get; set; }
    }
}
