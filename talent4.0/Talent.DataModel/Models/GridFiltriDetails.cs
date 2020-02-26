using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class GridFiltriDetails
    {
        public string GridfildeFieldName { get; set; }
        public string GridfildeSearchData { get; set; }
        public string GridfildeOrderby { get; set; }
        public string GridfildeGridfilmaNome { get; set; }
        public DateTime GridfildeInsTimestamp { get; set; }
        public string GridfildeInsUteId { get; set; }
        public DateTime GridfildeModTimestamp { get; set; }
        public string GridfildeModUteId { get; set; }
        public string GridfildeCliId { get; set; }

        public virtual Utenti Gridfilde { get; set; }
        public virtual GridFiltriMaster Gridfilde1 { get; set; }
        public virtual Clienti GridfildeCli { get; set; }
        public virtual Utenti GridfildeNavigation { get; set; }
    }
}
