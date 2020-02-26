using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Contatti
    {
        public Contatti()
        {
            Azioni = new HashSet<Azioni>();
            RichiesteRichC1 = new HashSet<Richieste>();
            RichiesteRichC2 = new HashSet<Richieste>();
            RichiesteRichCNavigation = new HashSet<Richieste>();
        }

        public int ContId { get; set; }
        public string ContTitolo { get; set; }
        public string ContNome { get; set; }
        public string ContCognome { get; set; }
        public int ContAzId { get; set; }
        public string ContPosizione { get; set; }
        public string ContCitta { get; set; }
        public string ContEmail1 { get; set; }
        public string ContEmail2 { get; set; }
        public string ContTelefono1 { get; set; }
        public string ContTelefono2 { get; set; }
        public string ContRifUteId { get; set; }
        public string ContNote { get; set; }
        public DateTime? ContInsTimestamp { get; set; }
        public string ContInsUteId { get; set; }
        public DateTime? ContModTimestamp { get; set; }
        public string ContModUteId { get; set; }
        public string ContCvIniziali { get; set; }
        public string ContTipoContatto { get; set; }
        public string ContAttivo { get; set; }
        public string ContDescrizione { get; set; }
        public int? ContPriormin { get; set; }
        public int? ContPriormax { get; set; }
        public string ContOrari1Giorno { get; set; }
        public string ContOrari1Inizio { get; set; }
        public string ContOrari1Fine { get; set; }
        public string ContOrari2Giorno { get; set; }
        public string ContOrari2Inizio { get; set; }
        public string ContOrari2Fine { get; set; }
        public string ContOrari3Giorno { get; set; }
        public string ContOrari3Inizio { get; set; }
        public string ContOrari3Fine { get; set; }
        public string ContOrari4Giorno { get; set; }
        public string ContOrari4Inizio { get; set; }
        public string ContOrari4Fine { get; set; }
        public string ContOrari5Giorno { get; set; }
        public string ContOrari5Inizio { get; set; }
        public string ContOrari5Fine { get; set; }
        public string ContInvioCvNote { get; set; }
        public string ContCliId { get; set; }
        public int? ContAzsedeId { get; set; }

        public virtual Aziende Cont { get; set; }
        public virtual Utenti Cont1 { get; set; }
        public virtual TipiContatto Cont2 { get; set; }
        public virtual SediAziende ContAzsede { get; set; }
        public virtual Clienti ContCli { get; set; }
        public virtual Utenti ContNavigation { get; set; }
        public virtual ICollection<Azioni> Azioni { get; set; }
        public virtual ICollection<Richieste> RichiesteRichC1 { get; set; }
        public virtual ICollection<Richieste> RichiesteRichC2 { get; set; }
        public virtual ICollection<Richieste> RichiesteRichCNavigation { get; set; }
    }
}
