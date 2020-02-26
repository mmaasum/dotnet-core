using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Persistence.Implementation;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAziendeRepository Aziende { get; private set; }
        public IClientiFinaleRepository AziendeClientiFinali { get; private set; }
        public IAzioniRepository Azioni { get; private set; }
        public ICittaRepository Citta { get; private set; }
        public IClientiRepository Clienti { get; private set; }
        public ICompetenzeRepository Competenze { get; private set; }
        public IContattiRepository Contatti { get; private set; }
        public IFilialiRepository Filiali { get; private set; }
        public IGenericQueryRepository GenericQuery { get; private set; }
        public IGridFiltriMasterRepository GridFiltriMaster { get; private set; }
        public IMasterFilterUtentiRepository MasterFilterUtenti { get; private set; }
        public IModelliEmailRepository ModelliEmail { get; private set; }
        public IOperazioniRepository LogOperazioni { get; private set; }
        public IRichiesteRepository Richieste { get; private set; }
        public IRichiesteListaRisorseRepository RichiesteListaRisorse { get; private set; }
        public IRisorseRepository Risorse { get; private set; }
        public IRuoloUtentiRepository RuoloUtenti { get; private set; }

        public IRuoliUtentiDescrRepository RuoliUtentiDescr { get; private set; }
        public IRuoliTipiAbilitazioneRepository RuoliTipiAbilitazione { get; private set; }
        public ISediAziendeRepository SediAziende { get; private set; }
        public ISoftSkillRepository SoftSkill { get; private set; }
        public ISoftskillsCompetenzeRepository SoftskillsCompetenze { get; private set; }
        public ISoftskillsProfiliRepository SoftskillsProfili { get; private set; }
        public ISoftskillsTestWsResultRepository SoftskillsTestWsResult { get; private set; }

        public IStatiTermineDescrRepository StatiTermineDescr { get; private set; }
        public ITalentFiltriPagineRepository TalentFiltriPagine { get; private set; }
        public ITalentFiltriPagineCampiRepository TalentFiltriPagineCampi { get; private set; }
        public ITalentFontDimensioniRepository TalentFontDimensioni { get; }
        public ITalentFontNomiRepository TalentFontNomi { get; private set; }
        public ITalentGriglieCampiRepository TalentGriglieCampi { get; private set; }
        public ITalentGriglieCampiUtentiRepository TalentGriglieCampiUtenti { get; private set; }
        public ITalentGriglieUtentiRepository TalentGriglieUtenti { get; private set; }
        public ITalentRichiesteListaRisorseRepository TalentRichiesteListaRisorse { get; private set; }
        public ITerminiRepository Termini { get; private set; }
        public ITestCompetenzeRepository TestCompetenze { get; private set; }
        public ITestRisultatiRepository TestRisultati { get; private set; }
        public ITestValutazioneRepository TestValutazione { get; private set; }
        public ITipiAziendaRepository TipiAzienda { get; private set; }
        public ITipiAzioneCategoriaDescrRepository TipiAzioneCategoriaDescr { get; private set; }
        public ITipiAzioneDescrRepository TipiAzioneDescr { get; private set; }
        public ITipiContattoRepository TipiContatto { get; private set; }
        public ITipiTermineRepository TipiTermine { get; private set; }
        public ITitoliRepository Titoli { get; private set; }
        public IUsersRepository Users { get; private set; }
       
        
        public IUtentiAbilitazioniRepository UtentiAbilitazioni { get; private set; }
        public IViewRisorseNoAllegatiRepository ViewRisorseNoAllegati { get; private set; }
       

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Aziende = new AziendeRepository(_context);
            AziendeClientiFinali = new ClientiFinaleRepository(_context);
            Azioni = new AzioniRepository(_context);
            Citta = new CittaRepository(_context);
            Clienti = new ClientiRepository(_context);
            Competenze = new CompetenzeRepository(_context);
            Contatti = new ContattiRepository(_context);
            Filiali = new FilialiRepository(_context);
            GenericQuery = new GenericQueryRepository(_context);
            GridFiltriMaster = new GridFiltriMasterRepository(_context);
            LogOperazioni = new OperazioniRepository(_context);
            MasterFilterUtenti = new MasterFilterUtentiRepository(_context);
            ModelliEmail = new ModelliEmailRepository(_context);
            Titoli = new TitoliRepository(_context);
            Users = new UsersRepository(_context);
            Richieste = new RichiesteRepository(_context);
            RichiesteListaRisorse = new RichiesteListaRisorseRepository(_context);
            Risorse = new RisorseRepository(_context);
            RuoloUtenti = new RuoloUtentiRepository(_context);
            RuoliUtentiDescr = new RuoliUtentiDescrRepository(_context);
            RuoliTipiAbilitazione = new RuoliTipiAbilitazioneRepository(_context);
            SediAziende = new SediAziendeRepository(_context);
            SoftskillsProfili = new SoftskillsProfiliRepository(_context);
            SoftskillsCompetenze = new SoftskillsCompetenzeRepository(_context);
            SoftskillsTestWsResult = new SoftskillsTestWsResultRepository(_context);
            StatiTermineDescr = new StatiTermineDescrRepository(_context);
            TalentFiltriPagine = new TalentFiltriPagineRepository(_context);
            TalentFiltriPagineCampi = new TalentFiltriPagineCampiRepository(_context);
            TalentFontDimensioni = new TalentFontDimensioniRepository(_context);
            TalentFontNomi = new TalentFontNomiRepository(_context);
            TalentGriglieCampi = new TalentGriglieCampiRepository(_context);
            TalentGriglieCampiUtenti = new TalentGriglieCampiUtentiRepository(_context);
            TalentGriglieUtenti = new TalentGriglieUtentiRepository(_context);
            TalentRichiesteListaRisorse = new TalentRichiesteListaRisorseRepository(_context);
            Termini = new TerminiRepository(_context);
            TestCompetenze = new TestCompetenzeRepository(_context);
            TestRisultati = new TestRisultatiRepository(_context);
            TestValutazione = new TestValutazioneRepository(_context);
            TipiAzienda = new TipiAziendaRepository(_context);
            TipiAzioneCategoriaDescr = new TipiAzioneCategoriaDescrRepository(_context);
            TipiAzioneDescr = new TipiAzioneDescrRepository(_context);
            TipiContatto = new TipiContattoRepository(_context);
            TipiTermine = new TipiTermineRepository(_context);
            UtentiAbilitazioni = new UtentiAbilitazioniRepository(_context);
            ViewRisorseNoAllegati = new ViewRisorseNoAllegatiRepository(_context);
            SoftSkill = new SoftSkillRepository(_context);
        }

        

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
