using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;

namespace Talent.BLL.DTO
{
    public class MasterFilterFieldsDto
    {

        public string TntfilFiltropagcampoCodice { get; set; }
        public string TntfilFiltropagcampoPagina { get; set; }
        public string TntfilFiltropagcampoCampoTabellaDb { get; set; }
        public string TntfilFiltropagcampoAttivo { get; set; }
        public string TntfilFiltropagcampoTipo { get; set; }
        public string TntfilFiltropagcampoListCodes { get; set; }
        public string TntfilFiltropagcampoListValues { get; set; }
        public string TntfilFiltropagcampoSoloFiltro { get; set; }
        public int TntfilFiltropagcampoFiltroOrdineVis { get; set; }
        public int? TntfilFiltropagcampoSortOrdineVis { get; set; }
        public string TntfilFiltropagcampoCodiceInterno { get; set; }
        public string TntfilFiltropagcampoFromList { get; set; }
        public string TntfilFiltropagcampoJoinWhereCondition { get; set; }


        public string TntfilFiltropagcampoCodiceDescr { get; set; }
        /// <summary>
        ///  
        /// 
        ///
        /// </summary>
        /// <param name="talentFiltriPagineCampi"></param>
        /// <returns></returns>
        public MasterFilterFieldsDto MapTalentFiltriPagineCampiToDto(TalentFiltriPagineCampi talentFiltriPagineCampi)
        {

            MasterFilterFieldsDto filterPageFieldsDto = new MasterFilterFieldsDto();

            filterPageFieldsDto.TntfilFiltropagcampoCodice = talentFiltriPagineCampi.TntfilFiltropagcampoCodice;
            filterPageFieldsDto.TntfilFiltropagcampoPagina = talentFiltriPagineCampi.TntfilFiltropagcampoPagina;
            filterPageFieldsDto.TntfilFiltropagcampoCampoTabellaDb = talentFiltriPagineCampi.TntfilFiltropagcampoCampoTabellaDb;
            filterPageFieldsDto.TntfilFiltropagcampoAttivo = talentFiltriPagineCampi.TntfilFiltropagcampoAttivo;
            filterPageFieldsDto.TntfilFiltropagcampoTipo = talentFiltriPagineCampi.TntfilFiltropagcampoTipo;
            filterPageFieldsDto.TntfilFiltropagcampoListCodes = talentFiltriPagineCampi.TntfilFiltropagcampoListCodes;
            filterPageFieldsDto.TntfilFiltropagcampoListValues = talentFiltriPagineCampi.TntfilFiltropagcampoListValues;
            filterPageFieldsDto.TntfilFiltropagcampoSoloFiltro = talentFiltriPagineCampi.TntfilFiltropagcampoSoloFiltro;
            filterPageFieldsDto.TntfilFiltropagcampoFiltroOrdineVis = talentFiltriPagineCampi.TntfilFiltropagcampoFiltroOrdineVis;
            filterPageFieldsDto.TntfilFiltropagcampoSortOrdineVis = talentFiltriPagineCampi.TntfilFiltropagcampoSortOrdineVis;
            filterPageFieldsDto.TntfilFiltropagcampoCodiceInterno = talentFiltriPagineCampi.TntfilFiltropagcampoCodiceInterno;

            filterPageFieldsDto.TntfilFiltropagcampoFromList = talentFiltriPagineCampi.TntfilFiltropagcampoFromList;
            filterPageFieldsDto.TntfilFiltropagcampoJoinWhereCondition = talentFiltriPagineCampi.TntfilFiltropagcampoJoinWhereCondition;

            filterPageFieldsDto.TntfilFiltropagcampoCodiceDescr = talentFiltriPagineCampi.TntfilFiltropagcampoPagina;
            
            return filterPageFieldsDto;
        }
    }
}
