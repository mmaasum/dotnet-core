using System;

namespace Talent.BLL.DTO
{
    public class RisorseDto
    {
        public int RisId ;
        public string RisNome ;
        public string RisCognome ;
        public string RisCittaPossibili ;
        public DateTime? RisDataNascita ;
        public DateTime? RisDataColloquio ;
        public string RisCompetenza1 ;
        public string RisCompetenza2 ;
        public string RisCompetenza3 ;
        public string RisTitolo ;
        public string RisCellulare ;
        public string RisEmail ;
        public string RisCliId ;

        public string RisSesso ;
        public string RisDisponibile ;
        public string RisProtetto ;

        public int Age ;
    }

    public class RisInfoStatusDto
    {
        public int RisId;
        public string RisNome ;
        public string RisCognome ;
        public string Status ;
    }

    public class RisorseCvInfo
    {
        public string RisCvNomeFile;
        public byte[] RisCvAllegato ;
        public string RisCvTesto ;
        public long? RisCvDimInKb ;
        public DateTime? RisCvDataInserimento ;
    }
}
