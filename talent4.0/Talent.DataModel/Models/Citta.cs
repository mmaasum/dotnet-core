using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Citta
    {
        public Citta()
        {
            Annunci = new HashSet<Annunci>();
            AnnunciModelli = new HashSet<AnnunciModelli>();
            Richieste = new HashSet<Richieste>();
        }

        public string Citta1 { get; set; }
        public DateTime CittaInsTimestamp { get; set; }
        public string CittaInsUteId { get; set; }
        public DateTime CittaModTimestamp { get; set; }
        public string CittaModUteId { get; set; }
        public string CittaTarga { get; set; }
        public string CittaPrincipale { get; set; }
        public string CittaCliId { get; set; }

        public virtual Utenti Citta2 { get; set; }
        public virtual Clienti CittaCli { get; set; }
        public virtual Utenti CittaNavigation { get; set; }
        public virtual ICollection<Annunci> Annunci { get; set; }
        public virtual ICollection<AnnunciModelli> AnnunciModelli { get; set; }
        public virtual ICollection<Richieste> Richieste { get; set; }
    }
}
