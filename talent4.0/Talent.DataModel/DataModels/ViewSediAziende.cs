using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.DataModel.DataModels
{
    public class ViewSediAziende
    {
        [Key]
        public int AzsedeId { get; set; }
        public int AzsedeAzId { get; set; }
        public string AzsedeAttiva { get; set; }
        public string AzsedeLegale { get; set; }
        public string AzsedeDescr { get; set; }
        public string AzsedeIndirizzo { get; set; }
        public string AzsedeCitta { get; set; }
        public string AzsedeCap { get; set; }
        public decimal AzsedeLocationLat { get; set; }
        public decimal AzsedeLocationLong { get; set; }
        public string AzsedeIndic { get; set; }
        public string AzsedeIndicColloquio { get; set; }
        public DateTime AzsedeInsTimestamp { get; set; }
        public string AzsedeInsUteId { get; set; }
        public DateTime AzsedeModTimestamp { get; set; }
        public string AzsedeModUteId { get; set; }
        public string AzsedeCliId { get; set; }
        public string AzRagSociale { get; set; }

        //public string AzRagSociale { get; set; }
    }
}
