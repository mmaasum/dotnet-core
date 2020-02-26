using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class AnnunciModelli
    {
        public int AnnmodId { get; set; }
        public string AnnmodCompetenza { get; set; }
        public string AnnmodTitolo { get; set; }
        public string AnnmodCitta { get; set; }
        public string AnnmodCompetenzeObbligatorie { get; set; }
        public string AnnmodCompetenzeFacoltative { get; set; }
        public int? AnnmodIntSchedulazione { get; set; }
        public DateTime? AnnmodDataInizio { get; set; }
        public DateTime? AnnmodDataFine { get; set; }
        public DateTime AnnmodInsTimestamp { get; set; }
        public string AnnmodInsUteId { get; set; }
        public DateTime AnnmodModTimestamp { get; set; }
        public string AnnmodModUteId { get; set; }
        public string AnnmodCliId { get; set; }

        public virtual Utenti Annmod { get; set; }
        public virtual Citta AnnmodC { get; set; }
        public virtual Clienti AnnmodCli { get; set; }
        public virtual Utenti AnnmodNavigation { get; set; }
    }
}
