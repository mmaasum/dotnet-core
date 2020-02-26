using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentPagine
    {
        public TalentPagine()
        {
            TalentFiltriPagine = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineCampi = new HashSet<TalentFiltriPagineCampi>();
            TalentGriglie = new HashSet<TalentGriglie>();
            TalentMenu = new HashSet<TalentMenu>();
        }

        public string TntfilPaginaCodice { get; set; }
        public string TntfilPaginaUrl { get; set; }
        public string TntfilPaginaDescrizione { get; set; }
        public string TntfilPaginaAttiva { get; set; }
        public string TntfilPaginaNote { get; set; }
        public string TntfilUteabProcedura { get; set; }

        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagine { get; set; }
        public virtual ICollection<TalentFiltriPagineCampi> TalentFiltriPagineCampi { get; set; }
        public virtual ICollection<TalentGriglie> TalentGriglie { get; set; }
        public virtual ICollection<TalentMenu> TalentMenu { get; set; }
    }
}
