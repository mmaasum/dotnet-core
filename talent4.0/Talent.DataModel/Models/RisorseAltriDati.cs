using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseAltriDati
    {
        public int RisaltrId { get; set; }
        public int RisaltrRisId { get; set; }
        public string RisaltrNazionalita { get; set; }
        public string RisaltrResidenza { get; set; }
        public string RisaltrDomicilio { get; set; }
        public string RisaltrCompetenzeTecniche { get; set; }
        public string RisaltrCompetenzeOrganizzative { get; set; }
        public string RisaltrPatente { get; set; }
        public string RisaltrLinguamadreLingua { get; set; }
        public DateTime RisaltrInsTimestamp { get; set; }
        public string RisaltrInsUteId { get; set; }
        public DateTime RisaltrModTimestamp { get; set; }
        public string RisaltrModUteId { get; set; }
        public string RisaltrCliId { get; set; }

        public virtual Utenti Risaltr { get; set; }
        public virtual Utenti Risaltr1 { get; set; }
        public virtual Clienti RisaltrCli { get; set; }
        public virtual Lingue RisaltrNavigation { get; set; }
    }
}
