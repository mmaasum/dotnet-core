using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Paesi
    {
        public string PaeseId { get; set; }
        public string PaeseDescrizione { get; set; }
        public string PaeseAttivo { get; set; }
        public string PaeseNazionalita { get; set; }
        public int PaeseNazionalitaOrdine { get; set; }
        public DateTime PaeseInsTimestamp { get; set; }
        public string PaeseInsUteId { get; set; }
        public DateTime PaeseModTimestamp { get; set; }
        public string PaeseModUteId { get; set; }
        public string PaeseCliId { get; set; }

        public virtual Utenti Paese { get; set; }
        public virtual Clienti PaeseCli { get; set; }
        public virtual Utenti PaeseNavigation { get; set; }
    }
}
