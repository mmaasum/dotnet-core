using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentFiltriPagineCampi
    {
        public TalentFiltriPagineCampi()
        {
            TalentFiltriPagineTntfilFiltropagSelect1FiltropagcampoCodiceNavigation = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineTntfilFiltropagSelect2FiltropagcampoCodiceNavigation = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineTntfilFiltropagSelect3FiltropagcampoCodiceNavigation = new HashSet<TalentFiltriPagine>();
        }

        public string TntfilFiltropagcampoCodice { get; set; }
        public string TntfilFiltropagcampoPagina { get; set; }
        public string TntfilFiltropagcampoCampoTabellaDb { get; set; }
        public string TntfilFiltropagcampoAttivo { get; set; }
        public string TntfilFiltropagcampoTipo { get; set; }
        public string TntfilFiltropagcampoListCodes { get; set; }
        public string TntfilFiltropagcampoListValues { get; set; }
        public string TntfilFiltropagcampoSoloFiltro { get; set; }
        public int TntfilFiltropagcampoFiltroOrdineVis { get; set; }
        public int? TntfilFiltropagcampoSortOrdineVis { get; set; }
        public string TntfilFiltropagcampoCodiceInterno { get; set; }
        public string TntfilFiltropagcampoFromList { get; set; }
        public string TntfilFiltropagcampoJoinWhereCondition { get; set; }

        public virtual TalentPagine TntfilFiltropagcampoPaginaNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagineTntfilFiltropagSelect1FiltropagcampoCodiceNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagineTntfilFiltropagSelect2FiltropagcampoCodiceNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagineTntfilFiltropagSelect3FiltropagcampoCodiceNavigation { get; set; }
    }
}
