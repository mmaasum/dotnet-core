using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SchedulazioniProcessi
    {
        public SchedulazioniProcessi()
        {
            Schedulazioni = new HashSet<Schedulazioni>();
        }

        public string SchedprocId { get; set; }
        public string SchedprocNome { get; set; }
        public string SchedprocDescrizione { get; set; }
        public string SchedprocAbilitato { get; set; }
        public string SchedprocRicercaPortali { get; set; }
        public string SchedprocInEsecuzione { get; set; }
        public int? SchedprocProxEsecDistanzaMinInOre { get; set; }
        public TimeSpan? SchedprocProxEsecOraMin { get; set; }
        public TimeSpan? SchedprocProxEsecOraMax { get; set; }
        public string SchedprocProxEsecFestivi { get; set; }
        public DateTime? SchedprocUltEsecInizio { get; set; }
        public DateTime? SchedprocUltEsecFine { get; set; }
        public string SchedprocUltEsecEsito { get; set; }
        public int? SchedprocUltEsecNumCvNuovi { get; set; }
        public int? SchedprocUltEsecNumCvAggiornati { get; set; }
        public int? SchedprocUltEsecNumCvTotali { get; set; }
        public int? SchedprocMaxCvScaricabili { get; set; }
        public DateTime? SchedprocInsTimestamp { get; set; }
        public string SchedprocInsUteId { get; set; }
        public DateTime? SchedprocModTimestamp { get; set; }
        public string SchedprocModUteId { get; set; }
        public int? SchedprocCvScaricati { get; set; }
        public DateTime? SchedprocUltCvScaricato { get; set; }
        public string SchedprocIpMacchinaHost { get; set; }
        public string SchedprocEmailDestXAlert { get; set; }
        public string SchedprocCliId { get; set; }

        public virtual Utenti Schedproc { get; set; }
        public virtual Clienti SchedprocCli { get; set; }
        public virtual Utenti SchedprocNavigation { get; set; }
        public virtual ICollection<Schedulazioni> Schedulazioni { get; set; }
    }
}
