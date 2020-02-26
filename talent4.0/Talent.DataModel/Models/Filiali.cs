using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Filiali
    {
        public int FilialeId { get; set; }
        public string FilialeCodice { get; set; }
        public string FilialeCitta { get; set; }
        public string FilialeNome { get; set; }
        public string FilialeIndirizzo { get; set; }
        public string FilialeDescrizione { get; set; }
        public string FilialeTelFisso { get; set; }
        public string FilialeFax { get; set; }
        public string FilialeSito { get; set; }
        public string FilialeCell1 { get; set; }
        public string FilialeCell2 { get; set; }
        public string FilialeCell3 { get; set; }
        public string FilialeMail1 { get; set; }
        public string FilialeMail2 { get; set; }
        public string FilialeMail3 { get; set; }
        public string FilialeAttiva { get; set; }
        public DateTime FilialeInsTimestamp { get; set; }
        public string FilialeInsUteId { get; set; }
        public DateTime FilialeModTimestamp { get; set; }
        public string FilialeModUteId { get; set; }
        public string FilialeCliId { get; set; }

        public virtual Utenti Filiale { get; set; }
        public virtual Clienti FilialeCli { get; set; }
        public virtual Utenti FilialeNavigation { get; set; }
    }
}
