using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.DataModels;

namespace Talent.BLL.DTO
{
    public class GenericSearchDto
    {
        public string TableName { get; set; }
        public string ClientColumn { get; set; }
        public string[] ConditionedColumns { get; set; }
        public string[] RetrievedColumns { get; set; }
        public string SearchedData { get; set; }
    }


    public class GenericSearchedDataDto
    {
        public string TableName { get; set; }
        public string RetrievedDataKey { get; set; }
        public string RetrievedDataName { get; set; }
        public string RetrievedDataClientId { get; set; }

        public GenericSearchedDataDto MapObjectToDto(Object iGenericSearchObj, string tableName)
        {
            GenericSearch genericSearchObj = (GenericSearch)iGenericSearchObj;
            return MapGenericSearchedDataToDto(genericSearchObj,tableName);
        }

        public GenericSearchedDataDto MapGenericSearchedDataToDto(GenericSearch genericSearchObj, string tableName)
        {
            GenericSearchedDataDto genericSearchedDataDto = new GenericSearchedDataDto();
            genericSearchedDataDto.TableName = tableName;
            genericSearchedDataDto.RetrievedDataKey = genericSearchObj.RetrievedDataKey;
            genericSearchedDataDto.RetrievedDataName = genericSearchObj.RetrievedDataName;
            genericSearchedDataDto.RetrievedDataClientId = genericSearchObj.RetrievedDataClientId;
         
            return genericSearchedDataDto;
        }



    }
}
