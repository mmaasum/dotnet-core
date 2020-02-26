using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class GridListaTabelle
    {
        public GridListaTabelle()
        {
            GridFiltriMaster = new HashSet<GridFiltriMaster>();
        }

        public string GridtabNome { get; set; }
        public string GridtabDescrizione { get; set; }
        public DateTime? GridtabInsTimestamp { get; set; }
        public string GridtabInsUteId { get; set; }
        public DateTime? GridtabModTimestamp { get; set; }
        public string GridtabModUteId { get; set; }
        public string GridtabCliId { get; set; }

        public virtual Utenti Gridtab { get; set; }
        public virtual Clienti GridtabCli { get; set; }
        public virtual Utenti GridtabNavigation { get; set; }
        public virtual ICollection<GridFiltriMaster> GridFiltriMaster { get; set; }
    }
}
