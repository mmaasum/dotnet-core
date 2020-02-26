using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class CvTemplatePlaceholders
    {
        public int CvtemplId { get; set; }
        public string CvtemplTemplate { get; set; }
        public string CvtemplPlaceholder { get; set; }
        public string CvtemplPlaceholderTesto { get; set; }
        public string CvtemplCliId { get; set; }

        public virtual Clienti CvtemplCli { get; set; }
    }
}
