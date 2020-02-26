using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public class GenericSearch
    {
        [Key]
        public string RetrievedDataKey { get; set; }
        public string RetrievedDataName { get; set; }
        public string RetrievedDataClientId { get; set; }
    }
}
