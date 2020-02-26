using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class ImplementazioniProgetti
    {
        public int ImplprogId { get; set; }
        public string ImplprogNome { get; set; }
        public string ImplprogMailto { get; set; }
        public string ImplprogNote { get; set; }
        public DateTime ImplprogInsTimestamp { get; set; }
        public string ImplprogInsUteId { get; set; }
        public DateTime ImplprogModTimestamp { get; set; }
        public string ImplprogModUteId { get; set; }
        public string ImplprogCliId { get; set; }

        public virtual Utenti Implprog { get; set; }
        public virtual Clienti ImplprogCli { get; set; }
        public virtual Utenti ImplprogNavigation { get; set; }
    }
}
