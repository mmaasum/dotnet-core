using System;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel
{
    public interface IUnitOfWork : IDisposable
    {
        IAziendeRepository Aziende { get; }
        IAzioniRepository Azioni { get; }
        ICittaRepository Citta { get; }
        IClientiFinaleRepository AziendeClientiFinali { get; }
        IClientiRepository Clienti { get; }
        ICompetenzeRepository Competenze { get; }
        IContattiRepository Contatti { get; }
        IFilialiRepository Filiali { get; }
        IGenericQueryRepository GenericQuery { get; }
        IGridFiltriMasterRepository GridFiltriMaster { get; }
        IMasterFilterUtentiRepository MasterFilterUtenti { get; }
        IModelliEmailRepository ModelliEmail { get; }
        IOperazioniRepository LogOperazioni { get; }
        IRichiesteRepository Richieste { get; }
        IRichiesteListaRisorseRepository RichiesteListaRisorse { get; }
        IRisorseRepository Risorse { get; }
        IRuoloUtentiRepository RuoloUtenti { get; }
        IRuoliUtentiDescrRepository RuoliUtentiDescr { get; }
        IRuoliTipiAbilitazioneRepository RuoliTipiAbilitazione { get; }
        ISediAziendeRepository SediAziende { get; }
        ISoftSkillRepository SoftSkill { get; }
        ISoftskillsCompetenzeRepository SoftskillsCompetenze { get; }
        ISoftskillsProfiliRepository SoftskillsProfili { get; }
        ISoftskillsTestWsResultRepository SoftskillsTestWsResult { get; }
        IStatiTermineDescrRepository StatiTermineDescr { get; }
        ITalentFiltriPagineRepository TalentFiltriPagine { get; }
        ITalentFiltriPagineCampiRepository TalentFiltriPagineCampi { get; }
        ITalentFontDimensioniRepository TalentFontDimensioni { get; }
        ITalentFontNomiRepository TalentFontNomi { get; }
        ITalentGriglieCampiRepository TalentGriglieCampi { get; }
        ITalentGriglieCampiUtentiRepository TalentGriglieCampiUtenti { get; }
        ITalentGriglieUtentiRepository TalentGriglieUtenti { get; }
        ITalentRichiesteListaRisorseRepository TalentRichiesteListaRisorse { get; }
        ITerminiRepository Termini { get; }
        ITestCompetenzeRepository TestCompetenze { get; }
        ITestRisultatiRepository TestRisultati { get; }
        ITestValutazioneRepository TestValutazione { get; }
        ITipiAziendaRepository TipiAzienda { get; }
        ITipiAzioneCategoriaDescrRepository TipiAzioneCategoriaDescr { get; }
        ITipiAzioneDescrRepository TipiAzioneDescr { get; }
        ITipiContattoRepository TipiContatto { get; }
        ITipiTermineRepository TipiTermine { get; }
        ITitoliRepository Titoli { get; }
        IUsersRepository Users { get; }
        IUtentiAbilitazioniRepository UtentiAbilitazioni { get; }
        IViewRisorseNoAllegatiRepository ViewRisorseNoAllegati { get; }

        

        Task<int> CompleteAsync();
    }
}
