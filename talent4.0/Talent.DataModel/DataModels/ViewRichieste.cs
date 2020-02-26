using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewRichieste
    {
        public string RichId { get; set; }
        public DateTime RichData { get; set; }
        public int RichContId { get; set; }
        public string RichCitta { get; set; }
        public int RichNumPosizioni { get; set; }
        public string RichCompPrincipale { get; set; }
        public string RichCompNecessarie { get; set; }
        public string RichCompSecondarie { get; set; }
        public string RichDescrizione { get; set; }
        public int RichPriorita { get; set; }
        public string RichAttiva { get; set; }
        public string RichStato { get; set; }
        public DateTime? RichProxAzData { get; set; }
        public string RichProxAzUteId { get; set; }
        public string RichProxAzDescr { get; set; }
        public string RichAssegnatoUteId { get; set; }
        public DateTime RichInsTimestamp { get; set; }
        public string RichInsUteId { get; set; }
        public DateTime RichModTimestamp { get; set; }
        public string RichModUteId { get; set; }
        public string RichAttivita { get; set; }
        public DateTime? RichDataIncarico { get; set; }
        public int? RichTariffa { get; set; }
        public int? RichCont2Id { get; set; }
        public int? RichCont3Id { get; set; }
        public string RichCompPrincipaleSenMin { get; set; }
        public string RichUteIdComm { get; set; }
        public int? RichAzId { get; set; }
        public string RichProxAzTipoAzioneRichiesta { get; set; }
        public string RichCompPrincipaleSenMax { get; set; }
        public int? RichCompPrincipaleSemMaxOrd { get; set; }
        public int? RichCompPrincipaleSemMinOrd { get; set; }
        public string RichCodiceRichiestaCliente { get; set; }
        public string RichDescrizioneRichiestaCliente { get; set; }
        public string RichFilialeCodice { get; set; }
        public DateTime? RichDataInizio { get; set; }
        public DateTime? RichDataFine { get; set; }
        public int? RichDurata { get; set; }
        public string RichRicerchePortaliKey1 { get; set; }
        public string RichRicerchePortaliKey2 { get; set; }
        public string RichRicerchePortaliKey3 { get; set; }
        public string RichRicerchePortaliKey4 { get; set; }
        public string RichRicerchePortaliCitta { get; set; }
        public string RichRicerchePortaliCittaVicine { get; set; }
        public string RichRicerchePortaliAbilitato { get; set; }
        public string RichRicerchePortaliStato { get; set; }
        public DateTime? RichRicerchePortaliInizio { get; set; }
        public DateTime? RichRicerchePortaliFine { get; set; }
        public int? RichRicerchePortaliNumEsecuzioni { get; set; }
        public int? RichRicerchePortaliNumCvNuovi { get; set; }
        public int? RichRicerchePortaliNumCvAggiornati { get; set; }
        public int? RichRicerchePortaliNumCvTotali { get; set; }
        public string RichCliId { get; set; }
        public string RichTipo { get; set; }
        public string RichRicercaContinua { get; set; }
        public int? RichDurataNum { get; set; }
        public string RichDurataDescrizione { get; set; }
        public string RichCategorieProtette { get; set; }

        public string AzRagSociale { get; set; }
    }
}
