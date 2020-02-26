using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseIstruzioneFormazione
    {
        public long RisistforId { get; set; }
        public int RisistforRisId { get; set; }
        public DateTime? RisistforInizio { get; set; }
        public DateTime? RisistforFine { get; set; }
        public string RisistforQualifica { get; set; }
        public string RisistforEnteNome { get; set; }
        public string RisistforEnteLuogo { get; set; }
        public string RisistforMaterieAbilita { get; set; }
        public DateTime RisistforInsTimestamp { get; set; }
        public string RisistforInsUteId { get; set; }
        public DateTime RisistforModTimestamp { get; set; }
        public string RisistforModUteId { get; set; }
        public string RisistforCliId { get; set; }

        public virtual Utenti Risistfor { get; set; }
        public virtual Clienti RisistforCli { get; set; }
        public virtual Utenti RisistforNavigation { get; set; }
    }
}
