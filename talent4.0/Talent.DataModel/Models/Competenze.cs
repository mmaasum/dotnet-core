using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Competenze
    {
        public string Competenza { get; set; }
        public string CompSenzaSeniority { get; set; }
        public string CompSeniority { get; set; }
        public string CompTipo { get; set; }
        public string CompDettTipo { get; set; }
        public string CompDettTipoDescr { get; set; }
        public string CompSenTipo { get; set; }
        public int? CompDettOrdVis { get; set; }
        public int? CompOrdVis { get; set; }
        public string CompRichSigla { get; set; }
        public string CompCliId { get; set; }

        public virtual Clienti CompCli { get; set; }
    }
}
