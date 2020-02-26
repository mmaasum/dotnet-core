using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class ViewContatti
    {
        [Key]
        public int ContId { get; set; }
        public string ContTitolo { get; set; }
        public string ContNome { get; set; }
        public string ContCognome { get; set; }
        public int? ContAzId { get; set; }
        public string ContPosizione { get; set; }
        public string ContCitta { get; set; }
        public string ContEmail1 { get; set; }
        public string ContEmail2 { get; set; }
        public string ContTelefono1 { get; set; }
        public string ContTelefono2 { get; set; }
        public string ContRifUteId { get; set; }
        public string ContNote { get; set; }
        public DateTime? ContInsTimestamp { get; set; }
        public string ContInsUteId { get; set; }
        public DateTime? ContModTimestamp { get; set; }
        public string ContModUteId { get; set; }
        public string ContCvIniziali { get; set; }
        public string ContTipoContatto { get; set; }
        public string ContAttivo { get; set; }
        public string ContDescrizione { get; set; }
        public int? ContPriormin { get; set; }
        public int? ContPriormax { get; set; }
        public string ContOrari1Giorno { get; set; }
        public string ContOrari1Inizio { get; set; }
        public string ContOrari1Fine { get; set; }
        public string ContOrari2Giorno { get; set; }
        public string ContOrari2Inizio { get; set; }
        public string ContOrari2Fine { get; set; }
        public string ContOrari3Giorno { get; set; }
        public string ContOrari3Inizio { get; set; }
        public string ContOrari3Fine { get; set; }
        public string ContOrari4Giorno { get; set; }
        public string ContOrari4Inizio { get; set; }
        public string ContOrari4Fine { get; set; }
        public string ContOrari5Giorno { get; set; }
        public string ContOrari5Inizio { get; set; }
        public string ContOrari5Fine { get; set; }
        public string ContInvioCvNote { get; set; }
        public string ContCliId { get; set; }
        public int? ContAzsedeId { get; set; }

        public string AzRagSociale { get; set; }
        public string AzsedeDescr { get; set; }
        public string UteNome { get; set; }
    }
}
