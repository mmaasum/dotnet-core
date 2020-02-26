using System.Collections.Generic;

namespace Talent.BLL.DTO
{
    public class ReturnSearchDataDto
    {
        public int TotalRecords;
        public IEnumerable<object> data;
        public IEnumerable<object> GroupData1;
        public IEnumerable<object> GroupData2;


        //public ReturnSearchDataDto(
        //    int records, IEnumerable<object> datas,
        //    IEnumerable<object> groupData1, IEnumerable<object> groupData2)
        //{
        //    TotalRecords = records;
        //    data = datas;

        //    GroupData1 = groupData1;
        //    GroupData2 = groupData2;
        //}

        public ReturnSearchDataDto()
        {
            //TotalRecords = returnSearchDataDto.TotalRecords;
            //data = returnSearchDataDto.data;

            //GroupData1 = returnSearchDataDto.GroupData1;
            //GroupData2 = returnSearchDataDto.GroupData2;
        }
    }
}
