using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Talent.DataModel.DataModels;

namespace Talent.DataModel.Models
{
    public partial class recruiting_multi_talent_testContext : DbContext
    {
        public recruiting_multi_talent_testContext()
        {
        }

        public recruiting_multi_talent_testContext(DbContextOptions<recruiting_multi_talent_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ViewTalentGriglieCampiUtenti> ViewTalentGriglieCampiUtenti { get; set; }
        public virtual DbSet<SPSchedulazioneGetSchedulazioni> SPSchedulazioneGetSchedulazionis { get; set; }
        public virtual DbSet<TableRecordCount> TableRecordCount { get; set; }
        public virtual DbSet<SPAuthRole> SPAuthRoles { get; set; }
        public virtual DbSet<SPLaunchRisorse> SPLaunchRisorse { get; set; }
        public virtual DbSet<ViewRisorseNoAllegati> ViewRisorseNoAllegati { get; set; }
        public virtual DbSet<ViewSediAziende> ViewSediAziende { get; set; }
        public virtual DbSet<ViewAziendeClientiFinali> ViewAziendeClientiFinali { get; set; }
        public virtual DbSet<ViewContatti> ViewContatti { get; set; }
        public virtual DbSet<ViewAzioni> ViewAzioni { get; set; }
        public virtual DbSet<ViewRichieste> ViewRichieste { get; set; }
        public virtual DbSet<SPSchedulazioneResiduoCv> SPSchedulazioneResiduoCv { get; set; }
        public virtual DbSet<StaticResult> StaticResult { get; set; }
        public virtual DbSet<SpItpFindResource> SpItpFindResource { get; set; }
        public virtual DbSet<GenericSearch> GenericSearch { get; set; }
        public virtual DbSet<DynamicButton> DynamicButton { get; set; }
        public virtual DbSet<TalentServiceSubscriber> TalentServiceSubscriber { get; set; }
        public virtual DbSet<TalentFiltriPagineUtenti> MasterFilterUtentiDmo { get; set; }
        public virtual DbSet<GeneralParameter> GeneralParameter { get; set; }
        public virtual DbSet<ViewTermini> ViewTermini { get; set; }
        public virtual DbSet<ViewRuoloUtenti> ViewRuoloUtenti { get; set; }
        public virtual DbSet<CustomDataClass> CustomDataClass { get; set; }



        public virtual DbSet<Allegati> Allegati { get; set; }
        public virtual DbSet<Annunci> Annunci { get; set; }
        public virtual DbSet<AnnunciModelli> AnnunciModelli { get; set; }
        public virtual DbSet<Aziende> Aziende { get; set; }
        public virtual DbSet<AziendeClientiFinali> AziendeClientiFinali { get; set; }
        public virtual DbSet<Azioni> Azioni { get; set; }
        public virtual DbSet<Candidature> Candidature { get; set; }
        public virtual DbSet<Citta> Citta { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Competenze> Competenze { get; set; }
        public virtual DbSet<CompetenzeTipi> CompetenzeTipi { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Contatti> Contatti { get; set; }
        public virtual DbSet<CvCampi> CvCampi { get; set; }
        public virtual DbSet<CvLingue> CvLingue { get; set; }
        public virtual DbSet<CvSchemi> CvSchemi { get; set; }
        public virtual DbSet<CvSchemiIdentificatori> CvSchemiIdentificatori { get; set; }
        public virtual DbSet<CvSezioni> CvSezioni { get; set; }
        public virtual DbSet<CvSostituzioni> CvSostituzioni { get; set; }
        public virtual DbSet<CvSottosezioni> CvSottosezioni { get; set; }
        public virtual DbSet<CvTemplatePlaceholders> CvTemplatePlaceholders { get; set; }
        public virtual DbSet<Filiali> Filiali { get; set; }
        public virtual DbSet<Implementazioni> Implementazioni { get; set; }
        public virtual DbSet<ImplementazioniProcedure> ImplementazioniProcedure { get; set; }
        public virtual DbSet<ImplementazioniProgetti> ImplementazioniProgetti { get; set; }
        public virtual DbSet<LinguaLivelli> LinguaLivelli { get; set; }
        public virtual DbSet<Lingue> Lingue { get; set; }
        public virtual DbSet<LogOperazioni> LogOperazioni { get; set; }
        public virtual DbSet<ModelliEmail> ModelliEmail { get; set; }
        public virtual DbSet<Paesi> Paesi { get; set; }
        public virtual DbSet<ParametriGenerali> ParametriGenerali { get; set; }
        public virtual DbSet<RaCategorie> RaCategorie { get; set; }
        public virtual DbSet<RaConfigurazioni> RaConfigurazioni { get; set; }
        public virtual DbSet<Richieste> Richieste { get; set; }
        public virtual DbSet<RichiesteListaRisorse> RichiesteListaRisorse { get; set; }
        public virtual DbSet<RichiesteLuoghiLavoro> RichiesteLuoghiLavoro { get; set; }
        public virtual DbSet<Risorse> Risorse { get; set; }
        public virtual DbSet<RisorseAltriDati> RisorseAltriDati { get; set; }
        public virtual DbSet<RisorseContratti> RisorseContratti { get; set; }
        public virtual DbSet<RisorseContrattiRetribuzione> RisorseContrattiRetribuzione { get; set; }
        public virtual DbSet<RisorseCvSchemi> RisorseCvSchemi { get; set; }
        public virtual DbSet<RisorseDatiAmministrativi> RisorseDatiAmministrativi { get; set; }
        public virtual DbSet<RisorseEsperienzeLavorative> RisorseEsperienzeLavorative { get; set; }
        public virtual DbSet<RisorseIstruzioneFormazione> RisorseIstruzioneFormazione { get; set; }
        public virtual DbSet<RisorseLingue> RisorseLingue { get; set; }
        public virtual DbSet<RisorseTestCompetenze> RisorseTestCompetenze { get; set; }
        public virtual DbSet<RpCommesse> RpCommesse { get; set; }
        public virtual DbSet<RpRapportini> RpRapportini { get; set; }
        public virtual DbSet<RpRapportiniDettaglio> RpRapportiniDettaglio { get; set; }
        public virtual DbSet<RpSottoCommesseUtenti> RpSottoCommesseUtenti { get; set; }
        public virtual DbSet<RuoliUtenti> RuoliUtenti { get; set; }
        public virtual DbSet<RuoliUtentiDescr> RuoliUtentiDescr { get; set; }
        public virtual DbSet<Schedulazioni> Schedulazioni { get; set; }
        public virtual DbSet<SchedulazioniProcessi> SchedulazioniProcessi { get; set; }
        public virtual DbSet<SchedulazioniProcessiEsecuzioni> SchedulazioniProcessiEsecuzioni { get; set; }
        public virtual DbSet<SediAziende> SediAziende { get; set; }
        public virtual DbSet<Siti> Siti { get; set; }
        public virtual DbSet<SitiAnnunci> SitiAnnunci { get; set; }
        public virtual DbSet<SitiSocieta> SitiSocieta { get; set; }
        public virtual DbSet<SoftskillsCompetenze> SoftskillsCompetenze { get; set; }
        public virtual DbSet<SoftskillsCompetenzeDescr> SoftskillsCompetenzeDescr { get; set; }
        public virtual DbSet<SoftskillsProfili> SoftskillsProfili { get; set; }
        public virtual DbSet<SoftskillsTestWsResult> SoftskillsTestWsResult { get; set; }
        public virtual DbSet<StatiRichiesta> StatiRichiesta { get; set; }
        public virtual DbSet<StatiRichiesteListaRisorse> StatiRichiesteListaRisorse { get; set; }
        public virtual DbSet<StatiRichiesteListaRisorseDescr> StatiRichiesteListaRisorseDescr { get; set; }
        public virtual DbSet<StatiTermine> StatiTermine { get; set; }
        public virtual DbSet<StatiTermineDescr> StatiTermineDescr { get; set; }
        public virtual DbSet<StatisticheIndicatori> StatisticheIndicatori { get; set; }
        public virtual DbSet<TalentFiltriPagine> TalentFiltriPagine { get; set; }
        public virtual DbSet<TalentFiltriPagineCampi> TalentFiltriPagineCampi { get; set; }
        public virtual DbSet<TalentFiltriPagineCampiDescr> TalentFiltriPagineCampiDescr { get; set; }
        public virtual DbSet<TalentFiltriPagineUtenti> TalentFiltriPagineUtenti { get; set; }
        public virtual DbSet<TalentFontDimensioni> TalentFontDimensioni { get; set; }
        public virtual DbSet<TalentFontNomi> TalentFontNomi { get; set; }
        public virtual DbSet<TalentGriglie> TalentGriglie { get; set; }
        public virtual DbSet<TalentGriglieCampi> TalentGriglieCampi { get; set; }
        public virtual DbSet<TalentGriglieCampiDescr> TalentGriglieCampiDescr { get; set; }
        public virtual DbSet<TalentGriglieCampiUtenti> TalentGriglieCampiUtenti { get; set; }
        public virtual DbSet<TalentGriglieUtenti> TalentGriglieUtenti { get; set; }
        public virtual DbSet<TalentLingue> TalentLingue { get; set; }
        public virtual DbSet<TalentLingueClienti> TalentLingueClienti { get; set; }
        public virtual DbSet<TalentLingueDescr> TalentLingueDescr { get; set; }
        public virtual DbSet<TalentMenu> TalentMenu { get; set; }
        public virtual DbSet<TalentMenuDescr> TalentMenuDescr { get; set; }
        public virtual DbSet<TalentPagine> TalentPagine { get; set; }
        public virtual DbSet<TalentRichiesteListaRisorse> TalentRichiesteListaRisorse { get; set; }
        public virtual DbSet<TalentRuoliTipiAbilitazione> TalentRuoliTipiAbilitazione { get; set; }
        public virtual DbSet<TalentTipiAbilitazione> TalentTipiAbilitazione { get; set; }
        public virtual DbSet<TalentTipiAbilitazioneDescr> TalentTipiAbilitazioneDescr { get; set; }
        public virtual DbSet<TalentUserProfiles> TalentUserProfiles { get; set; }
        public virtual DbSet<Termini> Termini { get; set; }
        public virtual DbSet<TestCompetenze> TestCompetenze { get; set; }
        public virtual DbSet<TestRisultati> TestRisultati { get; set; }
        public virtual DbSet<TestValutazione> TestValutazione { get; set; }
        public virtual DbSet<TipiAllegato> TipiAllegato { get; set; }
        public virtual DbSet<TipiAppuntamento> TipiAppuntamento { get; set; }
        public virtual DbSet<TipiAzienda> TipiAzienda { get; set; }
        public virtual DbSet<TipiAzione> TipiAzione { get; set; }
        public virtual DbSet<TipiAzioneCategoria> TipiAzioneCategoria { get; set; }
        public virtual DbSet<TipiAzioneCategoriaDescr> TipiAzioneCategoriaDescr { get; set; }
        public virtual DbSet<TipiAzioneDescr> TipiAzioneDescr { get; set; }
        public virtual DbSet<TipiAzioneRichiesta> TipiAzioneRichiesta { get; set; }
        public virtual DbSet<TipiColloquio> TipiColloquio { get; set; }
        public virtual DbSet<TipiContatto> TipiContatto { get; set; }
        public virtual DbSet<TipiContratto> TipiContratto { get; set; }
        public virtual DbSet<TipiContrattoDettagli> TipiContrattoDettagli { get; set; }
        public virtual DbSet<TipiLingue> TipiLingue { get; set; }
        public virtual DbSet<TipiLivelliLingue> TipiLivelliLingue { get; set; }
        public virtual DbSet<TipiTermine> TipiTermine { get; set; }
        public virtual DbSet<TipiTermineDescr> TipiTermineDescr { get; set; }
        public virtual DbSet<TipiTitoliStudio> TipiTitoliStudio { get; set; }
        public virtual DbSet<TipiValoriApplicazione> TipiValoriApplicazione { get; set; }
        public virtual DbSet<TipiValoriApplicazioneDescr> TipiValoriApplicazioneDescr { get; set; }
        public virtual DbSet<Titoli> Titoli { get; set; }
        public virtual DbSet<UnipiRisorseAnnotate> UnipiRisorseAnnotate { get; set; }
        public virtual DbSet<UnitaMisura> UnitaMisura { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }
        public virtual DbSet<UtentiAbilitazioni> UtentiAbilitazioni { get; set; }
        public virtual DbSet<UtentiImpostazioniGriglie> UtentiImpostazioniGriglie { get; set; }

        // Unable to generate entity type for table 'dbo.zz_nuovi_termini_raw'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_autoentry_campi_mancanti'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.compcalckey_comp_key'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.compcalckey_cvset'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.compcalckey_cvset_list'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_result_first_accodamento'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_result_keyword_accodamento'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.competenze_seniority'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_key_cv'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_no_pres_comp_base'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.competenze_tipi_dettagli'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_cv_inviati'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.competenze_tipi_keyword'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.dtproperties'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.rp_sotto_commesse'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.statistiche_indicatori_valori'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cv_schemi_sezioni_marcatori'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cv_schemi_sezioni'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cv_schemi_sezioni_sottosezioni'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_cv_citta_possibili'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cv_schemi_sezioni_sottosezioni_campi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cv_schemi_sezioni_sottosezioni_campi_marcatori'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_result_keyword'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_result'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_da_cancellare_dett'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_da_cancellare_tipo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_temp_comp_calc_attinenza_result_first'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.zz_cv_marcatori_sezioni_lingua'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettingsDto.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");



            modelBuilder.Entity<CustomDataClass>(entity =>
            {
                entity.Property(e => e.CustomDataString)
                   .HasColumnName("uteab_ute_id");
            });



            modelBuilder.Entity<ViewRuoloUtenti>(entity =>
            {
                entity.HasKey(e => new { e.RuoloCliId, e.Ruolo });
                
                    entity.Property(e => e.RuoloCliId)
                        .HasColumnName("ruolo_cli_id")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasDefaultValueSql("(N'ITP999')");

                    entity.Property(e => e.Ruolo)
                        .HasColumnName("ruolo")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    entity.Property(e => e.RuoloAbilitato)
                        .HasColumnName("ruolo_abilitato")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasDefaultValueSql("('S')");

                    entity.Property(e => e.RuoloInsTimestamp)
                        .HasColumnName("ruolo_ins_timestamp")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.RuoloInsUteId)
                        .IsRequired()
                        .HasColumnName("ruolo_ins_ute_id")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.RuoloModTimestamp)
                        .HasColumnName("ruolo_mod_timestamp")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    entity.Property(e => e.RuoloModUteId)
                        .IsRequired()
                        .HasColumnName("ruolo_mod_ute_id")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    entity.Property(e => e.RuoloSystem)
                        .HasColumnName("ruolo_system")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasDefaultValueSql("('N')");

                //entity.HasKey(e => new { e.RuolodescrRuolo, e.RuolodescrLingua, e.RuolodescrCliId });

             

                entity.Property(e => e.RuolodescrDescrizione)
                    .IsRequired()
                    .HasColumnName("ruolodescr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrDescrizioneBreve)
                    .HasColumnName("ruolodescr_descrizione_breve")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrDescrizioneEstesa)
                    .HasColumnName("ruolodescr_descrizione_estesa")
                    .HasMaxLength(300)
                    .IsUnicode(false);


                entity.Property(e => e.NoOfPermission)
                   .HasColumnName("NoOfPermission");

                entity.Property(e => e.NoOfActiveUser)
                  .HasColumnName("NoOfActiveUser");

            });



            modelBuilder.Entity<ViewTermini>(entity =>
            {
                entity.HasKey(e => new { e.TerCliId, e.Termine });

                entity.Property(e => e.TerCliId)
                    .HasColumnName("ter_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Termine)
                    .HasColumnName("termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerDescrizione)
                    .HasColumnName("ter_descrizione")
                    .IsUnicode(false);

                entity.Property(e => e.TerFrequenza).HasColumnName("ter_frequenza");

                entity.Property(e => e.TerInsTimestamp)
                    .HasColumnName("ter_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TerInsUteId)
                    .IsRequired()
                    .HasColumnName("ter_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerLingua)
                    .IsRequired()
                    .HasColumnName("ter_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.TerLink)
                    .HasColumnName("ter_link")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TerModTimestamp)
                    .HasColumnName("ter_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TerModUteId)
                    .IsRequired()
                    .HasColumnName("ter_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerNote)
                    .HasColumnName("ter_note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo1)
                    .HasColumnName("ter_sinonimo_1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo2)
                    .HasColumnName("ter_sinonimo_2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo3)
                    .HasColumnName("ter_sinonimo_3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo4)
                    .HasColumnName("ter_sinonimo_4")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo5)
                    .HasColumnName("ter_sinonimo_5")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo6)
                    .HasColumnName("ter_sinonimo_6")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo7)
                    .HasColumnName("ter_sinonimo_7")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo8)
                    .HasColumnName("ter_sinonimo_8")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerStato)
                    .HasColumnName("ter_stato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TerTipoTermine)
                    .IsRequired()
                    .HasColumnName("ter_tipo_termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerminiTipoDescr)
                   .HasColumnName("tipterdescr_descrizione");

                entity.Property(e => e.TerminiStatoDescr)
                   .HasColumnName("sterdescr_descrizione");
            });



            modelBuilder.Entity<ViewTalentGriglieCampiUtenti>(entity =>
            {
                entity.HasKey(e => new { e.TntgcuUteId, e.TntgcuCliId, e.TntgcuTntgcNomeCampo })
                     .HasName("PK_talent_grid_fields_users");

                entity.Property(e => e.TntgcuUteId)
                    .HasColumnName("tntgcu_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuCliId)
                    .HasColumnName("tntgcu_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuTntgcNomeCampo)
                    .HasColumnName("tntgcu_tntgc_nome_campo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuAllineamento)
                    .HasColumnName("tntgcu_allineamento")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Left')");

                entity.Property(e => e.TntgcuAutoSize)
                    .HasColumnName("tntgcu_auto_size")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.TntgcuId)
                    .HasColumnName("tntgcu_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TntgcuMaxSize)
                    .HasColumnName("tntgcu_max_size")
                    .HasDefaultValueSql("((1000))");

                entity.Property(e => e.TntgcuMinSize)
                    .HasColumnName("tntgcu_min_size")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.TntgcuOrdineVis)
                    .HasColumnName("tntgcu_ordine_vis")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TntgcuTntfontNomeFont)
                    .HasColumnName("tntgcu_tntfont_nome_font")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Arial')");

                entity.Property(e => e.TntgcuTntszFontDimensione)
                    .HasColumnName("tntgcu_tntsz_font_dimensione")
                    .HasDefaultValueSql("((10))");


                entity.Property(e => e.TntgcTntgridNomeGriglia)
                    .IsRequired()
                    .HasColumnName("tntgc_tntgrid_nome_griglia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcDescrizione)
                    .HasColumnName("tntgc_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcNomeCampoDb)
                    .HasColumnName("tntgc_nome_campo_db")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcFromList)
                   .HasColumnName("tntgc_from_list")
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.TntgcJoinWhereCondition)
                    .HasColumnName("tntgc_join_where_condition")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });




            //modelBuilder.Entity<MasterFilterUtentiDmo>(entity =>
            //{
            //    entity.HasKey(e => e.TntfilFiltropagUteId);
            //    entity.ToTable("talent_filtri_pagine_utenti");
            //    entity.Property(e => e.TntfilFiltropagUteId).HasColumnName("tntfil_filtropagute_id");
            //    entity.Property(e => e.TntfilFiltropagUteFiltroPagId).HasColumnName("tntfil_filtropagute_filtropag_id");
            //    entity.Property(e => e.TntfilFiltropagUteUteId).HasColumnName("tntfil_filtropagute_ute_id");
            //    entity.Property(e => e.TntfilFiltropagUteCliId).HasColumnName("tntfil_filtropagute_cli_id");
            //    entity.Property(e => e.TntfilFiltropagUteDefault).HasColumnName("tntfil_filtropagute_default");
            //    entity.Property(e => e.TntfilFiltropagUteOrdine).HasColumnName("tntfil_filtropagute_ordine");
            //    entity.Property(e => e.TntfilFiltropagUteButtonId).HasColumnName("tntfil_filtropagute_bottone");
            //    entity.Property(e => e.TntfilFiltropagUteButtonLabel).HasColumnName("tntfil_filtropagute_bottone_label");
            //    entity.Property(e => e.TntfilFiltropagUteInsUteId).HasColumnName("tntfil_filtropagute_ins_ute_id");
            //    entity.Property(e => e.TntfilFiltropagUteModUteId).HasColumnName("tntfil_filtropagute_mod_ute_id");
            //    entity.Property(e => e.TntfilFiltropagUteInsTimestamp).HasColumnName("tntfil_filtropagute_ins_timestamp");
            //    entity.Property(e => e.TntfilFiltropagUteModTimestamp).HasColumnName("tntfil_filtropagute_mod_timestamp");
            //});


            modelBuilder.Entity<TalentServiceSubscriber>(entity =>
            {
                entity.HasKey(e => e.TalentSubscriberUsername);

                entity.ToTable("talent_service_subscriber");

                entity.Property(e => e.TalentSubscriberUsername).HasColumnName("talent_subscriber_username");

                entity.Property(e => e.TalentSubscriberPassword)
                                .HasColumnName("talent_subscriber_password");


                entity.Property(e => e.TalentSubscriberCliId).HasColumnName("talent_subscriber_cli_id");

                entity.Property(e => e.TalentSubscriberStatus).HasColumnName("talent_subscriber_status");
            });


            modelBuilder.Entity<ViewRichieste>(entity =>
            {
                entity.HasKey(e => new { e.RichCliId, e.RichId });

                entity.Property(e => e.AzRagSociale).HasColumnName("az_rag_sociale");

                entity.Property(e => e.RichCliId)
                    .HasColumnName("rich_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RichId)
                    .HasColumnName("rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RichAssegnatoUteId)
                    .HasColumnName("rich_assegnato_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichAttiva)
                    .IsRequired()
                    .HasColumnName("rich_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RichAttivita)
                    .HasColumnName("rich_attivita")
                    .HasColumnType("text");

                entity.Property(e => e.RichAzId).HasColumnName("rich_az_id");

                entity.Property(e => e.RichCategorieProtette)
                    .HasColumnName("rich_categorie_protette")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichCitta)
                    .IsRequired()
                    .HasColumnName("rich_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RichCodiceRichiestaCliente)
                    .HasColumnName("rich_codice_richiesta_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompNecessarie)
                    .HasColumnName("rich_comp_necessarie")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipale)
                    .IsRequired()
                    .HasColumnName("rich_comp_principale")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipaleSemMaxOrd).HasColumnName("rich_comp_principale_sem_max_ord");

                entity.Property(e => e.RichCompPrincipaleSemMinOrd).HasColumnName("rich_comp_principale_sem_min_ord");

                entity.Property(e => e.RichCompPrincipaleSenMax)
                    .HasColumnName("rich_comp_principale_sen_max")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipaleSenMin)
                    .HasColumnName("rich_comp_principale_sen_min")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompSecondarie)
                    .HasColumnName("rich_comp_secondarie")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCont2Id).HasColumnName("rich_cont2_id");

                entity.Property(e => e.RichCont3Id).HasColumnName("rich_cont3_id");

                entity.Property(e => e.RichContId).HasColumnName("rich_cont_id");

                entity.Property(e => e.RichData)
                    .HasColumnName("rich_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataFine)
                    .HasColumnName("rich_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataIncarico)
                    .HasColumnName("rich_data_incarico")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataInizio)
                    .HasColumnName("rich_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDescrizione)
                    .HasColumnName("rich_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.RichDescrizioneRichiestaCliente)
                    .HasColumnName("rich_descrizione_richiesta_cliente")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RichDurata)
                    .HasColumnName("rich_durata")
                    .HasComputedColumnSql("(datediff(day,[rich_data_inizio],[rich_data_fine]))");

                entity.Property(e => e.RichDurataDescrizione)
                    .HasColumnName("rich_durata_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichDurataNum).HasColumnName("rich_durata_num");

                entity.Property(e => e.RichFilialeCodice)
                    .HasColumnName("rich_filiale_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RichInsTimestamp)
                    .HasColumnName("rich_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichInsUteId)
                    .IsRequired()
                    .HasColumnName("rich_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichModTimestamp)
                    .HasColumnName("rich_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichModUteId)
                    .IsRequired()
                    .HasColumnName("rich_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichNumPosizioni).HasColumnName("rich_num_posizioni");

                entity.Property(e => e.RichPriorita).HasColumnName("rich_priorita");

                entity.Property(e => e.RichProxAzData)
                    .HasColumnName("rich_prox_az_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichProxAzDescr)
                    .HasColumnName("rich_prox_az_descr")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RichProxAzTipoAzioneRichiesta)
                    .HasColumnName("rich_prox_az_tipo_azione_richiesta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichProxAzUteId)
                    .HasColumnName("rich_prox_az_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichRicercaContinua)
                    .HasColumnName("rich_ricerca_continua")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliAbilitato)
                    .IsRequired()
                    .HasColumnName("rich_ricerche_portali_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliCitta)
                    .HasColumnName("rich_ricerche_portali_citta")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliCittaVicine)
                    .IsRequired()
                    .HasColumnName("rich_ricerche_portali_citta_vicine")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliFine)
                    .HasColumnName("rich_ricerche_portali_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichRicerchePortaliInizio)
                    .HasColumnName("rich_ricerche_portali_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichRicerchePortaliKey1)
                    .HasColumnName("rich_ricerche_portali_key_1")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey2)
                    .HasColumnName("rich_ricerche_portali_key_2")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey3)
                    .HasColumnName("rich_ricerche_portali_key_3")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey4)
                    .HasColumnName("rich_ricerche_portali_key_4")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliNumCvAggiornati).HasColumnName("rich_ricerche_portali_num_cv_aggiornati");

                entity.Property(e => e.RichRicerchePortaliNumCvNuovi).HasColumnName("rich_ricerche_portali_num_cv_nuovi");

                entity.Property(e => e.RichRicerchePortaliNumCvTotali).HasColumnName("rich_ricerche_portali_num_cv_totali");

                entity.Property(e => e.RichRicerchePortaliNumEsecuzioni).HasColumnName("rich_ricerche_portali_num_esecuzioni");

                entity.Property(e => e.RichRicerchePortaliStato)
                    .HasColumnName("rich_ricerche_portali_stato")
                    .HasMaxLength(20);

                entity.Property(e => e.RichStato)
                    .HasColumnName("rich_stato")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichTariffa).HasColumnName("rich_tariffa");

                entity.Property(e => e.RichTipo)
                    .HasColumnName("rich_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichUteIdComm)
                    .HasColumnName("rich_ute_id_comm")
                    .HasMaxLength(20)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<ViewAzioni>(entity =>
            {

                entity.HasKey(e => new { e.AzioneCliId, e.AzioneId });

                entity.Property(e => e.RisNome)
                .HasColumnName("ris_nome")
                .HasMaxLength(50);

                entity.Property(e => e.RisCognome)
                .HasColumnName("ris_cognome")
                .HasMaxLength(50);

                entity.Property(e => e.RichDescrizione)
                .HasColumnName("rich_descrizione")
                .HasColumnType("text");

                entity.Property(e => e.UteNome).HasColumnName("ute_nome");

                entity.Property(e => e.ContNome)
                    .HasColumnName("cont_nome")
                    .HasMaxLength(25);


                entity.Property(e => e.ContCognome)
                    .HasColumnName("cont_cognome")
                    .HasMaxLength(25);


                entity.Property(e => e.AzRagSociale).HasColumnName("az_rag_sociale");

                entity.Property(e => e.AzioneCliId)
                    .HasColumnName("azione_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AzioneId)
                    .HasColumnName("azione_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AzioneContId).HasColumnName("azione_cont_id");

                entity.Property(e => e.AzioneDescrizione)
                    .HasColumnName("azione_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio01)
                    .HasColumnName("azione_dettaglio_01")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio02)
                    .HasColumnName("azione_dettaglio_02")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio03)
                    .HasColumnName("azione_dettaglio_03")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.AzioneDettaglio04)
                   .HasColumnName("azione_dettaglio_04")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio05)
                    .HasColumnName("azione_dettaglio_05")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio06)
                    .HasColumnName("azione_dettaglio_06")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.AzioneFine)
                    .HasColumnName("azione_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.AzioneInizio)
                    .HasColumnName("azione_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.AzioneInsTimestamp)
                    .HasColumnName("azione_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzioneInsUteId)
                    .IsRequired()
                    .HasColumnName("azione_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneLuogo)
                    .HasColumnName("azione_luogo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneModTimestamp)
                    .HasColumnName("azione_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzioneModUteId)
                    .IsRequired()
                    .HasColumnName("azione_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneRichId)
                    .HasColumnName("azione_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneRisId).HasColumnName("azione_ris_id");

                entity.Property(e => e.AzioneTipo)
                    .HasColumnName("azione_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneUteId)
                    .IsRequired()
                    .HasColumnName("azione_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.tipi_azione_categoria_descr_OF_tpazcatdescr_descrizione)
                                .HasColumnName("tpazcatdescr_descrizione");

                entity.Property(e => e.tipi_azione_descr_OF_tpazdescr_descrizione)
                               .HasColumnName("tpazdescr_tipazione_tipo_azione");

                entity.Property(e => e.richieste_OF_rich_citta)
                .HasColumnName("rich_citta");

                entity.Property(e => e.richieste_OF_rich_comp_principale)
                               .HasColumnName("rich_comp_principale");
            });

            modelBuilder.Entity<ViewContatti>(entity =>
            {
                entity.HasKey(e => new { e.ContCliId, e.ContId });

                entity.Property(e => e.AzRagSociale).HasColumnName("az_rag_sociale");
                entity.Property(e => e.AzsedeDescr).HasColumnName("azsede_descr");
                entity.Property(e => e.UteNome).HasColumnName("ute_nome");


                entity.HasIndex(e => e.ContAzId)
                    .HasName("cont_az_id");

                entity.Property(e => e.ContCliId)
                    .HasColumnName("cont_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ContId).HasColumnName("cont_id");

                entity.Property(e => e.ContAttivo)
                    .IsRequired()
                    .HasColumnName("cont_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.ContAzId).HasColumnName("cont_az_id");

                entity.Property(e => e.ContAzsedeId).HasColumnName("cont_azsede_id");

                entity.Property(e => e.ContCitta)
                    .IsRequired()
                    .HasColumnName("cont_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContCognome)
                    .IsRequired()
                    .HasColumnName("cont_cognome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ContCvIniziali)
                    .HasColumnName("cont_cv_iniziali")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ContDescrizione)
                    .HasColumnName("cont_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.ContEmail1)
                    .IsRequired()
                    .HasColumnName("cont_email_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContEmail2)
                    .HasColumnName("cont_email_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContInsTimestamp)
                    .HasColumnName("cont_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContInsUteId)
                    .HasColumnName("cont_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContInvioCvNote)
                    .HasColumnName("cont_invio_cv_note")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ContModTimestamp)
                    .HasColumnName("cont_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContModUteId)
                    .HasColumnName("cont_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContNome)
                    .IsRequired()
                    .HasColumnName("cont_nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);




                entity.Property(e => e.ContNote)
                    .HasColumnName("cont_note")
                    .HasColumnType("text");

                entity.Property(e => e.ContOrari1Fine)
                    .HasColumnName("cont_orari_1_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari1Giorno)
                    .HasColumnName("cont_orari_1_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari1Inizio)
                    .HasColumnName("cont_orari_1_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Fine)
                    .HasColumnName("cont_orari_2_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Giorno)
                    .HasColumnName("cont_orari_2_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Inizio)
                    .HasColumnName("cont_orari_2_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Fine)
                    .HasColumnName("cont_orari_3_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Giorno)
                    .HasColumnName("cont_orari_3_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Inizio)
                    .HasColumnName("cont_orari_3_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Fine)
                    .HasColumnName("cont_orari_4_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Giorno)
                    .HasColumnName("cont_orari_4_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Inizio)
                    .HasColumnName("cont_orari_4_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Fine)
                    .HasColumnName("cont_orari_5_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Giorno)
                    .HasColumnName("cont_orari_5_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Inizio)
                    .HasColumnName("cont_orari_5_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContPosizione)
                    .HasColumnName("cont_posizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContPriormax).HasColumnName("cont_priormax");

                entity.Property(e => e.ContPriormin).HasColumnName("cont_priormin");

                entity.Property(e => e.ContRifUteId)
                    .IsRequired()
                    .HasColumnName("cont_rif_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTelefono1)
                    .IsRequired()
                    .HasColumnName("cont_telefono_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTelefono2)
                    .HasColumnName("cont_telefono_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTipoContatto)
                    .IsRequired()
                    .HasColumnName("cont_tipo_contatto")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Altro')");

                entity.Property(e => e.ContTitolo)
                    .IsRequired()
                    .HasColumnName("cont_titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

            });



            modelBuilder.Entity<ViewAziendeClientiFinali>(entity =>
            {
                entity.HasKey(e => new { e.ClifinId, e.ClifinCliId });

                entity.Property(e => e.ClifinId)
                    .HasColumnName("clifin_id")
                    .ValueGeneratedOnAdd();


                entity.Property(e => e.AzRagSociale).HasColumnName("az_rag_sociale");

                entity.Property(e => e.ClifinCliId)
                    .HasColumnName("clifin_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinAzId).HasColumnName("clifin_az_id");

                entity.Property(e => e.ClifinIndirizzo)
                    .HasColumnName("clifin_indirizzo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinInsTimestamp)
                    .HasColumnName("clifin_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClifinInsUteId)
                    .IsRequired()
                    .HasColumnName("clifin_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinLocationLat)
                    .HasColumnName("clifin_location_lat")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ClifinLocationLong)
                    .HasColumnName("clifin_location_long")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ClifinLuogoLavoro)
                    .IsRequired()
                    .HasColumnName("clifin_luogo_lavoro")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinModTimestamp)
                    .HasColumnName("clifin_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClifinModUteId)
                    .IsRequired()
                    .HasColumnName("clifin_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinNomeClienteFinale)
                    .HasColumnName("clifin_nome_cliente_finale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinRaggMezziPubblici)
                    .HasColumnName("clifin_ragg_mezzi_pubblici")
                    .HasMaxLength(1)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<ViewSediAziende>(entity =>
            {
                entity.HasKey(e => e.AzsedeId);

                //entity.ToTable("sedi_aziende");

                entity.Property(e => e.AzsedeId).HasColumnName("azsede_id");
                entity.Property(e => e.AzRagSociale).HasColumnName("az_rag_sociale");

                entity.Property(e => e.AzsedeAttiva)
                    .IsRequired()
                    .HasColumnName("azsede_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeAzId).HasColumnName("azsede_az_id");

                entity.Property(e => e.AzsedeCap)
                    .HasColumnName("azsede_cap")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeCitta)
                    .HasColumnName("azsede_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeCliId)
                    .IsRequired()
                    .HasColumnName("azsede_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AzsedeDescr)
                    .HasColumnName("azsede_descr")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndic)
                    .HasColumnName("azsede_indic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndicColloquio)
                    .HasColumnName("azsede_indic_colloquio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndirizzo)
                    .HasColumnName("azsede_indirizzo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeInsTimestamp)
                    .HasColumnName("azsede_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzsedeInsUteId)
                    .IsRequired()
                    .HasColumnName("azsede_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeLegale)
                    .IsRequired()
                    .HasColumnName("azsede_legale")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeLocationLat)
                    .HasColumnName("azsede_location_lat")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzsedeLocationLong)
                    .HasColumnName("azsede_location_long")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzsedeModTimestamp)
                    .HasColumnName("azsede_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzsedeModUteId)
                    .IsRequired()
                    .HasColumnName("azsede_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewRisorseNoAllegati>(entity =>
            {
                entity.HasKey(e => new { e.RisCliId, e.RisId });

                entity.ToTable("v_risorse_no_allegati");


                entity.HasIndex(e => new { e.RisNome, e.RisCognome })
                    .HasName("idx_nome_cognome");



                entity.HasIndex(e => new { e.RisCompetenza1, e.RisCompetenza2, e.RisCompetenza3 })
                    .HasName("competenze");

                entity.HasIndex(e => new { e.RisId, e.RisNome, e.RisCognome, e.RisCittaPossibili, e.RisDataNascita, e.RisDataColloquio, e.RisCompetenza1, e.RisCompetenza2, e.RisCompetenza3, })
                    .HasName("idx_disp_altri");

                entity.Property(e => e.RisId)
                   .HasColumnName("ris_id")
                   .ValueGeneratedOnAdd();

                entity.Property(e => e.RisCliId)
                    .HasColumnName("ris_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");


                entity.Property(e => e.RisProtetto)
                .HasColumnName("ris_protetto")
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')");

                entity.Property(e => e.RisCognome)
                .IsRequired()
                .HasColumnName("ris_cognome")
                .HasMaxLength(50)
                .IsUnicode(false);


                entity.Property(e => e.RisCittaPossibili)
                    .IsRequired()
                    .HasColumnName("ris_citta_possibili")
                    .HasMaxLength(200)
                    .IsUnicode(false);


                entity.Property(e => e.RisCellulare)
                    .IsRequired()
                    .HasColumnName("ris_cellulare")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza1)
                    .IsRequired()
                    .HasColumnName("ris_competenza_1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza2)
                    .HasColumnName("ris_competenza_2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza3)
                    .HasColumnName("ris_competenza_3")
                    .HasMaxLength(150)
                    .IsUnicode(false);


                entity.Property(e => e.RisDataColloquio)
                    .HasColumnName("ris_data_colloquio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisDataNascita)
                   .HasColumnName("ris_data_nascita")
                   .HasColumnType("datetime");

                entity.Property(e => e.RisEmail)
                    .IsRequired()
                    .HasColumnName("ris_email")
                    .HasMaxLength(150)
                    .IsUnicode(false);



                entity.Property(e => e.RisNome)
                    .IsRequired()
                    .HasColumnName("ris_nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);




                entity.Property(e => e.RisTitolo)
                    .IsRequired()
                    .HasColumnName("ris_titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
































            modelBuilder.Entity<Allegati>(entity =>
            {
                entity.HasKey(e => new { e.AllCliId, e.AllId })
                    .HasName("PK__allegati__1BA4DCBD3C89182D");

                entity.ToTable("allegati");

                entity.HasIndex(e => new { e.AllCliId, e.AllRiferimentoTabella, e.AllRiferimentoId, e.AllRiferimentoContatoreInterno })
                    .HasName("IX_allegati")
                    .IsUnique();

                entity.Property(e => e.AllCliId)
                    .HasColumnName("all_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AllId)
                    .HasColumnName("all_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AllAllegato)
                    .HasColumnName("all_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.AllCodice)
                    .HasColumnName("all_codice")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllDataInserimento)
                    .HasColumnName("all_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.AllDimInKb).HasColumnName("all_dim_in_kb");

                entity.Property(e => e.AllInsTimestamp)
                    .HasColumnName("all_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AllInsUteId)
                    .IsRequired()
                    .HasColumnName("all_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AllModTimestamp)
                    .HasColumnName("all_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AllModUteId)
                    .IsRequired()
                    .HasColumnName("all_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AllNomeFile)
                    .HasColumnName("all_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AllRiferimentoContatoreInterno).HasColumnName("all_riferimento_contatore_interno");

                entity.Property(e => e.AllRiferimentoId)
                    .IsRequired()
                    .HasColumnName("all_riferimento_id")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AllRiferimentoTabella)
                    .IsRequired()
                    .HasColumnName("all_riferimento_tabella")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllTesto)
                    .HasColumnName("all_testo")
                    .HasColumnType("text");

                entity.Property(e => e.AllTipoAllegato)
                    .IsRequired()
                    .HasColumnName("all_tipo_allegato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.AllCli)
                    .WithMany(p => p.Allegati)
                    .HasForeignKey(d => d.AllCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_allegati_clienti");

                entity.HasOne(d => d.All)
                    .WithMany(p => p.AllegatiAll)
                    .HasForeignKey(d => new { d.AllCliId, d.AllInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_allegati_utenti_ins");

                entity.HasOne(d => d.AllNavigation)
                    .WithMany(p => p.AllegatiAllNavigation)
                    .HasForeignKey(d => new { d.AllCliId, d.AllModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_allegati_utenti_mod");
            });

            modelBuilder.Entity<Annunci>(entity =>
            {
                entity.HasKey(e => new { e.AnnCliId, e.AnnId })
                    .HasName("PK__annunci__D80DA2C77E02232D");

                entity.ToTable("annunci");

                entity.Property(e => e.AnnCliId)
                    .HasColumnName("ann_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AnnId)
                    .HasColumnName("ann_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnnAnnmodId)
                    .HasColumnName("ann_annmod_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AnnAttivo)
                    .IsRequired()
                    .HasColumnName("ann_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AnnCitta)
                    .IsRequired()
                    .HasColumnName("ann_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AnnCompetenzaPrincipale)
                    .HasColumnName("ann_competenza_principale")
                    .HasMaxLength(262)
                    .IsUnicode(false);

                entity.Property(e => e.AnnCompetenzeFacoltative)
                    .HasColumnName("ann_competenze_facoltative")
                    .HasColumnType("text");

                entity.Property(e => e.AnnCompetenzeObbligatorie)
                    .IsRequired()
                    .HasColumnName("ann_competenze_obbligatorie")
                    .HasColumnType("text");

                entity.Property(e => e.AnnDataDisattivazione)
                    .HasColumnName("ann_data_disattivazione")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnDataPubblicazione)
                    .HasColumnName("ann_data_pubblicazione")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnDataSchedulazione)
                    .HasColumnName("ann_data_schedulazione")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnDurata)
                    .IsRequired()
                    .HasColumnName("ann_durata")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnnInizio)
                    .IsRequired()
                    .HasColumnName("ann_inizio")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AnnInquadramento)
                    .IsRequired()
                    .HasColumnName("ann_inquadramento")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AnnInsTimestamp)
                    .HasColumnName("ann_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AnnInsUteId)
                    .IsRequired()
                    .HasColumnName("ann_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnnListaSitiPubblicazione)
                    .HasColumnName("ann_lista_siti_pubblicazione")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AnnModTimestamp)
                    .HasColumnName("ann_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AnnModUteId)
                    .IsRequired()
                    .HasColumnName("ann_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnnNote)
                    .HasColumnName("ann_note")
                    .HasColumnType("text");

                entity.Property(e => e.AnnNumPosizioni).HasColumnName("ann_num_posizioni");

                entity.Property(e => e.AnnRetribuzione)
                    .IsRequired()
                    .HasColumnName("ann_retribuzione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnnRevisionato)
                    .IsRequired()
                    .HasColumnName("ann_revisionato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.AnnRichId)
                    .HasColumnName("ann_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AnnTesto)
                    .IsRequired()
                    .HasColumnName("ann_testo")
                    .HasColumnType("text");

                entity.Property(e => e.AnnTestoHtml)
                    .HasColumnName("ann_testo_html")
                    .HasColumnType("text");

                entity.Property(e => e.AnnTitolo)
                    .IsRequired()
                    .HasColumnName("ann_titolo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnnCli)
                    .WithMany(p => p.Annunci)
                    .HasForeignKey(d => d.AnnCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_clienti");

                entity.HasOne(d => d.AnnC)
                    .WithMany(p => p.Annunci)
                    .HasForeignKey(d => new { d.AnnCliId, d.AnnCitta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_annunci");

                entity.HasOne(d => d.Ann)
                    .WithMany(p => p.AnnunciAnn)
                    .HasForeignKey(d => new { d.AnnCliId, d.AnnInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_utenti_ins");

                entity.HasOne(d => d.AnnNavigation)
                    .WithMany(p => p.AnnunciAnnNavigation)
                    .HasForeignKey(d => new { d.AnnCliId, d.AnnModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_utenti_mod");
            });

            modelBuilder.Entity<AnnunciModelli>(entity =>
            {
                entity.HasKey(e => new { e.AnnmodCliId, e.AnnmodId })
                    .HasName("PK__annunci___FCB491C949F5BB49");

                entity.ToTable("annunci_modelli");

                entity.HasIndex(e => new { e.AnnmodCliId, e.AnnmodCompetenza, e.AnnmodCitta, e.AnnmodTitolo })
                    .HasName("IX_annunci_modelli")
                    .IsUnique();

                entity.Property(e => e.AnnmodCliId)
                    .HasColumnName("annmod_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AnnmodId).HasColumnName("annmod_id");

                entity.Property(e => e.AnnmodCitta)
                    .IsRequired()
                    .HasColumnName("annmod_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AnnmodCompetenza)
                    .IsRequired()
                    .HasColumnName("annmod_competenza")
                    .HasMaxLength(262)
                    .IsUnicode(false);

                entity.Property(e => e.AnnmodCompetenzeFacoltative)
                    .HasColumnName("annmod_competenze_facoltative")
                    .HasColumnType("text");

                entity.Property(e => e.AnnmodCompetenzeObbligatorie)
                    .HasColumnName("annmod_competenze_obbligatorie")
                    .HasColumnType("text");

                entity.Property(e => e.AnnmodDataFine)
                    .HasColumnName("annmod_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnmodDataInizio)
                    .HasColumnName("annmod_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnmodInsTimestamp)
                    .HasColumnName("annmod_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnmodInsUteId)
                    .IsRequired()
                    .HasColumnName("annmod_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnnmodIntSchedulazione).HasColumnName("annmod_int_schedulazione");

                entity.Property(e => e.AnnmodModTimestamp)
                    .HasColumnName("annmod_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.AnnmodModUteId)
                    .IsRequired()
                    .HasColumnName("annmod_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnnmodTitolo)
                    .IsRequired()
                    .HasColumnName("annmod_titolo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnnmodCli)
                    .WithMany(p => p.AnnunciModelli)
                    .HasForeignKey(d => d.AnnmodCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_modelli_clienti");

                entity.HasOne(d => d.AnnmodC)
                    .WithMany(p => p.AnnunciModelli)
                    .HasForeignKey(d => new { d.AnnmodCliId, d.AnnmodCitta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_modelli_citta");

                entity.HasOne(d => d.Annmod)
                    .WithMany(p => p.AnnunciModelliAnnmod)
                    .HasForeignKey(d => new { d.AnnmodCliId, d.AnnmodInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_modelli_utenti_ins");

                entity.HasOne(d => d.AnnmodNavigation)
                    .WithMany(p => p.AnnunciModelliAnnmodNavigation)
                    .HasForeignKey(d => new { d.AnnmodCliId, d.AnnmodModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_annunci_modelli_utenti_mod");
            });

            modelBuilder.Entity<Aziende>(entity =>
            {
                entity.HasKey(e => new { e.AzCliId, e.AzId })
                    .HasName("PK__aziende__F79E770254BCAD9A");

                entity.ToTable("aziende");

                entity.HasIndex(e => e.AzRagSociale)
                    .HasName("az_rag_sociale");

                entity.Property(e => e.AzCliId)
                    .HasColumnName("az_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AzId)
                    .HasColumnName("az_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AzAttiva)
                    .HasColumnName("az_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AzCap)
                    .HasColumnName("az_cap")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AzCitta)
                    .HasColumnName("az_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo1)
                    .HasColumnName("az_coll_luogo_1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo1Indic)
                    .HasColumnName("az_coll_luogo_1_indic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo2)
                    .HasColumnName("az_coll_luogo_2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo2Indic)
                    .HasColumnName("az_coll_luogo_2_indic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo3)
                    .HasColumnName("az_coll_luogo_3")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AzCollLuogo3Indic)
                    .HasColumnName("az_coll_luogo_3_indic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzCvIniziali)
                    .HasColumnName("az_cv_iniziali")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.AzDescrizione)
                    .HasColumnName("az_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.AzEmail1)
                    .HasColumnName("az_email_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AzEmail2)
                    .HasColumnName("az_email_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AzIndirizzo)
                    .HasColumnName("az_indirizzo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzInsTimestamp)
                    .HasColumnName("az_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzInsUteId)
                    .IsRequired()
                    .HasColumnName("az_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzLocationLat)
                    .HasColumnName("az_location_lat")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzLocationLong)
                    .HasColumnName("az_location_long")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzModTimestamp)
                    .HasColumnName("az_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzModUteId)
                    .IsRequired()
                    .HasColumnName("az_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzNote)
                    .HasColumnName("az_note")
                    .HasColumnType("text");

                entity.Property(e => e.AzPriormax).HasColumnName("az_priormax");

                entity.Property(e => e.AzPriormin).HasColumnName("az_priormin");

                entity.Property(e => e.AzRagSociale)
                    .IsRequired()
                    .HasColumnName("az_rag_sociale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzSiglaRichiesta)
                    .HasColumnName("az_sigla_richiesta")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AzSitoWeb)
                    .HasColumnName("az_sito_web")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AzTelefono1)
                    .HasColumnName("az_telefono_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzTelefono2)
                    .HasColumnName("az_telefono_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzTipoAzienda)
                    .HasColumnName("az_tipo_azienda")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.AzUteIdComm)
                    .HasColumnName("az_ute_id_comm")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AzCli)
                    .WithMany(p => p.Aziende)
                    .HasForeignKey(d => d.AzCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_aziende_clienti");

                entity.HasOne(d => d.Az)
                    .WithMany(p => p.AziendeAz)
                    .HasForeignKey(d => new { d.AzCliId, d.AzInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_aziende_utenti_ins");

                entity.HasOne(d => d.AzNavigation)
                    .WithMany(p => p.AziendeAzNavigation)
                    .HasForeignKey(d => new { d.AzCliId, d.AzModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_aziende_utenti_mod");

                entity.HasOne(d => d.Az1)
                    .WithMany(p => p.AziendeAz1)
                    .HasForeignKey(d => new { d.AzCliId, d.AzUteIdComm })
                    .HasConstraintName("FK_aziende_utenti2");
            });

            modelBuilder.Entity<AziendeClientiFinali>(entity =>
            {
                entity.HasKey(e => new { e.ClifinId, e.ClifinCliId });

                entity.ToTable("aziende_clienti_finali");

                entity.Property(e => e.ClifinId)
                    .HasColumnName("clifin_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClifinCliId)
                    .HasColumnName("clifin_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinAzId).HasColumnName("clifin_az_id");

                entity.Property(e => e.ClifinIndirizzo)
                    .HasColumnName("clifin_indirizzo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinInsTimestamp)
                    .HasColumnName("clifin_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClifinInsUteId)
                    .IsRequired()
                    .HasColumnName("clifin_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinLocationLat)
                    .HasColumnName("clifin_location_lat")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ClifinLocationLong)
                    .HasColumnName("clifin_location_long")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ClifinLuogoLavoro)
                    .IsRequired()
                    .HasColumnName("clifin_luogo_lavoro")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinModTimestamp)
                    .HasColumnName("clifin_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ClifinModUteId)
                    .IsRequired()
                    .HasColumnName("clifin_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinNomeClienteFinale)
                    .HasColumnName("clifin_nome_cliente_finale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClifinRaggMezziPubblici)
                    .HasColumnName("clifin_ragg_mezzi_pubblici")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Clifin)
                    .WithMany(p => p.AziendeClientiFinali)
                    .HasForeignKey(d => new { d.ClifinCliId, d.ClifinAzId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_aziende_clienti_finali_aziende");
            });

            modelBuilder.Entity<Azioni>(entity =>
            {
                entity.HasKey(e => new { e.AzioneId, e.AzioneCliId });

                entity.ToTable("azioni");

                entity.Property(e => e.AzioneId)
                    .HasColumnName("azione_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AzioneCliId)
                    .HasColumnName("azione_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AzioneContId).HasColumnName("azione_cont_id");

                entity.Property(e => e.AzioneDescrizione)
                    .HasColumnName("azione_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio01)
                    .HasColumnName("azione_dettaglio_01")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio02)
                    .HasColumnName("azione_dettaglio_02")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio03)
                    .HasColumnName("azione_dettaglio_03")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio04)
                    .HasColumnName("azione_dettaglio_04")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio05)
                    .HasColumnName("azione_dettaglio_05")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneDettaglio06)
                    .HasColumnName("azione_dettaglio_06")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneFine)
                    .HasColumnName("azione_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.AzioneInizio)
                    .HasColumnName("azione_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.AzioneInsTimestamp)
                    .HasColumnName("azione_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzioneInsUteId)
                    .IsRequired()
                    .HasColumnName("azione_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneLuogo)
                    .HasColumnName("azione_luogo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneModTimestamp)
                    .HasColumnName("azione_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzioneModUteId)
                    .IsRequired()
                    .HasColumnName("azione_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneRichId)
                    .HasColumnName("azione_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneRisId).HasColumnName("azione_ris_id");

                entity.Property(e => e.AzioneTipo)
                    .HasColumnName("azione_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AzioneUteId)
                    .IsRequired()
                    .HasColumnName("azione_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AzioneCli)
                    .WithMany(p => p.Azioni)
                    .HasForeignKey(d => d.AzioneCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_azioni_clienti");

                entity.HasOne(d => d.AzioneTipoNavigation)
                    .WithMany(p => p.Azioni)
                    .HasForeignKey(d => d.AzioneTipo)
                    .HasConstraintName("FK_azioni_tipi_azione");

                entity.HasOne(d => d.AzioneC)
                    .WithMany(p => p.Azioni)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneContId })
                    .HasConstraintName("FK_azioni_contatti");

                entity.HasOne(d => d.Azione)
                    .WithMany(p => p.AzioniAzione)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_azioni_utenti_ins");

                entity.HasOne(d => d.AzioneNavigation)
                    .WithMany(p => p.AzioniAzioneNavigation)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_azioni_utenti_mod");

                entity.HasOne(d => d.Azione1)
                    .WithMany(p => p.Azioni)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneRichId })
                    .HasConstraintName("FK_azioni_richieste");

                entity.HasOne(d => d.Azione2)
                    .WithMany(p => p.Azioni)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneRisId })
                    .HasConstraintName("FK_azioni_risorse");

                entity.HasOne(d => d.Azione3)
                    .WithMany(p => p.AzioniAzione3)
                    .HasForeignKey(d => new { d.AzioneCliId, d.AzioneUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_azioni_utenti");
            });

            modelBuilder.Entity<Candidature>(entity =>
            {
                entity.HasKey(e => new { e.CandCliId, e.CandId })
                    .HasName("PK__candidat__26FB44E3E2C7FB5D");

                entity.ToTable("candidature");

                entity.Property(e => e.CandCliId)
                    .HasColumnName("cand_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CandId)
                    .HasColumnName("cand_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CandAnnId)
                    .HasColumnName("cand_ann_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CandData)
                    .HasColumnName("cand_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.CandInsTimestamp)
                    .HasColumnName("cand_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CandInsUteId)
                    .IsRequired()
                    .HasColumnName("cand_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CandModTimestamp)
                    .HasColumnName("cand_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CandModUteId)
                    .IsRequired()
                    .HasColumnName("cand_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CandRisId).HasColumnName("cand_ris_id");

                entity.Property(e => e.CandSito)
                    .IsRequired()
                    .HasColumnName("cand_sito")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CandCli)
                    .WithMany(p => p.Candidature)
                    .HasForeignKey(d => d.CandCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidature_clienti");

                entity.HasOne(d => d.Cand)
                    .WithMany(p => p.CandidatureCand)
                    .HasForeignKey(d => new { d.CandCliId, d.CandInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidature_utenti_ins");

                entity.HasOne(d => d.CandNavigation)
                    .WithMany(p => p.CandidatureCandNavigation)
                    .HasForeignKey(d => new { d.CandCliId, d.CandModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidature_utenti_mod");

                entity.HasOne(d => d.Cand1)
                    .WithMany(p => p.Candidature)
                    .HasForeignKey(d => new { d.CandCliId, d.CandRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_candidature_risorse");
            });

            modelBuilder.Entity<Citta>(entity =>
            {
                entity.HasKey(e => new { e.CittaCliId, e.Citta1 })
                    .HasName("PK__citta__75C6FD88984AA7FC");

                entity.ToTable("citta");

                entity.Property(e => e.CittaCliId)
                    .HasColumnName("citta_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Citta1)
                    .HasColumnName("citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CittaInsTimestamp)
                    .HasColumnName("citta_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CittaInsUteId)
                    .IsRequired()
                    .HasColumnName("citta_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('getdate')");

                entity.Property(e => e.CittaModTimestamp)
                    .HasColumnName("citta_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CittaModUteId)
                    .IsRequired()
                    .HasColumnName("citta_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CittaPrincipale)
                    .HasColumnName("citta_principale")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CittaTarga)
                    .HasColumnName("citta_targa")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CittaCli)
                    .WithMany(p => p.Citta)
                    .HasForeignKey(d => d.CittaCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citta_clienti");

                entity.HasOne(d => d.CittaNavigation)
                    .WithMany(p => p.CittaCittaNavigation)
                    .HasForeignKey(d => new { d.CittaCliId, d.CittaInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citta_utenti_ins");

                entity.HasOne(d => d.Citta2)
                    .WithMany(p => p.CittaCitta2)
                    .HasForeignKey(d => new { d.CittaCliId, d.CittaModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_citta_utenti_mod");
            });

            modelBuilder.Entity<Clienti>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.ToTable("clienti");

                entity.Property(e => e.CliId)
                    .HasColumnName("cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ITP999')");

                entity.Property(e => e.CliAttivoDataFine)
                    .HasColumnName("cli_attivo_data_fine")
                    .HasColumnType("date");

                entity.Property(e => e.CliAttivoDataInizio)
                    .HasColumnName("cli_attivo_data_inizio")
                    .HasColumnType("date");

                entity.Property(e => e.CliInsTimestamp)
                    .HasColumnName("cli_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.CliInsUteId)
                    .IsRequired()
                    .HasColumnName("cli_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CliLingua)
                    .IsRequired()
                    .HasColumnName("cli_lingua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliLogoPath)
                    .HasColumnName("cli_logo_path")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CliModTimestamp)
                    .HasColumnName("cli_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.CliModUteId)
                    .IsRequired()
                    .HasColumnName("cli_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CliNome)
                    .IsRequired()
                    .HasColumnName("cli_nome")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CliNomeWeb)
                    .IsRequired()
                    .HasColumnName("cli_nome_web")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CliNote)
                    .HasColumnName("cli_note")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CliWeb)
                    .HasColumnName("cli_web")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Competenze>(entity =>
            {
                entity.HasKey(e => new { e.CompCliId, e.Competenza })
                    .HasName("PK__competen__6A90B7392B2056B4")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("competenze");

                entity.HasIndex(e => new { e.CompCliId, e.CompSenzaSeniority, e.CompOrdVis })
                    .HasName("idx_comp_ord_vis")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.CompCliId)
                    .HasColumnName("comp_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Competenza)
                    .HasColumnName("competenza")
                    .HasMaxLength(262)
                    .IsUnicode(false);

                entity.Property(e => e.CompDettOrdVis).HasColumnName("comp_dett_ord_vis");

                entity.Property(e => e.CompDettTipo)
                    .HasColumnName("comp_dett_tipo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompDettTipoDescr)
                    .HasColumnName("comp_dett_tipo_descr")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompOrdVis).HasColumnName("comp_ord_vis");

                entity.Property(e => e.CompRichSigla)
                    .HasColumnName("comp_rich_sigla")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CompSenTipo)
                    .HasColumnName("comp_sen_tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompSeniority)
                    .HasColumnName("comp_seniority")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CompSenzaSeniority)
                    .HasColumnName("comp_senza_seniority")
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.CompTipo)
                    .HasColumnName("comp_tipo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompCli)
                    .WithMany(p => p.Competenze)
                    .HasForeignKey(d => d.CompCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competenze_clienti");
            });

            modelBuilder.Entity<CompetenzeTipi>(entity =>
            {
                entity.HasKey(e => new { e.ComptipCliId, e.CompetenzaTipo })
                    .HasName("PK__competen__0AB089C2B0B68105");

                entity.ToTable("competenze_tipi");

                entity.Property(e => e.ComptipCliId)
                    .HasColumnName("comptip_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CompetenzaTipo)
                    .HasColumnName("competenza_tipo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipCompetenzaTipoDettaglio)
                    .IsRequired()
                    .HasColumnName("comptip_competenza_tipo_dettaglio")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipLabelDefault)
                    .IsRequired()
                    .HasColumnName("comptip_label_default")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipRichSigla)
                    .HasColumnName("comptip_rich_sigla")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipSeniorityDefault)
                    .IsRequired()
                    .HasColumnName("comptip_seniority_default")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipSeniorityObb)
                    .HasColumnName("comptip_seniority_obb")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ComptipTipoDettaglioObb)
                    .HasColumnName("comptip_tipo_dettaglio_obb")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.ComptipCli)
                    .WithMany(p => p.CompetenzeTipi)
                    .HasForeignKey(d => d.ComptipCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_competenze_tipi_clienti");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => new { e.ConfigCliId, e.ConfigId })
                    .HasName("PK__config__C604EEBCE63DDDB1");

                entity.ToTable("config");

                entity.Property(e => e.ConfigCliId)
                    .HasColumnName("config_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ConfigId)
                    .HasColumnName("config_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConfigInsTimestamp)
                    .HasColumnName("config_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfigInsUteId)
                    .IsRequired()
                    .HasColumnName("config_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigModTimestamp)
                    .HasColumnName("config_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfigModUteId)
                    .IsRequired()
                    .HasColumnName("config_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigNoteParam).HasColumnName("config_note_param");

                entity.Property(e => e.ConfigParam)
                    .IsRequired()
                    .HasColumnName("config_param")
                    .HasMaxLength(500);

                entity.Property(e => e.ConfigParamName)
                    .IsRequired()
                    .HasColumnName("config_param_name");

                entity.HasOne(d => d.ConfigCli)
                    .WithMany(p => p.Config)
                    .HasForeignKey(d => d.ConfigCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_config_clienti");

                entity.HasOne(d => d.ConfigNavigation)
                    .WithMany(p => p.ConfigConfigNavigation)
                    .HasForeignKey(d => new { d.ConfigCliId, d.ConfigInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_config_utenti_ins");

                entity.HasOne(d => d.Config1)
                    .WithMany(p => p.ConfigConfig1)
                    .HasForeignKey(d => new { d.ConfigCliId, d.ConfigModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_config_utenti_mod");
            });

            modelBuilder.Entity<Contatti>(entity =>
            {
                entity.HasKey(e => new { e.ContCliId, e.ContId })
                    .HasName("PK__contatti__168BDA080DFA6689");

                entity.ToTable("contatti");

                entity.HasIndex(e => e.ContAzId)
                    .HasName("cont_az_id");

                entity.Property(e => e.ContCliId)
                    .HasColumnName("cont_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ContId).HasColumnName("cont_id");

                entity.Property(e => e.ContAttivo)
                    .IsRequired()
                    .HasColumnName("cont_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.ContAzId).HasColumnName("cont_az_id");

                entity.Property(e => e.ContAzsedeId).HasColumnName("cont_azsede_id");

                entity.Property(e => e.ContCitta)
                    .IsRequired()
                    .HasColumnName("cont_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContCognome)
                    .IsRequired()
                    .HasColumnName("cont_cognome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ContCvIniziali)
                    .HasColumnName("cont_cv_iniziali")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ContDescrizione)
                    .HasColumnName("cont_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.ContEmail1)
                    .IsRequired()
                    .HasColumnName("cont_email_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContEmail2)
                    .HasColumnName("cont_email_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContInsTimestamp)
                    .HasColumnName("cont_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContInsUteId)
                    .HasColumnName("cont_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContInvioCvNote)
                    .HasColumnName("cont_invio_cv_note")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ContModTimestamp)
                    .HasColumnName("cont_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContModUteId)
                    .HasColumnName("cont_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContNome)
                    .IsRequired()
                    .HasColumnName("cont_nome")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ContNote)
                    .HasColumnName("cont_note")
                    .HasColumnType("text");

                entity.Property(e => e.ContOrari1Fine)
                    .HasColumnName("cont_orari_1_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari1Giorno)
                    .HasColumnName("cont_orari_1_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari1Inizio)
                    .HasColumnName("cont_orari_1_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Fine)
                    .HasColumnName("cont_orari_2_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Giorno)
                    .HasColumnName("cont_orari_2_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari2Inizio)
                    .HasColumnName("cont_orari_2_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Fine)
                    .HasColumnName("cont_orari_3_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Giorno)
                    .HasColumnName("cont_orari_3_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari3Inizio)
                    .HasColumnName("cont_orari_3_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Fine)
                    .HasColumnName("cont_orari_4_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Giorno)
                    .HasColumnName("cont_orari_4_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari4Inizio)
                    .HasColumnName("cont_orari_4_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Fine)
                    .HasColumnName("cont_orari_5_fine")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Giorno)
                    .HasColumnName("cont_orari_5_giorno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContOrari5Inizio)
                    .HasColumnName("cont_orari_5_inizio")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ContPosizione)
                    .HasColumnName("cont_posizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContPriormax).HasColumnName("cont_priormax");

                entity.Property(e => e.ContPriormin).HasColumnName("cont_priormin");

                entity.Property(e => e.ContRifUteId)
                    .IsRequired()
                    .HasColumnName("cont_rif_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTelefono1)
                    .IsRequired()
                    .HasColumnName("cont_telefono_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTelefono2)
                    .HasColumnName("cont_telefono_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContTipoContatto)
                    .IsRequired()
                    .HasColumnName("cont_tipo_contatto")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Altro')");

                entity.Property(e => e.ContTitolo)
                    .IsRequired()
                    .HasColumnName("cont_titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContAzsede)
                    .WithMany(p => p.Contatti)
                    .HasForeignKey(d => d.ContAzsedeId)
                    .HasConstraintName("FK_contatti_sedi_aziende");

                entity.HasOne(d => d.ContCli)
                    .WithMany(p => p.Contatti)
                    .HasForeignKey(d => d.ContCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contatti_clienti");

                entity.HasOne(d => d.Cont)
                    .WithMany(p => p.Contatti)
                    .HasForeignKey(d => new { d.ContCliId, d.ContAzId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contatti_aziende");

                entity.HasOne(d => d.ContNavigation)
                    .WithMany(p => p.ContattiContNavigation)
                    .HasForeignKey(d => new { d.ContCliId, d.ContInsUteId })
                    .HasConstraintName("FK_contatti_utenti_ins");

                entity.HasOne(d => d.Cont1)
                    .WithMany(p => p.ContattiCont1)
                    .HasForeignKey(d => new { d.ContCliId, d.ContModUteId })
                    .HasConstraintName("FK_contatti_utenti_mod");

                entity.HasOne(d => d.Cont2)
                    .WithMany(p => p.Contatti)
                    .HasForeignKey(d => new { d.ContCliId, d.ContTipoContatto })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contatti_tipi_contatto");
            });

            modelBuilder.Entity<CvCampi>(entity =>
            {
                entity.HasKey(e => new { e.CvcamCliId, e.CvcamCodice })
                    .HasName("PK__cv_campi__315D5C594FF56D9B");

                entity.ToTable("cv_campi");

                entity.Property(e => e.CvcamCliId)
                    .HasColumnName("cvcam_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvcamCodice)
                    .HasColumnName("cvcam_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvcamDescrizione)
                    .IsRequired()
                    .HasColumnName("cvcam_descrizione")
                    .IsUnicode(false);

                entity.Property(e => e.CvcamEsempi)
                    .IsRequired()
                    .HasColumnName("cvcam_esempi")
                    .IsUnicode(false);

                entity.Property(e => e.CvcamInsTimestamp)
                    .HasColumnName("cvcam_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvcamInsUteId)
                    .IsRequired()
                    .HasColumnName("cvcam_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvcamModTimestamp)
                    .HasColumnName("cvcam_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvcamModUteId)
                    .IsRequired()
                    .HasColumnName("cvcam_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvcamNote)
                    .HasColumnName("cvcam_note")
                    .IsUnicode(false);

                entity.Property(e => e.CvcamTipo)
                    .HasColumnName("cvcam_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CvcamValidazione)
                    .HasColumnName("cvcam_validazione")
                    .IsUnicode(false);

                entity.HasOne(d => d.CvcamCli)
                    .WithMany(p => p.CvCampi)
                    .HasForeignKey(d => d.CvcamCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_campi_clienti");

                entity.HasOne(d => d.Cvcam)
                    .WithMany(p => p.CvCampiCvcam)
                    .HasForeignKey(d => new { d.CvcamCliId, d.CvcamInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_campi_utenti_ins");

                entity.HasOne(d => d.CvcamNavigation)
                    .WithMany(p => p.CvCampiCvcamNavigation)
                    .HasForeignKey(d => new { d.CvcamCliId, d.CvcamModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_campi_utenti_mod");
            });

            modelBuilder.Entity<CvLingue>(entity =>
            {
                entity.HasKey(e => new { e.CvlinCliId, e.CvlinCodice })
                    .HasName("PK__cv_lingu__A34F2B2000250174");

                entity.ToTable("cv_lingue");

                entity.Property(e => e.CvlinCliId)
                    .HasColumnName("cvlin_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvlinCodice)
                    .HasColumnName("cvlin_codice")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CvlinDescrizione)
                    .IsRequired()
                    .HasColumnName("cvlin_descrizione")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CvlinInsTimestamp)
                    .HasColumnName("cvlin_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvlinInsUteId)
                    .IsRequired()
                    .HasColumnName("cvlin_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvlinModTimestamp)
                    .HasColumnName("cvlin_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvlinModUteId)
                    .IsRequired()
                    .HasColumnName("cvlin_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvlinNote)
                    .HasColumnName("cvlin_note")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CvlinOrdineRicerca).HasColumnName("cvlin_ordine_ricerca");

                entity.HasOne(d => d.CvlinCli)
                    .WithMany(p => p.CvLingue)
                    .HasForeignKey(d => d.CvlinCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_lingue_clienti");

                entity.HasOne(d => d.Cvlin)
                    .WithMany(p => p.CvLingueCvlin)
                    .HasForeignKey(d => new { d.CvlinCliId, d.CvlinInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_lingue_utenti_ins");

                entity.HasOne(d => d.CvlinNavigation)
                    .WithMany(p => p.CvLingueCvlinNavigation)
                    .HasForeignKey(d => new { d.CvlinCliId, d.CvlinModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_lingue_utenti_mod");
            });

            modelBuilder.Entity<CvSchemi>(entity =>
            {
                entity.HasKey(e => new { e.CvschemCliId, e.CvschemCodice })
                    .HasName("PK__cv_schem__2804C8A038D31324");

                entity.ToTable("cv_schemi");

                entity.Property(e => e.CvschemCliId)
                    .HasColumnName("cvschem_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvschemCodice)
                    .HasColumnName("cvschem_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemCvlinCodice)
                    .IsRequired()
                    .HasColumnName("cvschem_cvlin_codice")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemDescrizione)
                    .IsRequired()
                    .HasColumnName("cvschem_descrizione")
                    .IsUnicode(false);

                entity.Property(e => e.CvschemInsTimestamp)
                    .HasColumnName("cvschem_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvschemInsUteId)
                    .IsRequired()
                    .HasColumnName("cvschem_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemModTimestamp)
                    .HasColumnName("cvschem_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvschemModUteId)
                    .IsRequired()
                    .HasColumnName("cvschem_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemNote)
                    .HasColumnName("cvschem_note")
                    .IsUnicode(false);

                entity.Property(e => e.CvschemOrdine).HasColumnName("cvschem_ordine");

                entity.Property(e => e.CvschemSito)
                    .HasColumnName("cvschem_sito")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemStatFrequenzaPerc)
                    .HasColumnName("cvschem_stat_frequenza_perc")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.CvschemStatNote)
                    .HasColumnName("cvschem_stat_note")
                    .IsUnicode(false);

                entity.Property(e => e.CvschemStatNumCvAnalizzati).HasColumnName("cvschem_stat_num_cv_analizzati");

                entity.Property(e => e.CvschemStatNumCvRilevati).HasColumnName("cvschem_stat_num_cv_rilevati");

                entity.Property(e => e.CvschemStatUltimoAggiornamento)
                    .HasColumnName("cvschem_stat_ultimo_aggiornamento")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CvschemCli)
                    .WithMany(p => p.CvSchemi)
                    .HasForeignKey(d => d.CvschemCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_clienti");

                entity.HasOne(d => d.CvschemC)
                    .WithMany(p => p.CvSchemi)
                    .HasForeignKey(d => new { d.CvschemCliId, d.CvschemCvlinCodice })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analisi_cv_schemi_analisi_cv_lingue");

                entity.HasOne(d => d.Cvschem)
                    .WithMany(p => p.CvSchemiCvschem)
                    .HasForeignKey(d => new { d.CvschemCliId, d.CvschemInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_utenti_ins");

                entity.HasOne(d => d.CvschemNavigation)
                    .WithMany(p => p.CvSchemiCvschemNavigation)
                    .HasForeignKey(d => new { d.CvschemCliId, d.CvschemModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_utenti_mod");
            });

            modelBuilder.Entity<CvSchemiIdentificatori>(entity =>
            {
                entity.HasKey(e => new { e.CvschemideCliId, e.CvschemideId })
                    .HasName("PK__cv_schem__238C3C4A4A76A577");

                entity.ToTable("cv_schemi_identificatori");

                entity.Property(e => e.CvschemideCliId)
                    .HasColumnName("cvschemide_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvschemideId)
                    .HasColumnName("cvschemide_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemideCvschemCodice)
                    .IsRequired()
                    .HasColumnName("cvschemide_cvschem_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemideInsTimestamp)
                    .HasColumnName("cvschemide_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvschemideInsUteId)
                    .IsRequired()
                    .HasColumnName("cvschemide_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemideModTimestamp)
                    .HasColumnName("cvschemide_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvschemideModUteId)
                    .IsRequired()
                    .HasColumnName("cvschemide_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvschemideNote)
                    .IsRequired()
                    .HasColumnName("cvschemide_note")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CvschemideOrdine).HasColumnName("cvschemide_ordine");

                entity.Property(e => e.CvschemideStatFrequenzaPerc)
                    .HasColumnName("cvschemide_stat_frequenza_perc")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.CvschemideStatNote)
                    .HasColumnName("cvschemide_stat_note")
                    .IsUnicode(false);

                entity.Property(e => e.CvschemideStatNumCvAnalizzati).HasColumnName("cvschemide_stat_num_cv_analizzati");

                entity.Property(e => e.CvschemideStatNumCvRilevati).HasColumnName("cvschemide_stat_num_cv_rilevati");

                entity.Property(e => e.CvschemideStatUltimoAggiornamento)
                    .HasColumnName("cvschemide_stat_ultimo_aggiornamento")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CvschemideCli)
                    .WithMany(p => p.CvSchemiIdentificatori)
                    .HasForeignKey(d => d.CvschemideCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_identificatori_clienti");

                entity.HasOne(d => d.CvschemideC)
                    .WithMany(p => p.CvSchemiIdentificatori)
                    .HasForeignKey(d => new { d.CvschemideCliId, d.CvschemideCvschemCodice })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analisi_cv_schemi_identificatori_analisi_cv_schemi");

                entity.HasOne(d => d.Cvschemide)
                    .WithMany(p => p.CvSchemiIdentificatoriCvschemide)
                    .HasForeignKey(d => new { d.CvschemideCliId, d.CvschemideInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_identificatori_utenti_ins");

                entity.HasOne(d => d.CvschemideNavigation)
                    .WithMany(p => p.CvSchemiIdentificatoriCvschemideNavigation)
                    .HasForeignKey(d => new { d.CvschemideCliId, d.CvschemideModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_schemi_identificatori_utenti_mod");
            });

            modelBuilder.Entity<CvSezioni>(entity =>
            {
                entity.HasKey(e => new { e.CvsezCliId, e.CvsezCodice })
                    .HasName("PK__cv_sezio__9FA90B93356466F0");

                entity.ToTable("cv_sezioni");

                entity.Property(e => e.CvsezCliId)
                    .HasColumnName("cvsez_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvsezCodice)
                    .HasColumnName("cvsez_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CvsezDescrizione)
                    .IsRequired()
                    .HasColumnName("cvsez_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvsezInsTimestamp)
                    .HasColumnName("cvsez_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsezInsUteId)
                    .IsRequired()
                    .HasColumnName("cvsez_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsezModTimestamp)
                    .HasColumnName("cvsez_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsezModUteId)
                    .IsRequired()
                    .HasColumnName("cvsez_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsezNote)
                    .HasColumnName("cvsez_note")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.CvsezCli)
                    .WithMany(p => p.CvSezioni)
                    .HasForeignKey(d => d.CvsezCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sezioni_clienti");

                entity.HasOne(d => d.Cvsez)
                    .WithMany(p => p.CvSezioniCvsez)
                    .HasForeignKey(d => new { d.CvsezCliId, d.CvsezInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sezioni_utenti_ins");

                entity.HasOne(d => d.CvsezNavigation)
                    .WithMany(p => p.CvSezioniCvsezNavigation)
                    .HasForeignKey(d => new { d.CvsezCliId, d.CvsezModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sezioni_utenti_mod");
            });

            modelBuilder.Entity<CvSostituzioni>(entity =>
            {
                entity.HasKey(e => new { e.CvsostCliId, e.CvsostId })
                    .HasName("PK__cv_sosti__6E32715021888901");

                entity.ToTable("cv_sostituzioni");

                entity.Property(e => e.CvsostCliId)
                    .HasColumnName("cvsost_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvsostId)
                    .HasColumnName("cvsost_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CvsostCvlinCodice)
                    .IsRequired()
                    .HasColumnName("cvsost_cvlin_codice")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostCvschemCodice)
                    .HasColumnName("cvsost_cvschem_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostDaSostituire)
                    .IsRequired()
                    .HasColumnName("cvsost_da_sostituire")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostDaSostituireTipo)
                    .IsRequired()
                    .HasColumnName("cvsost_da_sostituire_tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostInsTimestamp)
                    .HasColumnName("cvsost_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsostInsUteId)
                    .IsRequired()
                    .HasColumnName("cvsost_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostModTimestamp)
                    .HasColumnName("cvsost_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsostModUteId)
                    .IsRequired()
                    .HasColumnName("cvsost_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostNote)
                    .HasColumnName("cvsost_note")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostOrdine).HasColumnName("cvsost_ordine");

                entity.Property(e => e.CvsostSostituitoTipo)
                    .IsRequired()
                    .HasColumnName("cvsost_sostituito_tipo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CvsostSostituto)
                    .IsRequired()
                    .HasColumnName("cvsost_sostituto")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.CvsostCli)
                    .WithMany(p => p.CvSostituzioni)
                    .HasForeignKey(d => d.CvsostCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sostituzioni_clienti");

                entity.HasOne(d => d.CvsostC)
                    .WithMany(p => p.CvSostituzioni)
                    .HasForeignKey(d => new { d.CvsostCliId, d.CvsostCvlinCodice })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analisi_cv_sostituzioni_analisi_cv_lingue");

                entity.HasOne(d => d.CvsostCNavigation)
                    .WithMany(p => p.CvSostituzioni)
                    .HasForeignKey(d => new { d.CvsostCliId, d.CvsostCvschemCodice })
                    .HasConstraintName("FK_cv_sostituzioni_cv_schemi");

                entity.HasOne(d => d.Cvsost)
                    .WithMany(p => p.CvSostituzioniCvsost)
                    .HasForeignKey(d => new { d.CvsostCliId, d.CvsostInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sostituzioni_utenti_ins");

                entity.HasOne(d => d.CvsostNavigation)
                    .WithMany(p => p.CvSostituzioniCvsostNavigation)
                    .HasForeignKey(d => new { d.CvsostCliId, d.CvsostModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sostituzioni_utenti_mod");
            });

            modelBuilder.Entity<CvSottosezioni>(entity =>
            {
                entity.HasKey(e => new { e.CvsotsezCliId, e.CvsotsezCodice })
                    .HasName("PK__cv_sotto__A603967285EEF25A");

                entity.ToTable("cv_sottosezioni");

                entity.Property(e => e.CvsotsezCliId)
                    .HasColumnName("cvsotsez_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvsotsezCodice)
                    .HasColumnName("cvsotsez_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CvsotsezDescrizione)
                    .IsRequired()
                    .HasColumnName("cvsotsez_descrizione")
                    .IsUnicode(false);

                entity.Property(e => e.CvsotsezEsempi)
                    .IsRequired()
                    .HasColumnName("cvsotsez_esempi")
                    .IsUnicode(false);

                entity.Property(e => e.CvsotsezInsTimestamp)
                    .HasColumnName("cvsotsez_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsotsezInsUteId)
                    .IsRequired()
                    .HasColumnName("cvsotsez_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsotsezModTimestamp)
                    .HasColumnName("cvsotsez_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvsotsezModUteId)
                    .IsRequired()
                    .HasColumnName("cvsotsez_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CvsotsezNote)
                    .HasColumnName("cvsotsez_note")
                    .IsUnicode(false);

                entity.HasOne(d => d.CvsotsezCli)
                    .WithMany(p => p.CvSottosezioni)
                    .HasForeignKey(d => d.CvsotsezCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sottosezioni_clienti");

                entity.HasOne(d => d.Cvsotsez)
                    .WithMany(p => p.CvSottosezioniCvsotsez)
                    .HasForeignKey(d => new { d.CvsotsezCliId, d.CvsotsezInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sottosezioni_utenti_ins");

                entity.HasOne(d => d.CvsotsezNavigation)
                    .WithMany(p => p.CvSottosezioniCvsotsezNavigation)
                    .HasForeignKey(d => new { d.CvsotsezCliId, d.CvsotsezModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_sottosezioni_utenti_mod");
            });

            modelBuilder.Entity<CvTemplatePlaceholders>(entity =>
            {
                entity.HasKey(e => new { e.CvtemplCliId, e.CvtemplId })
                    .HasName("PK__cv_templ__3A413492C2274FA5");

                entity.ToTable("cv_template_placeholders");

                entity.Property(e => e.CvtemplCliId)
                    .HasColumnName("cvtempl_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.CvtemplId)
                    .HasColumnName("cvtempl_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CvtemplPlaceholder)
                    .IsRequired()
                    .HasColumnName("cvtempl_placeholder")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CvtemplPlaceholderTesto)
                    .HasColumnName("cvtempl_placeholder_testo")
                    .IsUnicode(false);

                entity.Property(e => e.CvtemplTemplate)
                    .IsRequired()
                    .HasColumnName("cvtempl_template")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CvtemplCli)
                    .WithMany(p => p.CvTemplatePlaceholders)
                    .HasForeignKey(d => d.CvtemplCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cv_template_placeholders_clienti");
            });

            modelBuilder.Entity<Filiali>(entity =>
            {
                entity.HasKey(e => new { e.FilialeCliId, e.FilialeId })
                    .HasName("PK__filiali__FB4140623363886B");

                entity.ToTable("filiali");

                entity.Property(e => e.FilialeCliId)
                    .HasColumnName("filiale_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.FilialeId)
                    .HasColumnName("filiale_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FilialeAttiva)
                    .HasColumnName("filiale_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.FilialeCell1)
                    .HasColumnName("filiale_cell1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeCell2)
                    .HasColumnName("filiale_cell2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeCell3)
                    .HasColumnName("filiale_cell3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeCitta)
                    .IsRequired()
                    .HasColumnName("filiale_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeCodice)
                    .IsRequired()
                    .HasColumnName("filiale_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeDescrizione)
                    .HasColumnName("filiale_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.FilialeFax)
                    .HasColumnName("filiale_fax")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeIndirizzo)
                    .IsRequired()
                    .HasColumnName("filiale_indirizzo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeInsTimestamp)
                    .HasColumnName("filiale_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilialeInsUteId)
                    .IsRequired()
                    .HasColumnName("filiale_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeMail1)
                    .HasColumnName("filiale_mail1")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeMail2)
                    .HasColumnName("filiale_mail2")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeMail3)
                    .HasColumnName("filiale_mail3")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeModTimestamp)
                    .HasColumnName("filiale_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilialeModUteId)
                    .IsRequired()
                    .HasColumnName("filiale_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeNome)
                    .HasColumnName("filiale_nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeSito)
                    .HasColumnName("filiale_sito")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FilialeTelFisso)
                    .HasColumnName("filiale_tel_fisso")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilialeCli)
                    .WithMany(p => p.Filiali)
                    .HasForeignKey(d => d.FilialeCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_filiali_clienti");

                entity.HasOne(d => d.Filiale)
                    .WithMany(p => p.FilialiFiliale)
                    .HasForeignKey(d => new { d.FilialeCliId, d.FilialeInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_filiali_utenti_ins");

                entity.HasOne(d => d.FilialeNavigation)
                    .WithMany(p => p.FilialiFilialeNavigation)
                    .HasForeignKey(d => new { d.FilialeCliId, d.FilialeModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_filiali_utenti_mod");
            });

            modelBuilder.Entity<Implementazioni>(entity =>
            {
                entity.HasKey(e => new { e.ImplCliId, e.ImplId })
                    .HasName("PK__implemen__C41DD9ECEDE74AB2");

                entity.ToTable("implementazioni");

                entity.Property(e => e.ImplCliId)
                    .HasColumnName("impl_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ImplId).HasColumnName("impl_id");

                entity.Property(e => e.ImplAssegnatarioUteId)
                    .HasColumnName("impl_assegnatario_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplCodice)
                    .HasColumnName("impl_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImplCodiceRelease)
                    .HasColumnName("impl_codice_release")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ImplDataImplementazione)
                    .HasColumnName("impl_data_implementazione")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImplDataRichiesta)
                    .HasColumnName("impl_data_richiesta")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplDataRilascio)
                    .HasColumnName("impl_data_rilascio")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImplDescImplementazione)
                    .HasColumnName("impl_desc_implementazione")
                    .HasColumnType("text");

                entity.Property(e => e.ImplDescrizione)
                    .IsRequired()
                    .HasColumnName("impl_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.ImplEsportata)
                    .HasColumnName("impl_esportata")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ImplFrequenza)
                    .HasColumnName("impl_frequenza")
                    .HasMaxLength(50);

                entity.Property(e => e.ImplImplprocId)
                    .IsRequired()
                    .HasColumnName("impl_implproc_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplInclusoInRelease)
                    .HasColumnName("impl_incluso_in_release")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ImplInsTimestamp)
                    .HasColumnName("impl_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplInsUteId)
                    .IsRequired()
                    .HasColumnName("impl_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplModTimestamp)
                    .HasColumnName("impl_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplModUteId)
                    .IsRequired()
                    .HasColumnName("impl_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplNoteSviluppo)
                    .HasColumnName("impl_note_sviluppo")
                    .IsUnicode(false);

                entity.Property(e => e.ImplPersCoinvolte)
                    .HasColumnName("impl_pers_coinvolte")
                    .HasMaxLength(50);

                entity.Property(e => e.ImplPriorita).HasColumnName("impl_priorita");

                entity.Property(e => e.ImplRichiedenteUteId)
                    .IsRequired()
                    .HasColumnName("impl_richiedente_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplRifEmail)
                    .HasColumnName("impl_rif_email")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImplStato)
                    .IsRequired()
                    .HasColumnName("impl_stato")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplStimaOre).HasColumnName("impl_stima_ore");

                entity.Property(e => e.ImplTempoPerso)
                    .HasColumnName("impl_tempo_perso")
                    .HasMaxLength(50);

                entity.Property(e => e.ImplTipo)
                    .IsRequired()
                    .HasColumnName("impl_tipo")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ImplTotTempi)
                    .HasColumnName("impl_tot_tempi")
                    .HasComputedColumnSql("((CONVERT([int],[impl_frequenza],(0))*CONVERT([int],[impl_pers_coinvolte],(0)))*CONVERT([int],[impl_tempo_perso],(0)))");

                entity.HasOne(d => d.ImplCli)
                    .WithMany(p => p.Implementazioni)
                    .HasForeignKey(d => d.ImplCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_clienti");

                entity.HasOne(d => d.Impl)
                    .WithMany(p => p.Implementazioni)
                    .HasForeignKey(d => new { d.ImplCliId, d.ImplImplprocId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_implementazioni_procedure");

                entity.HasOne(d => d.ImplNavigation)
                    .WithMany(p => p.ImplementazioniImplNavigation)
                    .HasForeignKey(d => new { d.ImplCliId, d.ImplInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_utenti_ins");

                entity.HasOne(d => d.Impl1)
                    .WithMany(p => p.ImplementazioniImpl1)
                    .HasForeignKey(d => new { d.ImplCliId, d.ImplModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_utenti_mod");
            });

            modelBuilder.Entity<ImplementazioniProcedure>(entity =>
            {
                entity.HasKey(e => new { e.ImplprocCliId, e.ImplprocId })
                    .HasName("PK__implemen__FFBA40FF32C6E77F");

                entity.ToTable("implementazioni_procedure");

                entity.Property(e => e.ImplprocCliId)
                    .HasColumnName("implproc_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ImplprocId)
                    .HasColumnName("implproc_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplprocDescrizione)
                    .IsRequired()
                    .HasColumnName("implproc_descrizione")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImplprocInsTimestamp)
                    .HasColumnName("implproc_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplprocInsUteId)
                    .IsRequired()
                    .HasColumnName("implproc_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplprocModTimestamp)
                    .HasColumnName("implproc_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplprocModUteId)
                    .IsRequired()
                    .HasColumnName("implproc_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImplprocCli)
                    .WithMany(p => p.ImplementazioniProcedure)
                    .HasForeignKey(d => d.ImplprocCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_procedure_clienti");

                entity.HasOne(d => d.Implproc)
                    .WithMany(p => p.ImplementazioniProcedureImplproc)
                    .HasForeignKey(d => new { d.ImplprocCliId, d.ImplprocInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_procedure_utenti_ins");

                entity.HasOne(d => d.ImplprocNavigation)
                    .WithMany(p => p.ImplementazioniProcedureImplprocNavigation)
                    .HasForeignKey(d => new { d.ImplprocCliId, d.ImplprocModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_procedure_utenti_mod");
            });

            modelBuilder.Entity<ImplementazioniProgetti>(entity =>
            {
                entity.HasKey(e => new { e.ImplprogCliId, e.ImplprogId })
                    .HasName("PK__implemen__F56A32C05C60E10A");

                entity.ToTable("implementazioni_progetti");

                entity.Property(e => e.ImplprogCliId)
                    .HasColumnName("implprog_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ImplprogId)
                    .HasColumnName("implprog_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ImplprogInsTimestamp)
                    .HasColumnName("implprog_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplprogInsUteId)
                    .IsRequired()
                    .HasColumnName("implprog_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplprogMailto)
                    .HasColumnName("implprog_mailto")
                    .HasMaxLength(100);

                entity.Property(e => e.ImplprogModTimestamp)
                    .HasColumnName("implprog_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImplprogModUteId)
                    .IsRequired()
                    .HasColumnName("implprog_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImplprogNome)
                    .IsRequired()
                    .HasColumnName("implprog_nome")
                    .HasMaxLength(100);

                entity.Property(e => e.ImplprogNote).HasColumnName("implprog_note");

                entity.HasOne(d => d.ImplprogCli)
                    .WithMany(p => p.ImplementazioniProgetti)
                    .HasForeignKey(d => d.ImplprogCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_progetti_clienti");

                entity.HasOne(d => d.Implprog)
                    .WithMany(p => p.ImplementazioniProgettiImplprog)
                    .HasForeignKey(d => new { d.ImplprogCliId, d.ImplprogInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_progetti_utenti_ins");

                entity.HasOne(d => d.ImplprogNavigation)
                    .WithMany(p => p.ImplementazioniProgettiImplprogNavigation)
                    .HasForeignKey(d => new { d.ImplprogCliId, d.ImplprogModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_implementazioni_progetti_utenti_mod");
            });

            modelBuilder.Entity<LinguaLivelli>(entity =>
            {
                entity.HasKey(e => new { e.LingualivCliId, e.LinguaLivello })
                    .HasName("PK__lingua_l__81D102A641A60DC4");

                entity.ToTable("lingua_livelli");

                entity.Property(e => e.LingualivCliId)
                    .HasColumnName("lingualiv_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.LinguaLivello).HasColumnName("lingua_livello");

                entity.Property(e => e.LingualivClass1)
                    .HasColumnName("lingualiv_class1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivClass1Descr)
                    .HasColumnName("lingualiv_class1_descr")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivClass2)
                    .HasColumnName("lingualiv_class2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivClass2Descr)
                    .HasColumnName("lingualiv_class2_descr")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivClass3)
                    .HasColumnName("lingualiv_class3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivClass3Descr)
                    .HasColumnName("lingualiv_class3_descr")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivInsTimestamp)
                    .HasColumnName("lingualiv_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LingualivInsUteId)
                    .IsRequired()
                    .HasColumnName("lingualiv_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LingualivModTimestamp)
                    .HasColumnName("lingualiv_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LingualivModUteId)
                    .IsRequired()
                    .HasColumnName("lingualiv_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LingualivCli)
                    .WithMany(p => p.LinguaLivelli)
                    .HasForeignKey(d => d.LingualivCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingua_livelli_clienti");

                entity.HasOne(d => d.Lingualiv)
                    .WithMany(p => p.LinguaLivelliLingualiv)
                    .HasForeignKey(d => new { d.LingualivCliId, d.LingualivInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingua_livelli_utenti_ins");

                entity.HasOne(d => d.LingualivNavigation)
                    .WithMany(p => p.LinguaLivelliLingualivNavigation)
                    .HasForeignKey(d => new { d.LingualivCliId, d.LingualivModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingua_livelli_utenti_mod");
            });

            modelBuilder.Entity<Lingue>(entity =>
            {
                entity.HasKey(e => new { e.LinguaCliId, e.Lingua })
                    .HasName("PK__lingue__A3C7C55413D37AB8");

                entity.ToTable("lingue");

                entity.Property(e => e.LinguaCliId)
                    .HasColumnName("lingua_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Lingua)
                    .HasColumnName("lingua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinguaInsTimestamp)
                    .HasColumnName("lingua_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LinguaInsUteId)
                    .IsRequired()
                    .HasColumnName("lingua_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LinguaModTimestamp)
                    .HasColumnName("lingua_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LinguaModUteId)
                    .IsRequired()
                    .HasColumnName("lingua_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LinguaOrdine).HasColumnName("lingua_ordine");

                entity.HasOne(d => d.LinguaCli)
                    .WithMany(p => p.Lingue)
                    .HasForeignKey(d => d.LinguaCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingue_clienti");

                entity.HasOne(d => d.LinguaNavigation)
                    .WithMany(p => p.LingueLinguaNavigation)
                    .HasForeignKey(d => new { d.LinguaCliId, d.LinguaInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingue_utenti_ins");

                entity.HasOne(d => d.Lingua1)
                    .WithMany(p => p.LingueLingua1)
                    .HasForeignKey(d => new { d.LinguaCliId, d.LinguaModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lingue_utenti_mod");
            });

            modelBuilder.Entity<LogOperazioni>(entity =>
            {
                entity.HasKey(e => new { e.LogCliId, e.LogId })
                    .HasName("PK__log_oper__FF40C1418CA92A70");

                entity.ToTable("log_operazioni");

                entity.Property(e => e.LogCliId)
                    .HasColumnName("log_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LogAccAccountEmail)
                    .HasColumnName("log_acc_account_email")
                    .HasMaxLength(250);

                entity.Property(e => e.LogDescr)
                    .IsRequired()
                    .HasColumnName("log_descr")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogDettaglio)
                    .HasColumnName("log_dettaglio")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LogTimestamp)
                    .HasColumnName("log_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogUteId)
                    .IsRequired()
                    .HasColumnName("log_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LogCli)
                    .WithMany(p => p.LogOperazioni)
                    .HasForeignKey(d => d.LogCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_operazioni_clienti");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.LogOperazioni)
                    .HasForeignKey(d => new { d.LogCliId, d.LogUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_log_operazioni_utenti");
            });

            modelBuilder.Entity<ModelliEmail>(entity =>
            {
                entity.HasKey(e => new { e.ModemCliId, e.ModemId })
                    .HasName("PK__modelli___348C5A6C1466BF9C");

                entity.ToTable("modelli_email");

                entity.HasIndex(e => new { e.ModemCliId, e.ModemLanguage, e.ModemFunzione })
                    .HasName("modem_funzione")
                    .IsUnique();

                entity.Property(e => e.ModemCliId)
                    .HasColumnName("modem_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.ModemId)
                    .HasColumnName("modem_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ModemCc)
                    .IsRequired()
                    .HasColumnName("modem_cc")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModemDescrizione)
                    .IsRequired()
                    .HasColumnName("modem_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModemFunzione)
                    .IsRequired()
                    .HasColumnName("modem_funzione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModemInsTimestamp)
                    .HasColumnName("modem_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModemInsUteId)
                    .IsRequired()
                    .HasColumnName("modem_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemLanguage)
                    .HasColumnName("modem_language")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ModemModTimestamp)
                    .HasColumnName("modem_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModemModUteId)
                    .IsRequired()
                    .HasColumnName("modem_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemOggetto)
                    .IsRequired()
                    .HasColumnName("modem_oggetto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModemTestoFine)
                    .HasColumnName("modem_testo_fine")
                    .HasColumnType("text");

                entity.Property(e => e.ModemTestoInizio)
                    .IsRequired()
                    .HasColumnName("modem_testo_inizio")
                    .HasColumnType("text");

                entity.Property(e => e.ModemTestoIntermedio)
                    .HasColumnName("modem_testo_intermedio")
                    .HasColumnType("text");

                entity.Property(e => e.ModemTestoIntermedio2)
                    .HasColumnName("modem_testo_intermedio2")
                    .HasColumnType("text");

                entity.Property(e => e.ModemTo)
                    .HasColumnName("modem_to")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ModemCli)
                    .WithMany(p => p.ModelliEmail)
                    .HasForeignKey(d => d.ModemCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_modelli_email_clienti");

                entity.HasOne(d => d.Modem)
                    .WithMany(p => p.ModelliEmailModem)
                    .HasForeignKey(d => new { d.ModemCliId, d.ModemInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_modelli_email_utenti_ins");

                entity.HasOne(d => d.ModemNavigation)
                    .WithMany(p => p.ModelliEmailModemNavigation)
                    .HasForeignKey(d => new { d.ModemCliId, d.ModemModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_modelli_email_utenti_mod");
            });

            modelBuilder.Entity<Paesi>(entity =>
            {
                entity.HasKey(e => new { e.PaeseCliId, e.PaeseId })
                    .HasName("PK__paesi__25841200F9E5CF07");

                entity.ToTable("paesi");

                entity.Property(e => e.PaeseCliId)
                    .HasColumnName("paese_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.PaeseId)
                    .HasColumnName("paese_id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseAttivo)
                    .IsRequired()
                    .HasColumnName("paese_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseDescrizione)
                    .IsRequired()
                    .HasColumnName("paese_descrizione")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseInsTimestamp)
                    .HasColumnName("paese_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaeseInsUteId)
                    .IsRequired()
                    .HasColumnName("paese_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseModTimestamp)
                    .HasColumnName("paese_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaeseModUteId)
                    .IsRequired()
                    .HasColumnName("paese_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseNazionalita)
                    .IsRequired()
                    .HasColumnName("paese_nazionalita")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PaeseNazionalitaOrdine).HasColumnName("paese_nazionalita_ordine");

                entity.HasOne(d => d.PaeseCli)
                    .WithMany(p => p.Paesi)
                    .HasForeignKey(d => d.PaeseCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paesi_clienti");

                entity.HasOne(d => d.Paese)
                    .WithMany(p => p.PaesiPaese)
                    .HasForeignKey(d => new { d.PaeseCliId, d.PaeseInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paesi_utenti_ins");

                entity.HasOne(d => d.PaeseNavigation)
                    .WithMany(p => p.PaesiPaeseNavigation)
                    .HasForeignKey(d => new { d.PaeseCliId, d.PaeseModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paesi_utenti_mod");
            });

            modelBuilder.Entity<ParametriGenerali>(entity =>
            {
                entity.HasKey(e => new { e.NomeParametro, e.CliId })
                    .HasName("PK__parametr__AC485DEF3AED3C83");

                entity.ToTable("parametri_generali");

                entity.HasIndex(e => e.NomeParametro)
                    .HasName("nome_parametro");

                entity.Property(e => e.NomeParametro)
                    .HasColumnName("nome_parametro")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CliId)
                    .HasColumnName("cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Valore)
                    .HasColumnName("valore")
                    .HasColumnType("text");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.ParametriGenerali)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parametri_generali_clienti");
            });

            modelBuilder.Entity<RaCategorie>(entity =>
            {
                entity.HasKey(e => new { e.RacatCliId, e.RacatId })
                    .HasName("PK__ra_categ__AF17B3A24ED53C1E");

                entity.ToTable("ra_categorie");

                entity.Property(e => e.RacatCliId)
                    .HasColumnName("racat_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RacatId)
                    .HasColumnName("racat_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RacatCodice)
                    .HasColumnName("racat_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacatDescrizione)
                    .HasColumnName("racat_descrizione")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RacatLabelEmail)
                    .HasColumnName("racat_label_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RaConfigurazioni>(entity =>
            {
                entity.HasKey(e => new { e.RacCliId, e.RacId })
                    .HasName("PK__ra_confi__258918E91A04A2AA");

                entity.ToTable("ra_configurazioni");

                entity.Property(e => e.RacCliId)
                    .HasColumnName("rac_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RacId)
                    .HasColumnName("rac_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RacDataFine)
                    .HasColumnName("rac_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RacEmail)
                    .IsRequired()
                    .HasColumnName("rac_email")
                    .IsUnicode(false);

                entity.Property(e => e.RacEmailCc)
                    .HasColumnName("rac_email_cc")
                    .IsUnicode(false);

                entity.Property(e => e.RacEmailCcn)
                    .HasColumnName("rac_email_ccn")
                    .IsUnicode(false);

                entity.Property(e => e.RacEmailException)
                    .HasColumnName("rac_email_exception")
                    .IsUnicode(false);

                entity.Property(e => e.RacEnable)
                    .IsRequired()
                    .HasColumnName("rac_enable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacEsito)
                    .HasColumnName("rac_esito")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RacFrequenza)
                    .IsRequired()
                    .HasColumnName("rac_frequenza")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacGiorno)
                    .HasColumnName("rac_giorno")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RacInsTimestamp)
                    .HasColumnName("rac_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.RacInsUteId)
                    .IsRequired()
                    .HasColumnName("rac_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RacModTimestamp)
                    .HasColumnName("rac_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.RacModUteId)
                    .IsRequired()
                    .HasColumnName("rac_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RacNote)
                    .HasColumnName("rac_note")
                    .HasColumnType("text");

                entity.Property(e => e.RacOggetto)
                    .IsRequired()
                    .HasColumnName("rac_oggetto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RacOra)
                    .IsRequired()
                    .HasColumnName("rac_ora")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RacParametri)
                    .HasColumnName("rac_parametri")
                    .IsUnicode(false);

                entity.Property(e => e.RacProssimaEsecuzione)
                    .HasColumnName("rac_prossima_esecuzione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacRacatCodice)
                    .HasColumnName("rac_racat_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacSql)
                    .IsRequired()
                    .HasColumnName("rac_sql")
                    .HasColumnType("text");

                entity.Property(e => e.RacSqlType)
                    .IsRequired()
                    .HasColumnName("rac_sql_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RacStyleTable)
                    .HasColumnName("rac_style_table")
                    .IsUnicode(false);

                entity.Property(e => e.RacStyleTableHeader)
                    .HasColumnName("rac_style_table_header")
                    .IsUnicode(false);

                entity.Property(e => e.RacStyleTableText)
                    .HasColumnName("rac_style_table_text")
                    .IsUnicode(false);

                entity.Property(e => e.RacStyleText)
                    .HasColumnName("rac_style_text")
                    .IsUnicode(false);

                entity.Property(e => e.RacUltimaEsecuzione)
                    .HasColumnName("rac_ultima_esecuzione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RacCli)
                    .WithMany(p => p.RaConfigurazioni)
                    .HasForeignKey(d => d.RacCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ra_configurazioni_clienti");

                entity.HasOne(d => d.Rac)
                    .WithMany(p => p.RaConfigurazioniRac)
                    .HasForeignKey(d => new { d.RacCliId, d.RacInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ra_configurazioni_utenti_ins");

                entity.HasOne(d => d.RacNavigation)
                    .WithMany(p => p.RaConfigurazioniRacNavigation)
                    .HasForeignKey(d => new { d.RacCliId, d.RacModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ra_configurazioni_utenti_mod");
            });

            modelBuilder.Entity<Richieste>(entity =>
            {
                entity.HasKey(e => new { e.RichCliId, e.RichId })
                    .HasName("PK__richiest__E32951D32CD755D5");

                entity.ToTable("richieste");

                entity.Property(e => e.RichCliId)
                    .HasColumnName("rich_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RichId)
                    .HasColumnName("rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RichAssegnatoUteId)
                    .HasColumnName("rich_assegnato_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichAttiva)
                    .IsRequired()
                    .HasColumnName("rich_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RichAttivita)
                    .HasColumnName("rich_attivita")
                    .HasColumnType("text");

                entity.Property(e => e.RichAzId).HasColumnName("rich_az_id");

                entity.Property(e => e.RichCategorieProtette)
                    .HasColumnName("rich_categorie_protette")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichCitta)
                    .IsRequired()
                    .HasColumnName("rich_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RichCodiceRichiestaCliente)
                    .HasColumnName("rich_codice_richiesta_cliente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompNecessarie)
                    .HasColumnName("rich_comp_necessarie")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipale)
                    .IsRequired()
                    .HasColumnName("rich_comp_principale")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipaleSemMaxOrd).HasColumnName("rich_comp_principale_sem_max_ord");

                entity.Property(e => e.RichCompPrincipaleSemMinOrd).HasColumnName("rich_comp_principale_sem_min_ord");

                entity.Property(e => e.RichCompPrincipaleSenMax)
                    .HasColumnName("rich_comp_principale_sen_max")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompPrincipaleSenMin)
                    .HasColumnName("rich_comp_principale_sen_min")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RichCompSecondarie)
                    .HasColumnName("rich_comp_secondarie")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RichCont2Id).HasColumnName("rich_cont2_id");

                entity.Property(e => e.RichCont3Id).HasColumnName("rich_cont3_id");

                entity.Property(e => e.RichContId).HasColumnName("rich_cont_id");

                entity.Property(e => e.RichData)
                    .HasColumnName("rich_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataFine)
                    .HasColumnName("rich_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataIncarico)
                    .HasColumnName("rich_data_incarico")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDataInizio)
                    .HasColumnName("rich_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichDescrizione)
                    .HasColumnName("rich_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.RichDescrizioneRichiestaCliente)
                    .HasColumnName("rich_descrizione_richiesta_cliente")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RichDurata)
                    .HasColumnName("rich_durata")
                    .HasComputedColumnSql("(datediff(day,[rich_data_inizio],[rich_data_fine]))");

                entity.Property(e => e.RichDurataDescrizione)
                    .HasColumnName("rich_durata_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichDurataNum).HasColumnName("rich_durata_num");

                entity.Property(e => e.RichFilialeCodice)
                    .HasColumnName("rich_filiale_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RichInsTimestamp)
                    .HasColumnName("rich_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichInsUteId)
                    .IsRequired()
                    .HasColumnName("rich_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichModTimestamp)
                    .HasColumnName("rich_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichModUteId)
                    .IsRequired()
                    .HasColumnName("rich_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichNumPosizioni).HasColumnName("rich_num_posizioni");

                entity.Property(e => e.RichPriorita).HasColumnName("rich_priorita");

                entity.Property(e => e.RichProxAzData)
                    .HasColumnName("rich_prox_az_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichProxAzDescr)
                    .HasColumnName("rich_prox_az_descr")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RichProxAzTipoAzioneRichiesta)
                    .HasColumnName("rich_prox_az_tipo_azione_richiesta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichProxAzUteId)
                    .HasColumnName("rich_prox_az_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichRicercaContinua)
                    .HasColumnName("rich_ricerca_continua")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliAbilitato)
                    .IsRequired()
                    .HasColumnName("rich_ricerche_portali_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliCitta)
                    .HasColumnName("rich_ricerche_portali_citta")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliCittaVicine)
                    .IsRequired()
                    .HasColumnName("rich_ricerche_portali_citta_vicine")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RichRicerchePortaliFine)
                    .HasColumnName("rich_ricerche_portali_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichRicerchePortaliInizio)
                    .HasColumnName("rich_ricerche_portali_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichRicerchePortaliKey1)
                    .HasColumnName("rich_ricerche_portali_key_1")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey2)
                    .HasColumnName("rich_ricerche_portali_key_2")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey3)
                    .HasColumnName("rich_ricerche_portali_key_3")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliKey4)
                    .HasColumnName("rich_ricerche_portali_key_4")
                    .HasMaxLength(50);

                entity.Property(e => e.RichRicerchePortaliNumCvAggiornati).HasColumnName("rich_ricerche_portali_num_cv_aggiornati");

                entity.Property(e => e.RichRicerchePortaliNumCvNuovi).HasColumnName("rich_ricerche_portali_num_cv_nuovi");

                entity.Property(e => e.RichRicerchePortaliNumCvTotali).HasColumnName("rich_ricerche_portali_num_cv_totali");

                entity.Property(e => e.RichRicerchePortaliNumEsecuzioni).HasColumnName("rich_ricerche_portali_num_esecuzioni");

                entity.Property(e => e.RichRicerchePortaliStato)
                    .HasColumnName("rich_ricerche_portali_stato")
                    .HasMaxLength(20);

                entity.Property(e => e.RichStato)
                    .HasColumnName("rich_stato")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichTariffa).HasColumnName("rich_tariffa");

                entity.Property(e => e.RichTipo)
                    .HasColumnName("rich_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichUteIdComm)
                    .HasColumnName("rich_ute_id_comm")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RichCli)
                    .WithMany(p => p.Richieste)
                    .HasForeignKey(d => d.RichCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_clienti");

                entity.HasOne(d => d.RichC)
                    .WithMany(p => p.Richieste)
                    .HasForeignKey(d => new { d.RichCliId, d.RichCitta })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_citta");

                entity.HasOne(d => d.RichCNavigation)
                    .WithMany(p => p.RichiesteRichCNavigation)
                    .HasForeignKey(d => new { d.RichCliId, d.RichCont2Id })
                    .HasConstraintName("FK_richieste_contatti1");

                entity.HasOne(d => d.RichC1)
                    .WithMany(p => p.RichiesteRichC1)
                    .HasForeignKey(d => new { d.RichCliId, d.RichCont3Id })
                    .HasConstraintName("FK_richieste_contatti2");

                entity.HasOne(d => d.RichC2)
                    .WithMany(p => p.RichiesteRichC2)
                    .HasForeignKey(d => new { d.RichCliId, d.RichContId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_contatti");

                entity.HasOne(d => d.Rich)
                    .WithMany(p => p.RichiesteRich)
                    .HasForeignKey(d => new { d.RichCliId, d.RichInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_utenti_ins");

                entity.HasOne(d => d.RichNavigation)
                    .WithMany(p => p.RichiesteRichNavigation)
                    .HasForeignKey(d => new { d.RichCliId, d.RichModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_utenti_mod");

                entity.HasOne(d => d.Rich1)
                    .WithMany(p => p.RichiesteRich1)
                    .HasForeignKey(d => new { d.RichCliId, d.RichProxAzUteId })
                    .HasConstraintName("FK_richieste_utenti2");

                entity.HasOne(d => d.Rich2)
                    .WithMany(p => p.RichiesteRich2)
                    .HasForeignKey(d => new { d.RichCliId, d.RichUteIdComm })
                    .HasConstraintName("FK_richieste_utenti3");
            });

            modelBuilder.Entity<RichiesteListaRisorse>(entity =>
            {
                entity.HasKey(e => new { e.RichlistCliId, e.RichlistId })
                    .HasName("PK__richiest__6D94EDD7F3D9F1CE")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("richieste_lista_risorse");

                entity.HasIndex(e => new { e.RichlistRichId, e.RichlistRisId })
                    .HasName("idx_rich_id_ris_id")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.RichlistRichId, e.RichlistRisId, e.RichlistStato })
                    .HasName("richiesta_risorsa_stato");

                entity.Property(e => e.RichlistCliId)
                    .HasColumnName("richlist_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RichlistId)
                    .HasColumnName("richlist_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RichlistAttinenzaTot).HasColumnName("richlist_attinenza_tot");

                entity.Property(e => e.RichlistInsTimestamp)
                    .HasColumnName("richlist_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichlistInsUteId)
                    .HasColumnName("richlist_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistModTimestamp)
                    .HasColumnName("richlist_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RichlistModUteId)
                    .HasColumnName("richlist_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistMotivazioneScarto)
                    .HasColumnName("richlist_motivazione_scarto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistNote)
                    .HasColumnName("richlist_note")
                    .HasColumnType("text");

                entity.Property(e => e.RichlistNoteEstrazioneNegative)
                    .HasColumnName("richlist_note_estrazione_negative")
                    .HasColumnType("text");

                entity.Property(e => e.RichlistNoteEstrazionePositive)
                    .HasColumnName("richlist_note_estrazione_positive")
                    .HasColumnType("text");

                entity.Property(e => e.RichlistNumRicPres).HasColumnName("richlist_num_ric_pres");

                entity.Property(e => e.RichlistPosizioneOrdinale).HasColumnName("richlist_posizione_ordinale");

                entity.Property(e => e.RichlistRichId)
                    .IsRequired()
                    .HasColumnName("richlist_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistRisId).HasColumnName("richlist_ris_id");

                entity.Property(e => e.RichlistStato)
                    .HasColumnName("richlist_stato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistUltimaSelData)
                    .HasColumnName("richlist_ultima_sel_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RichlistUltimaSelUteId)
                    .IsRequired()
                    .HasColumnName("richlist_ultima_sel_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RichlistVoto)
                    .HasColumnName("richlist_voto")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.RichlistVotoUteId)
                    .HasColumnName("richlist_voto_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RichlistCli)
                    .WithMany(p => p.RichiesteListaRisorse)
                    .HasForeignKey(d => d.RichlistCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_lista_risorse_clienti");

                entity.HasOne(d => d.RichlistStatoNavigation)
                    .WithMany(p => p.RichiesteListaRisorse)
                    .HasForeignKey(d => d.RichlistStato)
                    .HasConstraintName("FK_richieste_lista_risorse_stati_richieste_lista_risorse");

                entity.HasOne(d => d.Richlist)
                    .WithMany(p => p.RichiesteListaRisorseRichlist)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistInsUteId })
                    .HasConstraintName("FK_richieste_lista_risorse_utenti_ins");

                entity.HasOne(d => d.RichlistNavigation)
                    .WithMany(p => p.RichiesteListaRisorseRichlistNavigation)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistModUteId })
                    .HasConstraintName("FK_richieste_lista_risorse_utenti_mod");

                entity.HasOne(d => d.Richlist1)
                    .WithMany(p => p.RichiesteListaRisorse)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistRichId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_lista_risorse_richieste");

                entity.HasOne(d => d.Richlist2)
                    .WithMany(p => p.RichiesteListaRisorse)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_lista_risorse_risorse");

                entity.HasOne(d => d.Richlist3)
                    .WithMany(p => p.RichiesteListaRisorseRichlist3)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistUltimaSelUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_lista_risorse_utenti2");

                entity.HasOne(d => d.Richlist4)
                    .WithMany(p => p.RichiesteListaRisorseRichlist4)
                    .HasForeignKey(d => new { d.RichlistCliId, d.RichlistVotoUteId })
                    .HasConstraintName("FK_richieste_lista_risorse_utenti3");
            });

            modelBuilder.Entity<RichiesteLuoghiLavoro>(entity =>
            {
                entity.HasKey(e => new { e.RichllavRichId, e.RichllavCliId });

                entity.ToTable("richieste_luoghi_lavoro");

                entity.Property(e => e.RichllavRichId)
                    .HasColumnName("richllav_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RichllavCliId)
                    .HasColumnName("richllav_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RichllavAzId).HasColumnName("richllav_az_id");

                entity.Property(e => e.RichllavAzsedeId).HasColumnName("richllav_azsede_id");

                entity.Property(e => e.RichllavClifinId).HasColumnName("richllav_clifin_id");

                entity.Property(e => e.RichllavId)
                    .HasColumnName("richllav_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Richllav)
                    .WithMany(p => p.RichiesteLuoghiLavoro)
                    .HasForeignKey(d => new { d.RichllavCliId, d.RichllavAzId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_luoghi_lavoro_aziende");

                entity.HasOne(d => d.RichllavNavigation)
                    .WithMany(p => p.RichiesteLuoghiLavoro)
                    .HasForeignKey(d => new { d.RichllavCliId, d.RichllavRichId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_richieste_luoghi_lavoro_richieste");
            });

            modelBuilder.Entity<Risorse>(entity =>
            {
                entity.HasKey(e => new { e.RisCliId, e.RisId })
                    .HasName("PK__risorse__D7163E928D2C9D7C");

                entity.ToTable("risorse");

                entity.HasIndex(e => e.RisModTimestamp)
                    .HasName("idx_data_ultima_modifica");

                entity.HasIndex(e => e.RisProtetto)
                    .HasName("ris_protetto");

                entity.HasIndex(e => new { e.RisNome, e.RisCognome })
                    .HasName("idx_nome_cognome");

                entity.HasIndex(e => new { e.RisCellulare, e.RisEmail, e.RisAltriRiferimenti })
                    .HasName("idx_cell_email_altri_riferimenti");

                entity.HasIndex(e => new { e.RisCittaPossibili, e.RisDisponibile, e.RisDataColloquio })
                    .HasName("idx_citta_disp_data_colloquio");

                entity.HasIndex(e => new { e.RisCompetenza1, e.RisCompetenza2, e.RisCompetenza3 })
                    .HasName("competenze");

                entity.HasIndex(e => new { e.RisId, e.RisNome, e.RisCognome, e.RisCittaPossibili, e.RisDataNascita, e.RisDataColloquio, e.RisCompetenza1, e.RisCompetenza2, e.RisCompetenza3, e.RisLastRispAnnAnnuncio, e.RisCvNomeFile, e.RisCvDataInserimento, e.RisAll1DataInserimento, e.RisAll2DataInserimento, e.RisModTimestamp, e.RisDisponibile })
                    .HasName("idx_disp_altri");

                entity.Property(e => e.RisCliId)
                    .HasColumnName("ris_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisId)
                    .HasColumnName("ris_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RisAll1Allegato)
                    .HasColumnName("ris_all1_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.RisAll1DataInserimento)
                    .HasColumnName("ris_all1_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisAll1DimInKb).HasColumnName("ris_all1_dim_in_kb");

                entity.Property(e => e.RisAll1NomeFile)
                    .HasColumnName("ris_all1_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisAll1TipoAllegato)
                    .HasColumnName("ris_all1_tipo_allegato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RisAll2Allegato)
                    .HasColumnName("ris_all2_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.RisAll2DataInserimento)
                    .HasColumnName("ris_all2_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisAll2DimInKb).HasColumnName("ris_all2_dim_in_kb");

                entity.Property(e => e.RisAll2NomeFile)
                    .HasColumnName("ris_all2_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisAll2TipoAllegato)
                    .HasColumnName("ris_all2_tipo_allegato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RisAltriRiferimenti)
                    .HasColumnName("ris_altri_riferimenti")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisAzioni)
                    .HasColumnName("ris_azioni")
                    .HasColumnType("text");

                entity.Property(e => e.RisCandidature)
                    .HasColumnName("ris_candidature")
                    .HasColumnType("text");

                entity.Property(e => e.RisCellulare)
                    .IsRequired()
                    .HasColumnName("ris_cellulare")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisCittaPossibili)
                    .IsRequired()
                    .HasColumnName("ris_citta_possibili")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisCognome)
                    .IsRequired()
                    .HasColumnName("ris_cognome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RisColloquio)
                    .HasColumnName("ris_colloquio")
                    .HasColumnType("text");

                entity.Property(e => e.RisColloquioFiliale)
                    .HasColumnName("ris_colloquio_filiale")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RisColloquioTipo)
                    .HasColumnName("ris_colloquio_tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisColloquioUteId)
                    .HasColumnName("ris_colloquio_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza1)
                    .IsRequired()
                    .HasColumnName("ris_competenza_1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza2)
                    .HasColumnName("ris_competenza_2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisCompetenza3)
                    .HasColumnName("ris_competenza_3")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttDescr1)
                    .HasColumnName("ris_contr_att_descr_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttDescr2)
                    .HasColumnName("ris_contr_att_descr_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttDescr3)
                    .HasColumnName("ris_contr_att_descr_3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttDett)
                    .HasColumnName("ris_contr_att_dett")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttModTimestamp)
                    .HasColumnName("ris_contr_att_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisContrAttModUteId)
                    .HasColumnName("ris_contr_att_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttNetto).HasColumnName("ris_contr_att_netto");

                entity.Property(e => e.RisContrAttNettoAltreInfo)
                    .HasColumnName("ris_contr_att_netto_altre_info")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttNettoTipo)
                    .HasColumnName("ris_contr_att_netto_tipo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttNote)
                    .HasColumnName("ris_contr_att_note")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttNoteLong)
                    .HasColumnName("ris_contr_att_note_long")
                    .HasColumnType("text");

                entity.Property(e => e.RisContrAttPreavvDett)
                    .HasColumnName("ris_contr_att_preavv_dett")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttPreavvGg).HasColumnName("ris_contr_att_preavv_gg");

                entity.Property(e => e.RisContrAttPreavvGgTipo)
                    .HasColumnName("ris_contr_att_preavv_gg_tipo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RisContrAttTipo)
                    .HasColumnName("ris_contr_att_tipo")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('non.presente')");

                entity.Property(e => e.RisCvAllegato)
                    .HasColumnName("ris_cv_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.RisCvDataInserimento)
                    .HasColumnName("ris_cv_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisCvDimInKb).HasColumnName("ris_cv_dim_in_kb");

                entity.Property(e => e.RisCvNomeFile)
                    .HasColumnName("ris_cv_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisCvTesto)
                    .HasColumnName("ris_cv_testo")
                    .HasColumnType("text");

                entity.Property(e => e.RisDataColloquio)
                    .HasColumnName("ris_data_colloquio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisDataDisponibilita)
                    .HasColumnName("ris_data_disponibilita")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisDataNascita)
                    .HasColumnName("ris_data_nascita")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisDisponibile)
                    .IsRequired()
                    .HasColumnName("ris_disponibile")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RisEmail)
                    .IsRequired()
                    .HasColumnName("ris_email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RisIniziali)
                    .HasColumnName("ris_iniziali")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RisInsTimestamp)
                    .HasColumnName("ris_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisInsUteId)
                    .IsRequired()
                    .HasColumnName("ris_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisLastRispAnnAnnuncio)
                    .HasColumnName("ris_last_risp_ann_annuncio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisLastRispAnnId)
                    .HasColumnName("ris_last_risp_ann_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisLastRispSito)
                    .HasColumnName("ris_last_risp_sito")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RisLinkedin)
                    .HasColumnName("ris_linkedin")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RisModTimestamp)
                    .HasColumnName("ris_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisModUteId)
                    .IsRequired()
                    .HasColumnName("ris_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisNome)
                    .IsRequired()
                    .HasColumnName("ris_nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RisNote)
                    .HasColumnName("ris_note")
                    .HasColumnType("text");

                entity.Property(e => e.RisNoteRicerca)
                    .HasColumnName("ris_note_ricerca")
                    .HasColumnType("text");

                entity.Property(e => e.RisPrivacy)
                    .HasColumnName("ris_privacy")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RisProtetto)
                    .HasColumnName("ris_protetto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RisRevData)
                    .HasColumnName("ris_rev_data")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisRevUtente)
                    .HasColumnName("ris_rev_utente")
                    .HasMaxLength(100);

                entity.Property(e => e.RisSesso)
                    .IsRequired()
                    .HasColumnName("ris_sesso")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RisTerzaParte)
                    .HasColumnName("ris_terza_parte")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisTitolo)
                    .IsRequired()
                    .HasColumnName("ris_titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RisCli)
                    .WithMany(p => p.Risorse)
                    .HasForeignKey(d => d.RisCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_clienti");

                entity.HasOne(d => d.Ris)
                    .WithMany(p => p.RisorseRis)
                    .HasForeignKey(d => new { d.RisCliId, d.RisInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_utenti_ins");

                entity.HasOne(d => d.RisNavigation)
                    .WithMany(p => p.Risorse)
                    .HasForeignKey(d => new { d.RisCliId, d.RisLastRispAnnId })
                    .HasConstraintName("FK_risorse_annunci");

                entity.HasOne(d => d.Ris1)
                    .WithMany(p => p.RisorseRis1)
                    .HasForeignKey(d => new { d.RisCliId, d.RisModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_utenti_mod");

                entity.HasOne(d => d.Ris2)
                    .WithMany(p => p.Risorse)
                    .HasForeignKey(d => new { d.RisCliId, d.RisTitolo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_risorse");
            });

            modelBuilder.Entity<RisorseAltriDati>(entity =>
            {
                entity.HasKey(e => new { e.RisaltrCliId, e.RisaltrId })
                    .HasName("PK__risorse___7D1E80D2CFE17079");

                entity.ToTable("risorse_altri_dati");

                entity.Property(e => e.RisaltrCliId)
                    .HasColumnName("risaltr_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisaltrId)
                    .HasColumnName("risaltr_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RisaltrCompetenzeOrganizzative)
                    .HasColumnName("risaltr_competenze_organizzative")
                    .HasColumnType("text");

                entity.Property(e => e.RisaltrCompetenzeTecniche)
                    .HasColumnName("risaltr_competenze_tecniche")
                    .HasColumnType("text");

                entity.Property(e => e.RisaltrDomicilio)
                    .HasColumnName("risaltr_domicilio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrInsTimestamp)
                    .HasColumnName("risaltr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisaltrInsUteId)
                    .IsRequired()
                    .HasColumnName("risaltr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrLinguamadreLingua)
                    .HasColumnName("risaltr_linguamadre_lingua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrModTimestamp)
                    .HasColumnName("risaltr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisaltrModUteId)
                    .IsRequired()
                    .HasColumnName("risaltr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrNazionalita)
                    .HasColumnName("risaltr_nazionalita")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrPatente)
                    .HasColumnName("risaltr_patente")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrResidenza)
                    .HasColumnName("risaltr_residenza")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisaltrRisId).HasColumnName("risaltr_ris_id");

                entity.HasOne(d => d.RisaltrCli)
                    .WithMany(p => p.RisorseAltriDati)
                    .HasForeignKey(d => d.RisaltrCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_altri_dati_clienti");

                entity.HasOne(d => d.Risaltr)
                    .WithMany(p => p.RisorseAltriDatiRisaltr)
                    .HasForeignKey(d => new { d.RisaltrCliId, d.RisaltrInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_altri_dati_utenti_ins");

                entity.HasOne(d => d.RisaltrNavigation)
                    .WithMany(p => p.RisorseAltriDati)
                    .HasForeignKey(d => new { d.RisaltrCliId, d.RisaltrLinguamadreLingua })
                    .HasConstraintName("FK_risorse_altri_dati_lingue");

                entity.HasOne(d => d.Risaltr1)
                    .WithMany(p => p.RisorseAltriDatiRisaltr1)
                    .HasForeignKey(d => new { d.RisaltrCliId, d.RisaltrModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_altri_dati_utenti_mod");
            });

            modelBuilder.Entity<RisorseContratti>(entity =>
            {
                entity.HasKey(e => new { e.RiscontrCliId, e.RiscontrId })
                    .HasName("PK__risorse___400C4E0A6759C23B");

                entity.ToTable("risorse_contratti");

                entity.HasIndex(e => e.RiscontrRisId)
                    .HasName("ris_id");

                entity.HasIndex(e => new { e.RiscontrDataInizio, e.RiscontrDataFine })
                    .HasName("data_inizio_data_fine");

                entity.Property(e => e.RiscontrCliId)
                    .HasColumnName("riscontr_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RiscontrId)
                    .HasColumnName("riscontr_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrAttivo)
                    .IsRequired()
                    .HasColumnName("riscontr_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrCitta)
                    .HasColumnName("riscontr_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrCliente)
                    .HasColumnName("riscontr_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrClienteFinale)
                    .HasColumnName("riscontr_cliente_finale")
                    .HasColumnType("text");

                entity.Property(e => e.RiscontrContatto)
                    .HasColumnName("riscontr_contatto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrContrFirmAllegato)
                    .HasColumnName("riscontr_contr_firm_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.RiscontrContrFirmDataInserimento)
                    .HasColumnName("riscontr_contr_firm_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrContrFirmDimInKb).HasColumnName("riscontr_contr_firm_dim_in_kb");

                entity.Property(e => e.RiscontrContrFirmNomeFile)
                    .HasColumnName("riscontr_contr_firm_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrContrModAllegato)
                    .HasColumnName("riscontr_contr_mod_allegato")
                    .HasColumnType("image");

                entity.Property(e => e.RiscontrContrModDataInserimento)
                    .HasColumnName("riscontr_contr_mod_data_inserimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrContrModDimInKb).HasColumnName("riscontr_contr_mod_dim_in_kb");

                entity.Property(e => e.RiscontrContrModNomeFile)
                    .HasColumnName("riscontr_contr_mod_nome_file")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrCostoGgLavMedio)
                    .HasColumnName("riscontr_costo_gg_lav_medio")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.RiscontrDataFine)
                    .HasColumnName("riscontr_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrDataFineInps)
                    .HasColumnName("riscontr_data_fine_inps")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrDataInizio)
                    .HasColumnName("riscontr_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrDescrizione)
                    .IsRequired()
                    .HasColumnName("riscontr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrGgPreavviso).HasColumnName("riscontr_gg_preavviso");

                entity.Property(e => e.RiscontrGgPreavvisoLavorativi)
                    .IsRequired()
                    .HasColumnName("riscontr_gg_preavviso_lavorativi")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrGgProva).HasColumnName("riscontr_gg_prova");

                entity.Property(e => e.RiscontrGgProvaLavorativi)
                    .IsRequired()
                    .HasColumnName("riscontr_gg_prova_lavorativi")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrInsTimestamp)
                    .HasColumnName("riscontr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscontrInsUteId)
                    .HasColumnName("riscontr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrModTimestamp)
                    .HasColumnName("riscontr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscontrModUteId)
                    .HasColumnName("riscontr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrNote)
                    .HasColumnName("riscontr_note")
                    .HasColumnType("text");

                entity.Property(e => e.RiscontrNoteCliente)
                    .HasColumnName("riscontr_note_cliente")
                    .HasColumnType("text");

                entity.Property(e => e.RiscontrOffertaDataFine)
                    .HasColumnName("riscontr_offerta_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrOffertaDataInizio)
                    .HasColumnName("riscontr_offerta_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrOffertaGgPreavviso).HasColumnName("riscontr_offerta_gg_preavviso");

                entity.Property(e => e.RiscontrOffertaGgProva).HasColumnName("riscontr_offerta_gg_prova");

                entity.Property(e => e.RiscontrOffertaTariffa).HasColumnName("riscontr_offerta_tariffa");

                entity.Property(e => e.RiscontrRisId).HasColumnName("riscontr_ris_id");

                entity.Property(e => e.RiscontrRisorsaInterna)
                    .HasColumnName("riscontr_risorsa_interna")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('?')");

                entity.Property(e => e.RiscontrTipoContratto)
                    .IsRequired()
                    .HasColumnName("riscontr_tipo_contratto")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrUteId)
                    .HasColumnName("riscontr_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrUteIdRisorsa)
                    .HasColumnName("riscontr_ute_id_risorsa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RiscontrCli)
                    .WithMany(p => p.RisorseContratti)
                    .HasForeignKey(d => d.RiscontrCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_clienti");

                entity.HasOne(d => d.Riscontr)
                    .WithMany(p => p.RisorseContrattiRiscontr)
                    .HasForeignKey(d => new { d.RiscontrCliId, d.RiscontrInsUteId })
                    .HasConstraintName("FK_risorse_contratti_utenti_ins");

                entity.HasOne(d => d.RiscontrNavigation)
                    .WithMany(p => p.RisorseContrattiRiscontrNavigation)
                    .HasForeignKey(d => new { d.RiscontrCliId, d.RiscontrModUteId })
                    .HasConstraintName("FK_risorse_contratti_utenti_mod");

                entity.HasOne(d => d.Riscontr1)
                    .WithMany(p => p.RisorseContratti)
                    .HasForeignKey(d => new { d.RiscontrCliId, d.RiscontrRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_risorse");

                entity.HasOne(d => d.Riscontr2)
                    .WithMany(p => p.RisorseContratti)
                    .HasForeignKey(d => new { d.RiscontrCliId, d.RiscontrTipoContratto })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_tipi_contratto");
            });

            modelBuilder.Entity<RisorseContrattiRetribuzione>(entity =>
            {
                entity.HasKey(e => new { e.RiscontrretrCliId, e.RiscontrretrId })
                    .HasName("PK__risorse___2610268DBAF324B6");

                entity.ToTable("risorse_contratti_retribuzione");

                entity.Property(e => e.RiscontrretrCliId)
                    .HasColumnName("riscontrretr_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RiscontrretrId).HasColumnName("riscontrretr_id");

                entity.Property(e => e.RiscontrretrDataFine)
                    .HasColumnName("riscontrretr_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrretrDataInizio)
                    .HasColumnName("riscontrretr_data_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.RiscontrretrImporto)
                    .HasColumnName("riscontrretr_importo")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.RiscontrretrInsTimestamp)
                    .HasColumnName("riscontrretr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscontrretrInsUteId)
                    .IsRequired()
                    .HasColumnName("riscontrretr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrretrModTimestamp)
                    .HasColumnName("riscontrretr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscontrretrModUteId)
                    .IsRequired()
                    .HasColumnName("riscontrretr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrretrRiscontrId)
                    .IsRequired()
                    .HasColumnName("riscontrretr_riscontr_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RiscontrretrTipcontrdettId).HasColumnName("riscontrretr_tipcontrdett_id");

                entity.HasOne(d => d.RiscontrretrCli)
                    .WithMany(p => p.RisorseContrattiRetribuzione)
                    .HasForeignKey(d => d.RiscontrretrCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_retribuzione_clienti");

                entity.HasOne(d => d.Riscontrretr)
                    .WithMany(p => p.RisorseContrattiRetribuzioneRiscontrretr)
                    .HasForeignKey(d => new { d.RiscontrretrCliId, d.RiscontrretrInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_retribuzione_utenti_ins");

                entity.HasOne(d => d.RiscontrretrNavigation)
                    .WithMany(p => p.RisorseContrattiRetribuzioneRiscontrretrNavigation)
                    .HasForeignKey(d => new { d.RiscontrretrCliId, d.RiscontrretrModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_retribuzione_utenti_mod");

                entity.HasOne(d => d.Riscontrretr1)
                    .WithMany(p => p.RisorseContrattiRetribuzione)
                    .HasForeignKey(d => new { d.RiscontrretrCliId, d.RiscontrretrRiscontrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_retribuzione_risorse_contratti");

                entity.HasOne(d => d.Riscontrretr2)
                    .WithMany(p => p.RisorseContrattiRetribuzione)
                    .HasForeignKey(d => new { d.RiscontrretrCliId, d.RiscontrretrTipcontrdettId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_contratti_retribuzione_tipi_contratto_dettagli");
            });

            modelBuilder.Entity<RisorseCvSchemi>(entity =>
            {
                entity.HasKey(e => new { e.RiscvschemCliId, e.RiscvschemId })
                    .HasName("PK__risorse___9CAF7C12B9F842B0");

                entity.ToTable("risorse_cv_schemi");

                entity.Property(e => e.RiscvschemCliId)
                    .HasColumnName("riscvschem_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RiscvschemId)
                    .HasColumnName("riscvschem_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RiscvschemCvschemCodice)
                    .IsRequired()
                    .HasColumnName("riscvschem_cvschem_codice")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RiscvschemCvschemideId)
                    .IsRequired()
                    .HasColumnName("riscvschem_cvschemide_id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RiscvschemInsTimestamp)
                    .HasColumnName("riscvschem_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscvschemInsUteId)
                    .IsRequired()
                    .HasColumnName("riscvschem_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscvschemModTimestamp)
                    .HasColumnName("riscvschem_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RiscvschemModUteId)
                    .IsRequired()
                    .HasColumnName("riscvschem_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RiscvschemNote)
                    .HasColumnName("riscvschem_note")
                    .IsUnicode(false);

                entity.Property(e => e.RiscvschemRisCvTesto)
                    .IsRequired()
                    .HasColumnName("riscvschem_ris_cv_testo")
                    .HasColumnType("text");

                entity.Property(e => e.RiscvschemRisId).HasColumnName("riscvschem_ris_id");

                entity.HasOne(d => d.RiscvschemCli)
                    .WithMany(p => p.RisorseCvSchemi)
                    .HasForeignKey(d => d.RiscvschemCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_cv_schemi_clienti");

                entity.HasOne(d => d.RiscvschemC)
                    .WithMany(p => p.RisorseCvSchemi)
                    .HasForeignKey(d => new { d.RiscvschemCliId, d.RiscvschemCvschemCodice })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analisi_cv_schemi_statistiche_dettaglio_analisi_cv_schemi");

                entity.HasOne(d => d.Riscvschem)
                    .WithMany(p => p.RisorseCvSchemiRiscvschem)
                    .HasForeignKey(d => new { d.RiscvschemCliId, d.RiscvschemInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_cv_schemi_utenti_ins");

                entity.HasOne(d => d.RiscvschemNavigation)
                    .WithMany(p => p.RisorseCvSchemiRiscvschemNavigation)
                    .HasForeignKey(d => new { d.RiscvschemCliId, d.RiscvschemModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_cv_schemi_utenti_mod");

                entity.HasOne(d => d.Riscvschem1)
                    .WithMany(p => p.RisorseCvSchemi)
                    .HasForeignKey(d => new { d.RiscvschemCliId, d.RiscvschemRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analisi_cv_schemi_statistiche_dettaglio_risorse");
            });

            modelBuilder.Entity<RisorseDatiAmministrativi>(entity =>
            {
                entity.HasKey(e => new { e.RisdammCliId, e.RisdammId })
                    .HasName("PK__risorse___6564F1C6ED122764");

                entity.ToTable("risorse_dati_amministrativi");

                entity.Property(e => e.RisdammCliId)
                    .HasColumnName("risdamm_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisdammId)
                    .HasColumnName("risdamm_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RisdammBeniAssegnati)
                    .HasColumnName("risdamm_beni_assegnati")
                    .HasColumnType("text");

                entity.Property(e => e.RisdammCodiceFiscale)
                    .HasColumnName("risdamm_codice_fiscale")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RisdammDomicilio)
                    .HasColumnName("risdamm_domicilio")
                    .HasColumnType("text");

                entity.Property(e => e.RisdammInsTimestamp)
                    .HasColumnName("risdamm_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisdammInsUteId)
                    .IsRequired()
                    .HasColumnName("risdamm_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisdammModTimestamp)
                    .HasColumnName("risdamm_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisdammModUteId)
                    .IsRequired()
                    .HasColumnName("risdamm_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisdammPartitaIva)
                    .HasColumnName("risdamm_partita_iva")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.RisdammResidenza)
                    .HasColumnName("risdamm_residenza")
                    .HasColumnType("text");

                entity.Property(e => e.RisdammRisId).HasColumnName("risdamm_ris_id");

                entity.HasOne(d => d.RisdammCli)
                    .WithMany(p => p.RisorseDatiAmministrativi)
                    .HasForeignKey(d => d.RisdammCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_dati_amministrativi_clienti");

                entity.HasOne(d => d.Risdamm)
                    .WithMany(p => p.RisorseDatiAmministrativiRisdamm)
                    .HasForeignKey(d => new { d.RisdammCliId, d.RisdammInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_dati_amministrativi_utenti_ins");

                entity.HasOne(d => d.RisdammNavigation)
                    .WithMany(p => p.RisorseDatiAmministrativiRisdammNavigation)
                    .HasForeignKey(d => new { d.RisdammCliId, d.RisdammModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_dati_amministrativi_utenti_mod");

                entity.HasOne(d => d.Risdamm1)
                    .WithMany(p => p.RisorseDatiAmministrativi)
                    .HasForeignKey(d => new { d.RisdammCliId, d.RisdammRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_dati_amministrativi_risorse");
            });

            modelBuilder.Entity<RisorseEsperienzeLavorative>(entity =>
            {
                entity.HasKey(e => new { e.RisesplavCliId, e.RisesplavId })
                    .HasName("PK__risorse___39D32F29D29B17EC");

                entity.ToTable("risorse_esperienze_lavorative");

                entity.Property(e => e.RisesplavCliId)
                    .HasColumnName("risesplav_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisesplavId)
                    .HasColumnName("risesplav_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RisesplavAzienda)
                    .HasColumnName("risesplav_azienda")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisesplavCompetenzaCv)
                    .HasColumnName("risesplav_competenza_cv")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RisesplavDescrizione)
                    .HasColumnName("risesplav_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.RisesplavFine)
                    .HasColumnName("risesplav_fine")
                    .HasColumnType("date");

                entity.Property(e => e.RisesplavInizio)
                    .HasColumnName("risesplav_inizio")
                    .HasColumnType("date");

                entity.Property(e => e.RisesplavInsTimestamp)
                    .HasColumnName("risesplav_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisesplavInsUteId)
                    .IsRequired()
                    .HasColumnName("risesplav_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisesplavLuogo)
                    .HasColumnName("risesplav_luogo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisesplavModTimestamp)
                    .HasColumnName("risesplav_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisesplavModUteId)
                    .IsRequired()
                    .HasColumnName("risesplav_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisesplavRisId).HasColumnName("risesplav_ris_id");

                entity.Property(e => e.RisesplavSettore)
                    .HasColumnName("risesplav_settore")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.RisesplavCli)
                    .WithMany(p => p.RisorseEsperienzeLavorative)
                    .HasForeignKey(d => d.RisesplavCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_esperienze_lavorative_clienti");

                entity.HasOne(d => d.Risesplav)
                    .WithMany(p => p.RisorseEsperienzeLavorativeRisesplav)
                    .HasForeignKey(d => new { d.RisesplavCliId, d.RisesplavInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_esperienze_lavorative_utenti_ins");

                entity.HasOne(d => d.RisesplavNavigation)
                    .WithMany(p => p.RisorseEsperienzeLavorativeRisesplavNavigation)
                    .HasForeignKey(d => new { d.RisesplavCliId, d.RisesplavModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_esperienze_lavorative_utenti_mod");
            });

            modelBuilder.Entity<RisorseIstruzioneFormazione>(entity =>
            {
                entity.HasKey(e => new { e.RisistforCliId, e.RisistforId })
                    .HasName("PK__risorse___1932D6A3F4ACBE4A");

                entity.ToTable("risorse_istruzione_formazione");

                entity.Property(e => e.RisistforCliId)
                    .HasColumnName("risistfor_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisistforId)
                    .HasColumnName("risistfor_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RisistforEnteLuogo)
                    .HasColumnName("risistfor_ente_luogo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisistforEnteNome)
                    .HasColumnName("risistfor_ente_nome")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisistforFine)
                    .HasColumnName("risistfor_fine")
                    .HasColumnType("date");

                entity.Property(e => e.RisistforInizio)
                    .HasColumnName("risistfor_inizio")
                    .HasColumnType("date");

                entity.Property(e => e.RisistforInsTimestamp)
                    .HasColumnName("risistfor_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisistforInsUteId)
                    .IsRequired()
                    .HasColumnName("risistfor_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisistforMaterieAbilita)
                    .HasColumnName("risistfor_materie_abilita")
                    .HasColumnType("text");

                entity.Property(e => e.RisistforModTimestamp)
                    .HasColumnName("risistfor_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RisistforModUteId)
                    .IsRequired()
                    .HasColumnName("risistfor_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RisistforQualifica)
                    .HasColumnName("risistfor_qualifica")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RisistforRisId).HasColumnName("risistfor_ris_id");

                entity.HasOne(d => d.RisistforCli)
                    .WithMany(p => p.RisorseIstruzioneFormazione)
                    .HasForeignKey(d => d.RisistforCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_istruzione_formazione_clienti");

                entity.HasOne(d => d.Risistfor)
                    .WithMany(p => p.RisorseIstruzioneFormazioneRisistfor)
                    .HasForeignKey(d => new { d.RisistforCliId, d.RisistforInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_istruzione_formazione_utenti_ins");

                entity.HasOne(d => d.RisistforNavigation)
                    .WithMany(p => p.RisorseIstruzioneFormazioneRisistforNavigation)
                    .HasForeignKey(d => new { d.RisistforCliId, d.RisistforModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_istruzione_formazione_utenti_mod");
            });

            modelBuilder.Entity<RisorseLingue>(entity =>
            {
                entity.HasKey(e => new { e.RislingueCliId, e.RislingueId })
                    .HasName("PK__risorse___C2ACF4A0A5932C4A");

                entity.ToTable("risorse_lingue");

                entity.Property(e => e.RislingueCliId)
                    .HasColumnName("rislingue_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RislingueId)
                    .HasColumnName("rislingue_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RislingueInsTimestamp)
                    .HasColumnName("rislingue_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RislingueInsUteId)
                    .IsRequired()
                    .HasColumnName("rislingue_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueLettura)
                    .HasColumnName("rislingue_lettura")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueLetturaLinguaLivello).HasColumnName("rislingue_lettura_lingua_livello");

                entity.Property(e => e.RislingueLingua)
                    .IsRequired()
                    .HasColumnName("rislingue_lingua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueModTimestamp)
                    .HasColumnName("rislingue_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RislingueModUteId)
                    .IsRequired()
                    .HasColumnName("rislingue_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueOrale)
                    .HasColumnName("rislingue_orale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueOraleLinguaLivello).HasColumnName("rislingue_orale_lingua_livello");

                entity.Property(e => e.RislingueOrdine)
                    .HasColumnName("rislingue_ordine")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.RislingueRisId).HasColumnName("rislingue_ris_id");

                entity.Property(e => e.RislingueScrittura)
                    .HasColumnName("rislingue_scrittura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RislingueScritturaLinguaLivello).HasColumnName("rislingue_scrittura_lingua_livello");

                entity.HasOne(d => d.RislingueCli)
                    .WithMany(p => p.RisorseLingue)
                    .HasForeignKey(d => d.RislingueCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_lingue_clienti");

                entity.HasOne(d => d.Rislingue)
                    .WithMany(p => p.RisorseLingueRislingue)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_lingue_utenti_ins");

                entity.HasOne(d => d.RislingueNavigation)
                    .WithMany(p => p.RisorseLingueRislingueNavigation)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueLetturaLinguaLivello })
                    .HasConstraintName("FK_risorse_lingue_lingua_livelli");

                entity.HasOne(d => d.Rislingue1)
                    .WithMany(p => p.RisorseLingue)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueLingua })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_lingue_lingue");

                entity.HasOne(d => d.Rislingue2)
                    .WithMany(p => p.RisorseLingueRislingue2)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_lingue_utenti_mod");

                entity.HasOne(d => d.Rislingue3)
                    .WithMany(p => p.RisorseLingueRislingue3)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueOraleLinguaLivello })
                    .HasConstraintName("FK_risorse_lingue_lingua_livelli2");

                entity.HasOne(d => d.Rislingue4)
                    .WithMany(p => p.RisorseLingueRislingue4)
                    .HasForeignKey(d => new { d.RislingueCliId, d.RislingueScritturaLinguaLivello })
                    .HasConstraintName("FK_risorse_lingue_lingua_livelli1");
            });

            modelBuilder.Entity<RisorseTestCompetenze>(entity =>
            {
                entity.HasKey(e => new { e.RisCliId, e.RisId })
                    .HasName("PK__risorse___D7163E924157837C");

                entity.ToTable("risorse_test_competenze");

                entity.Property(e => e.RisCliId)
                    .HasColumnName("ris_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RisId).HasColumnName("ris_id");

                entity.Property(e => e.RisCognome)
                    .IsRequired()
                    .HasColumnName("ris_cognome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RisNome)
                    .IsRequired()
                    .HasColumnName("ris_nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RisCli)
                    .WithMany(p => p.RisorseTestCompetenze)
                    .HasForeignKey(d => d.RisCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_risorse_test_competenze_clienti");
            });

            modelBuilder.Entity<RpCommesse>(entity =>
            {
                entity.HasKey(e => new { e.RpcommCliId, e.RpcommCodice })
                    .HasName("PK__rp_comme__A6B1C7EE036F82EA");

                entity.ToTable("rp_commesse");

                entity.HasIndex(e => new { e.RpcommCliId, e.RpcommCodice })
                    .HasName("codice_commessa")
                    .IsUnique();

                entity.Property(e => e.RpcommCliId)
                    .HasColumnName("rpcomm_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RpcommCodice)
                    .HasColumnName("rpcomm_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RpcommDescrizione)
                    .IsRequired()
                    .HasColumnName("rpcomm_descrizione")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RpcommInsTimestamp)
                    .HasColumnName("rpcomm_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RpcommInsUteId)
                    .IsRequired()
                    .HasColumnName("rpcomm_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RpcommModTimestamp)
                    .HasColumnName("rpcomm_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RpcommModUteId)
                    .IsRequired()
                    .HasColumnName("rpcomm_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RpcommNote)
                    .HasColumnName("rpcomm_note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.RpcommCli)
                    .WithMany(p => p.RpCommesse)
                    .HasForeignKey(d => d.RpcommCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_commesse_clienti");

                entity.HasOne(d => d.Rpcomm)
                    .WithMany(p => p.RpCommesseRpcomm)
                    .HasForeignKey(d => new { d.RpcommCliId, d.RpcommInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_commesse_utenti_ins");

                entity.HasOne(d => d.RpcommNavigation)
                    .WithMany(p => p.RpCommesseRpcommNavigation)
                    .HasForeignKey(d => new { d.RpcommCliId, d.RpcommModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_commesse_utenti_mod");
            });

            modelBuilder.Entity<RpRapportini>(entity =>
            {
                entity.HasKey(e => new { e.RprappCliId, e.RprappId })
                    .HasName("PK__rp_rappo__A237F4BA209D5131");

                entity.ToTable("rp_rapportini");

                entity.HasIndex(e => new { e.RprappCliId, e.RprappUteId, e.RprappMese, e.RprappConsolidato })
                    .HasName("utente_mese_cosolidato");

                entity.Property(e => e.RprappCliId)
                    .HasColumnName("rprapp_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RprappId)
                    .HasColumnName("rprapp_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RprappConsolidato)
                    .IsRequired()
                    .HasColumnName("rprapp_consolidato")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RprappInsTimestamp)
                    .HasColumnName("rprapp_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RprappInsUteId)
                    .IsRequired()
                    .HasColumnName("rprapp_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RprappMese)
                    .HasColumnName("rprapp_mese")
                    .HasColumnType("date");

                entity.Property(e => e.RprappModTimestamp)
                    .HasColumnName("rprapp_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RprappModUteId)
                    .IsRequired()
                    .HasColumnName("rprapp_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RprappNote)
                    .HasColumnName("rprapp_note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RprappUteId)
                    .IsRequired()
                    .HasColumnName("rprapp_ute_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.RprappCli)
                    .WithMany(p => p.RpRapportini)
                    .HasForeignKey(d => d.RprappCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_clienti");

                entity.HasOne(d => d.Rprapp)
                    .WithMany(p => p.RpRapportiniRprapp)
                    .HasForeignKey(d => new { d.RprappCliId, d.RprappInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_utenti_ins");

                entity.HasOne(d => d.RprappNavigation)
                    .WithMany(p => p.RpRapportiniRprappNavigation)
                    .HasForeignKey(d => new { d.RprappCliId, d.RprappModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_utenti_mod");
            });

            modelBuilder.Entity<RpRapportiniDettaglio>(entity =>
            {
                entity.HasKey(e => new { e.RprappdettCliId, e.RprappdettId })
                    .HasName("PK__rp_rappo__D70279846701B5C1");

                entity.ToTable("rp_rapportini_dettaglio");

                entity.HasIndex(e => new { e.RprappdettCliId, e.RprappdettGiorno, e.RprappdettRpscommutId })
                    .HasName("idx_rapp_dett_giorno_sottomessa");

                entity.Property(e => e.RprappdettCliId)
                    .HasColumnName("rprappdett_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RprappdettId)
                    .HasColumnName("rprappdett_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RprappdettDescrizione)
                    .HasColumnName("rprappdett_descrizione")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.RprappdettGiornInviato)
                    .IsRequired()
                    .HasColumnName("rprappdett_giorn_inviato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RprappdettGiorno)
                    .HasColumnName("rprappdett_giorno")
                    .HasColumnType("date");

                entity.Property(e => e.RprappdettInsTimestamp)
                    .HasColumnName("rprappdett_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RprappdettInsUteId)
                    .IsRequired()
                    .HasColumnName("rprappdett_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RprappdettMinutiLavorati).HasColumnName("rprappdett_minuti_lavorati");

                entity.Property(e => e.RprappdettModTimestamp)
                    .HasColumnName("rprappdett_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RprappdettModUteId)
                    .IsRequired()
                    .HasColumnName("rprappdett_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('system')");

                entity.Property(e => e.RprappdettNote)
                    .HasColumnName("rprappdett_note")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.RprappdettRpscommutId).HasColumnName("rprappdett_rpscommut_id");

                entity.HasOne(d => d.RprappdettCli)
                    .WithMany(p => p.RpRapportiniDettaglio)
                    .HasForeignKey(d => d.RprappdettCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_dettaglio_clienti");

                entity.HasOne(d => d.Rprappdett)
                    .WithMany(p => p.RpRapportiniDettaglioRprappdett)
                    .HasForeignKey(d => new { d.RprappdettCliId, d.RprappdettInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_dettaglio_utenti_ins");

                entity.HasOne(d => d.RprappdettNavigation)
                    .WithMany(p => p.RpRapportiniDettaglioRprappdettNavigation)
                    .HasForeignKey(d => new { d.RprappdettCliId, d.RprappdettModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_rapportini_dettaglio_utenti_mod");
            });

            modelBuilder.Entity<RpSottoCommesseUtenti>(entity =>
            {
                entity.HasKey(e => new { e.RpscommutCliId, e.RpscommutId })
                    .HasName("PK__rp_sotto__7599E40132429800");

                entity.ToTable("rp_sotto_commesse_utenti");

                entity.HasIndex(e => new { e.RpscommutCliId, e.RpscommutId })
                    .HasName("idx_main")
                    .IsUnique();

                entity.HasIndex(e => new { e.RpscommutCliId, e.RpscommutRpscommCodice })
                    .HasName("codice_sotto_commessa");

                entity.HasIndex(e => new { e.RpscommutCliId, e.RpscommutUteId })
                    .HasName("ute_id");

                entity.Property(e => e.RpscommutCliId)
                    .HasColumnName("rpscommut_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.RpscommutId)
                    .HasColumnName("rpscommut_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RpscommutDataFine)
                    .HasColumnName("rpscommut_data_fine")
                    .HasColumnType("date");

                entity.Property(e => e.RpscommutDataInizio)
                    .HasColumnName("rpscommut_data_inizio")
                    .HasColumnType("date");

                entity.Property(e => e.RpscommutInsTimestamp)
                    .HasColumnName("rpscommut_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RpscommutInsUteId)
                    .IsRequired()
                    .HasColumnName("rpscommut_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RpscommutModTimestamp)
                    .HasColumnName("rpscommut_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RpscommutModUteId)
                    .IsRequired()
                    .HasColumnName("rpscommut_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RpscommutNote)
                    .HasColumnName("rpscommut_note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RpscommutRpscommCodice)
                    .IsRequired()
                    .HasColumnName("rpscommut_rpscomm_codice")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.RpscommutUteId)
                    .IsRequired()
                    .HasColumnName("rpscommut_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RpscommutCli)
                    .WithMany(p => p.RpSottoCommesseUtenti)
                    .HasForeignKey(d => d.RpscommutCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_sotto_commesse_utenti_clienti");

                entity.HasOne(d => d.Rpscommut)
                    .WithMany(p => p.RpSottoCommesseUtentiRpscommut)
                    .HasForeignKey(d => new { d.RpscommutCliId, d.RpscommutInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_sotto_commesse_utenti_utenti_ins");

                entity.HasOne(d => d.RpscommutNavigation)
                    .WithMany(p => p.RpSottoCommesseUtentiRpscommutNavigation)
                    .HasForeignKey(d => new { d.RpscommutCliId, d.RpscommutModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rp_sotto_commesse_utenti_utenti_mod");
            });

            modelBuilder.Entity<RuoliUtenti>(entity =>
            {
                entity.HasKey(e => new { e.RuoloCliId, e.Ruolo })
                    .HasName("PK__ruoli_ut__DF64977327995E66");

                entity.ToTable("ruoli_utenti");

                entity.Property(e => e.RuoloCliId)
                    .HasColumnName("ruolo_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Ruolo)
                    .HasColumnName("ruolo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RuoloAbilitato)
                    .HasColumnName("ruolo_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.RuoloInsTimestamp)
                    .HasColumnName("ruolo_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuoloInsUteId)
                    .IsRequired()
                    .HasColumnName("ruolo_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RuoloModTimestamp)
                    .HasColumnName("ruolo_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuoloModUteId)
                    .IsRequired()
                    .HasColumnName("ruolo_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RuoloSystem)
                    .HasColumnName("ruolo_system")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.HasOne(d => d.RuoloCli)
                    .WithMany(p => p.RuoliUtenti)
                    .HasForeignKey(d => d.RuoloCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_utenti_clienti");

                entity.HasOne(d => d.RuoloNavigation)
                    .WithMany(p => p.RuoliUtentiRuoloNavigation)
                    .HasForeignKey(d => new { d.RuoloCliId, d.RuoloInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_utenti_utenti_ins");

                entity.HasOne(d => d.Ruolo1)
                    .WithMany(p => p.RuoliUtentiRuolo1)
                    .HasForeignKey(d => new { d.RuoloCliId, d.RuoloModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_utenti_utenti_mod");
            });

            modelBuilder.Entity<RuoliUtentiDescr>(entity =>
            {
                entity.HasKey(e => new { e.RuolodescrRuolo, e.RuolodescrLingua, e.RuolodescrCliId });

                entity.ToTable("ruoli_utenti_descr");

                entity.Property(e => e.RuolodescrRuolo)
                    .HasColumnName("ruolodescr_ruolo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrLingua)
                    .HasColumnName("ruolodescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrCliId)
                    .HasColumnName("ruolodescr_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrDescrizione)
                    .IsRequired()
                    .HasColumnName("ruolodescr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrDescrizioneBreve)
                    .HasColumnName("ruolodescr_descrizione_breve")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrDescrizioneEstesa)
                    .HasColumnName("ruolodescr_descrizione_estesa")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrInsTimestamp)
                    .HasColumnName("ruolodescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuolodescrInsUteId)
                    .HasColumnName("ruolodescr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RuolodescrModTimestamp)
                    .HasColumnName("ruolodescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuolodescrModUteId)
                    .HasColumnName("ruolodescr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RuolodescrLinguaNavigation)
                    .WithMany(p => p.RuoliUtentiDescr)
                    .HasForeignKey(d => d.RuolodescrLingua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_utenti_descr_talent_lingue");

                entity.HasOne(d => d.Ruolodescr)
                    .WithMany(p => p.RuoliUtentiDescrRuolodescr)
                    .HasForeignKey(d => new { d.RuolodescrCliId, d.RuolodescrInsUteId })
                    .HasConstraintName("FK_ruoli_utenti_descr_utenti_ins");

                entity.HasOne(d => d.RuolodescrNavigation)
                    .WithMany(p => p.RuoliUtentiDescrRuolodescrNavigation)
                    .HasForeignKey(d => new { d.RuolodescrCliId, d.RuolodescrModUteId })
                    .HasConstraintName("FK_ruoli_utenti_descr_utenti_mod");

                entity.HasOne(d => d.Ruolodescr1)
                    .WithMany(p => p.RuoliUtentiDescr)
                    .HasForeignKey(d => new { d.RuolodescrCliId, d.RuolodescrRuolo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_utenti_descr_ruoli_utenti");
            });

            modelBuilder.Entity<Schedulazioni>(entity =>
            {
                entity.HasKey(e => new { e.SchedCliId, e.SchedId })
                    .HasName("PK__schedula__718493509CC1F593");

                entity.ToTable("schedulazioni");

                entity.Property(e => e.SchedCliId)
                    .HasColumnName("sched_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.SchedId)
                    .HasColumnName("sched_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SchedAbilitato)
                    .HasColumnName("sched_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SchedCitta)
                    .HasColumnName("sched_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SchedDataFine)
                    .HasColumnName("sched_data_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedDataInizio)
                    .HasColumnName("sched_data_inizio")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedInEsecuzione)
                    .HasColumnName("sched_in_esecuzione")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SchedInsTimestamp)
                    .HasColumnName("sched_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedInsUteId)
                    .HasColumnName("sched_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey1)
                    .HasColumnName("sched_key_1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey2)
                    .HasColumnName("sched_key_2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey3)
                    .HasColumnName("sched_key_3")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey4)
                    .HasColumnName("sched_key_4")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey5)
                    .HasColumnName("sched_key_5")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedKey6)
                    .HasColumnName("sched_key_6")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SchedModTimestamp)
                    .HasColumnName("sched_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedModUteId)
                    .HasColumnName("sched_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedProxEsecMin)
                    .HasColumnName("sched_prox_esec_min")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedRichId)
                    .HasColumnName("sched_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SchedSchedprocId)
                    .HasColumnName("sched_schedproc_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SchedUltEsecEsito)
                    .HasColumnName("sched_ult_esec_esito")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SchedUltEsecFine)
                    .HasColumnName("sched_ult_esec_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedUltEsecInizio)
                    .HasColumnName("sched_ult_esec_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedUltEsecNumCvAggiornati).HasColumnName("sched_ult_esec_num_cv_aggiornati");

                entity.Property(e => e.SchedUltEsecNumCvNuovi).HasColumnName("sched_ult_esec_num_cv_nuovi");

                entity.Property(e => e.SchedUltEsecNumCvTotali).HasColumnName("sched_ult_esec_num_cv_totali");

                entity.Property(e => e.SchedUteId)
                    .HasColumnName("sched_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SchedCli)
                    .WithMany(p => p.Schedulazioni)
                    .HasForeignKey(d => d.SchedCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schedulazioni_clienti");

                entity.HasOne(d => d.Sched)
                    .WithMany(p => p.SchedulazioniSched)
                    .HasForeignKey(d => new { d.SchedCliId, d.SchedInsUteId })
                    .HasConstraintName("FK_schedulazioni_utenti_ins");

                entity.HasOne(d => d.SchedNavigation)
                    .WithMany(p => p.SchedulazioniSchedNavigation)
                    .HasForeignKey(d => new { d.SchedCliId, d.SchedModUteId })
                    .HasConstraintName("FK_schedulazioni_utenti_mod");

                entity.HasOne(d => d.Sched1)
                    .WithMany(p => p.Schedulazioni)
                    .HasForeignKey(d => new { d.SchedCliId, d.SchedRichId })
                    .HasConstraintName("FK_schedulazioni_richieste");

                entity.HasOne(d => d.Sched2)
                    .WithMany(p => p.Schedulazioni)
                    .HasForeignKey(d => new { d.SchedCliId, d.SchedSchedprocId })
                    .HasConstraintName("FK_schedulazioni_processi");

                entity.HasOne(d => d.Sched3)
                    .WithMany(p => p.SchedulazioniSched3)
                    .HasForeignKey(d => new { d.SchedCliId, d.SchedUteId })
                    .HasConstraintName("FK_schedulazioni_utenti");
            });

            modelBuilder.Entity<SchedulazioniProcessi>(entity =>
            {
                entity.HasKey(e => new { e.SchedprocCliId, e.SchedprocId })
                    .HasName("PK__schedula__19A3C0682BD60659");

                entity.ToTable("schedulazioni_processi");

                entity.Property(e => e.SchedprocCliId)
                    .HasColumnName("schedproc_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.SchedprocId)
                    .HasColumnName("schedproc_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocAbilitato)
                    .HasColumnName("schedproc_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SchedprocCvScaricati).HasColumnName("schedproc_cv_scaricati");

                entity.Property(e => e.SchedprocDescrizione)
                    .HasColumnName("schedproc_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.SchedprocEmailDestXAlert)
                    .HasColumnName("schedproc_email_dest_x_alert")
                    .HasMaxLength(150);

                entity.Property(e => e.SchedprocInEsecuzione)
                    .HasColumnName("schedproc_in_esecuzione")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SchedprocInsTimestamp)
                    .HasColumnName("schedproc_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedprocInsUteId)
                    .HasColumnName("schedproc_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocIpMacchinaHost)
                    .HasColumnName("schedproc_ip_macchina_host")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocMaxCvScaricabili).HasColumnName("schedproc_max_cv_scaricabili");

                entity.Property(e => e.SchedprocModTimestamp)
                    .HasColumnName("schedproc_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedprocModUteId)
                    .HasColumnName("schedproc_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocNome)
                    .HasColumnName("schedproc_nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocProxEsecDistanzaMinInOre).HasColumnName("schedproc_prox_esec_distanza_min_in_ore");

                entity.Property(e => e.SchedprocProxEsecFestivi)
                    .HasColumnName("schedproc_prox_esec_festivi")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SchedprocProxEsecOraMax).HasColumnName("schedproc_prox_esec_ora_max");

                entity.Property(e => e.SchedprocProxEsecOraMin).HasColumnName("schedproc_prox_esec_ora_min");

                entity.Property(e => e.SchedprocRicercaPortali)
                    .HasColumnName("schedproc_ricerca_portali")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocUltCvScaricato)
                    .HasColumnName("schedproc_ult_cv_scaricato")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedprocUltEsecEsito)
                    .HasColumnName("schedproc_ult_esec_esito")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocUltEsecFine)
                    .HasColumnName("schedproc_ult_esec_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedprocUltEsecInizio)
                    .HasColumnName("schedproc_ult_esec_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedprocUltEsecNumCvAggiornati).HasColumnName("schedproc_ult_esec_num_cv_aggiornati");

                entity.Property(e => e.SchedprocUltEsecNumCvNuovi).HasColumnName("schedproc_ult_esec_num_cv_nuovi");

                entity.Property(e => e.SchedprocUltEsecNumCvTotali).HasColumnName("schedproc_ult_esec_num_cv_totali");

                entity.HasOne(d => d.SchedprocCli)
                    .WithMany(p => p.SchedulazioniProcessi)
                    .HasForeignKey(d => d.SchedprocCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schedulazioni_processi_clienti");

                entity.HasOne(d => d.Schedproc)
                    .WithMany(p => p.SchedulazioniProcessiSchedproc)
                    .HasForeignKey(d => new { d.SchedprocCliId, d.SchedprocInsUteId })
                    .HasConstraintName("FK_schedulazioni_processi_utenti_ins");

                entity.HasOne(d => d.SchedprocNavigation)
                    .WithMany(p => p.SchedulazioniProcessiSchedprocNavigation)
                    .HasForeignKey(d => new { d.SchedprocCliId, d.SchedprocModUteId })
                    .HasConstraintName("FK_schedulazioni_processi_utenti_mod");
            });

            modelBuilder.Entity<SchedulazioniProcessiEsecuzioni>(entity =>
            {
                entity.HasKey(e => new { e.SchedprocesecCliId, e.SchedprocesecId })
                    .HasName("PK__schedula__7FDCD14E9504FD83");

                entity.ToTable("schedulazioni_processi_esecuzioni");

                entity.Property(e => e.SchedprocesecCliId)
                    .HasColumnName("schedprocesec_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.SchedprocesecId)
                    .HasColumnName("schedprocesec_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SchedprocesecEsito)
                    .HasColumnName("schedprocesec_esito")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocesecFine)
                    .HasColumnName("schedprocesec_fine")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedprocesecInizio)
                    .HasColumnName("schedprocesec_inizio")
                    .HasColumnType("datetime");

                entity.Property(e => e.SchedprocesecInsTimestamp)
                    .HasColumnName("schedprocesec_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedprocesecInsUteId)
                    .HasColumnName("schedprocesec_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocesecModTimestamp)
                    .HasColumnName("schedprocesec_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchedprocesecModUteId)
                    .HasColumnName("schedprocesec_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchedprocesecNumCvAggiornati).HasColumnName("schedprocesec_num_cv_aggiornati");

                entity.Property(e => e.SchedprocesecNumCvNuovi).HasColumnName("schedprocesec_num_cv_nuovi");

                entity.Property(e => e.SchedprocesecNumCvTotali).HasColumnName("schedprocesec_num_cv_totali");

                entity.Property(e => e.SchedprocesecSchedId).HasColumnName("schedprocesec_sched_id");

                entity.Property(e => e.SchedprocesecSchedprocId)
                    .HasColumnName("schedprocesec_schedproc_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.SchedprocesecCli)
                    .WithMany(p => p.SchedulazioniProcessiEsecuzioni)
                    .HasForeignKey(d => d.SchedprocesecCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schedulazioni_processi_esecuzioni_clienti");

                entity.HasOne(d => d.Schedprocesec)
                    .WithMany(p => p.SchedulazioniProcessiEsecuzioniSchedprocesec)
                    .HasForeignKey(d => new { d.SchedprocesecCliId, d.SchedprocesecInsUteId })
                    .HasConstraintName("FK_schedulazioni_processi_esecuzioni_utenti_ins");

                entity.HasOne(d => d.SchedprocesecNavigation)
                    .WithMany(p => p.SchedulazioniProcessiEsecuzioniSchedprocesecNavigation)
                    .HasForeignKey(d => new { d.SchedprocesecCliId, d.SchedprocesecModUteId })
                    .HasConstraintName("FK_schedulazioni_processi_esecuzioni_utenti_mod");
            });

            modelBuilder.Entity<SediAziende>(entity =>
            {
                entity.HasKey(e => e.AzsedeId);

                entity.ToTable("sedi_aziende");

                entity.Property(e => e.AzsedeId).HasColumnName("azsede_id");

                entity.Property(e => e.AzsedeAttiva)
                    .IsRequired()
                    .HasColumnName("azsede_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeAzId).HasColumnName("azsede_az_id");

                entity.Property(e => e.AzsedeCap)
                    .HasColumnName("azsede_cap")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeCitta)
                    .HasColumnName("azsede_citta")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeCliId)
                    .IsRequired()
                    .HasColumnName("azsede_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.AzsedeDescr)
                    .HasColumnName("azsede_descr")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndic)
                    .HasColumnName("azsede_indic")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndicColloquio)
                    .HasColumnName("azsede_indic_colloquio")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeIndirizzo)
                    .HasColumnName("azsede_indirizzo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeInsTimestamp)
                    .HasColumnName("azsede_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzsedeInsUteId)
                    .IsRequired()
                    .HasColumnName("azsede_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeLegale)
                    .IsRequired()
                    .HasColumnName("azsede_legale")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AzsedeLocationLat)
                    .HasColumnName("azsede_location_lat")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzsedeLocationLong)
                    .HasColumnName("azsede_location_long")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AzsedeModTimestamp)
                    .HasColumnName("azsede_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AzsedeModUteId)
                    .IsRequired()
                    .HasColumnName("azsede_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AzsedeCli)
                    .WithMany(p => p.SediAziende)
                    .HasForeignKey(d => d.AzsedeCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sedi_aziende_clienti");

                entity.HasOne(d => d.Azsede)
                    .WithMany(p => p.SediAziende)
                    .HasForeignKey(d => new { d.AzsedeCliId, d.AzsedeAzId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sedi_aziende_sedi_aziende");
            });

            modelBuilder.Entity<Siti>(entity =>
            {
                entity.HasKey(e => new { e.SitoCliId, e.Sito })
                    .HasName("PK__siti__C257390867EED56C");

                entity.ToTable("siti");

                entity.Property(e => e.SitoCliId)
                    .HasColumnName("sito_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Sito)
                    .HasColumnName("sito")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SitoAttivo)
                    .IsRequired()
                    .HasColumnName("sito_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoDaValutare)
                    .IsRequired()
                    .HasColumnName("sito_da_valutare")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoDataFineContratto)
                    .HasColumnName("sito_data_fine_contratto")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitoDataInizioContratto)
                    .HasColumnName("sito_data_inizio_contratto")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitoGratuito)
                    .IsRequired()
                    .HasColumnName("sito_gratuito")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoInsTimestamp)
                    .HasColumnName("sito_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SitoInsUteId)
                    .IsRequired()
                    .HasColumnName("sito_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoLink)
                    .IsRequired()
                    .HasColumnName("sito_link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SitoModTimestamp)
                    .HasColumnName("sito_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SitoModUteId)
                    .IsRequired()
                    .HasColumnName("sito_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoNote)
                    .HasColumnName("sito_note")
                    .HasColumnType("text");

                entity.Property(e => e.SitoPassword)
                    .HasColumnName("sito_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoPrezzo)
                    .HasColumnName("sito_prezzo")
                    .HasColumnType("text");

                entity.Property(e => e.SitoPrezzo100Ann)
                    .HasColumnName("sito_prezzo_100_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzo200Ann)
                    .HasColumnName("sito_prezzo_200_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzo50Ann)
                    .HasColumnName("sito_prezzo_50_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzoConsDb)
                    .HasColumnName("sito_prezzo_cons_db")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoRicercaCv)
                    .IsRequired()
                    .HasColumnName("sito_ricerca_cv")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoSitiSocId)
                    .IsRequired()
                    .HasColumnName("sito_siti_soc_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('01')");

                entity.Property(e => e.SitoTemplate)
                    .HasColumnName("sito_template")
                    .HasColumnType("text");

                entity.Property(e => e.SitoTemplateTipo)
                    .HasColumnName("sito_template_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SitoUsername)
                    .HasColumnName("sito_username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SitoVoto).HasColumnName("sito_voto");

                entity.HasOne(d => d.SitoCli)
                    .WithMany(p => p.Siti)
                    .HasForeignKey(d => d.SitoCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_clienti");

                entity.HasOne(d => d.SitoNavigation)
                    .WithMany(p => p.SitiSitoNavigation)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_utenti_ins");

                entity.HasOne(d => d.Sito1)
                    .WithMany(p => p.SitiSito1)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_utenti_mod");

                entity.HasOne(d => d.Sito2)
                    .WithMany(p => p.Siti)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoSitiSocId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_siti_societa");
            });

            modelBuilder.Entity<SitiAnnunci>(entity =>
            {
                entity.HasKey(e => new { e.SitoCliId, e.Sito })
                    .HasName("PK__siti_ann__C25739080DA863E9");

                entity.ToTable("siti_annunci");

                entity.Property(e => e.SitoCliId)
                    .HasColumnName("sito_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Sito)
                    .HasColumnName("sito")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SitoAttivo)
                    .IsRequired()
                    .HasColumnName("sito_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoDaValutare)
                    .IsRequired()
                    .HasColumnName("sito_da_valutare")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoDataFineContratto)
                    .HasColumnName("sito_data_fine_contratto")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitoDataInizioContratto)
                    .HasColumnName("sito_data_inizio_contratto")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitoGratuito)
                    .IsRequired()
                    .HasColumnName("sito_gratuito")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoInsTimestamp)
                    .HasColumnName("sito_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SitoInsUteId)
                    .IsRequired()
                    .HasColumnName("sito_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoLink)
                    .IsRequired()
                    .HasColumnName("sito_link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SitoModTimestamp)
                    .HasColumnName("sito_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SitoModUteId)
                    .IsRequired()
                    .HasColumnName("sito_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoNote)
                    .HasColumnName("sito_note")
                    .HasColumnType("text");

                entity.Property(e => e.SitoPassword)
                    .HasColumnName("sito_password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitoPrezzo)
                    .HasColumnName("sito_prezzo")
                    .HasColumnType("text");

                entity.Property(e => e.SitoPrezzo100Ann)
                    .HasColumnName("sito_prezzo_100_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzo200Ann)
                    .HasColumnName("sito_prezzo_200_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzo50Ann)
                    .HasColumnName("sito_prezzo_50_ann")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoPrezzoConsDb)
                    .HasColumnName("sito_prezzo_cons_db")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.SitoRicercaCv)
                    .IsRequired()
                    .HasColumnName("sito_ricerca_cv")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SitoSitiSocId)
                    .IsRequired()
                    .HasColumnName("sito_siti_soc_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('01')");

                entity.Property(e => e.SitoTemplate)
                    .HasColumnName("sito_template")
                    .HasColumnType("text");

                entity.Property(e => e.SitoTemplateTipo)
                    .HasColumnName("sito_template_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SitoUsername)
                    .HasColumnName("sito_username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SitoVoto).HasColumnName("sito_voto");

                entity.HasOne(d => d.SitoCli)
                    .WithMany(p => p.SitiAnnunci)
                    .HasForeignKey(d => d.SitoCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_annunci_clienti");

                entity.HasOne(d => d.SitoNavigation)
                    .WithMany(p => p.SitiAnnunciSitoNavigation)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_annunci_utenti_ins");

                entity.HasOne(d => d.Sito1)
                    .WithMany(p => p.SitiAnnunciSito1)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_annunci_utenti_mod");

                entity.HasOne(d => d.Sito2)
                    .WithMany(p => p.SitiAnnunci)
                    .HasForeignKey(d => new { d.SitoCliId, d.SitoSitiSocId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_annunci_siti_societa");
            });

            modelBuilder.Entity<SitiSocieta>(entity =>
            {
                entity.HasKey(e => new { e.SitiSocCliId, e.SitiSocId })
                    .HasName("PK__siti_soc__01C518044FAE6F72");

                entity.ToTable("siti_societa");

                entity.Property(e => e.SitiSocCliId)
                    .HasColumnName("siti_soc_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.SitiSocId)
                    .HasColumnName("siti_soc_id")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SitiSocDescrizione)
                    .HasColumnName("siti_soc_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SitiSocFormCodAnn)
                    .HasColumnName("siti_soc_form_cod_ann")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SitiSocInsTimestamp)
                    .HasColumnName("siti_soc_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitiSocInsUteId)
                    .IsRequired()
                    .HasColumnName("siti_soc_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitiSocModTimestamp)
                    .HasColumnName("siti_soc_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.SitiSocModUteId)
                    .IsRequired()
                    .HasColumnName("siti_soc_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SitiSocRagSociale)
                    .IsRequired()
                    .HasColumnName("siti_soc_rag_sociale")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SitiSocCli)
                    .WithMany(p => p.SitiSocieta)
                    .HasForeignKey(d => d.SitiSocCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_societa_clienti");

                entity.HasOne(d => d.SitiSoc)
                    .WithMany(p => p.SitiSocietaSitiSoc)
                    .HasForeignKey(d => new { d.SitiSocCliId, d.SitiSocInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_societa_utenti_ins");

                entity.HasOne(d => d.SitiSocNavigation)
                    .WithMany(p => p.SitiSocietaSitiSocNavigation)
                    .HasForeignKey(d => new { d.SitiSocCliId, d.SitiSocModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_siti_societa_utenti_mod");
            });

            modelBuilder.Entity<SoftskillsCompetenze>(entity =>
            {
                entity.HasKey(e => e.SskcompCompetenza)
                    .HasName("PK_softskills_competenze_play");

                entity.ToTable("softskills_competenze");

                entity.Property(e => e.SskcompCompetenza)
                    .HasColumnName("sskcomp_competenza")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SskcompIdPlay).HasColumnName("sskcomp_id_play");

                entity.Property(e => e.SskcompInsTimestamp)
                    .HasColumnName("sskcomp_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SskcompLivello)
                    .HasColumnName("sskcomp_livello")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SskcompModTimestamp)
                    .HasColumnName("sskcomp_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SskcompVariabilePlay)
                    .HasColumnName("sskcomp_variabile_play")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SoftskillsCompetenzeDescr>(entity =>
            {
                entity.HasKey(e => new { e.SskcompdescrCompetenza, e.SskcompdescrLingua });

                entity.ToTable("softskills_competenze_descr");

                entity.Property(e => e.SskcompdescrCompetenza)
                    .HasColumnName("sskcompdescr_competenza")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SskcompdescrLingua)
                    .HasColumnName("sskcompdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SskcompdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("sskcompdescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SskcompdescrInsTimestamp)
                    .HasColumnName("sskcompdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SskcompdescrModTimestamp)
                    .HasColumnName("sskcompdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SskcompdescrCompetenzaNavigation)
                    .WithMany(p => p.SoftskillsCompetenzeDescr)
                    .HasForeignKey(d => d.SskcompdescrCompetenza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_softskills_competenze_descr_softskills_competenze");
            });

            modelBuilder.Entity<SoftskillsProfili>(entity =>
            {
                entity.HasKey(e => new { e.SskprofProfilo, e.SskprofLingua });

                entity.ToTable("softskills_profili");

                entity.Property(e => e.SskprofProfilo)
                    .HasColumnName("sskprof_profilo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SskprofLingua)
                    .HasColumnName("sskprof_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SskprofDescrizione)
                    .HasColumnName("sskprof_descrizione")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SskprofIdPlay).HasColumnName("sskprof_id_play");

                entity.Property(e => e.SskprofInsTimestamp)
                    .HasColumnName("sskprof_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SskprofModTimestamp)
                    .HasColumnName("sskprof_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SoftskillsTestWsResult>(entity =>
            {
                entity.HasKey(e => e.SsktestresId)
                    .HasName("PK_softskills_test_sostenuti");

                entity.ToTable("softskills_test_ws_result");

                entity.Property(e => e.SsktestresId).HasColumnName("ssktestres_id");

                entity.Property(e => e.SsktestresInsTimestamp)
                    .HasColumnName("ssktestres_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsktestresModTimestamp)
                    .HasColumnName("ssktestres_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsktestresPlayField1)
                    .HasColumnName("ssktestres_play_field_1")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.SsktestresPlayField2)
                    .HasColumnName("ssktestres_play_field_2")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.SsktestresPlayField3)
                    .HasColumnName("ssktestres_play_field_3")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.SsktestresPlayField4)
                    .HasColumnName("ssktestres_play_field_4")
                    .HasColumnType("decimal(20, 6)");

                entity.Property(e => e.SsktestresProfilo).HasColumnName("ssktestres_profilo");

                entity.Property(e => e.SsktestresRichId)
                    .HasColumnName("ssktestres_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SsktestresRisDataRisposta)
                    .HasColumnName("ssktestres_ris_data_risposta")
                    .HasColumnType("datetime");

                entity.Property(e => e.SsktestresRisId).HasColumnName("ssktestres_ris_id");

                entity.Property(e => e.SsktestresTestId).HasColumnName("ssktestres_test_id");

                entity.Property(e => e.SsktestresTipoTestQuiz)
                    .IsRequired()
                    .HasColumnName("ssktestres_tipo_test_quiz")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatiRichiesta>(entity =>
            {
                entity.HasKey(e => new { e.StatrichCliId, e.StatrichId })
                    .HasName("PK__stati_ri__90E17A92D8A2DA77");

                entity.ToTable("stati_richiesta");

                entity.Property(e => e.StatrichCliId)
                    .HasColumnName("statrich_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.StatrichId)
                    .HasColumnName("statrich_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StatrichInsTimestamp)
                    .HasColumnName("statrich_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatrichInsUteId)
                    .IsRequired()
                    .HasColumnName("statrich_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatrichModTimestamp)
                    .HasColumnName("statrich_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatrichModUteId)
                    .IsRequired()
                    .HasColumnName("statrich_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatrichStato)
                    .IsRequired()
                    .HasColumnName("statrich_stato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatrichCli)
                    .WithMany(p => p.StatiRichiesta)
                    .HasForeignKey(d => d.StatrichCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stati_richiesta_clienti");

                entity.HasOne(d => d.Statrich)
                    .WithMany(p => p.StatiRichiestaStatrich)
                    .HasForeignKey(d => new { d.StatrichCliId, d.StatrichInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stati_richiesta_utenti_ins");

                entity.HasOne(d => d.StatrichNavigation)
                    .WithMany(p => p.StatiRichiestaStatrichNavigation)
                    .HasForeignKey(d => new { d.StatrichCliId, d.StatrichModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stati_richiesta_utenti_mod");
            });

            modelBuilder.Entity<StatiRichiesteListaRisorse>(entity =>
            {
                entity.HasKey(e => e.StarichlistStato);

                entity.ToTable("stati_richieste_lista_risorse");

                entity.Property(e => e.StarichlistStato)
                    .HasColumnName("starichlist_stato")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StarichlistInsTimestamp)
                    .HasColumnName("starichlist_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StarichlistModTimestamp)
                    .HasColumnName("starichlist_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StarichlistWf).HasColumnName("starichlist_wf");
            });

            modelBuilder.Entity<StatiRichiesteListaRisorseDescr>(entity =>
            {
                entity.HasKey(e => new { e.StarichlistdescrStato, e.StarichlistdescrLingua });

                entity.ToTable("stati_richieste_lista_risorse_descr");

                entity.Property(e => e.StarichlistdescrStato)
                    .HasColumnName("starichlistdescr_stato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StarichlistdescrLingua)
                    .HasColumnName("starichlistdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StarichlistModTimestamp)
                    .HasColumnName("starichlist_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StarichlistdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("starichlistdescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StarichlistdescrInsTimestamp)
                    .HasColumnName("starichlistdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.StarichlistdescrStatoNavigation)
                    .WithMany(p => p.StatiRichiesteListaRisorseDescr)
                    .HasForeignKey(d => d.StarichlistdescrStato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stati_richieste_lista_risorse_descr_stati_richieste_lista_risorse");
            });

            modelBuilder.Entity<StatiTermine>(entity =>
            {
                entity.HasKey(e => e.SterStato)
                    .HasName("PK__stati_te__3725F78683A80A96");

                entity.ToTable("stati_termine");

                entity.Property(e => e.SterStato)
                    .HasColumnName("ster_stato")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SterDescrizione)
                    .IsRequired()
                    .HasColumnName("ster_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SterInsTimestamp)
                    .HasColumnName("ster_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SterModTimestamp)
                    .HasColumnName("ster_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StatiTermineDescr>(entity =>
            {
                entity.HasKey(e => new { e.SterdescrSterStato, e.SterdescrLingua })
                    .HasName("PK_stati_termine");

                entity.ToTable("stati_termine_descr");

                entity.Property(e => e.SterdescrSterStato)
                    .HasColumnName("sterdescr_ster_stato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SterdescrLingua)
                    .HasColumnName("sterdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SterdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("sterdescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SterdescrInsTimestamp)
                    .HasColumnName("sterdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SterdescrModTimestamp)
                    .HasColumnName("sterdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SterdescrSterStatoNavigation)
                    .WithMany(p => p.StatiTermineDescr)
                    .HasForeignKey(d => d.SterdescrSterStato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stati_termine_ster_stato");
            });

            modelBuilder.Entity<StatisticheIndicatori>(entity =>
            {
                entity.HasKey(e => new { e.StatCliId, e.StatCodice })
                    .HasName("PK__statisti__6E86B0805A4D9D66");

                entity.ToTable("statistiche_indicatori");

                entity.Property(e => e.StatCliId)
                    .HasColumnName("stat_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.StatCodice)
                    .HasColumnName("stat_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatDataFineRilevazione)
                    .HasColumnName("stat_data_fine_rilevazione")
                    .HasColumnType("date");

                entity.Property(e => e.StatDataInizioRilevazione)
                    .HasColumnName("stat_data_inizio_rilevazione")
                    .HasColumnType("date");

                entity.Property(e => e.StatDescrizione)
                    .IsRequired()
                    .HasColumnName("stat_descrizione")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatInsTimestamp)
                    .HasColumnName("stat_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatInsUteId)
                    .IsRequired()
                    .HasColumnName("stat_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatModTimestamp)
                    .HasColumnName("stat_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatModUteId)
                    .IsRequired()
                    .HasColumnName("stat_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatNote)
                    .HasColumnName("stat_note")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StatOrdineElaborazione).HasColumnName("stat_ordine_elaborazione");

                entity.Property(e => e.StatQuery)
                    .IsRequired()
                    .HasColumnName("stat_query")
                    .IsUnicode(false);

                entity.Property(e => e.StatTipoValore)
                    .IsRequired()
                    .HasColumnName("stat_tipo_valore")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatCli)
                    .WithMany(p => p.StatisticheIndicatori)
                    .HasForeignKey(d => d.StatCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_statistiche_indicatori_clienti");

                entity.HasOne(d => d.Stat)
                    .WithMany(p => p.StatisticheIndicatoriStat)
                    .HasForeignKey(d => new { d.StatCliId, d.StatInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_statistiche_indicatori_utenti_ins");

                entity.HasOne(d => d.StatNavigation)
                    .WithMany(p => p.StatisticheIndicatoriStatNavigation)
                    .HasForeignKey(d => new { d.StatCliId, d.StatModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_statistiche_indicatori_utenti_mod");
            });

            modelBuilder.Entity<TalentFiltriPagine>(entity =>
            {
                entity.HasKey(e => e.TntfilFiltropagId)
                    .HasName("PK_talent_filtri_pagina");

                entity.ToTable("talent_filtri_pagine");

                entity.Property(e => e.TntfilFiltropagId).HasColumnName("tntfil_filtropag_id");

                entity.Property(e => e.TntfilFiltropagCliId)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagDescrizione)
                    .HasColumnName("tntfil_filtropag_descrizione")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagInsTimestamp)
                    .HasColumnName("tntfil_filtropag_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntfilFiltropagInsUteId)
                    .HasColumnName("tntfil_filtropag_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagInternalRepresentation)
                    .HasColumnName("tntfil_filtropag_internal_representation")
                    .HasColumnType("text");

                entity.Property(e => e.TntfilFiltropagModTimestamp)
                    .HasColumnName("tntfil_filtropag_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntfilFiltropagModUteId)
                    .HasColumnName("tntfil_filtropag_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagNome)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_nome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagNomeCorto)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_nome_corto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagOrder1Ascending)
                    .HasColumnName("tntfil_filtropag_order_1_ascending")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagOrder1FiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropag_order_1_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagOrder2Ascending)
                    .HasColumnName("tntfil_filtropag_order_2_ascending")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagOrder2FiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropag_order_2_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagPaginaCodice)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_pagina_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagPubblico)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_pubblico")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagPulisciPrecedenti)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_pulisci_precedenti")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagQuery)
                    .HasColumnName("tntfil_filtropag_query")
                    .HasColumnType("text");

                entity.Property(e => e.TntfilFiltropagSelect1Filtrocond)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_select_1_filtrocond")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect1FiltrocondDatafissa)
                    .HasColumnName("tntfil_filtropag_select_1_filtrocond_datafissa")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect1FiltropagcampoCodice)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropag_select_1_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect1Valore)
                    .HasColumnName("tntfil_filtropag_select_1_valore")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect2Filtrocond)
                    .HasColumnName("tntfil_filtropag_select_2_filtrocond")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect2FiltrocondDatafissa)
                    .HasColumnName("tntfil_filtropag_select_2_filtrocond_datafissa")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect2FiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropag_select_2_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect2Valore)
                    .HasColumnName("tntfil_filtropag_select_2_valore")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect3Filtrocond)
                    .HasColumnName("tntfil_filtropag_select_3_filtrocond")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect3FiltrocondDatafissa)
                    .HasColumnName("tntfil_filtropag_select_3_filtrocond_datafissa")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect3FiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropag_select_3_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagSelect3Valore)
                    .HasColumnName("tntfil_filtropag_select_3_valore")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntfilFiltropagCli)
                    .WithMany(p => p.TalentFiltriPagine)
                    .HasForeignKey(d => d.TntfilFiltropagCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_clienti");

                entity.HasOne(d => d.TntfilFiltropagPaginaCodiceNavigation)
                    .WithMany(p => p.TalentFiltriPagine)
                    .HasForeignKey(d => d.TntfilFiltropagPaginaCodice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_talent_pagine");

                entity.HasOne(d => d.TntfilFiltropagSelect1FiltropagcampoCodiceNavigation)
                    .WithMany(p => p.TalentFiltriPagineTntfilFiltropagSelect1FiltropagcampoCodiceNavigation)
                    .HasForeignKey(d => d.TntfilFiltropagSelect1FiltropagcampoCodice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_talent_filtri_pagina_campi");

                entity.HasOne(d => d.TntfilFiltropagSelect2FiltropagcampoCodiceNavigation)
                    .WithMany(p => p.TalentFiltriPagineTntfilFiltropagSelect2FiltropagcampoCodiceNavigation)
                    .HasForeignKey(d => d.TntfilFiltropagSelect2FiltropagcampoCodice)
                    .HasConstraintName("FK_talent_filtri_pagina_talent_filtri_pagina_campi1");

                entity.HasOne(d => d.TntfilFiltropagSelect3FiltropagcampoCodiceNavigation)
                    .WithMany(p => p.TalentFiltriPagineTntfilFiltropagSelect3FiltropagcampoCodiceNavigation)
                    .HasForeignKey(d => d.TntfilFiltropagSelect3FiltropagcampoCodice)
                    .HasConstraintName("FK_talent_filtri_pagina_talent_filtri_pagina_campi2");

                entity.HasOne(d => d.TntfilFiltropag)
                    .WithMany(p => p.TalentFiltriPagineTntfilFiltropag)
                    .HasForeignKey(d => new { d.TntfilFiltropagCliId, d.TntfilFiltropagInsUteId })
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_utenti_ins");

                entity.HasOne(d => d.TntfilFiltropagNavigation)
                    .WithMany(p => p.TalentFiltriPagineTntfilFiltropagNavigation)
                    .HasForeignKey(d => new { d.TntfilFiltropagCliId, d.TntfilFiltropagModUteId })
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_utenti_mod");
            });

            modelBuilder.Entity<TalentFiltriPagineCampi>(entity =>
            {
                entity.HasKey(e => e.TntfilFiltropagcampoCodice)
                    .HasName("PK_talent_filtri_pagina_campi");

                entity.ToTable("talent_filtri_pagine_campi");

                entity.Property(e => e.TntfilFiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TntfilFiltropagcampoAttivo)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampo_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoCampoTabellaDb)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampo_campo_tabella_db")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoCodiceInterno)
                    .HasColumnName("tntfil_filtropagcampo_codice_interno")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoFiltroOrdineVis).HasColumnName("tntfil_filtropagcampo_filtro_ordine_vis");

                entity.Property(e => e.TntfilFiltropagcampoFromList)
                    .HasColumnName("tntfil_filtropagcampo_from_list")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoJoinWhereCondition)
                    .HasColumnName("tntfil_filtropagcampo_join_where_condition")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoListCodes)
                    .HasColumnName("tntfil_filtropagcampo_list_codes")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoListValues)
                    .HasColumnName("tntfil_filtropagcampo_list_values")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoPagina)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampo_pagina")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoSoloFiltro)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampo_solo_filtro")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampoSortOrdineVis).HasColumnName("tntfil_filtropagcampo_sort_ordine_vis");

                entity.Property(e => e.TntfilFiltropagcampoTipo)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampo_tipo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntfilFiltropagcampoPaginaNavigation)
                    .WithMany(p => p.TalentFiltriPagineCampi)
                    .HasForeignKey(d => d.TntfilFiltropagcampoPagina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_campi_talent_pagine");
            });

            modelBuilder.Entity<TalentFiltriPagineCampiDescr>(entity =>
            {
                entity.HasKey(e => new { e.TntfilFiltropagcampodescrFiltropagcampoCodice, e.TntfilFiltropagcampodescrLingua });

                entity.ToTable("talent_filtri_pagine_campi_descr");

                entity.Property(e => e.TntfilFiltropagcampodescrFiltropagcampoCodice)
                    .HasColumnName("tntfil_filtropagcampodescr_filtropagcampo_codice")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampodescrLingua)
                    .HasColumnName("tntfil_filtropagcampodescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampodescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagcampodescr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropagcampodescrInsTimestamp)
                    .HasColumnName("tntfil_filtropagcampodescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(getdate())");

                entity.Property(e => e.TntfilFiltropagcampodescrModTimestamp)
                    .HasColumnName("tntfil_filtropagcampodescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(getdate())");
            });

            modelBuilder.Entity<TalentFiltriPagineUtenti>(entity =>
            {
                entity.HasKey(e => e.TntfilFiltropaguteId);

                entity.ToTable("talent_filtri_pagine_utenti");

                entity.Property(e => e.TntfilFiltropaguteId).HasColumnName("tntfil_filtropagute_id");

                entity.Property(e => e.TntfilFiltropaguteBottone).HasColumnName("tntfil_filtropagute_bottone");

                entity.Property(e => e.TntfilFiltropaguteBottoneLabel)
                    .HasColumnName("tntfil_filtropagute_bottone_label")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropaguteCliId)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagute_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropaguteDefault)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagute_default")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropaguteFiltropagId).HasColumnName("tntfil_filtropagute_filtropag_id");

                entity.Property(e => e.TntfilFiltropaguteInsTimestamp)
                    .HasColumnName("tntfil_filtropagute_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntfilFiltropaguteInsUteId)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagute_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropaguteModTimestamp)
                    .HasColumnName("tntfil_filtropagute_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntfilFiltropaguteModUteId)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagute_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilFiltropaguteOrdine).HasColumnName("tntfil_filtropagute_ordine");

                entity.Property(e => e.TntfilFiltropaguteUteId)
                    .IsRequired()
                    .HasColumnName("tntfil_filtropagute_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntfilFiltropaguteCli)
                    .WithMany(p => p.TalentFiltriPagineUtenti)
                    .HasForeignKey(d => d.TntfilFiltropaguteCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_clienti");

                entity.HasOne(d => d.TntfilFiltropaguteFiltropag)
                    .WithMany(p => p.TalentFiltriPagineUtenti)
                    .HasForeignKey(d => d.TntfilFiltropaguteFiltropagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_talent_filtri_pagina");

                entity.HasOne(d => d.TntfilFiltropagute)
                    .WithMany(p => p.TalentFiltriPagineUtentiTntfilFiltropagute)
                    .HasForeignKey(d => new { d.TntfilFiltropaguteCliId, d.TntfilFiltropaguteInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_utenti_utenti_ins");

                entity.HasOne(d => d.TntfilFiltropaguteNavigation)
                    .WithMany(p => p.TalentFiltriPagineUtentiTntfilFiltropaguteNavigation)
                    .HasForeignKey(d => new { d.TntfilFiltropaguteCliId, d.TntfilFiltropaguteModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_utenti_utenti_mod");

                entity.HasOne(d => d.TntfilFiltropagute1)
                    .WithMany(p => p.TalentFiltriPagineUtentiTntfilFiltropagute1)
                    .HasForeignKey(d => new { d.TntfilFiltropaguteCliId, d.TntfilFiltropaguteUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_filtri_pagina_utenti_utenti");
            });

            modelBuilder.Entity<TalentFontDimensioni>(entity =>
            {
                entity.HasKey(e => e.TntszFontDimensione)
                    .HasName("PK_talent_font_size");

                entity.ToTable("talent_font_dimensioni");

                entity.Property(e => e.TntszFontDimensione)
                    .HasColumnName("tntsz_font_dimensione")
                    .ValueGeneratedNever();

                entity.Property(e => e.TntszInsTimestamp)
                    .HasColumnName("tntsz_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntszModTimestamp)
                    .HasColumnName("tntsz_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TalentFontNomi>(entity =>
            {
                entity.HasKey(e => e.TntfontNomeFont)
                    .HasName("PK_talent_font_names");

                entity.ToTable("talent_font_nomi");

                entity.Property(e => e.TntfontNomeFont)
                    .HasColumnName("tntfont_nome_font")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TntfontInsTimestamp)
                    .HasColumnName("tntfont_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntfontModTimestamp)
                    .HasColumnName("tntfont_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TalentGriglie>(entity =>
            {
                entity.HasKey(e => e.TntgrlNomeGriglia)
                    .HasName("PK_talent_grids");

                entity.ToTable("talent_griglie");

                entity.Property(e => e.TntgrlNomeGriglia)
                    .HasColumnName("tntgrl_nome_griglia")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TntgrlInsTimestamp)
                    .HasColumnName("tntgrl_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgrlModTimestamp)
                    .HasColumnName("tntgrl_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgrlTntfilPaginaCodice)
                    .HasColumnName("tntgrl_tntfil_pagina_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntgrlTntfilPaginaCodiceNavigation)
                    .WithMany(p => p.TalentGriglie)
                    .HasForeignKey(d => d.TntgrlTntfilPaginaCodice)
                    .HasConstraintName("FK_talent_grids_talent_pagine");
            });

            modelBuilder.Entity<TalentGriglieCampi>(entity =>
            {
                entity.HasKey(e => new { e.TntgcNomeCampo, e.TntgcTntgridNomeGriglia });

                entity.ToTable("talent_griglie_campi");

                entity.Property(e => e.TntgcNomeCampo)
                    .HasColumnName("tntgc_nome_campo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcTntgridNomeGriglia)
                    .HasColumnName("tntgc_tntgrid_nome_griglia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcAttivo)
                    .IsRequired()
                    .HasColumnName("tntgc_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'S')");

                entity.Property(e => e.TntgcDescrizione)
                    .HasColumnName("tntgc_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcFromList)
                    .HasColumnName("tntgc_from_list")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcInsTimestamp)
                    .HasColumnName("tntgc_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgcJoinWhereCondition)
                    .HasColumnName("tntgc_join_where_condition")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcModTimestamp)
                    .HasColumnName("tntgc_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgcNomeCampoDb)
                    .HasColumnName("tntgc_nome_campo_db")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntgcTntgridNomeGrigliaNavigation)
                    .WithMany(p => p.TalentGriglieCampi)
                    .HasForeignKey(d => d.TntgcTntgridNomeGriglia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_griglie_campi_talent_griglie");
            });

            modelBuilder.Entity<TalentGriglieCampiDescr>(entity =>
            {
                entity.HasKey(e => new { e.TntgcNomeCampo, e.TntgcLingua });

                entity.ToTable("talent_griglie_campi_descr");

                entity.Property(e => e.TntgcNomeCampo)
                    .HasColumnName("tntgc_nome_campo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcLingua)
                    .HasColumnName("tntgc_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcDescrizione)
                    .IsRequired()
                    .HasColumnName("tntgc_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcInsTimestamp)
                    .HasColumnName("tntgc_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgcModTimestamp)
                    .HasColumnName("tntgc_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TalentGriglieCampiUtenti>(entity =>
            {
                entity.HasKey(e => new { e.TntgcuUteId, e.TntgcuCliId, e.TntgcuTntgcNomeCampo })
                    .HasName("PK_talent_grid_fields_users");

                entity.ToTable("talent_griglie_campi_utenti");

                entity.Property(e => e.TntgcuUteId)
                    .HasColumnName("tntgcu_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuCliId)
                    .HasColumnName("tntgcu_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuTntgcNomeCampo)
                    .HasColumnName("tntgcu_tntgc_nome_campo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntgcuAllineamento)
                    .HasColumnName("tntgcu_allineamento")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Left')");

                entity.Property(e => e.TntgcuAutoSize)
                    .HasColumnName("tntgcu_auto_size")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.TntgcuId)
                   .HasColumnName("tntgcu_id").UseSqlServerIdentityColumn();

                entity.Property(e => e.TntgcuId)
                        .HasColumnName("tntgcu_id").Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                entity.Property(e => e.TntgcuMaxSize)
                    .HasColumnName("tntgcu_max_size")
                    .HasDefaultValueSql("((1000))");

                entity.Property(e => e.TntgcuMinSize)
                    .HasColumnName("tntgcu_min_size")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.TntgcuOrdineVis)
                    .HasColumnName("tntgcu_ordine_vis")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TntgcuTntfontNomeFont)
                    .HasColumnName("tntgcu_tntfont_nome_font")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Arial')");

                entity.Property(e => e.TntgcuTntszFontDimensione)
                    .HasColumnName("tntgcu_tntsz_font_dimensione")
                    .HasDefaultValueSql("((10))");

                entity.HasOne(d => d.TntgcuTntfontNomeFontNavigation)
                    .WithMany(p => p.TalentGriglieCampiUtenti)
                    .HasForeignKey(d => d.TntgcuTntfontNomeFont)
                    .HasConstraintName("FK_talent_grid_fields_users_talent_font_names");

                entity.HasOne(d => d.TntgcuTntszFontDimensioneNavigation)
                    .WithMany(p => p.TalentGriglieCampiUtenti)
                    .HasForeignKey(d => d.TntgcuTntszFontDimensione)
                    .HasConstraintName("FK_talent_grid_fields_users_talent_font_size");

                entity.HasOne(d => d.Tntgcu)
                    .WithMany(p => p.TalentGriglieCampiUtenti)
                    .HasForeignKey(d => new { d.TntgcuCliId, d.TntgcuUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_grid_fields_users_utenti");
            });

            modelBuilder.Entity<TalentGriglieUtenti>(entity =>
            {
                entity.HasKey(e => new { e.TntgruNomeGriglia, e.TntgruUteId, e.TntgruCliId })
                    .HasName("PK_talent_grid_user_settings");

                entity.ToTable("talent_griglie_utenti");

                entity.Property(e => e.TntgruNomeGriglia)
                    .HasColumnName("tntgru_nome_griglia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TntgruUteId)
                    .HasColumnName("tntgru_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TntgruCliId)
                    .HasColumnName("tntgru_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TntgruColoreRigheDispari)
                    .HasColumnName("tntgru_colore_righe_dispari")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('#F5F5F5')");

                entity.Property(e => e.TntgruColoreRighePari)
                    .HasColumnName("tntgru_colore_righe_pari")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('#FFFFFF')");

                entity.Property(e => e.TntgruId)
                    .HasColumnName("tntgru_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TntgruInsTimestamp)
                    .HasColumnName("tntgru_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgruModTimestamp)
                    .HasColumnName("tntgru_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntgruMostraNumeriRiga)
                    .HasColumnName("tntgru_mostra_numeri_riga")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TntgruTntfontNomeFont)
                    .HasColumnName("tntgru_tntfont_nome_font")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Arial')");

                entity.Property(e => e.TntgruTntszFontDimensione)
                    .HasColumnName("tntgru_tntsz_font_dimensione")
                    .HasDefaultValueSql("((10))");

                entity.HasOne(d => d.TntgruNomeGrigliaNavigation)
                    .WithMany(p => p.TalentGriglieUtenti)
                    .HasForeignKey(d => d.TntgruNomeGriglia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_grid_user_settings_talent_grids");

                entity.HasOne(d => d.TntgruTntfontNomeFontNavigation)
                    .WithMany(p => p.TalentGriglieUtenti)
                    .HasForeignKey(d => d.TntgruTntfontNomeFont)
                    .HasConstraintName("FK_talent_grid_user_settings_talent_font_names");

                entity.HasOne(d => d.TntgruTntszFontDimensioneNavigation)
                    .WithMany(p => p.TalentGriglieUtenti)
                    .HasForeignKey(d => d.TntgruTntszFontDimensione)
                    .HasConstraintName("FK_talent_grid_user_settings_talent_font_size");

                entity.HasOne(d => d.Tntgru)
                    .WithMany(p => p.TalentGriglieUtenti)
                    .HasForeignKey(d => new { d.TntgruCliId, d.TntgruUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_grid_user_settings_utenti");
            });

            modelBuilder.Entity<TalentLingue>(entity =>
            {
                entity.HasKey(e => e.TlngLingua);

                entity.ToTable("talent_lingue");

                entity.Property(e => e.TlngLingua)
                    .HasColumnName("tlng_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TlngInsTimestamp)
                    .HasColumnName("tlng_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TlngModTimestamp)
                    .HasColumnName("tlng_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TalentLingueClienti>(entity =>
            {
                entity.HasKey(e => new { e.LngcliCliId, e.LngcliLingua });

                entity.ToTable("talent_lingue_clienti");

                entity.Property(e => e.LngcliCliId)
                    .HasColumnName("lngcli_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LngcliLingua)
                    .HasColumnName("lngcli_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LngcliCv)
                    .IsRequired()
                    .HasColumnName("lngcli_cv")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LngcliDefault)
                    .IsRequired()
                    .HasColumnName("lngcli_default")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LngcliInsTimestamp)
                    .HasColumnName("lngcli_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LngcliModTimestamp)
                    .HasColumnName("lngcli_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LngcliUi)
                    .IsRequired()
                    .HasColumnName("lngcli_ui")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.LngcliCli)
                    .WithMany(p => p.TalentLingueClienti)
                    .HasForeignKey(d => d.LngcliCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_lingue_clienti_clienti");

                entity.HasOne(d => d.LngcliLinguaNavigation)
                    .WithMany(p => p.TalentLingueClienti)
                    .HasForeignKey(d => d.LngcliLingua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_lingue_clienti_talent_lingue");
            });

            modelBuilder.Entity<TalentLingueDescr>(entity =>
            {
                entity.HasKey(e => new { e.TlngdescrTlngLingua, e.TlngdescrLingua });

                entity.ToTable("talent_lingue_descr");

                entity.Property(e => e.TlngdescrTlngLingua)
                    .HasColumnName("tlngdescr_tlng_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TlngdescrLingua)
                    .HasColumnName("tlngdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TipoabilitModTimestamp)
                    .HasColumnName("tipoabilit_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TlngdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tlngdescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TlngdescrInsTimestamp)
                    .HasColumnName("tlngdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TlngdescrLinguaNavigation)
                    .WithMany(p => p.TalentLingueDescrTlngdescrLinguaNavigation)
                    .HasForeignKey(d => d.TlngdescrLingua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_lingue_descr_talent_lingue");

                entity.HasOne(d => d.TlngdescrTlngLinguaNavigation)
                    .WithMany(p => p.TalentLingueDescrTlngdescrTlngLinguaNavigation)
                    .HasForeignKey(d => d.TlngdescrTlngLingua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_lingue_descr_talent_lingue_descr");
            });

            modelBuilder.Entity<TalentMenu>(entity =>
            {
                entity.HasKey(e => new { e.TntmenuId, e.TntmenuCliId });

                entity.ToTable("talent_menu");

                entity.Property(e => e.TntmenuId)
                    .HasColumnName("tntmenu_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TntmenuCliId)
                    .HasColumnName("tntmenu_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TntmenuAttivo).HasColumnName("tntmenu_attivo");

                entity.Property(e => e.TntmenuDescrizione)
                    .HasColumnName("tntmenu_descrizione")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TntmenuHasubmenu).HasColumnName("tntmenu_hasubmenu");

                entity.Property(e => e.TntmenuIsdefault).HasColumnName("tntmenu_isdefault");

                entity.Property(e => e.TntmenuLivello).HasColumnName("tntmenu_livello");

                entity.Property(e => e.TntmenuOrdinamento).HasColumnName("tntmenu_ordinamento");

                entity.Property(e => e.TntmenuParentid).HasColumnName("tntmenu_parentid");

                entity.Property(e => e.TntmenuTntfilPaginaCodice)
                    .HasColumnName("tntmenu_tntfil_pagina_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TntmenuTntfilPaginaCodiceNavigation)
                    .WithMany(p => p.TalentMenu)
                    .HasForeignKey(d => d.TntmenuTntfilPaginaCodice)
                    .HasConstraintName("FK_talent_menu_talent_pagine");
            });

            modelBuilder.Entity<TalentMenuDescr>(entity =>
            {
                entity.HasKey(e => new { e.TntmenudescrTntmenuId, e.TntmenudescrLingua, e.TntmenudescrTntmenuCliId });

                entity.ToTable("talent_menu_descr");

                entity.Property(e => e.TntmenudescrTntmenuId).HasColumnName("tntmenudescr_tntmenu_id");

                entity.Property(e => e.TntmenudescrLingua)
                    .HasColumnName("tntmenudescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TntmenudescrTntmenuCliId)
                    .HasColumnName("tntmenudescr_tntmenu_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoabilitModTimestamp)
                    .HasColumnName("tipoabilit_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TntmenudescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tntmenudescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TntmenudescrInsTimestamp)
                    .HasColumnName("tntmenudescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TntmenudescrTntmenu)
                    .WithMany(p => p.TalentMenuDescr)
                    .HasForeignKey(d => new { d.TntmenudescrTntmenuId, d.TntmenudescrTntmenuCliId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_menu_descr_talent_menu");
            });

            modelBuilder.Entity<TalentPagine>(entity =>
            {
                entity.HasKey(e => e.TntfilPaginaCodice)
                    .HasName("PK_pagine");

                entity.ToTable("talent_pagine");

                entity.Property(e => e.TntfilPaginaCodice)
                    .HasColumnName("tntfil_pagina_codice")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TntfilPaginaAttiva)
                    .IsRequired()
                    .HasColumnName("tntfil_pagina_attiva")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.TntfilPaginaDescrizione)
                    .IsRequired()
                    .HasColumnName("tntfil_pagina_descrizione")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilPaginaNote)
                    .HasColumnName("tntfil_pagina_note")
                    .HasColumnType("text");

                entity.Property(e => e.TntfilPaginaUrl)
                    .IsRequired()
                    .HasColumnName("tntfil_pagina_url")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TntfilUteabProcedura)
                    .HasColumnName("tntfil_uteab_procedura")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TalentRichiesteListaRisorse>(entity =>
            {
                entity.HasKey(e => new { e.TrichlistCliId, e.TrichlistId })
                    .HasName("PK__talent_r__48AA56CBBA3B9DF3")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("talent_richieste_lista_risorse");

                entity.Property(e => e.TrichlistCliId)
                    .HasColumnName("trichlist_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TrichlistId)
                    .HasColumnName("trichlist_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TrichlistInsTimestamp)
                    .HasColumnName("trichlist_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrichlistInsUteId)
                    .HasColumnName("trichlist_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrichlistModTimestamp)
                    .HasColumnName("trichlist_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrichlistModUteId)
                    .HasColumnName("trichlist_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrichlistRichId)
                    .IsRequired()
                    .HasColumnName("trichlist_rich_id")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.TrichlistRisId).HasColumnName("trichlist_ris_id");

                entity.Property(e => e.TrichlistStato)
                    .HasColumnName("trichlist_stato")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrichlistVoto)
                    .HasColumnName("trichlist_voto")
                    .HasColumnType("decimal(5, 1)");

                entity.HasOne(d => d.TrichlistCli)
                    .WithMany(p => p.TalentRichiesteListaRisorse)
                    .HasForeignKey(d => d.TrichlistCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_richieste_lista_risorse_clienti");

                entity.HasOne(d => d.Trichlist)
                    .WithMany(p => p.TalentRichiesteListaRisorseTrichlist)
                    .HasForeignKey(d => new { d.TrichlistCliId, d.TrichlistInsUteId })
                    .HasConstraintName("FK_talent_richieste_lista_risorse_utenti_ins");

                entity.HasOne(d => d.TrichlistNavigation)
                    .WithMany(p => p.TalentRichiesteListaRisorseTrichlistNavigation)
                    .HasForeignKey(d => new { d.TrichlistCliId, d.TrichlistModUteId })
                    .HasConstraintName("FK_talent_richieste_lista_risorse_utenti_mod");

                entity.HasOne(d => d.Trichlist1)
                    .WithMany(p => p.TalentRichiesteListaRisorse)
                    .HasForeignKey(d => new { d.TrichlistCliId, d.TrichlistRichId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_richieste_lista_risorse_richieste");

                entity.HasOne(d => d.Trichlist2)
                    .WithMany(p => p.TalentRichiesteListaRisorse)
                    .HasForeignKey(d => new { d.TrichlistCliId, d.TrichlistRisId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_talent_richieste_lista_risorse_risorse");
            });

            modelBuilder.Entity<TalentRuoliTipiAbilitazione>(entity =>
            {
                entity.HasKey(e => new { e.RuoltipabRuolo, e.RuoltipabUteabProcedura, e.RuoltipabCliId })
                    .HasName("PK_ruoli_tipi_abilitazione");

                entity.ToTable("talent_ruoli_tipi_abilitazione");

                entity.Property(e => e.RuoltipabRuolo)
                    .HasColumnName("ruoltipab_ruolo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RuoltipabUteabProcedura)
                    .HasColumnName("ruoltipab_uteab_procedura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuoltipabCliId)
                    .HasColumnName("ruoltipab_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ITP999')");

                entity.Property(e => e.RuoltipabUteabAbilitato)
                    .IsRequired()
                    .HasColumnName("ruoltipab_uteab_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RuoltipabUteabInsTimestamp)
                    .HasColumnName("ruoltipab_uteab_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuoltipabUteabModTimestamp)
                    .HasColumnName("ruoltipab_uteab_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RuoltipabCli)
                    .WithMany(p => p.TalentRuoliTipiAbilitazione)
                    .HasForeignKey(d => d.RuoltipabCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_tipi_abilitazione_clienti");

                entity.HasOne(d => d.RuoltipabUteabProceduraNavigation)
                    .WithMany(p => p.TalentRuoliTipiAbilitazione)
                    .HasForeignKey(d => d.RuoltipabUteabProcedura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_tipi_abilitazione_ruoli_tipi_abilitazione");

                entity.HasOne(d => d.Ruoltipab)
                    .WithMany(p => p.TalentRuoliTipiAbilitazione)
                    .HasForeignKey(d => new { d.RuoltipabCliId, d.RuoltipabRuolo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ruoli_tipi_abilitazione_ruoli_utenti");
            });

            modelBuilder.Entity<TalentTipiAbilitazione>(entity =>
            {
                entity.HasKey(e => e.TipoabilitProcedura)
                    .HasName("PK_tipi_abilitazione");

                entity.ToTable("talent_tipi_abilitazione");

                entity.Property(e => e.TipoabilitProcedura)
                    .HasColumnName("tipoabilit_procedura")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TipoabilitInsTimestamp)
                    .HasColumnName("tipoabilit_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoabilitModTimestamp)
                    .HasColumnName("tipoabilit_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TalentTipiAbilitazioneDescr>(entity =>
            {
                entity.HasKey(e => new { e.TabildescrProcedura, e.TabildescrLingua })
                    .HasName("PK_tipi_abilitazione_descr");

                entity.ToTable("talent_tipi_abilitazione_descr");

                entity.Property(e => e.TabildescrProcedura)
                    .HasColumnName("tabildescr_procedura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TabildescrLingua)
                    .HasColumnName("tabildescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TabildescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tabildescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TabildescrInsTimestamp)
                    .HasColumnName("tabildescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoabilitModTimestamp)
                    .HasColumnName("tipoabilit_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TabildescrProceduraNavigation)
                    .WithMany(p => p.TalentTipiAbilitazioneDescr)
                    .HasForeignKey(d => d.TabildescrProcedura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_abilitazione_descr_tipi_abilitazione");
            });

            modelBuilder.Entity<TalentUserProfiles>(entity =>
            {
                entity.HasKey(e => new { e.TauseCliId, e.TauseUteId })
                    .HasName("PK__talent_u__EEA3A5C3A2F51431");

                entity.ToTable("talent_user_profiles");

                entity.Property(e => e.TauseCliId)
                    .HasColumnName("tause_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TauseUteId)
                    .HasColumnName("tause_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TauseDefaultLanguage)
                    .IsRequired()
                    .HasColumnName("tause_default_language")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ENG')");

                entity.Property(e => e.TauseInsTimestamp)
                    .HasColumnName("tause_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TauseInsUteId)
                    .HasColumnName("tause_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TauseLandingPage)
                    .HasColumnName("tause_landing_page")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TauseModTimestamp)
                    .HasColumnName("tause_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TauseModUteId)
                    .HasColumnName("tause_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TauseCli)
                    .WithMany(p => p.TalentUserProfiles)
                    .HasForeignKey(d => d.TauseCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tause_clienti");

                entity.HasOne(d => d.Tause)
                    .WithMany(p => p.TalentUserProfilesTause)
                    .HasForeignKey(d => new { d.TauseCliId, d.TauseInsUteId })
                    .HasConstraintName("FK_tause_ins");

                entity.HasOne(d => d.TauseNavigation)
                    .WithMany(p => p.TalentUserProfilesTauseNavigation)
                    .HasForeignKey(d => new { d.TauseCliId, d.TauseModUteId })
                    .HasConstraintName("FK_tause_mod");
            });

            modelBuilder.Entity<Termini>(entity =>
            {
                entity.HasKey(e => new { e.Termine, e.TerCliId, e.TerLingua })
                    .HasName("PK__termini__1D2D4FE021CC3D87");

                entity.ToTable("termini");

                entity.Property(e => e.Termine)
                    .HasColumnName("termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerCliId)
                    .HasColumnName("ter_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TerLingua)
                    .HasColumnName("ter_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'-')");

                entity.Property(e => e.TerDescrizione)
                    .HasColumnName("ter_descrizione")
                    .IsUnicode(false);

                entity.Property(e => e.TerFrequenza).HasColumnName("ter_frequenza");

                entity.Property(e => e.TerInsTimestamp)
                    .HasColumnName("ter_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TerInsUteId)
                    .IsRequired()
                    .HasColumnName("ter_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerLink)
                    .HasColumnName("ter_link")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TerModTimestamp)
                    .HasColumnName("ter_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TerModUteId)
                    .IsRequired()
                    .HasColumnName("ter_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TerNote)
                    .HasColumnName("ter_note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo1)
                    .HasColumnName("ter_sinonimo_1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo2)
                    .HasColumnName("ter_sinonimo_2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo3)
                    .HasColumnName("ter_sinonimo_3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo4)
                    .HasColumnName("ter_sinonimo_4")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo5)
                    .HasColumnName("ter_sinonimo_5")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo6)
                    .HasColumnName("ter_sinonimo_6")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo7)
                    .HasColumnName("ter_sinonimo_7")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerSinonimo8)
                    .HasColumnName("ter_sinonimo_8")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TerStato)
                    .HasColumnName("ter_stato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TerTipoTermine)
                    .IsRequired()
                    .HasColumnName("ter_tipo_termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TerCli)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.TerCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_termini_clienti");

                entity.HasOne(d => d.TerLinguaNavigation)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.TerLingua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_termini_talent_lingue");

                entity.HasOne(d => d.TerStatoNavigation)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => d.TerStato)
                    .HasConstraintName("FK_termini_stati_termine");

                entity.HasOne(d => d.Ter)
                    .WithMany(p => p.TerminiTer)
                    .HasForeignKey(d => new { d.TerCliId, d.TerInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_termini_utenti_ins");

                entity.HasOne(d => d.TerNavigation)
                    .WithMany(p => p.TerminiTerNavigation)
                    .HasForeignKey(d => new { d.TerCliId, d.TerModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_termini_utenti_mod");

                entity.HasOne(d => d.Ter1)
                    .WithMany(p => p.Termini)
                    .HasForeignKey(d => new { d.TerCliId, d.TerTipoTermine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_termini_tipi_termine");
            });

            modelBuilder.Entity<TestCompetenze>(entity =>
            {
                entity.HasKey(e => e.TscompId);

                entity.ToTable("test_competenze");

                entity.Property(e => e.TscompId).HasColumnName("tscomp_id");

                entity.Property(e => e.TscompCliId)
                    .HasColumnName("tscomp_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TscompCompetenza)
                    .IsRequired()
                    .HasColumnName("tscomp_competenza")
                    .HasMaxLength(262)
                    .IsUnicode(false);

                entity.Property(e => e.TscompInsTimestamp)
                    .HasColumnName("tscomp_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TscompInsUteId)
                    .IsRequired()
                    .HasColumnName("tscomp_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TscompModTimestamp)
                    .HasColumnName("tscomp_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TscompModUteId)
                    .IsRequired()
                    .HasColumnName("tscomp_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TscompTest)
                    .IsRequired()
                    .HasColumnName("tscomp_test")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TscompCli)
                    .WithMany(p => p.TestCompetenze)
                    .HasForeignKey(d => d.TscompCliId)
                    .HasConstraintName("FK_test_competenze_clienti");

                entity.HasOne(d => d.Tscomp)
                    .WithMany(p => p.TestCompetenze)
                    .HasForeignKey(d => new { d.TscompCliId, d.TscompTest })
                    .HasConstraintName("FK_test_competenze_test_valutazione");
            });

            modelBuilder.Entity<TestRisultati>(entity =>
            {
                entity.HasKey(e => e.TsrisId);

                entity.ToTable("test_risultati");

                entity.Property(e => e.TsrisId).HasColumnName("tsris_id");

                entity.Property(e => e.TsrisDataCompletamento)
                    .HasColumnName("tsris_data_completamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsrisInsTimestamp)
                    .HasColumnName("tsris_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TsrisMinutiTrascorsi).HasColumnName("tsris_minuti_trascorsi");

                entity.Property(e => e.TsrisModTimestamp)
                    .HasColumnName("tsris_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TsrisRisId).HasColumnName("tsris_ris_id");

                entity.Property(e => e.TsrisRisposteCorrette).HasColumnName("tsris_risposte_corrette");

                entity.Property(e => e.TsrisScore).HasColumnName("tsris_score");

                entity.Property(e => e.TsrisTestLink)
                    .HasColumnName("tsris_test_link")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TsrisTitoloTest)
                    .IsRequired()
                    .HasColumnName("tsris_titolo_test")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestValutazione>(entity =>
            {
                entity.HasKey(e => new { e.TsvalCliId, e.TsvalTitolo })
                    .HasName("PK__test_val__B56976F349EE5D5E");

                entity.ToTable("test_valutazione");

                entity.Property(e => e.TsvalCliId)
                    .HasColumnName("tsval_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TsvalTitolo)
                    .HasColumnName("tsval_titolo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TsvalAttivo)
                    .IsRequired()
                    .HasColumnName("tsval_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.TsvalDescrizione)
                    .IsRequired()
                    .HasColumnName("tsval_descrizione")
                    .HasColumnType("text");

                entity.Property(e => e.TsvalInsTimestamp)
                    .HasColumnName("tsval_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TsvalInsUteId)
                    .IsRequired()
                    .HasColumnName("tsval_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TsvalLink)
                    .IsRequired()
                    .HasColumnName("tsval_link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TsvalModTimestamp)
                    .HasColumnName("tsval_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TsvalModUteId)
                    .IsRequired()
                    .HasColumnName("tsval_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TsvalNote)
                    .HasColumnName("tsval_note")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TipiAllegato>(entity =>
            {
                entity.HasKey(e => new { e.TipallCliId, e.TipallId })
                    .HasName("PK__tipi_all__30BF8F4E57C2D03E");

                entity.ToTable("tipi_allegato");

                entity.HasIndex(e => new { e.TipallCliId, e.TipallGestione, e.TipallDescrizione })
                    .HasName("IX_tipi_allegato")
                    .IsUnique();

                entity.Property(e => e.TipallCliId)
                    .HasColumnName("tipall_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipallId).HasColumnName("tipall_id");

                entity.Property(e => e.TipallDescrizione)
                    .IsRequired()
                    .HasColumnName("tipall_descrizione")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipallGestione)
                    .IsRequired()
                    .HasColumnName("tipall_gestione")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipallInsTimestamp)
                    .HasColumnName("tipall_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.TipallInsUteId)
                    .IsRequired()
                    .HasColumnName("tipall_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipallModTimestamp)
                    .HasColumnName("tipall_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.TipallModUteId)
                    .IsRequired()
                    .HasColumnName("tipall_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipallOrdinamento).HasColumnName("tipall_ordinamento");

                entity.HasOne(d => d.TipallCli)
                    .WithMany(p => p.TipiAllegato)
                    .HasForeignKey(d => d.TipallCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_allegato_clienti");

                entity.HasOne(d => d.Tipall)
                    .WithMany(p => p.TipiAllegatoTipall)
                    .HasForeignKey(d => new { d.TipallCliId, d.TipallInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_allegato_utenti_ins");

                entity.HasOne(d => d.TipallNavigation)
                    .WithMany(p => p.TipiAllegatoTipallNavigation)
                    .HasForeignKey(d => new { d.TipallCliId, d.TipallModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_allegato_utenti_mod");
            });

            modelBuilder.Entity<TipiAppuntamento>(entity =>
            {
                entity.HasKey(e => new { e.TipoappCliId, e.TipoAppuntamento })
                    .HasName("PK__tipi_app__6EFD5C6E583273E6");

                entity.ToTable("tipi_appuntamento");

                entity.Property(e => e.TipoappCliId)
                    .HasColumnName("tipoapp_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoAppuntamento)
                    .HasColumnName("tipo_appuntamento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoappInsTimestamp)
                    .HasColumnName("tipoapp_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoappInsUteId)
                    .IsRequired()
                    .HasColumnName("tipoapp_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoappModTimestamp)
                    .HasColumnName("tipoapp_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoappModUteId)
                    .IsRequired()
                    .HasColumnName("tipoapp_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoappCli)
                    .WithMany(p => p.TipiAppuntamento)
                    .HasForeignKey(d => d.TipoappCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_appuntamento_clienti");

                entity.HasOne(d => d.Tipoapp)
                    .WithMany(p => p.TipiAppuntamentoTipoapp)
                    .HasForeignKey(d => new { d.TipoappCliId, d.TipoappInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_appuntamento_utenti_ins");

                entity.HasOne(d => d.TipoappNavigation)
                    .WithMany(p => p.TipiAppuntamentoTipoappNavigation)
                    .HasForeignKey(d => new { d.TipoappCliId, d.TipoappModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_appuntamento_utenti_mod");
            });

            modelBuilder.Entity<TipiAzienda>(entity =>
            {
                entity.HasKey(e => new { e.TipazCliId, e.TipoAzienda })
                    .HasName("PK__tipi_azi__3E7CC2F759E95075");

                entity.ToTable("tipi_azienda");

                entity.Property(e => e.TipazCliId)
                    .HasColumnName("tipaz_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoAzienda)
                    .HasColumnName("tipo_azienda")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipazInsTimestamp)
                    .HasColumnName("tipaz_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazInsUteId)
                    .IsRequired()
                    .HasColumnName("tipaz_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipazModTimestamp)
                    .HasColumnName("tipaz_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazModUteId)
                    .IsRequired()
                    .HasColumnName("tipaz_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipazCli)
                    .WithMany(p => p.TipiAzienda)
                    .HasForeignKey(d => d.TipazCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azienda_clienti");

                entity.HasOne(d => d.Tipaz)
                    .WithMany(p => p.TipiAziendaTipaz)
                    .HasForeignKey(d => new { d.TipazCliId, d.TipazInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azienda_utenti_ins");

                entity.HasOne(d => d.TipazNavigation)
                    .WithMany(p => p.TipiAziendaTipazNavigation)
                    .HasForeignKey(d => new { d.TipazCliId, d.TipazModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azienda_utenti_mod");
            });

            modelBuilder.Entity<TipiAzione>(entity =>
            {
                entity.HasKey(e => e.TipazioneTipoAzione)
                    .HasName("PK_tipi_azioni");

                entity.ToTable("tipi_azione");

                entity.Property(e => e.TipazioneTipoAzione)
                    .HasColumnName("tipazione_tipo_azione")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TipazioneInsTimestamp)
                    .HasColumnName("tipazione_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazioneModTimestamp)
                    .HasColumnName("tipazione_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazioneTipazionecatCodice)
                    .IsRequired()
                    .HasColumnName("tipazione_tipazionecat_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipazioneTipazionecatCodiceNavigation)
                    .WithMany(p => p.TipiAzione)
                    .HasForeignKey(d => d.TipazioneTipazionecatCodice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipazione_tipazionecat_codice");
            });

            modelBuilder.Entity<TipiAzioneCategoria>(entity =>
            {
                entity.HasKey(e => e.TipazionecatCodice);

                entity.ToTable("tipi_azione_categoria");

                entity.Property(e => e.TipazionecatCodice)
                    .HasColumnName("tipazionecat_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TipazionecatDescrizione)
                    .HasColumnName("tipazionecat_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TipazionecatInsTimestamp)
                    .HasColumnName("tipazionecat_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazionecatModTimestamp)
                    .HasColumnName("tipazionecat_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipiAzioneCategoriaDescr>(entity =>
            {
                entity.HasKey(e => new { e.TpazcatdescrTipazionecatCodice, e.TpazcatdescrLingua })
                    .HasName("PK_tpazcatdescr_tipazione_tipo_azione");

                entity.ToTable("tipi_azione_categoria_descr");

                entity.Property(e => e.TpazcatdescrTipazionecatCodice)
                    .HasColumnName("tpazcatdescr_tipazionecat_codice")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TpazcatdescrLingua)
                    .HasColumnName("tpazcatdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TpazcatdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tpazcatdescr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazcatdescrInsTimestamp)
                    .HasColumnName("tpazcatdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TpazcatdescrModTimestamp)
                    .HasColumnName("tpazcatdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TpazcatdescrTipazionecatCodiceNavigation)
                    .WithMany(p => p.TipiAzioneCategoriaDescr)
                    .HasForeignKey(d => d.TpazcatdescrTipazionecatCodice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azione_tipi_azione_categoria_descr");
            });

            modelBuilder.Entity<TipiAzioneDescr>(entity =>
            {
                entity.HasKey(e => new { e.TpazdescrTipazioneTipoAzione, e.TpazdescrLingua })
                    .HasName("PK_tpazdescr_tipazione_tipo_azione");

                entity.ToTable("tipi_azione_descr");

                entity.Property(e => e.TpazdescrTipazioneTipoAzione)
                    .HasColumnName("tpazdescr_tipazione_tipo_azione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrLingua)
                    .HasColumnName("tpazdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio01Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_01_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio01DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_01_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio02Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_02_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio02DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_02_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio03Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_03_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio03DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_03_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio04Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_04_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio04DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_04_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio05Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_05_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio05DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_05_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio06Descr)
                    .HasColumnName("tpazdescr_azione_dettaglio_06_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrAzioneDettaglio06DescrShort)
                    .HasColumnName("tpazdescr_azione_dettaglio_06_descr_short")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tpazdescr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TpazdescrInsTimestamp)
                    .HasColumnName("tpazdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TpazdescrModTimestamp)
                    .HasColumnName("tpazdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TpazdescrTipazioneTipoAzioneNavigation)
                    .WithMany(p => p.TipiAzioneDescr)
                    .HasForeignKey(d => d.TpazdescrTipazioneTipoAzione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azione_tipi_azione_descr");
            });

            modelBuilder.Entity<TipiAzioneRichiesta>(entity =>
            {
                entity.HasKey(e => new { e.TipazrichCliId, e.TipoAzioneRichiesta })
                    .HasName("PK__tipi_azi__C55ABBC272AB6E6B");

                entity.ToTable("tipi_azione_richiesta");

                entity.Property(e => e.TipazrichCliId)
                    .HasColumnName("tipazrich_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoAzioneRichiesta)
                    .HasColumnName("tipo_azione_richiesta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipazrichInsTimestamp)
                    .HasColumnName("tipazrich_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazrichInsUteId)
                    .IsRequired()
                    .HasColumnName("tipazrich_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipazrichModTimestamp)
                    .HasColumnName("tipazrich_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipazrichModUteId)
                    .IsRequired()
                    .HasColumnName("tipazrich_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipazrichCli)
                    .WithMany(p => p.TipiAzioneRichiesta)
                    .HasForeignKey(d => d.TipazrichCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azione_richiesta_clienti");

                entity.HasOne(d => d.Tipazrich)
                    .WithMany(p => p.TipiAzioneRichiestaTipazrich)
                    .HasForeignKey(d => new { d.TipazrichCliId, d.TipazrichInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azione_richiesta_utenti_ins");

                entity.HasOne(d => d.TipazrichNavigation)
                    .WithMany(p => p.TipiAzioneRichiestaTipazrichNavigation)
                    .HasForeignKey(d => new { d.TipazrichCliId, d.TipazrichModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_azione_richiesta_utenti_mod");
            });

            modelBuilder.Entity<TipiColloquio>(entity =>
            {
                entity.HasKey(e => new { e.TipcollCliId, e.TipcollCod })
                    .HasName("PK__tipi_col__C2B9EF8115597605");

                entity.ToTable("tipi_colloquio");

                entity.Property(e => e.TipcollCliId)
                    .HasColumnName("tipcoll_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipcollCod).HasColumnName("tipcoll_cod");

                entity.Property(e => e.TipcollDescrizione)
                    .IsRequired()
                    .HasColumnName("tipcoll_descrizione")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipcollCli)
                    .WithMany(p => p.TipiColloquio)
                    .HasForeignKey(d => d.TipcollCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_colloquio_clienti");
            });

            modelBuilder.Entity<TipiContatto>(entity =>
            {
                entity.HasKey(e => new { e.TipcontCliId, e.TipoContatto })
                    .HasName("PK__tipi_con__161860EF1634E23A");

                entity.ToTable("tipi_contatto");

                entity.Property(e => e.TipcontCliId)
                    .HasColumnName("tipcont_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoContatto)
                    .HasColumnName("tipo_contatto")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontInsTimestamp)
                    .HasColumnName("tipcont_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontInsUteId)
                    .IsRequired()
                    .HasColumnName("tipcont_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontModTimestamp)
                    .HasColumnName("tipcont_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontModUteId)
                    .IsRequired()
                    .HasColumnName("tipcont_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipcontCli)
                    .WithMany(p => p.TipiContatto)
                    .HasForeignKey(d => d.TipcontCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contatto_clienti");

                entity.HasOne(d => d.Tipcont)
                    .WithMany(p => p.TipiContattoTipcont)
                    .HasForeignKey(d => new { d.TipcontCliId, d.TipcontInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contatto_utenti_ins");

                entity.HasOne(d => d.TipcontNavigation)
                    .WithMany(p => p.TipiContattoTipcontNavigation)
                    .HasForeignKey(d => new { d.TipcontCliId, d.TipcontModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contatto_utenti_mod");
            });

            modelBuilder.Entity<TipiContratto>(entity =>
            {
                entity.HasKey(e => new { e.TipcontrCliId, e.TipoContratto })
                    .HasName("PK__tipi_con__68809BD83CD5B6A4");

                entity.ToTable("tipi_contratto");

                entity.Property(e => e.TipcontrCliId)
                    .HasColumnName("tipcontr_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoContratto)
                    .HasColumnName("tipo_contratto")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrDescrizione)
                    .IsRequired()
                    .HasColumnName("tipcontr_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrDescrizioneBreve)
                    .HasColumnName("tipcontr_descrizione_breve")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrInsTimestamp)
                    .HasColumnName("tipcontr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontrInsUteId)
                    .IsRequired()
                    .HasColumnName("tipcontr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrModTimestamp)
                    .HasColumnName("tipcontr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontrModUteId)
                    .IsRequired()
                    .HasColumnName("tipcontr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrNote)
                    .HasColumnName("tipcontr_note")
                    .HasColumnType("text");

                entity.Property(e => e.TipcontrUsoInterno)
                    .HasColumnName("tipcontr_uso_interno")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.HasOne(d => d.TipcontrCli)
                    .WithMany(p => p.TipiContratto)
                    .HasForeignKey(d => d.TipcontrCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_clienti");

                entity.HasOne(d => d.Tipcontr)
                    .WithMany(p => p.TipiContrattoTipcontr)
                    .HasForeignKey(d => new { d.TipcontrCliId, d.TipcontrInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_utenti_ins");

                entity.HasOne(d => d.TipcontrNavigation)
                    .WithMany(p => p.TipiContrattoTipcontrNavigation)
                    .HasForeignKey(d => new { d.TipcontrCliId, d.TipcontrModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_utenti_mod");
            });

            modelBuilder.Entity<TipiContrattoDettagli>(entity =>
            {
                entity.HasKey(e => new { e.TipcontrdettCliId, e.TipcontrdettId })
                    .HasName("PK__tipi_con__F8D9EF4DE394B946");

                entity.ToTable("tipi_contratto_dettagli");

                entity.Property(e => e.TipcontrdettCliId)
                    .HasColumnName("tipcontrdett_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipcontrdettId).HasColumnName("tipcontrdett_id");

                entity.Property(e => e.TipcontrdettCalcStip)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_calc_stip")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettDescrizione)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettInsTimestamp)
                    .HasColumnName("tipcontrdett_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontrdettInsUteId)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettModTimestamp)
                    .HasColumnName("tipcontrdett_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipcontrdettModUteId)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettNetto)
                    .HasColumnName("tipcontrdett_netto")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettNumerico)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_numerico")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettObbligatorio)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_obbligatorio")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettTipoContratto)
                    .IsRequired()
                    .HasColumnName("tipcontrdett_tipo_contratto")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipcontrdettUnmis)
                    .HasColumnName("tipcontrdett_unmis")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipcontrdettCli)
                    .WithMany(p => p.TipiContrattoDettagli)
                    .HasForeignKey(d => d.TipcontrdettCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_dettagli_clienti");

                entity.HasOne(d => d.Tipcontrdett)
                    .WithMany(p => p.TipiContrattoDettagliTipcontrdett)
                    .HasForeignKey(d => new { d.TipcontrdettCliId, d.TipcontrdettInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_dettagli_utenti_ins");

                entity.HasOne(d => d.TipcontrdettNavigation)
                    .WithMany(p => p.TipiContrattoDettagliTipcontrdettNavigation)
                    .HasForeignKey(d => new { d.TipcontrdettCliId, d.TipcontrdettModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_dettagli_utenti_mod");

                entity.HasOne(d => d.Tipcontrdett1)
                    .WithMany(p => p.TipiContrattoDettagli)
                    .HasForeignKey(d => new { d.TipcontrdettCliId, d.TipcontrdettTipoContratto })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_contratto_dettagli_tipi_contratto");

                entity.HasOne(d => d.Tipcontrdett2)
                    .WithMany(p => p.TipiContrattoDettagli)
                    .HasForeignKey(d => new { d.TipcontrdettCliId, d.TipcontrdettUnmis })
                    .HasConstraintName("FK_tipi_contratto_dettagli_unita_misura");
            });

            modelBuilder.Entity<TipiLingue>(entity =>
            {
                entity.HasKey(e => new { e.TiplingCliId, e.TiplingId })
                    .HasName("PK__tipi_lin__6E9931497E1546B2");

                entity.ToTable("tipi_lingue");

                entity.Property(e => e.TiplingCliId)
                    .HasColumnName("tipling_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TiplingId)
                    .HasColumnName("tipling_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TiplingAttivo)
                    .IsRequired()
                    .HasColumnName("tipling_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TiplingDescrizione)
                    .IsRequired()
                    .HasColumnName("tipling_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiplingInsTimestamp)
                    .HasColumnName("tipling_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiplingInsUteId)
                    .IsRequired()
                    .HasColumnName("tipling_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiplingModTimestamp)
                    .HasColumnName("tipling_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiplingModUteId)
                    .IsRequired()
                    .HasColumnName("tipling_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiplingOrdine).HasColumnName("tipling_ordine");

                entity.HasOne(d => d.TiplingCli)
                    .WithMany(p => p.TipiLingue)
                    .HasForeignKey(d => d.TiplingCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_lingue_clienti");

                entity.HasOne(d => d.Tipling)
                    .WithMany(p => p.TipiLingueTipling)
                    .HasForeignKey(d => new { d.TiplingCliId, d.TiplingInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_lingue_utenti_ins");

                entity.HasOne(d => d.TiplingNavigation)
                    .WithMany(p => p.TipiLingueTiplingNavigation)
                    .HasForeignKey(d => new { d.TiplingCliId, d.TiplingModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_lingue_utenti_mod");
            });

            modelBuilder.Entity<TipiLivelliLingue>(entity =>
            {
                entity.HasKey(e => new { e.TiplivlingCliId, e.TiplivlingId })
                    .HasName("PK__tipi_liv__4285B884C1E1990B");

                entity.ToTable("tipi_livelli_lingue");

                entity.Property(e => e.TiplivlingCliId)
                    .HasColumnName("tiplivling_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TiplivlingId)
                    .HasColumnName("tiplivling_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingAttivo)
                    .IsRequired()
                    .HasColumnName("tiplivling_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingDescrizione)
                    .IsRequired()
                    .HasColumnName("tiplivling_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingDescrizioneEstesa)
                    .IsRequired()
                    .HasColumnName("tiplivling_descrizione_estesa")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingInsTimestamp)
                    .HasColumnName("tiplivling_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiplivlingInsUteId)
                    .IsRequired()
                    .HasColumnName("tiplivling_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingModTimestamp)
                    .HasColumnName("tiplivling_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiplivlingModUteId)
                    .IsRequired()
                    .HasColumnName("tiplivling_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiplivlingOrdine).HasColumnName("tiplivling_ordine");

                entity.HasOne(d => d.TiplivlingCli)
                    .WithMany(p => p.TipiLivelliLingue)
                    .HasForeignKey(d => d.TiplivlingCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_livelli_lingue_clienti");

                entity.HasOne(d => d.Tiplivling)
                    .WithMany(p => p.TipiLivelliLingueTiplivling)
                    .HasForeignKey(d => new { d.TiplivlingCliId, d.TiplivlingInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_livelli_lingue_utenti_ins");

                entity.HasOne(d => d.TiplivlingNavigation)
                    .WithMany(p => p.TipiLivelliLingueTiplivlingNavigation)
                    .HasForeignKey(d => new { d.TiplivlingCliId, d.TiplivlingModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_livelli_lingue_utenti_mod");
            });

            modelBuilder.Entity<TipiTermine>(entity =>
            {
                entity.HasKey(e => new { e.TipterCliId, e.TipoTermine })
                    .HasName("PK__tipi_ter__8C5E258A10FE9993");

                entity.ToTable("tipi_termine");

                entity.Property(e => e.TipterCliId)
                    .HasColumnName("tipter_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipoTermine)
                    .HasColumnName("tipo_termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipterInsTimestamp)
                    .HasColumnName("tipter_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipterInsUteId)
                    .IsRequired()
                    .HasColumnName("tipter_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipterModTimestamp)
                    .HasColumnName("tipter_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipterModUteId)
                    .IsRequired()
                    .HasColumnName("tipter_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipterCli)
                    .WithMany(p => p.TipiTermine)
                    .HasForeignKey(d => d.TipterCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_termine_clienti");

                entity.HasOne(d => d.Tipter)
                    .WithMany(p => p.TipiTermineTipter)
                    .HasForeignKey(d => new { d.TipterCliId, d.TipterInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_termine_utenti_ins");

                entity.HasOne(d => d.TipterNavigation)
                    .WithMany(p => p.TipiTermineTipterNavigation)
                    .HasForeignKey(d => new { d.TipterCliId, d.TipterModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_termine_utenti_mod");
            });

            modelBuilder.Entity<TipiTermineDescr>(entity =>
            {
                entity.HasKey(e => new { e.TipterdescrTipoTermine, e.TipterdescrLingua, e.TipterdescrTipterCliId });

                entity.ToTable("tipi_termine_descr");

                entity.Property(e => e.TipterdescrTipoTermine)
                    .HasColumnName("tipterdescr_tipo_termine")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipterdescrLingua)
                    .HasColumnName("tipterdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TipterdescrTipterCliId)
                    .HasColumnName("tipterdescr_tipter_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TipterdescrDescrizione)
                    .IsRequired()
                    .HasColumnName("tipterdescr_descrizione")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TipterdescrInsTimestamp)
                    .HasColumnName("tipterdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipterdescrInsUteId)
                    .IsRequired()
                    .HasColumnName("tipterdescr_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipterdescrModTimestamp)
                    .HasColumnName("tipterdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipterdescrModUteId)
                    .IsRequired()
                    .HasColumnName("tipterdescr_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipterdescrTip)
                    .WithMany(p => p.TipiTermineDescr)
                    .HasForeignKey(d => new { d.TipterdescrTipterCliId, d.TipterdescrTipoTermine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_termine_descr_tipi_termine");
            });

            modelBuilder.Entity<TipiTitoliStudio>(entity =>
            {
                entity.HasKey(e => new { e.TiptitstudCliId, e.TiptitstudId })
                    .HasName("PK__tipi_tit__EBAB587FE94F3E72");

                entity.ToTable("tipi_titoli_studio");

                entity.Property(e => e.TiptitstudCliId)
                    .HasColumnName("tiptitstud_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.TiptitstudId)
                    .HasColumnName("tiptitstud_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TiptitstudAttivo)
                    .IsRequired()
                    .HasColumnName("tiptitstud_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TiptitstudDescrizione)
                    .IsRequired()
                    .HasColumnName("tiptitstud_descrizione")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiptitstudInsTimestamp)
                    .HasColumnName("tiptitstud_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiptitstudInsUteId)
                    .IsRequired()
                    .HasColumnName("tiptitstud_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiptitstudModTimestamp)
                    .HasColumnName("tiptitstud_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TiptitstudModUteId)
                    .IsRequired()
                    .HasColumnName("tiptitstud_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TiptitstudOrdine).HasColumnName("tiptitstud_ordine");

                entity.HasOne(d => d.TiptitstudCli)
                    .WithMany(p => p.TipiTitoliStudio)
                    .HasForeignKey(d => d.TiptitstudCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_titoli_studio_clienti");

                entity.HasOne(d => d.Tiptitstud)
                    .WithMany(p => p.TipiTitoliStudioTiptitstud)
                    .HasForeignKey(d => new { d.TiptitstudCliId, d.TiptitstudInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_titoli_studio_utenti_ins");

                entity.HasOne(d => d.TiptitstudNavigation)
                    .WithMany(p => p.TipiTitoliStudioTiptitstudNavigation)
                    .HasForeignKey(d => new { d.TiptitstudCliId, d.TiptitstudModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_titoli_studio_utenti_mod");
            });

            modelBuilder.Entity<TipiValoriApplicazione>(entity =>
            {
                entity.HasKey(e => new { e.TipappMenu, e.TipappOrdine })
                    .HasName("PK_tipi_valori_applicazione_1");

                entity.ToTable("tipi_valori_applicazione");

                entity.Property(e => e.TipappMenu)
                    .HasColumnName("tipapp_menu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipappOrdine)
                    .HasColumnName("tipapp_ordine")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TipappInsTimestamp)
                    .HasColumnName("tipapp_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipappModTimestamp)
                    .HasColumnName("tipapp_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipappValore)
                    .IsRequired()
                    .HasColumnName("tipapp_valore")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipiValoriApplicazioneDescr>(entity =>
            {
                entity.HasKey(e => new { e.TipappdescrMenu, e.TipappdescrOrdine, e.TipappdescrLingua });

                entity.ToTable("tipi_valori_applicazione_descr");

                entity.Property(e => e.TipappdescrMenu)
                    .HasColumnName("tipappdescr_menu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipappdescrOrdine)
                    .HasColumnName("tipappdescr_ordine")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TipappdescrLingua)
                    .HasColumnName("tipappdescr_lingua")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TipappdescrInsTimestamp)
                    .HasColumnName("tipappdescr_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipappdescrModTimestamp)
                    .HasColumnName("tipappdescr_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipappdescrValore)
                    .IsRequired()
                    .HasColumnName("tipappdescr_valore")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tipappdescr)
                    .WithMany(p => p.TipiValoriApplicazioneDescr)
                    .HasForeignKey(d => new { d.TipappdescrMenu, d.TipappdescrOrdine })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipi_valori_applicazione_descr_tipi_valori_applicazione");
            });

            modelBuilder.Entity<Titoli>(entity =>
            {
                entity.HasKey(e => new { e.TitoloCliId, e.Titolo })
                    .HasName("PK__titoli__F169F082B4FAA66D");

                entity.ToTable("titoli");

                entity.Property(e => e.TitoloCliId)
                    .HasColumnName("titolo_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Titolo)
                    .HasColumnName("titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TitoloInsTimestamp)
                    .HasColumnName("titolo_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TitoloInsUteId)
                    .IsRequired()
                    .HasColumnName("titolo_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TitoloModTimestamp)
                    .HasColumnName("titolo_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TitoloModUteId)
                    .IsRequired()
                    .HasColumnName("titolo_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TitoloSesso)
                    .IsRequired()
                    .HasColumnName("titolo_sesso")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.TitoloCli)
                    .WithMany(p => p.Titoli)
                    .HasForeignKey(d => d.TitoloCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_titoli_clienti");

                entity.HasOne(d => d.TitoloNavigation)
                    .WithMany(p => p.TitoliTitoloNavigation)
                    .HasForeignKey(d => new { d.TitoloCliId, d.TitoloInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_titoli_utenti_ins");

                entity.HasOne(d => d.Titolo1)
                    .WithMany(p => p.TitoliTitolo1)
                    .HasForeignKey(d => new { d.TitoloCliId, d.TitoloModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_titoli_utenti_mod");
            });

            modelBuilder.Entity<UnipiRisorseAnnotate>(entity =>
            {
                entity.HasKey(e => e.RisId)
                    .HasName("PK__unipi_ri__6E30C5371909BFCF");

                entity.ToTable("unipi_risorse_annotate");

                entity.Property(e => e.RisId)
                    .HasColumnName("ris_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.RisCvTestoAnnotato)
                    .HasColumnName("ris_cv_testo_annotato")
                    .IsUnicode(false);

                entity.Property(e => e.RisCvTestoDataAnnotazione)
                    .HasColumnName("ris_cv_testo_data_annotazione")
                    .HasColumnType("datetime");

                entity.Property(e => e.RisCvTestoLingua)
                    .IsRequired()
                    .HasColumnName("ris_cv_testo_lingua")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnitaMisura>(entity =>
            {
                entity.HasKey(e => new { e.UnmisCliId, e.Unmis })
                    .HasName("PK__unita_mi__6F3F3F5585FECDE2");

                entity.ToTable("unita_misura");

                entity.Property(e => e.UnmisCliId)
                    .HasColumnName("unmis_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.Unmis)
                    .HasColumnName("unmis")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnmisDescr)
                    .IsRequired()
                    .HasColumnName("unmis_descr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnmisInsTimestamp)
                    .HasColumnName("unmis_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnmisInsUteId)
                    .IsRequired()
                    .HasColumnName("unmis_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnmisModTimestamp)
                    .HasColumnName("unmis_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnmisModUteId)
                    .IsRequired()
                    .HasColumnName("unmis_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UnmisCli)
                    .WithMany(p => p.UnitaMisura)
                    .HasForeignKey(d => d.UnmisCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_unita_misura_clienti");
            });

            modelBuilder.Entity<Utenti>(entity =>
            {
                entity.HasKey(e => new { e.UteCliId, e.UteId })
                    .HasName("PK__utenti__BF6FCC2EF3BC62D4");

                entity.ToTable("utenti");

                entity.Property(e => e.UteCliId)
                    .HasColumnName("ute_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.UteId)
                    .HasColumnName("ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteAltriRiferimenti)
                    .HasColumnName("ute_altri_riferimenti")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UteAttivo)
                    .IsRequired()
                    .HasColumnName("ute_attivo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UteDeveloper)
                    .IsRequired()
                    .HasColumnName("ute_developer")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UteInsTimestamp)
                    .HasColumnName("ute_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UteInsUteId)
                    .HasColumnName("ute_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteLimiteMaxSms)
                    .HasColumnName("ute_limite_max_sms")
                    .HasDefaultValueSql("((50))");

                entity.Property(e => e.UteMail)
                    .HasColumnName("ute_mail")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UteModTimestamp)
                    .HasColumnName("ute_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UteModUteId)
                    .HasColumnName("ute_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteModalitaDebug)
                    .HasColumnName("ute_modalita_debug")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UteNome)
                    .IsRequired()
                    .HasColumnName("ute_nome")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UtePassword)
                    .IsRequired()
                    .HasColumnName("ute_password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UteProfilo)
                    .HasColumnName("ute_profilo")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UteRapportiniEmailInvio)
                    .HasColumnName("ute_rapportini_email_invio")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UteRapportiniUtentiGestiti)
                    .HasColumnName("ute_rapportini_utenti_gestiti")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.UteRicerchePortaliMaxNum).HasColumnName("ute_ricerche_portali_max_num");

                entity.Property(e => e.UteRisId).HasColumnName("ute_ris_id");

                entity.Property(e => e.UteRuolo)
                    .HasColumnName("ute_ruolo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UteSede)
                    .HasColumnName("ute_sede")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UteTelefono)
                    .HasColumnName("ute_telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteTipoClientEmail)
                    .HasColumnName("ute_tipo_client_email")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Outlook')");

                entity.Property(e => e.UteTitolo)
                    .HasColumnName("ute_titolo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UteUsaVpn)
                    .HasColumnName("ute_usa_vpn")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.HasOne(d => d.UteCli)
                    .WithMany(p => p.Utenti)
                    .HasForeignKey(d => d.UteCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_clienti");

                entity.HasOne(d => d.Ute)
                    .WithMany(p => p.InverseUte)
                    .HasForeignKey(d => new { d.UteCliId, d.UteInsUteId })
                    .HasConstraintName("FK_utenti_utenti");

                entity.HasOne(d => d.UteNavigation)
                    .WithMany(p => p.InverseUteNavigation)
                    .HasForeignKey(d => new { d.UteCliId, d.UteModUteId })
                    .HasConstraintName("FK_utenti_utenti1");

                entity.HasOne(d => d.Ute1)
                    .WithMany(p => p.Utenti)
                    .HasForeignKey(d => new { d.UteCliId, d.UteRuolo })
                    .HasConstraintName("FK_utenti_ruoli_utenti");
            });

            modelBuilder.Entity<UtentiAbilitazioni>(entity =>
            {
                entity.HasKey(e => new { e.UteabCliId, e.UteabId })
                    .HasName("PK__utenti_a__19D76288A6FAD043");

                entity.ToTable("utenti_abilitazioni");

                entity.HasIndex(e => new { e.UteabUteId, e.UteabProcedura, e.UteabAbilitato })
                    .HasName("utente_abilitazione_attivo");

                entity.Property(e => e.UteabCliId)
                    .HasColumnName("uteab_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.UteabId)
                    .HasColumnName("uteab_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UteabAbilitato)
                    .IsRequired()
                    .HasColumnName("uteab_abilitato")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UteabInsTimestamp)
                    .HasColumnName("uteab_ins_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UteabInsUteId)
                    .IsRequired()
                    .HasColumnName("uteab_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteabModTimestamp)
                    .HasColumnName("uteab_mod_timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UteabModUteId)
                    .IsRequired()
                    .HasColumnName("uteab_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteabProcedura)
                    .IsRequired()
                    .HasColumnName("uteab_procedura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UteabUteId)
                    .IsRequired()
                    .HasColumnName("uteab_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UteabCli)
                    .WithMany(p => p.UtentiAbilitazioni)
                    .HasForeignKey(d => d.UteabCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_abilitazioni_clienti");

                entity.HasOne(d => d.UteabProceduraNavigation)
                    .WithMany(p => p.UtentiAbilitazioni)
                    .HasForeignKey(d => d.UteabProcedura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_abilitazioni_tipi_abilitazione");

                entity.HasOne(d => d.Uteab)
                    .WithMany(p => p.UtentiAbilitazioniUteab)
                    .HasForeignKey(d => new { d.UteabCliId, d.UteabInsUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_abilitazioni_utenti_ins");

                entity.HasOne(d => d.UteabNavigation)
                    .WithMany(p => p.UtentiAbilitazioniUteabNavigation)
                    .HasForeignKey(d => new { d.UteabCliId, d.UteabModUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_abilitazioni_utenti_mod");

                entity.HasOne(d => d.Uteab1)
                    .WithMany(p => p.UtentiAbilitazioniUteab1)
                    .HasForeignKey(d => new { d.UteabCliId, d.UteabUteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_abilitazioni_utenti");
            });

            modelBuilder.Entity<UtentiImpostazioniGriglie>(entity =>
            {
                entity.HasKey(e => new { e.UteimpgridCliId, e.UteimpgridId })
                    .HasName("PK__utenti_i__3947FB3B869AA394");

                entity.ToTable("utenti_impostazioni_griglie");

                entity.HasIndex(e => e.UteimpgridNomeGriglia)
                    .HasName("nome_griglia");

                entity.HasIndex(e => e.UteimpgridUtente)
                    .HasName("utente");

                entity.Property(e => e.UteimpgridCliId)
                    .HasColumnName("uteimpgrid_cli_id")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'ITP999')");

                entity.Property(e => e.UteimpgridId)
                    .HasColumnName("uteimpgrid_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UteimpgridColonnaIndex).HasColumnName("uteimpgrid_colonna_index");

                entity.Property(e => e.UteimpgridColonnaLarghezza).HasColumnName("uteimpgrid_colonna_larghezza");

                entity.Property(e => e.UteimpgridColonnaVisible).HasColumnName("uteimpgrid_colonna_visible");

                entity.Property(e => e.UteimpgridInsTimestamp)
                    .HasColumnName("uteimpgrid_ins_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UteimpgridInsUteId)
                    .HasColumnName("uteimpgrid_ins_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteimpgridModTimestamp)
                    .HasColumnName("uteimpgrid_mod_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UteimpgridModUteId)
                    .HasColumnName("uteimpgrid_mod_ute_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UteimpgridNomeColonna)
                    .IsRequired()
                    .HasColumnName("uteimpgrid_nome_colonna")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.UteimpgridNomeGriglia)
                    .IsRequired()
                    .HasColumnName("uteimpgrid_nome_griglia")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UteimpgridUtente)
                    .IsRequired()
                    .HasColumnName("uteimpgrid_utente")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UteimpgridCli)
                    .WithMany(p => p.UtentiImpostazioniGriglie)
                    .HasForeignKey(d => d.UteimpgridCliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_impostazioni_griglie_clienti");

                entity.HasOne(d => d.Uteimpgr)
                    .WithMany(p => p.UtentiImpostazioniGriglieUteimpgr)
                    .HasForeignKey(d => new { d.UteimpgridCliId, d.UteimpgridInsUteId })
                    .HasConstraintName("FK_utenti_impostazioni_griglie_utenti_ins");

                entity.HasOne(d => d.UteimpgrNavigation)
                    .WithMany(p => p.UtentiImpostazioniGriglieUteimpgrNavigation)
                    .HasForeignKey(d => new { d.UteimpgridCliId, d.UteimpgridModUteId })
                    .HasConstraintName("FK_utenti_impostazioni_griglie_utenti_mod");

                entity.HasOne(d => d.Uteimpgr1)
                    .WithMany(p => p.UtentiImpostazioniGriglieUteimpgr1)
                    .HasForeignKey(d => new { d.UteimpgridCliId, d.UteimpgridUtente })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_utenti_impostazioni_griglie_utenti");
            });
        }
    }
}
