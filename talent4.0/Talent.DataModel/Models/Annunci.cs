using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Annunci
    {
        public Annunci()
        {
            Risorse = new HashSet<Risorse>();
        }

        public string AnnId { get; set; }
        public string AnnTitolo { get; set; }
        public string AnnAttivo { get; set; }
        public DateTime? AnnDataPubblicazione { get; set; }
        public string AnnCitta { get; set; }
        public string AnnDurata { get; set; }
        public string AnnInizio { get; set; }
        public string AnnInquadramento { get; set; }
        public int AnnNumPosizioni { get; set; }
        public string AnnRetribuzione { get; set; }
        public string AnnCompetenzeObbligatorie { get; set; }
        public string AnnCompetenzeFacoltative { get; set; }
        public string AnnTesto { get; set; }
        public string AnnTestoHtml { get; set; }
        public DateTime? AnnDataDisattivazione { get; set; }
        public string AnnNote { get; set; }
        public DateTime AnnInsTimestamp { get; set; }
        public string AnnInsUteId { get; set; }
        public DateTime AnnModTimestamp { get; set; }
        public string AnnModUteId { get; set; }
        public string AnnCompetenzaPrincipale { get; set; }
        public DateTime? AnnDataSchedulazione { get; set; }
        public string AnnRevisionato { get; set; }
        public string AnnRichId { get; set; }
        public string AnnListaSitiPubblicazione { get; set; }
        public string AnnAnnmodId { get; set; }
        public string AnnCliId { get; set; }

        public virtual Utenti Ann { get; set; }
        public virtual Citta AnnC { get; set; }
        public virtual Clienti AnnCli { get; set; }
        public virtual Utenti AnnNavigation { get; set; }
        public virtual ICollection<Risorse> Risorse { get; set; }
    }
}
