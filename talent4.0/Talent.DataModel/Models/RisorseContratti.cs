using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class RisorseContratti
    {
        public RisorseContratti()
        {
            RisorseContrattiRetribuzione = new HashSet<RisorseContrattiRetribuzione>();
        }

        public string RiscontrId { get; set; }
        public int RiscontrRisId { get; set; }
        public string RiscontrTipoContratto { get; set; }
        public DateTime RiscontrDataInizio { get; set; }
        public DateTime? RiscontrDataFine { get; set; }
        public DateTime? RiscontrDataFineInps { get; set; }
        public int RiscontrGgProva { get; set; }
        public string RiscontrGgProvaLavorativi { get; set; }
        public int RiscontrGgPreavviso { get; set; }
        public string RiscontrGgPreavvisoLavorativi { get; set; }
        public string RiscontrAttivo { get; set; }
        public string RiscontrDescrizione { get; set; }
        public decimal RiscontrCostoGgLavMedio { get; set; }
        public string RiscontrContrModNomeFile { get; set; }
        public byte[] RiscontrContrModAllegato { get; set; }
        public int? RiscontrContrModDimInKb { get; set; }
        public DateTime? RiscontrContrModDataInserimento { get; set; }
        public string RiscontrContrFirmNomeFile { get; set; }
        public byte[] RiscontrContrFirmAllegato { get; set; }
        public int? RiscontrContrFirmDimInKb { get; set; }
        public DateTime? RiscontrContrFirmDataInserimento { get; set; }
        public string RiscontrNote { get; set; }
        public DateTime? RiscontrInsTimestamp { get; set; }
        public string RiscontrInsUteId { get; set; }
        public DateTime? RiscontrModTimestamp { get; set; }
        public string RiscontrModUteId { get; set; }
        public string RiscontrRisorsaInterna { get; set; }
        public string RiscontrUteId { get; set; }
        public string RiscontrCliente { get; set; }
        public string RiscontrContatto { get; set; }
        public string RiscontrNoteCliente { get; set; }
        public string RiscontrClienteFinale { get; set; }
        public string RiscontrCitta { get; set; }
        public DateTime? RiscontrOffertaDataInizio { get; set; }
        public DateTime? RiscontrOffertaDataFine { get; set; }
        public int? RiscontrOffertaGgProva { get; set; }
        public int? RiscontrOffertaGgPreavviso { get; set; }
        public int? RiscontrOffertaTariffa { get; set; }
        public string RiscontrUteIdRisorsa { get; set; }
        public string RiscontrCliId { get; set; }

        public virtual Utenti Riscontr { get; set; }
        public virtual Risorse Riscontr1 { get; set; }
        public virtual TipiContratto Riscontr2 { get; set; }
        public virtual Clienti RiscontrCli { get; set; }
        public virtual Utenti RiscontrNavigation { get; set; }
        public virtual ICollection<RisorseContrattiRetribuzione> RisorseContrattiRetribuzione { get; set; }
    }
}
