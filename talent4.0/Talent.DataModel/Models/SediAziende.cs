using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class SediAziende
    {
        public SediAziende()
        {
            Contatti = new HashSet<Contatti>();
        }

        public int AzsedeId { get; set; }
        public int AzsedeAzId { get; set; }
        public string AzsedeAttiva { get; set; }
        public string AzsedeLegale { get; set; }
        public string AzsedeDescr { get; set; }
        public string AzsedeIndirizzo { get; set; }
        public string AzsedeCitta { get; set; }
        public string AzsedeCap { get; set; }
        public decimal AzsedeLocationLat { get; set; }
        public decimal AzsedeLocationLong { get; set; }
        public string AzsedeIndic { get; set; }
        public string AzsedeIndicColloquio { get; set; }
        public DateTime AzsedeInsTimestamp { get; set; }
        public string AzsedeInsUteId { get; set; }
        public DateTime AzsedeModTimestamp { get; set; }
        public string AzsedeModUteId { get; set; }
        public string AzsedeCliId { get; set; }

        public virtual Aziende Azsede { get; set; }
        public virtual Clienti AzsedeCli { get; set; }
        public virtual ICollection<Contatti> Contatti { get; set; }
    }
}
