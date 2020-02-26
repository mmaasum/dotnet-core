using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewRisorseNoAllegati
    {

        [Key]
        public int RisId { get; set; }
        public string RisNome { get; set; }
        public string RisCognome { get; set; }
        public string RisCittaPossibili { get; set; }
        public DateTime? RisDataNascita { get; set; }
        public DateTime? RisDataColloquio { get; set; }
        public string RisCompetenza1 { get; set; }
        public string RisCompetenza2 { get; set; }
        public string RisCompetenza3 { get; set; }
        public string RisTitolo { get; set; }
        public string RisCellulare { get; set; }
        public string RisEmail { get; set; }
        public string RisCliId { get; set; }

        public string RisProtetto { get; set; }
    }
}
