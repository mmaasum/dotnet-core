using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class Siti
    {
        public string Sito { get; set; }
        public string SitoLink { get; set; }
        public string SitoUsername { get; set; }
        public string SitoPassword { get; set; }
        public string SitoNote { get; set; }
        public int SitoVoto { get; set; }
        public string SitoPrezzo { get; set; }
        public string SitoGratuito { get; set; }
        public string SitoAttivo { get; set; }
        public string SitoDaValutare { get; set; }
        public string SitoRicercaCv { get; set; }
        public DateTime SitoInsTimestamp { get; set; }
        public string SitoInsUteId { get; set; }
        public DateTime SitoModTimestamp { get; set; }
        public string SitoModUteId { get; set; }
        public string SitoSitiSocId { get; set; }
        public string SitoTemplate { get; set; }
        public string SitoTemplateTipo { get; set; }
        public DateTime? SitoDataInizioContratto { get; set; }
        public DateTime? SitoDataFineContratto { get; set; }
        public decimal? SitoPrezzo50Ann { get; set; }
        public decimal? SitoPrezzo100Ann { get; set; }
        public decimal? SitoPrezzo200Ann { get; set; }
        public decimal? SitoPrezzoConsDb { get; set; }
        public string SitoCliId { get; set; }

        public virtual Utenti Sito1 { get; set; }
        public virtual SitiSocieta Sito2 { get; set; }
        public virtual Clienti SitoCli { get; set; }
        public virtual Utenti SitoNavigation { get; set; }
    }
}
