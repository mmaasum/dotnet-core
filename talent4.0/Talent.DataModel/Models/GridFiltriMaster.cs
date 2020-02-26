using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class GridFiltriMaster
    {
        public string GridfilmaNome { get; set; }
        public string GridfilmaDescrizione { get; set; }
        public bool GridfilmaAccessLevel { get; set; }
        public string GridfilmaUteId { get; set; }
        public string GridfilmaGridtabNome { get; set; }
        public string GridfilmaPageUrl { get; set; }
        public bool GridfilmaFiltroDefault { get; set; }
        public DateTime GridfilmaInsTimestamp { get; set; }
        public string GridfilmaInsUteId { get; set; }
        public DateTime GridfilmaModTimestamp { get; set; }
        public string GridfilmaModUteId { get; set; }
        public string GridfilmaFilterString { get; set; }
        public string GridfilmaSortingString { get; set; }
        public string GridfilmaCliId { get; set; }
        public int? GridfilmaNomeOrder { get; set; }

        public virtual Utenti Gridfilma { get; set; }
        public virtual Utenti Gridfilma1 { get; set; }
        public virtual GridListaTabelle Gridfilma2 { get; set; }
        public virtual Clienti GridfilmaCli { get; set; }
        public virtual Utenti GridfilmaNavigation { get; set; }
    }
}
