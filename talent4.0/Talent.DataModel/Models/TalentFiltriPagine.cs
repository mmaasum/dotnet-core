using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentFiltriPagine
    {
        public TalentFiltriPagine()
        {
            TalentFiltriPagineUtenti = new HashSet<TalentFiltriPagineUtenti>();
        }

        public long TntfilFiltropagId { get; set; }
        public string TntfilFiltropagCliId { get; set; }
        public string TntfilFiltropagPaginaCodice { get; set; }
        public string TntfilFiltropagNome { get; set; }
        public string TntfilFiltropagNomeCorto { get; set; }
        public string TntfilFiltropagPulisciPrecedenti { get; set; }
        public string TntfilFiltropagPubblico { get; set; }
        public string TntfilFiltropagDescrizione { get; set; }
        public string TntfilFiltropagSelect1FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect1Filtrocond { get; set; }
        public string TntfilFiltropagSelect1FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect1Valore { get; set; }
        public string TntfilFiltropagSelect2FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect2Filtrocond { get; set; }
        public string TntfilFiltropagSelect2FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect2Valore { get; set; }
        public string TntfilFiltropagSelect3FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagSelect3Filtrocond { get; set; }
        public string TntfilFiltropagSelect3FiltrocondDatafissa { get; set; }
        public string TntfilFiltropagSelect3Valore { get; set; }
        public string TntfilFiltropagOrder1FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagOrder1Ascending { get; set; }
        public string TntfilFiltropagOrder2FiltropagcampoCodice { get; set; }
        public string TntfilFiltropagOrder2Ascending { get; set; }
        public string TntfilFiltropagQuery { get; set; }
        public string TntfilFiltropagInternalRepresentation { get; set; }
        public DateTime TntfilFiltropagInsTimestamp { get; set; }
        public string TntfilFiltropagInsUteId { get; set; }
        public DateTime TntfilFiltropagModTimestamp { get; set; }
        public string TntfilFiltropagModUteId { get; set; }

        public virtual Utenti TntfilFiltropag { get; set; }
        public virtual Clienti TntfilFiltropagCli { get; set; }
        public virtual Utenti TntfilFiltropagNavigation { get; set; }
        public virtual TalentPagine TntfilFiltropagPaginaCodiceNavigation { get; set; }
        public virtual TalentFiltriPagineCampi TntfilFiltropagSelect1FiltropagcampoCodiceNavigation { get; set; }
        public virtual TalentFiltriPagineCampi TntfilFiltropagSelect2FiltropagcampoCodiceNavigation { get; set; }
        public virtual TalentFiltriPagineCampi TntfilFiltropagSelect3FiltropagcampoCodiceNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagineUtenti> TalentFiltriPagineUtenti { get; set; }
    }
}
