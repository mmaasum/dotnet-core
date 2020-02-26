using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Risorse
    {
        public Risorse()
        {
            Azioni = new HashSet<Azioni>();
            Candidature = new HashSet<Candidature>();
            RichiesteListaRisorse = new HashSet<RichiesteListaRisorse>();
            RisorseContratti = new HashSet<RisorseContratti>();
            RisorseCvSchemi = new HashSet<RisorseCvSchemi>();
            RisorseDatiAmministrativi = new HashSet<RisorseDatiAmministrativi>();
            TalentRichiesteListaRisorse = new HashSet<TalentRichiesteListaRisorse>();
        }

        public int RisId { get; set; }
        public string RisTitolo { get; set; }
        public string RisNome { get; set; }
        public string RisCognome { get; set; }
        public string RisSesso { get; set; }
        public string RisIniziali { get; set; }
        public string RisCellulare { get; set; }
        public string RisEmail { get; set; }
        public string RisCittaPossibili { get; set; }
        public DateTime? RisDataNascita { get; set; }
        public DateTime? RisDataColloquio { get; set; }
        public string RisColloquioUteId { get; set; }
        public string RisColloquio { get; set; }
        public string RisNote { get; set; }
        public string RisAzioni { get; set; }
        public string RisNoteRicerca { get; set; }
        public string RisDisponibile { get; set; }
        public DateTime? RisDataDisponibilita { get; set; }
        public string RisCompetenza1 { get; set; }
        public string RisCompetenza2 { get; set; }
        public string RisCompetenza3 { get; set; }
        public DateTime? RisLastRispAnnAnnuncio { get; set; }
        public string RisLastRispAnnId { get; set; }
        public string RisLastRispSito { get; set; }
        public string RisCandidature { get; set; }
        public string RisCvNomeFile { get; set; }
        public byte[] RisCvAllegato { get; set; }
        public string RisCvTesto { get; set; }
        public long? RisCvDimInKb { get; set; }
        public DateTime? RisCvDataInserimento { get; set; }
        public string RisAll1TipoAllegato { get; set; }
        public string RisAll1NomeFile { get; set; }
        public byte[] RisAll1Allegato { get; set; }
        public long? RisAll1DimInKb { get; set; }
        public DateTime? RisAll1DataInserimento { get; set; }
        public string RisAll2TipoAllegato { get; set; }
        public string RisAll2NomeFile { get; set; }
        public byte[] RisAll2Allegato { get; set; }
        public long? RisAll2DimInKb { get; set; }
        public DateTime? RisAll2DataInserimento { get; set; }
        public string RisTerzaParte { get; set; }
        public DateTime RisInsTimestamp { get; set; }
        public string RisInsUteId { get; set; }
        public DateTime RisModTimestamp { get; set; }
        public string RisModUteId { get; set; }
        public string RisAltriRiferimenti { get; set; }
        public string RisContrAttTipo { get; set; }
        public string RisContrAttDett { get; set; }
        public int? RisContrAttPreavvGg { get; set; }
        public string RisContrAttPreavvGgTipo { get; set; }
        public string RisContrAttPreavvDett { get; set; }
        public long? RisContrAttNetto { get; set; }
        public string RisContrAttNettoTipo { get; set; }
        public string RisContrAttNettoAltreInfo { get; set; }
        public string RisContrAttNote { get; set; }
        public string RisContrAttDescr1 { get; set; }
        public string RisContrAttDescr2 { get; set; }
        public string RisContrAttDescr3 { get; set; }
        public DateTime? RisContrAttModTimestamp { get; set; }
        public string RisContrAttModUteId { get; set; }
        public string RisContrAttNoteLong { get; set; }
        public string RisProtetto { get; set; }
        public string RisColloquioFiliale { get; set; }
        public string RisColloquioTipo { get; set; }
        public string RisPrivacy { get; set; }
        public string RisLinkedin { get; set; }
        public DateTime? RisRevData { get; set; }
        public string RisRevUtente { get; set; }
        public string RisCliId { get; set; }

        public virtual Utenti Ris { get; set; }
        public virtual Utenti Ris1 { get; set; }
        public virtual Titoli Ris2 { get; set; }
        public virtual Clienti RisCli { get; set; }
        public virtual Annunci RisNavigation { get; set; }
        public virtual ICollection<Azioni> Azioni { get; set; }
        public virtual ICollection<Candidature> Candidature { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorse { get; set; }
        public virtual ICollection<RisorseContratti> RisorseContratti { get; set; }
        public virtual ICollection<RisorseCvSchemi> RisorseCvSchemi { get; set; }
        public virtual ICollection<RisorseDatiAmministrativi> RisorseDatiAmministrativi { get; set; }
        public virtual ICollection<TalentRichiesteListaRisorse> TalentRichiesteListaRisorse { get; set; }
    }
}
