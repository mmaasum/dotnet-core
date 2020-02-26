using System;
using System.Collections.Generic;

namespace Talent.DataModel.Models
{
    public partial class TipiAzioneDescr
    {
        public string TpazdescrTipazioneTipoAzione { get; set; }
        public string TpazdescrLingua { get; set; }
        public string TpazdescrDescrizione { get; set; }
        public string TpazdescrAzioneDettaglio01Descr { get; set; }
        public string TpazdescrAzioneDettaglio01DescrShort { get; set; }
        public string TpazdescrAzioneDettaglio02Descr { get; set; }
        public string TpazdescrAzioneDettaglio02DescrShort { get; set; }
        public string TpazdescrAzioneDettaglio03Descr { get; set; }
        public string TpazdescrAzioneDettaglio03DescrShort { get; set; }
        public string TpazdescrAzioneDettaglio04Descr { get; set; }
        public string TpazdescrAzioneDettaglio04DescrShort { get; set; }
        public string TpazdescrAzioneDettaglio05Descr { get; set; }
        public string TpazdescrAzioneDettaglio05DescrShort { get; set; }
        public string TpazdescrAzioneDettaglio06Descr { get; set; }
        public string TpazdescrAzioneDettaglio06DescrShort { get; set; }
        public DateTime TpazdescrInsTimestamp { get; set; }
        public DateTime TpazdescrModTimestamp { get; set; }

        public virtual TipiAzione TpazdescrTipazioneTipoAzioneNavigation { get; set; }
    }
}
