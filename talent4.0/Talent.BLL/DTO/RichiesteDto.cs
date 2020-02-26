using System;

namespace Talent.BLL.DTO
{
    public class RichiesteDto
    {
        public int? RichAzId;
        public string RichCompPrincipale ;
        public string RichId ;
        public string RichCitta ;
        public string AzRagSociale ;
        public DateTime RichData ;
        public int? RichTariffa ;
        public int RichContId ;
        public int RichPriorita ;
        public int? RichDurata ;
        public int RichNumPosizioni ;
        public string RichCompNecessarie ;
        public string RichCompSecondarie ;
        public string RichDescrizione ;
        public string RichAttiva ;
        public string RichStato ;
        public DateTime? RichProxAzData ;
        public string RichProxAzUteId ;
        public string RichProxAzDescr ;
        public string RichAssegnatoUteId ;
        public string RichAttivita ;
        public DateTime? RichDataIncarico ;
        public int? RichCont2Id ;
        public int? RichCont3Id ;
        public string RichCompPrincipaleSenMin ;
        public string RichUteIdComm ;
        public string RichProxAzTipoAzioneRichiesta ;
        public string RichCompPrincipaleSenMax ;
        public int? RichCompPrincipaleSemMaxOrd ;
        public int? RichCompPrincipaleSemMinOrd ;
        public string RichCodiceRichiestaCliente ;
        public string RichDescrizioneRichiestaCliente ;
        public string RichFilialeCodice ;
        public DateTime? RichDataInizio ;
        public DateTime? RichDataFine ;
        public string RichRicerchePortaliKey1 ;
        public string RichRicerchePortaliKey2 ;
        public string RichRicerchePortaliKey3 ;
        public string RichRicerchePortaliKey4 ;
        public string RichRicerchePortaliCitta ;
        public string RichRicerchePortaliCittaVicine ;
        public string RichRicerchePortaliAbilitato ;
        public string RichRicerchePortaliStato ;
        public DateTime? RichRicerchePortaliInizio ;
        public DateTime? RichRicerchePortaliFine ;
        public int? RichRicerchePortaliNumEsecuzioni ;
        public int? RichRicerchePortaliNumCvNuovi ;
        public int? RichRicerchePortaliNumCvAggiornati ;
        public int? RichRicerchePortaliNumCvTotali ;
        public string RichCliId ;
        public string RichRicercaContinua ;
        public string RichCategorieProtette ;


        public string RichTipo;
        public int? RichDurataNum ;
        public string RichDurataDescrizione ;
    }


    public class RichiesteDetailDto
    {
        public string RichId;
        public DateTime RichData ;
        public string RichCompPrincipale ;
        public int RichNumPosizioni ;
        public int? RichDurata ;
        public int? RichTariffa ;
        public int RichPriorita ;
        public string AzRagSociale ;
        public string RichCitta ;
        public string RichFilialeCodice ;
        public string RichAttiva ;
        public string RichStato ;
       
        public string RichAssegnatoUteId ;
        public string RichDescrizione ;
    }


    public class RichiesteListaRisorseDto
    {
        public int RichlistId;
        public string RichlistRichId ;
        public int RichlistRisId ;
        public string RichlistUltimaSelUteId ;
        public DateTime RichlistUltimaSelData ;
        public long RichlistAttinenzaTot ;
        public int RichlistNumRicPres ;
        public string RichlistStato ;
        public decimal? RichlistVoto ;
        public string RichlistVotoUteId ;
        public string RichlistNote ;
        public string RichlistNoteEstrazionePositive ;
        public string RichlistNoteEstrazioneNegative ;
        public DateTime? RichlistInsTimestamp ;
        public string RichlistInsUteId ;
        public DateTime? RichlistModTimestamp ;
        public string RichlistModUteId ;
        public int? RichlistPosizioneOrdinale ;
        public string RichlistMotivazioneScarto ;
        public string RichlistCliId ;
    }

}
