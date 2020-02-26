using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Clienti
    {
        public Clienti()
        {
            Allegati = new HashSet<Allegati>();
            Annunci = new HashSet<Annunci>();
            AnnunciModelli = new HashSet<AnnunciModelli>();
            Aziende = new HashSet<Aziende>();
            Azioni = new HashSet<Azioni>();
            Candidature = new HashSet<Candidature>();
            Citta = new HashSet<Citta>();
            Competenze = new HashSet<Competenze>();
            CompetenzeTipi = new HashSet<CompetenzeTipi>();
            Config = new HashSet<Config>();
            Contatti = new HashSet<Contatti>();
            CvCampi = new HashSet<CvCampi>();
            CvLingue = new HashSet<CvLingue>();
            CvSchemi = new HashSet<CvSchemi>();
            CvSchemiIdentificatori = new HashSet<CvSchemiIdentificatori>();
            CvSezioni = new HashSet<CvSezioni>();
            CvSostituzioni = new HashSet<CvSostituzioni>();
            CvSottosezioni = new HashSet<CvSottosezioni>();
            CvTemplatePlaceholders = new HashSet<CvTemplatePlaceholders>();
            Filiali = new HashSet<Filiali>();
            Implementazioni = new HashSet<Implementazioni>();
            ImplementazioniProcedure = new HashSet<ImplementazioniProcedure>();
            ImplementazioniProgetti = new HashSet<ImplementazioniProgetti>();
            LinguaLivelli = new HashSet<LinguaLivelli>();
            Lingue = new HashSet<Lingue>();
            LogOperazioni = new HashSet<LogOperazioni>();
            ModelliEmail = new HashSet<ModelliEmail>();
            Paesi = new HashSet<Paesi>();
            ParametriGenerali = new HashSet<ParametriGenerali>();
            RaConfigurazioni = new HashSet<RaConfigurazioni>();
            Richieste = new HashSet<Richieste>();
            RichiesteListaRisorse = new HashSet<RichiesteListaRisorse>();
            Risorse = new HashSet<Risorse>();
            RisorseAltriDati = new HashSet<RisorseAltriDati>();
            RisorseContratti = new HashSet<RisorseContratti>();
            RisorseContrattiRetribuzione = new HashSet<RisorseContrattiRetribuzione>();
            RisorseCvSchemi = new HashSet<RisorseCvSchemi>();
            RisorseDatiAmministrativi = new HashSet<RisorseDatiAmministrativi>();
            RisorseEsperienzeLavorative = new HashSet<RisorseEsperienzeLavorative>();
            RisorseIstruzioneFormazione = new HashSet<RisorseIstruzioneFormazione>();
            RisorseLingue = new HashSet<RisorseLingue>();
            RisorseTestCompetenze = new HashSet<RisorseTestCompetenze>();
            RpCommesse = new HashSet<RpCommesse>();
            RpRapportini = new HashSet<RpRapportini>();
            RpRapportiniDettaglio = new HashSet<RpRapportiniDettaglio>();
            RpSottoCommesseUtenti = new HashSet<RpSottoCommesseUtenti>();
            RuoliUtenti = new HashSet<RuoliUtenti>();
            Schedulazioni = new HashSet<Schedulazioni>();
            SchedulazioniProcessi = new HashSet<SchedulazioniProcessi>();
            SchedulazioniProcessiEsecuzioni = new HashSet<SchedulazioniProcessiEsecuzioni>();
            SediAziende = new HashSet<SediAziende>();
            Siti = new HashSet<Siti>();
            SitiAnnunci = new HashSet<SitiAnnunci>();
            SitiSocieta = new HashSet<SitiSocieta>();
            StatiRichiesta = new HashSet<StatiRichiesta>();
            StatisticheIndicatori = new HashSet<StatisticheIndicatori>();
            TalentFiltriPagine = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineUtenti = new HashSet<TalentFiltriPagineUtenti>();
            TalentLingueClienti = new HashSet<TalentLingueClienti>();
            TalentRichiesteListaRisorse = new HashSet<TalentRichiesteListaRisorse>();
            TalentRuoliTipiAbilitazione = new HashSet<TalentRuoliTipiAbilitazione>();
            TalentUserProfiles = new HashSet<TalentUserProfiles>();
            Termini = new HashSet<Termini>();
            TestCompetenze = new HashSet<TestCompetenze>();
            TipiAllegato = new HashSet<TipiAllegato>();
            TipiAppuntamento = new HashSet<TipiAppuntamento>();
            TipiAzienda = new HashSet<TipiAzienda>();
            TipiAzioneRichiesta = new HashSet<TipiAzioneRichiesta>();
            TipiColloquio = new HashSet<TipiColloquio>();
            TipiContatto = new HashSet<TipiContatto>();
            TipiContratto = new HashSet<TipiContratto>();
            TipiContrattoDettagli = new HashSet<TipiContrattoDettagli>();
            TipiLingue = new HashSet<TipiLingue>();
            TipiLivelliLingue = new HashSet<TipiLivelliLingue>();
            TipiTermine = new HashSet<TipiTermine>();
            TipiTitoliStudio = new HashSet<TipiTitoliStudio>();
            Titoli = new HashSet<Titoli>();
            UnitaMisura = new HashSet<UnitaMisura>();
            Utenti = new HashSet<Utenti>();
            UtentiAbilitazioni = new HashSet<UtentiAbilitazioni>();
            UtentiImpostazioniGriglie = new HashSet<UtentiImpostazioniGriglie>();
        }

        public string CliId { get; set; }
        public string CliNome { get; set; }
        public string CliNomeWeb { get; set; }
        public DateTime CliAttivoDataInizio { get; set; }
        public DateTime CliAttivoDataFine { get; set; }
        public string CliLingua { get; set; }
        public string CliWeb { get; set; }
        public string CliNote { get; set; }
        public DateTime CliInsTimestamp { get; set; }
        public string CliInsUteId { get; set; }
        public DateTime CliModTimestamp { get; set; }
        public string CliModUteId { get; set; }
        public string CliLogoPath { get; set; }

        public virtual ICollection<Allegati> Allegati { get; set; }
        public virtual ICollection<Annunci> Annunci { get; set; }
        public virtual ICollection<AnnunciModelli> AnnunciModelli { get; set; }
        public virtual ICollection<Aziende> Aziende { get; set; }
        public virtual ICollection<Azioni> Azioni { get; set; }
        public virtual ICollection<Candidature> Candidature { get; set; }
        public virtual ICollection<Citta> Citta { get; set; }
        public virtual ICollection<Competenze> Competenze { get; set; }
        public virtual ICollection<CompetenzeTipi> CompetenzeTipi { get; set; }
        public virtual ICollection<Config> Config { get; set; }
        public virtual ICollection<Contatti> Contatti { get; set; }
        public virtual ICollection<CvCampi> CvCampi { get; set; }
        public virtual ICollection<CvLingue> CvLingue { get; set; }
        public virtual ICollection<CvSchemi> CvSchemi { get; set; }
        public virtual ICollection<CvSchemiIdentificatori> CvSchemiIdentificatori { get; set; }
        public virtual ICollection<CvSezioni> CvSezioni { get; set; }
        public virtual ICollection<CvSostituzioni> CvSostituzioni { get; set; }
        public virtual ICollection<CvSottosezioni> CvSottosezioni { get; set; }
        public virtual ICollection<CvTemplatePlaceholders> CvTemplatePlaceholders { get; set; }
        public virtual ICollection<Filiali> Filiali { get; set; }
        public virtual ICollection<Implementazioni> Implementazioni { get; set; }
        public virtual ICollection<ImplementazioniProcedure> ImplementazioniProcedure { get; set; }
        public virtual ICollection<ImplementazioniProgetti> ImplementazioniProgetti { get; set; }
        public virtual ICollection<LinguaLivelli> LinguaLivelli { get; set; }
        public virtual ICollection<Lingue> Lingue { get; set; }
        public virtual ICollection<LogOperazioni> LogOperazioni { get; set; }
        public virtual ICollection<ModelliEmail> ModelliEmail { get; set; }
        public virtual ICollection<Paesi> Paesi { get; set; }
        public virtual ICollection<ParametriGenerali> ParametriGenerali { get; set; }
        public virtual ICollection<RaConfigurazioni> RaConfigurazioni { get; set; }
        public virtual ICollection<Richieste> Richieste { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorse { get; set; }
        public virtual ICollection<Risorse> Risorse { get; set; }
        public virtual ICollection<RisorseAltriDati> RisorseAltriDati { get; set; }
        public virtual ICollection<RisorseContratti> RisorseContratti { get; set; }
        public virtual ICollection<RisorseContrattiRetribuzione> RisorseContrattiRetribuzione { get; set; }
        public virtual ICollection<RisorseCvSchemi> RisorseCvSchemi { get; set; }
        public virtual ICollection<RisorseDatiAmministrativi> RisorseDatiAmministrativi { get; set; }
        public virtual ICollection<RisorseEsperienzeLavorative> RisorseEsperienzeLavorative { get; set; }
        public virtual ICollection<RisorseIstruzioneFormazione> RisorseIstruzioneFormazione { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingue { get; set; }
        public virtual ICollection<RisorseTestCompetenze> RisorseTestCompetenze { get; set; }
        public virtual ICollection<RpCommesse> RpCommesse { get; set; }
        public virtual ICollection<RpRapportini> RpRapportini { get; set; }
        public virtual ICollection<RpRapportiniDettaglio> RpRapportiniDettaglio { get; set; }
        public virtual ICollection<RpSottoCommesseUtenti> RpSottoCommesseUtenti { get; set; }
        public virtual ICollection<RuoliUtenti> RuoliUtenti { get; set; }
        public virtual ICollection<Schedulazioni> Schedulazioni { get; set; }
        public virtual ICollection<SchedulazioniProcessi> SchedulazioniProcessi { get; set; }
        public virtual ICollection<SchedulazioniProcessiEsecuzioni> SchedulazioniProcessiEsecuzioni { get; set; }
        public virtual ICollection<SediAziende> SediAziende { get; set; }
        public virtual ICollection<Siti> Siti { get; set; }
        public virtual ICollection<SitiAnnunci> SitiAnnunci { get; set; }
        public virtual ICollection<SitiSocieta> SitiSocieta { get; set; }
        public virtual ICollection<StatiRichiesta> StatiRichiesta { get; set; }
        public virtual ICollection<StatisticheIndicatori> StatisticheIndicatori { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagine { get; set; }
        public virtual ICollection<TalentFiltriPagineUtenti> TalentFiltriPagineUtenti { get; set; }
        public virtual ICollection<TalentLingueClienti> TalentLingueClienti { get; set; }
        public virtual ICollection<TalentRichiesteListaRisorse> TalentRichiesteListaRisorse { get; set; }
        public virtual ICollection<TalentRuoliTipiAbilitazione> TalentRuoliTipiAbilitazione { get; set; }
        public virtual ICollection<TalentUserProfiles> TalentUserProfiles { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
        public virtual ICollection<TestCompetenze> TestCompetenze { get; set; }
        public virtual ICollection<TipiAllegato> TipiAllegato { get; set; }
        public virtual ICollection<TipiAppuntamento> TipiAppuntamento { get; set; }
        public virtual ICollection<TipiAzienda> TipiAzienda { get; set; }
        public virtual ICollection<TipiAzioneRichiesta> TipiAzioneRichiesta { get; set; }
        public virtual ICollection<TipiColloquio> TipiColloquio { get; set; }
        public virtual ICollection<TipiContatto> TipiContatto { get; set; }
        public virtual ICollection<TipiContratto> TipiContratto { get; set; }
        public virtual ICollection<TipiContrattoDettagli> TipiContrattoDettagli { get; set; }
        public virtual ICollection<TipiLingue> TipiLingue { get; set; }
        public virtual ICollection<TipiLivelliLingue> TipiLivelliLingue { get; set; }
        public virtual ICollection<TipiTermine> TipiTermine { get; set; }
        public virtual ICollection<TipiTitoliStudio> TipiTitoliStudio { get; set; }
        public virtual ICollection<Titoli> Titoli { get; set; }
        public virtual ICollection<UnitaMisura> UnitaMisura { get; set; }
        public virtual ICollection<Utenti> Utenti { get; set; }
        public virtual ICollection<UtentiAbilitazioni> UtentiAbilitazioni { get; set; }
        public virtual ICollection<UtentiImpostazioniGriglie> UtentiImpostazioniGriglie { get; set; }
    }
}
