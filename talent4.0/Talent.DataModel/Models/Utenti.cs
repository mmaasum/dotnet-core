using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Utenti
    {
        public Utenti()
        {
            AllegatiAll = new HashSet<Allegati>();
            AllegatiAllNavigation = new HashSet<Allegati>();
            AnnunciAnn = new HashSet<Annunci>();
            AnnunciAnnNavigation = new HashSet<Annunci>();
            AnnunciModelliAnnmod = new HashSet<AnnunciModelli>();
            AnnunciModelliAnnmodNavigation = new HashSet<AnnunciModelli>();
            AziendeAz = new HashSet<Aziende>();
            AziendeAz1 = new HashSet<Aziende>();
            AziendeAzNavigation = new HashSet<Aziende>();
            AzioniAzione = new HashSet<Azioni>();
            AzioniAzione3 = new HashSet<Azioni>();
            AzioniAzioneNavigation = new HashSet<Azioni>();
            CandidatureCand = new HashSet<Candidature>();
            CandidatureCandNavigation = new HashSet<Candidature>();
            CittaCitta2 = new HashSet<Citta>();
            CittaCittaNavigation = new HashSet<Citta>();
            ConfigConfig1 = new HashSet<Config>();
            ConfigConfigNavigation = new HashSet<Config>();
            ContattiCont1 = new HashSet<Contatti>();
            ContattiContNavigation = new HashSet<Contatti>();
            CvCampiCvcam = new HashSet<CvCampi>();
            CvCampiCvcamNavigation = new HashSet<CvCampi>();
            CvLingueCvlin = new HashSet<CvLingue>();
            CvLingueCvlinNavigation = new HashSet<CvLingue>();
            CvSchemiCvschem = new HashSet<CvSchemi>();
            CvSchemiCvschemNavigation = new HashSet<CvSchemi>();
            CvSchemiIdentificatoriCvschemide = new HashSet<CvSchemiIdentificatori>();
            CvSchemiIdentificatoriCvschemideNavigation = new HashSet<CvSchemiIdentificatori>();
            CvSezioniCvsez = new HashSet<CvSezioni>();
            CvSezioniCvsezNavigation = new HashSet<CvSezioni>();
            CvSostituzioniCvsost = new HashSet<CvSostituzioni>();
            CvSostituzioniCvsostNavigation = new HashSet<CvSostituzioni>();
            CvSottosezioniCvsotsez = new HashSet<CvSottosezioni>();
            CvSottosezioniCvsotsezNavigation = new HashSet<CvSottosezioni>();
            FilialiFiliale = new HashSet<Filiali>();
            FilialiFilialeNavigation = new HashSet<Filiali>();
            ImplementazioniImpl1 = new HashSet<Implementazioni>();
            ImplementazioniImplNavigation = new HashSet<Implementazioni>();
            ImplementazioniProcedureImplproc = new HashSet<ImplementazioniProcedure>();
            ImplementazioniProcedureImplprocNavigation = new HashSet<ImplementazioniProcedure>();
            ImplementazioniProgettiImplprog = new HashSet<ImplementazioniProgetti>();
            ImplementazioniProgettiImplprogNavigation = new HashSet<ImplementazioniProgetti>();
            InverseUte = new HashSet<Utenti>();
            InverseUteNavigation = new HashSet<Utenti>();
            LinguaLivelliLingualiv = new HashSet<LinguaLivelli>();
            LinguaLivelliLingualivNavigation = new HashSet<LinguaLivelli>();
            LingueLingua1 = new HashSet<Lingue>();
            LingueLinguaNavigation = new HashSet<Lingue>();
            LogOperazioni = new HashSet<LogOperazioni>();
            ModelliEmailModem = new HashSet<ModelliEmail>();
            ModelliEmailModemNavigation = new HashSet<ModelliEmail>();
            PaesiPaese = new HashSet<Paesi>();
            PaesiPaeseNavigation = new HashSet<Paesi>();
            RaConfigurazioniRac = new HashSet<RaConfigurazioni>();
            RaConfigurazioniRacNavigation = new HashSet<RaConfigurazioni>();
            RichiesteListaRisorseRichlist = new HashSet<RichiesteListaRisorse>();
            RichiesteListaRisorseRichlist3 = new HashSet<RichiesteListaRisorse>();
            RichiesteListaRisorseRichlist4 = new HashSet<RichiesteListaRisorse>();
            RichiesteListaRisorseRichlistNavigation = new HashSet<RichiesteListaRisorse>();
            RichiesteRich = new HashSet<Richieste>();
            RichiesteRich1 = new HashSet<Richieste>();
            RichiesteRich2 = new HashSet<Richieste>();
            RichiesteRichNavigation = new HashSet<Richieste>();
            RisorseAltriDatiRisaltr = new HashSet<RisorseAltriDati>();
            RisorseAltriDatiRisaltr1 = new HashSet<RisorseAltriDati>();
            RisorseContrattiRetribuzioneRiscontrretr = new HashSet<RisorseContrattiRetribuzione>();
            RisorseContrattiRetribuzioneRiscontrretrNavigation = new HashSet<RisorseContrattiRetribuzione>();
            RisorseContrattiRiscontr = new HashSet<RisorseContratti>();
            RisorseContrattiRiscontrNavigation = new HashSet<RisorseContratti>();
            RisorseCvSchemiRiscvschem = new HashSet<RisorseCvSchemi>();
            RisorseCvSchemiRiscvschemNavigation = new HashSet<RisorseCvSchemi>();
            RisorseDatiAmministrativiRisdamm = new HashSet<RisorseDatiAmministrativi>();
            RisorseDatiAmministrativiRisdammNavigation = new HashSet<RisorseDatiAmministrativi>();
            RisorseEsperienzeLavorativeRisesplav = new HashSet<RisorseEsperienzeLavorative>();
            RisorseEsperienzeLavorativeRisesplavNavigation = new HashSet<RisorseEsperienzeLavorative>();
            RisorseIstruzioneFormazioneRisistfor = new HashSet<RisorseIstruzioneFormazione>();
            RisorseIstruzioneFormazioneRisistforNavigation = new HashSet<RisorseIstruzioneFormazione>();
            RisorseLingueRislingue = new HashSet<RisorseLingue>();
            RisorseLingueRislingue2 = new HashSet<RisorseLingue>();
            RisorseRis = new HashSet<Risorse>();
            RisorseRis1 = new HashSet<Risorse>();
            RpCommesseRpcomm = new HashSet<RpCommesse>();
            RpCommesseRpcommNavigation = new HashSet<RpCommesse>();
            RpRapportiniDettaglioRprappdett = new HashSet<RpRapportiniDettaglio>();
            RpRapportiniDettaglioRprappdettNavigation = new HashSet<RpRapportiniDettaglio>();
            RpRapportiniRprapp = new HashSet<RpRapportini>();
            RpRapportiniRprappNavigation = new HashSet<RpRapportini>();
            RpSottoCommesseUtentiRpscommut = new HashSet<RpSottoCommesseUtenti>();
            RpSottoCommesseUtentiRpscommutNavigation = new HashSet<RpSottoCommesseUtenti>();
            RuoliUtentiDescrRuolodescr = new HashSet<RuoliUtentiDescr>();
            RuoliUtentiDescrRuolodescrNavigation = new HashSet<RuoliUtentiDescr>();
            RuoliUtentiRuolo1 = new HashSet<RuoliUtenti>();
            RuoliUtentiRuoloNavigation = new HashSet<RuoliUtenti>();
            SchedulazioniProcessiEsecuzioniSchedprocesec = new HashSet<SchedulazioniProcessiEsecuzioni>();
            SchedulazioniProcessiEsecuzioniSchedprocesecNavigation = new HashSet<SchedulazioniProcessiEsecuzioni>();
            SchedulazioniProcessiSchedproc = new HashSet<SchedulazioniProcessi>();
            SchedulazioniProcessiSchedprocNavigation = new HashSet<SchedulazioniProcessi>();
            SchedulazioniSched = new HashSet<Schedulazioni>();
            SchedulazioniSched3 = new HashSet<Schedulazioni>();
            SchedulazioniSchedNavigation = new HashSet<Schedulazioni>();
            SitiAnnunciSito1 = new HashSet<SitiAnnunci>();
            SitiAnnunciSitoNavigation = new HashSet<SitiAnnunci>();
            SitiSito1 = new HashSet<Siti>();
            SitiSitoNavigation = new HashSet<Siti>();
            SitiSocietaSitiSoc = new HashSet<SitiSocieta>();
            SitiSocietaSitiSocNavigation = new HashSet<SitiSocieta>();
            StatiRichiestaStatrich = new HashSet<StatiRichiesta>();
            StatiRichiestaStatrichNavigation = new HashSet<StatiRichiesta>();
            StatisticheIndicatoriStat = new HashSet<StatisticheIndicatori>();
            StatisticheIndicatoriStatNavigation = new HashSet<StatisticheIndicatori>();
            TalentFiltriPagineTntfilFiltropag = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineTntfilFiltropagNavigation = new HashSet<TalentFiltriPagine>();
            TalentFiltriPagineUtentiTntfilFiltropagute = new HashSet<TalentFiltriPagineUtenti>();
            TalentFiltriPagineUtentiTntfilFiltropagute1 = new HashSet<TalentFiltriPagineUtenti>();
            TalentFiltriPagineUtentiTntfilFiltropaguteNavigation = new HashSet<TalentFiltriPagineUtenti>();
            TalentGriglieCampiUtenti = new HashSet<TalentGriglieCampiUtenti>();
            TalentGriglieUtenti = new HashSet<TalentGriglieUtenti>();
            TalentRichiesteListaRisorseTrichlist = new HashSet<TalentRichiesteListaRisorse>();
            TalentRichiesteListaRisorseTrichlistNavigation = new HashSet<TalentRichiesteListaRisorse>();
            TalentUserProfilesTause = new HashSet<TalentUserProfiles>();
            TalentUserProfilesTauseNavigation = new HashSet<TalentUserProfiles>();
            TerminiTer = new HashSet<Termini>();
            TerminiTerNavigation = new HashSet<Termini>();
            TipiAllegatoTipall = new HashSet<TipiAllegato>();
            TipiAllegatoTipallNavigation = new HashSet<TipiAllegato>();
            TipiAppuntamentoTipoapp = new HashSet<TipiAppuntamento>();
            TipiAppuntamentoTipoappNavigation = new HashSet<TipiAppuntamento>();
            TipiAziendaTipaz = new HashSet<TipiAzienda>();
            TipiAziendaTipazNavigation = new HashSet<TipiAzienda>();
            TipiAzioneRichiestaTipazrich = new HashSet<TipiAzioneRichiesta>();
            TipiAzioneRichiestaTipazrichNavigation = new HashSet<TipiAzioneRichiesta>();
            TipiContattoTipcont = new HashSet<TipiContatto>();
            TipiContattoTipcontNavigation = new HashSet<TipiContatto>();
            TipiContrattoDettagliTipcontrdett = new HashSet<TipiContrattoDettagli>();
            TipiContrattoDettagliTipcontrdettNavigation = new HashSet<TipiContrattoDettagli>();
            TipiContrattoTipcontr = new HashSet<TipiContratto>();
            TipiContrattoTipcontrNavigation = new HashSet<TipiContratto>();
            TipiLingueTipling = new HashSet<TipiLingue>();
            TipiLingueTiplingNavigation = new HashSet<TipiLingue>();
            TipiLivelliLingueTiplivling = new HashSet<TipiLivelliLingue>();
            TipiLivelliLingueTiplivlingNavigation = new HashSet<TipiLivelliLingue>();
            TipiTermineTipter = new HashSet<TipiTermine>();
            TipiTermineTipterNavigation = new HashSet<TipiTermine>();
            TipiTitoliStudioTiptitstud = new HashSet<TipiTitoliStudio>();
            TipiTitoliStudioTiptitstudNavigation = new HashSet<TipiTitoliStudio>();
            TitoliTitolo1 = new HashSet<Titoli>();
            TitoliTitoloNavigation = new HashSet<Titoli>();
            UtentiAbilitazioniUteab = new HashSet<UtentiAbilitazioni>();
            UtentiAbilitazioniUteab1 = new HashSet<UtentiAbilitazioni>();
            UtentiAbilitazioniUteabNavigation = new HashSet<UtentiAbilitazioni>();
            UtentiImpostazioniGriglieUteimpgr = new HashSet<UtentiImpostazioniGriglie>();
            UtentiImpostazioniGriglieUteimpgr1 = new HashSet<UtentiImpostazioniGriglie>();
            UtentiImpostazioniGriglieUteimpgrNavigation = new HashSet<UtentiImpostazioniGriglie>();
        }

        public string UteId { get; set; }
        public string UtePassword { get; set; }
        public string UteNome { get; set; }
        public string UteRuolo { get; set; }
        public string UteAttivo { get; set; }
        public DateTime UteInsTimestamp { get; set; }
        public string UteInsUteId { get; set; }
        public DateTime UteModTimestamp { get; set; }
        public string UteModUteId { get; set; }
        public string UteTitolo { get; set; }
        public string UteProfilo { get; set; }
        public string UteMail { get; set; }
        public string UteTelefono { get; set; }
        public string UteAltriRiferimenti { get; set; }
        public string UteDeveloper { get; set; }
        public string UteTipoClientEmail { get; set; }
        public string UteSede { get; set; }
        public short? UteLimiteMaxSms { get; set; }
        public string UteRapportiniEmailInvio { get; set; }
        public string UteRapportiniUtentiGestiti { get; set; }
        public string UteModalitaDebug { get; set; }
        public string UteUsaVpn { get; set; }
        public int UteRicerchePortaliMaxNum { get; set; }
        public int? UteRisId { get; set; }
        public string UteCliId { get; set; }

        public virtual Utenti Ute { get; set; }
        public virtual RuoliUtenti Ute1 { get; set; }
        public virtual Clienti UteCli { get; set; }
        public virtual Utenti UteNavigation { get; set; }
        public virtual ICollection<Allegati> AllegatiAll { get; set; }
        public virtual ICollection<Allegati> AllegatiAllNavigation { get; set; }
        public virtual ICollection<Annunci> AnnunciAnn { get; set; }
        public virtual ICollection<Annunci> AnnunciAnnNavigation { get; set; }
        public virtual ICollection<AnnunciModelli> AnnunciModelliAnnmod { get; set; }
        public virtual ICollection<AnnunciModelli> AnnunciModelliAnnmodNavigation { get; set; }
        public virtual ICollection<Aziende> AziendeAz { get; set; }
        public virtual ICollection<Aziende> AziendeAz1 { get; set; }
        public virtual ICollection<Aziende> AziendeAzNavigation { get; set; }
        public virtual ICollection<Azioni> AzioniAzione { get; set; }
        public virtual ICollection<Azioni> AzioniAzione3 { get; set; }
        public virtual ICollection<Azioni> AzioniAzioneNavigation { get; set; }
        public virtual ICollection<Candidature> CandidatureCand { get; set; }
        public virtual ICollection<Candidature> CandidatureCandNavigation { get; set; }
        public virtual ICollection<Citta> CittaCitta2 { get; set; }
        public virtual ICollection<Citta> CittaCittaNavigation { get; set; }
        public virtual ICollection<Config> ConfigConfig1 { get; set; }
        public virtual ICollection<Config> ConfigConfigNavigation { get; set; }
        public virtual ICollection<Contatti> ContattiCont1 { get; set; }
        public virtual ICollection<Contatti> ContattiContNavigation { get; set; }
        public virtual ICollection<CvCampi> CvCampiCvcam { get; set; }
        public virtual ICollection<CvCampi> CvCampiCvcamNavigation { get; set; }
        public virtual ICollection<CvLingue> CvLingueCvlin { get; set; }
        public virtual ICollection<CvLingue> CvLingueCvlinNavigation { get; set; }
        public virtual ICollection<CvSchemi> CvSchemiCvschem { get; set; }
        public virtual ICollection<CvSchemi> CvSchemiCvschemNavigation { get; set; }
        public virtual ICollection<CvSchemiIdentificatori> CvSchemiIdentificatoriCvschemide { get; set; }
        public virtual ICollection<CvSchemiIdentificatori> CvSchemiIdentificatoriCvschemideNavigation { get; set; }
        public virtual ICollection<CvSezioni> CvSezioniCvsez { get; set; }
        public virtual ICollection<CvSezioni> CvSezioniCvsezNavigation { get; set; }
        public virtual ICollection<CvSostituzioni> CvSostituzioniCvsost { get; set; }
        public virtual ICollection<CvSostituzioni> CvSostituzioniCvsostNavigation { get; set; }
        public virtual ICollection<CvSottosezioni> CvSottosezioniCvsotsez { get; set; }
        public virtual ICollection<CvSottosezioni> CvSottosezioniCvsotsezNavigation { get; set; }
        public virtual ICollection<Filiali> FilialiFiliale { get; set; }
        public virtual ICollection<Filiali> FilialiFilialeNavigation { get; set; }
        public virtual ICollection<Implementazioni> ImplementazioniImpl1 { get; set; }
        public virtual ICollection<Implementazioni> ImplementazioniImplNavigation { get; set; }
        public virtual ICollection<ImplementazioniProcedure> ImplementazioniProcedureImplproc { get; set; }
        public virtual ICollection<ImplementazioniProcedure> ImplementazioniProcedureImplprocNavigation { get; set; }
        public virtual ICollection<ImplementazioniProgetti> ImplementazioniProgettiImplprog { get; set; }
        public virtual ICollection<ImplementazioniProgetti> ImplementazioniProgettiImplprogNavigation { get; set; }
        public virtual ICollection<Utenti> InverseUte { get; set; }
        public virtual ICollection<Utenti> InverseUteNavigation { get; set; }
        public virtual ICollection<LinguaLivelli> LinguaLivelliLingualiv { get; set; }
        public virtual ICollection<LinguaLivelli> LinguaLivelliLingualivNavigation { get; set; }
        public virtual ICollection<Lingue> LingueLingua1 { get; set; }
        public virtual ICollection<Lingue> LingueLinguaNavigation { get; set; }
        public virtual ICollection<LogOperazioni> LogOperazioni { get; set; }
        public virtual ICollection<ModelliEmail> ModelliEmailModem { get; set; }
        public virtual ICollection<ModelliEmail> ModelliEmailModemNavigation { get; set; }
        public virtual ICollection<Paesi> PaesiPaese { get; set; }
        public virtual ICollection<Paesi> PaesiPaeseNavigation { get; set; }
        public virtual ICollection<RaConfigurazioni> RaConfigurazioniRac { get; set; }
        public virtual ICollection<RaConfigurazioni> RaConfigurazioniRacNavigation { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorseRichlist { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorseRichlist3 { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorseRichlist4 { get; set; }
        public virtual ICollection<RichiesteListaRisorse> RichiesteListaRisorseRichlistNavigation { get; set; }
        public virtual ICollection<Richieste> RichiesteRich { get; set; }
        public virtual ICollection<Richieste> RichiesteRich1 { get; set; }
        public virtual ICollection<Richieste> RichiesteRich2 { get; set; }
        public virtual ICollection<Richieste> RichiesteRichNavigation { get; set; }
        public virtual ICollection<RisorseAltriDati> RisorseAltriDatiRisaltr { get; set; }
        public virtual ICollection<RisorseAltriDati> RisorseAltriDatiRisaltr1 { get; set; }
        public virtual ICollection<RisorseContrattiRetribuzione> RisorseContrattiRetribuzioneRiscontrretr { get; set; }
        public virtual ICollection<RisorseContrattiRetribuzione> RisorseContrattiRetribuzioneRiscontrretrNavigation { get; set; }
        public virtual ICollection<RisorseContratti> RisorseContrattiRiscontr { get; set; }
        public virtual ICollection<RisorseContratti> RisorseContrattiRiscontrNavigation { get; set; }
        public virtual ICollection<RisorseCvSchemi> RisorseCvSchemiRiscvschem { get; set; }
        public virtual ICollection<RisorseCvSchemi> RisorseCvSchemiRiscvschemNavigation { get; set; }
        public virtual ICollection<RisorseDatiAmministrativi> RisorseDatiAmministrativiRisdamm { get; set; }
        public virtual ICollection<RisorseDatiAmministrativi> RisorseDatiAmministrativiRisdammNavigation { get; set; }
        public virtual ICollection<RisorseEsperienzeLavorative> RisorseEsperienzeLavorativeRisesplav { get; set; }
        public virtual ICollection<RisorseEsperienzeLavorative> RisorseEsperienzeLavorativeRisesplavNavigation { get; set; }
        public virtual ICollection<RisorseIstruzioneFormazione> RisorseIstruzioneFormazioneRisistfor { get; set; }
        public virtual ICollection<RisorseIstruzioneFormazione> RisorseIstruzioneFormazioneRisistforNavigation { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingueRislingue { get; set; }
        public virtual ICollection<RisorseLingue> RisorseLingueRislingue2 { get; set; }
        public virtual ICollection<Risorse> RisorseRis { get; set; }
        public virtual ICollection<Risorse> RisorseRis1 { get; set; }
        public virtual ICollection<RpCommesse> RpCommesseRpcomm { get; set; }
        public virtual ICollection<RpCommesse> RpCommesseRpcommNavigation { get; set; }
        public virtual ICollection<RpRapportiniDettaglio> RpRapportiniDettaglioRprappdett { get; set; }
        public virtual ICollection<RpRapportiniDettaglio> RpRapportiniDettaglioRprappdettNavigation { get; set; }
        public virtual ICollection<RpRapportini> RpRapportiniRprapp { get; set; }
        public virtual ICollection<RpRapportini> RpRapportiniRprappNavigation { get; set; }
        public virtual ICollection<RpSottoCommesseUtenti> RpSottoCommesseUtentiRpscommut { get; set; }
        public virtual ICollection<RpSottoCommesseUtenti> RpSottoCommesseUtentiRpscommutNavigation { get; set; }
        public virtual ICollection<RuoliUtentiDescr> RuoliUtentiDescrRuolodescr { get; set; }
        public virtual ICollection<RuoliUtentiDescr> RuoliUtentiDescrRuolodescrNavigation { get; set; }
        public virtual ICollection<RuoliUtenti> RuoliUtentiRuolo1 { get; set; }
        public virtual ICollection<RuoliUtenti> RuoliUtentiRuoloNavigation { get; set; }
        public virtual ICollection<SchedulazioniProcessiEsecuzioni> SchedulazioniProcessiEsecuzioniSchedprocesec { get; set; }
        public virtual ICollection<SchedulazioniProcessiEsecuzioni> SchedulazioniProcessiEsecuzioniSchedprocesecNavigation { get; set; }
        public virtual ICollection<SchedulazioniProcessi> SchedulazioniProcessiSchedproc { get; set; }
        public virtual ICollection<SchedulazioniProcessi> SchedulazioniProcessiSchedprocNavigation { get; set; }
        public virtual ICollection<Schedulazioni> SchedulazioniSched { get; set; }
        public virtual ICollection<Schedulazioni> SchedulazioniSched3 { get; set; }
        public virtual ICollection<Schedulazioni> SchedulazioniSchedNavigation { get; set; }
        public virtual ICollection<SitiAnnunci> SitiAnnunciSito1 { get; set; }
        public virtual ICollection<SitiAnnunci> SitiAnnunciSitoNavigation { get; set; }
        public virtual ICollection<Siti> SitiSito1 { get; set; }
        public virtual ICollection<Siti> SitiSitoNavigation { get; set; }
        public virtual ICollection<SitiSocieta> SitiSocietaSitiSoc { get; set; }
        public virtual ICollection<SitiSocieta> SitiSocietaSitiSocNavigation { get; set; }
        public virtual ICollection<StatiRichiesta> StatiRichiestaStatrich { get; set; }
        public virtual ICollection<StatiRichiesta> StatiRichiestaStatrichNavigation { get; set; }
        public virtual ICollection<StatisticheIndicatori> StatisticheIndicatoriStat { get; set; }
        public virtual ICollection<StatisticheIndicatori> StatisticheIndicatoriStatNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagineTntfilFiltropag { get; set; }
        public virtual ICollection<TalentFiltriPagine> TalentFiltriPagineTntfilFiltropagNavigation { get; set; }
        public virtual ICollection<TalentFiltriPagineUtenti> TalentFiltriPagineUtentiTntfilFiltropagute { get; set; }
        public virtual ICollection<TalentFiltriPagineUtenti> TalentFiltriPagineUtentiTntfilFiltropagute1 { get; set; }
        public virtual ICollection<TalentFiltriPagineUtenti> TalentFiltriPagineUtentiTntfilFiltropaguteNavigation { get; set; }
        public virtual ICollection<TalentGriglieCampiUtenti> TalentGriglieCampiUtenti { get; set; }
        public virtual ICollection<TalentGriglieUtenti> TalentGriglieUtenti { get; set; }
        public virtual ICollection<TalentRichiesteListaRisorse> TalentRichiesteListaRisorseTrichlist { get; set; }
        public virtual ICollection<TalentRichiesteListaRisorse> TalentRichiesteListaRisorseTrichlistNavigation { get; set; }
        public virtual ICollection<TalentUserProfiles> TalentUserProfilesTause { get; set; }
        public virtual ICollection<TalentUserProfiles> TalentUserProfilesTauseNavigation { get; set; }
        public virtual ICollection<Termini> TerminiTer { get; set; }
        public virtual ICollection<Termini> TerminiTerNavigation { get; set; }
        public virtual ICollection<TipiAllegato> TipiAllegatoTipall { get; set; }
        public virtual ICollection<TipiAllegato> TipiAllegatoTipallNavigation { get; set; }
        public virtual ICollection<TipiAppuntamento> TipiAppuntamentoTipoapp { get; set; }
        public virtual ICollection<TipiAppuntamento> TipiAppuntamentoTipoappNavigation { get; set; }
        public virtual ICollection<TipiAzienda> TipiAziendaTipaz { get; set; }
        public virtual ICollection<TipiAzienda> TipiAziendaTipazNavigation { get; set; }
        public virtual ICollection<TipiAzioneRichiesta> TipiAzioneRichiestaTipazrich { get; set; }
        public virtual ICollection<TipiAzioneRichiesta> TipiAzioneRichiestaTipazrichNavigation { get; set; }
        public virtual ICollection<TipiContatto> TipiContattoTipcont { get; set; }
        public virtual ICollection<TipiContatto> TipiContattoTipcontNavigation { get; set; }
        public virtual ICollection<TipiContrattoDettagli> TipiContrattoDettagliTipcontrdett { get; set; }
        public virtual ICollection<TipiContrattoDettagli> TipiContrattoDettagliTipcontrdettNavigation { get; set; }
        public virtual ICollection<TipiContratto> TipiContrattoTipcontr { get; set; }
        public virtual ICollection<TipiContratto> TipiContrattoTipcontrNavigation { get; set; }
        public virtual ICollection<TipiLingue> TipiLingueTipling { get; set; }
        public virtual ICollection<TipiLingue> TipiLingueTiplingNavigation { get; set; }
        public virtual ICollection<TipiLivelliLingue> TipiLivelliLingueTiplivling { get; set; }
        public virtual ICollection<TipiLivelliLingue> TipiLivelliLingueTiplivlingNavigation { get; set; }
        public virtual ICollection<TipiTermine> TipiTermineTipter { get; set; }
        public virtual ICollection<TipiTermine> TipiTermineTipterNavigation { get; set; }
        public virtual ICollection<TipiTitoliStudio> TipiTitoliStudioTiptitstud { get; set; }
        public virtual ICollection<TipiTitoliStudio> TipiTitoliStudioTiptitstudNavigation { get; set; }
        public virtual ICollection<Titoli> TitoliTitolo1 { get; set; }
        public virtual ICollection<Titoli> TitoliTitoloNavigation { get; set; }
        public virtual ICollection<UtentiAbilitazioni> UtentiAbilitazioniUteab { get; set; }
        public virtual ICollection<UtentiAbilitazioni> UtentiAbilitazioniUteab1 { get; set; }
        public virtual ICollection<UtentiAbilitazioni> UtentiAbilitazioniUteabNavigation { get; set; }
        public virtual ICollection<UtentiImpostazioniGriglie> UtentiImpostazioniGriglieUteimpgr { get; set; }
        public virtual ICollection<UtentiImpostazioniGriglie> UtentiImpostazioniGriglieUteimpgr1 { get; set; }
        public virtual ICollection<UtentiImpostazioniGriglie> UtentiImpostazioniGriglieUteimpgrNavigation { get; set; }
    }
}
