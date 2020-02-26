using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TalentGriglieUtenti
    {
        public int TntgruId { get; set; }
        public string TntgruNomeGriglia { get; set; }
        public string TntgruUteId { get; set; }
        public string TntgruCliId { get; set; }
        public string TntgruTntfontNomeFont { get; set; }
        public int? TntgruTntszFontDimensione { get; set; }
        public string TntgruMostraNumeriRiga { get; set; }
        public string TntgruColoreRighePari { get; set; }
        public string TntgruColoreRigheDispari { get; set; }
        public DateTime TntgruInsTimestamp { get; set; }
        public DateTime TntgruModTimestamp { get; set; }

        public virtual Utenti Tntgru { get; set; }
        public virtual TalentGriglie TntgruNomeGrigliaNavigation { get; set; }
        public virtual TalentFontNomi TntgruTntfontNomeFontNavigation { get; set; }
        public virtual TalentFontDimensioni TntgruTntszFontDimensioneNavigation { get; set; }
    }
}
