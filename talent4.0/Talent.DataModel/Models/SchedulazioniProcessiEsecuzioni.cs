using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SchedulazioniProcessiEsecuzioni
    {
        public int SchedprocesecId { get; set; }
        public string SchedprocesecSchedprocId { get; set; }
        public int? SchedprocesecSchedId { get; set; }
        public DateTime? SchedprocesecInizio { get; set; }
        public DateTime? SchedprocesecFine { get; set; }
        public string SchedprocesecEsito { get; set; }
        public int? SchedprocesecNumCvNuovi { get; set; }
        public int? SchedprocesecNumCvAggiornati { get; set; }
        public int? SchedprocesecNumCvTotali { get; set; }
        public DateTime? SchedprocesecInsTimestamp { get; set; }
        public string SchedprocesecInsUteId { get; set; }
        public DateTime? SchedprocesecModTimestamp { get; set; }
        public string SchedprocesecModUteId { get; set; }
        public string SchedprocesecCliId { get; set; }

        public virtual Utenti Schedprocesec { get; set; }
        public virtual Clienti SchedprocesecCli { get; set; }
        public virtual Utenti SchedprocesecNavigation { get; set; }
    }
}
