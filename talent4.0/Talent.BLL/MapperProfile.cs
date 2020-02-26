using AutoMapper;
using Talent.BLL.DTO;
using Talent.Common.ExtensionMethods;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            // Map Domain Model to DTO

            CreateMap<AziendeClientiFinali, AziendeClientiFinaleDto>();
            CreateMap<AziendeClientiFinali, AziendeClientiFinaleOptimizedDto>();
            CreateMap<ViewAziendeClientiFinali, AziendeClientiFinaleDto>();
            CreateMap<Azioni, AzioniDto>();
            CreateMap<Clienti, ClientDto>();
            CreateMap<Contatti, ContattiDto>();
            CreateMap<Contatti, ContattiOptimizedDto>();
            CreateMap<Competenze, CompetenzaDto>();
            CreateMap<Citta, CittaDto>();
            CreateMap<TalentUserProfiles, TalentUserProfileDto>();
            CreateMap<Utenti, UtentiOptimizedDto>();
            CreateMap<Utenti, UtentiDto>();
            CreateMap<RuoliUtenti, RuoliUtentiDto>();
            CreateMap<LogOperazioni, LogOperazioniDto>();
            CreateMap<ModelliEmail, ModelliEmailDto>();
            CreateMap<SediAziende, SediAziendeDto>();
            CreateMap<ViewSediAziende, SediAziendeDto>();
            CreateMap<Richieste, RichiesteDto>();
            CreateMap<Richieste, RichiesteDetailDto>()
                .ForMember(dest => dest.AzRagSociale,
                    opt => opt.MapFrom(a => string.Empty));
            CreateMap<RichiesteListaRisorse, RichiesteListaRisorseDto>();
            CreateMap<Risorse, RisorseDto>();
            CreateMap<Risorse, RisorseCvInfo>();
            CreateMap<SPAuthRole, SPAuthRoleDto>()
                .ForMember(dest => dest.TipoabilitProcedura,
                    opt => opt.MapFrom(src => src.tipoabilit_procedura))
                .ForMember(dest => dest.UteabUteId,
                    opt => opt.MapFrom(src => src.ruoltipab_ruolo));
            CreateMap<SoftskillsCompetenzeDescr, SoftskillsCompetenzeDescrDto>();
            CreateMap<SPSchedulazioneGetSchedulazioni, SPSchedulazioneGetSchedulazioniDto>();
            CreateMap<TalentFontDimensioni, TalentFontSizeDto>();
            CreateMap<TalentFontNomi, TalentFontNameDto>()
                .ForMember(dest => dest.FontName,
                    opt => opt.MapFrom(src => src.TntfontNomeFont));
            CreateMap<Termini, TerminiDto>();
            CreateMap<TestCompetenze, TestCompetenzeDto>();
            CreateMap<TestRisultati, TestRisultatiDto>();
            CreateMap<TestValutazione, TestValutazioneDto>();
            CreateMap<TipiAzienda, TipiAziendaDto>();
            CreateMap<TipiContatto, TipiContattoDto>();
            CreateMap<TipiTermine, TipiTermineDto>();
            CreateMap<UtentiAbilitazioni, UtentiAbilitazioniDto>();
            CreateMap<ViewSoftSkillWsResult, ViewSoftSkillWsResultDto>();

            




            // Map DTO to Domain Model

            CreateMap<AziendeClientiFinaleDto, AziendeClientiFinali>();
            CreateMap<AzioniDto, Azioni>();
            CreateMap<CompetenzaDto, Competenze>();
            CreateMap<CittaDto, Citta>();
            CreateMap<ContattiDto, Contatti>();
            CreateMap<UtentiDto, Utenti>();
            CreateMap<RichiesteDto, Richieste>();
            CreateMap<RichiesteListaRisorseDto, RichiesteListaRisorse>()
                .ForMember(dest => dest.RichlistUltimaSelUteId,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistUltimaSelData,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistInsTimestamp,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistInsUteId,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistModTimestamp,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistModUteId,
                    opt => opt.Ignore())
                .ForMember(dest => dest.RichlistCliId,
                    opt => opt.Ignore());


            CreateMap<RisorseDto, Risorse>();
            CreateMap<RuoliUtentiDto, RuoliUtenti>();
            CreateMap<SediAziendeDto, SediAziende>();
            CreateMap<TerminiDto, Termini>();
            CreateMap<TipiAziendaDto, TipiAzienda>();
            CreateMap<TipiTermineDto, TipiTermine>();
            CreateMap<LogOperazioniDto, LogOperazioni>();
            CreateMap<UtentiAbilitazioniDto, UtentiAbilitazioni>();
            CreateMap<RuoliTipiAbilitazioneDto, RuoliTipiAbilitazione>();


            CreateMap<RichiesteListaRisorseDto, TalentRichiesteListaRisorse>()
                .ForMember(dest => dest.TrichlistRichId,
                    opt => opt.MapFrom(src => src.RichlistRichId))
                .ForMember(dest => dest.TrichlistRisId,
                    opt => opt.MapFrom(src => src.RichlistRisId))
                .ForMember(dest => dest.TrichlistStato,
                    opt => opt.MapFrom(src => src.RichlistStato))
                .ForMember(dest => dest.TrichlistVoto,
                    opt => opt.MapFrom(src => src.RichlistVoto));

            CreateMap<ViewRisorseNoAllegati, RisorseDto>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(src => src.RisDataNascita.ToAge()));

            CreateMap<MatchingRisorse, RisInfoStatusDto>()
                .ForMember(dest => dest.RisNome,
                    opt => opt.MapFrom(src => src.Candidates))
                .ForMember(dest => dest.RisCognome,
                    opt => opt.MapFrom(src => src.Skills));









            // Map Models to KeyValuePairDto object
            CreateMap<TipiAzioneCategoriaDescr, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.TpazcatdescrTipazionecatCodice))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.TpazcatdescrDescrizione));

            CreateMap<TipiAzioneDescr, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.TpazdescrTipazioneTipoAzione))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.TpazdescrDescrizione));
            CreateMap<StatiTermineDescr, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.SterdescrSterStato))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.SterdescrDescrizione));
            CreateMap<TipiTermineDescr, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.TipterdescrTipoTermine))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.TipterdescrDescrizione));

            CreateMap<RuoliUtenti, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.Ruolo))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.Ruolo));
            CreateMap<RuoliUtentiDescr, KeyValuePairDto>()
                .ForMember(dest => dest.Key,
                    opt => opt.MapFrom(src => src.RuolodescrDescrizione))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.RuolodescrDescrizione));

        }
    }
}
