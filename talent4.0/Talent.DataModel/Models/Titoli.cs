using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Titoli
    {
        public Titoli()
        {
            Risorse = new HashSet<Risorse>();
        }

        public string Titolo { get; set; }
        public string TitoloSesso { get; set; }
        public DateTime TitoloInsTimestamp { get; set; }
        public string TitoloInsUteId { get; set; }
        public DateTime TitoloModTimestamp { get; set; }
        public string TitoloModUteId { get; set; }
        public string TitoloCliId { get; set; }

        public virtual Utenti Titolo1 { get; set; }
        public virtual Clienti TitoloCli { get; set; }
        public virtual Utenti TitoloNavigation { get; set; }
        public virtual ICollection<Risorse> Risorse { get; set; }
    }
}
