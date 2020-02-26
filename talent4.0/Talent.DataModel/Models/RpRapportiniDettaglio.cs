using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RpRapportiniDettaglio
    {
        public int RprappdettId { get; set; }
        public int RprappdettRpscommutId { get; set; }
        public DateTime RprappdettGiorno { get; set; }
        public int RprappdettMinutiLavorati { get; set; }
        public string RprappdettDescrizione { get; set; }
        public string RprappdettNote { get; set; }
        public DateTime RprappdettInsTimestamp { get; set; }
        public string RprappdettInsUteId { get; set; }
        public DateTime RprappdettModTimestamp { get; set; }
        public string RprappdettModUteId { get; set; }
        public string RprappdettGiornInviato { get; set; }
        public string RprappdettCliId { get; set; }

        public virtual Utenti Rprappdett { get; set; }
        public virtual Clienti RprappdettCli { get; set; }
        public virtual Utenti RprappdettNavigation { get; set; }
    }
}
