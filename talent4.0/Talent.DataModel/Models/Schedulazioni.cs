using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Schedulazioni
    {
        public int SchedId { get; set; }
        public string SchedUteId { get; set; }
        public string SchedRichId { get; set; }
        public string SchedSchedprocId { get; set; }
        public string SchedAbilitato { get; set; }
        public DateTime? SchedDataInizio { get; set; }
        public DateTime? SchedDataFine { get; set; }
        public DateTime? SchedProxEsecMin { get; set; }
        public string SchedInEsecuzione { get; set; }
        public string SchedCitta { get; set; }
        public string SchedKey1 { get; set; }
        public string SchedKey2 { get; set; }
        public string SchedKey3 { get; set; }
        public string SchedKey4 { get; set; }
        public string SchedKey5 { get; set; }
        public string SchedKey6 { get; set; }
        public DateTime? SchedUltEsecInizio { get; set; }
        public DateTime? SchedUltEsecFine { get; set; }
        public string SchedUltEsecEsito { get; set; }
        public int? SchedUltEsecNumCvNuovi { get; set; }
        public int? SchedUltEsecNumCvAggiornati { get; set; }
        public int? SchedUltEsecNumCvTotali { get; set; }
        public DateTime? SchedInsTimestamp { get; set; }
        public string SchedInsUteId { get; set; }
        public DateTime? SchedModTimestamp { get; set; }
        public string SchedModUteId { get; set; }
        public string SchedCliId { get; set; }

        public virtual Utenti Sched { get; set; }
        public virtual Richieste Sched1 { get; set; }
        public virtual SchedulazioniProcessi Sched2 { get; set; }
        public virtual Utenti Sched3 { get; set; }
        public virtual Clienti SchedCli { get; set; }
        public virtual Utenti SchedNavigation { get; set; }
    }
}
