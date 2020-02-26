using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class ModelliEmail
    {
        public int ModemId { get; set; }
        public string ModemFunzione { get; set; }
        public string ModemCc { get; set; }
        public string ModemOggetto { get; set; }
        public string ModemTestoInizio { get; set; }
        public string ModemTestoIntermedio { get; set; }
        public string ModemTestoIntermedio2 { get; set; }
        public string ModemTestoFine { get; set; }
        public string ModemDescrizione { get; set; }
        public DateTime ModemInsTimestamp { get; set; }
        public string ModemInsUteId { get; set; }
        public DateTime ModemModTimestamp { get; set; }
        public string ModemModUteId { get; set; }
        public string ModemTo { get; set; }
        public string ModemCliId { get; set; }
        public string ModemLanguage { get; set; }

        public virtual Utenti Modem { get; set; }
        public virtual Clienti ModemCli { get; set; }
        public virtual Utenti ModemNavigation { get; set; }
    }
}
