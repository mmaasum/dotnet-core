using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class ImplementazioniProcedure
    {
        public ImplementazioniProcedure()
        {
            Implementazioni = new HashSet<Implementazioni>();
        }

        public string ImplprocId { get; set; }
        public string ImplprocDescrizione { get; set; }
        public DateTime ImplprocInsTimestamp { get; set; }
        public string ImplprocInsUteId { get; set; }
        public DateTime ImplprocModTimestamp { get; set; }
        public string ImplprocModUteId { get; set; }
        public string ImplprocCliId { get; set; }

        public virtual Utenti Implproc { get; set; }
        public virtual Clienti ImplprocCli { get; set; }
        public virtual Utenti ImplprocNavigation { get; set; }
        public virtual ICollection<Implementazioni> Implementazioni { get; set; }
    }
}
