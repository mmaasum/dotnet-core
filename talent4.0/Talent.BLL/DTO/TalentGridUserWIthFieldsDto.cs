using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.DataModels;

namespace Talent.BLL.DTO
{
    public class TalentGridUserWIthFieldsDto
    {
        public TalentGridUser TalentGridUser;
        public IEnumerable<TalentGridFieldsUser> TalentGridFieldsUserList;
        //public IEnumerable<ViewTalentGriglieCampiUtenti> ViewTalentGridFieldsUserList;

        public TalentGridUserWIthFieldsDto()
        {
            TalentGridFieldsUserList = new List<TalentGridFieldsUser>();
            //ViewTalentGridFieldsUserList = new List<ViewTalentGriglieCampiUtenti>();

        }

        public TalentGridUserWIthFieldsDto(TalentGridUser _talentGridUser, 
                                           IEnumerable<TalentGridFieldsUser> _talentGridFieldsUserList)
                                           //IEnumerable<ViewTalentGriglieCampiUtenti> _viewTalentGridFieldsUserList)
        {
            TalentGridUser = _talentGridUser;
            TalentGridFieldsUserList = _talentGridFieldsUserList;
            //ViewTalentGridFieldsUserList = _viewTalentGridFieldsUserList;
        }

        //public TalentGridUserWIthFieldsDto(TalentGridUser _talentGridUser, IEnumerable<ViewTalentGriglieCampiUtenti> _viewTalentGridFieldsUserList)
        //{
        //    TalentGridUser = _talentGridUser;
        //    ViewTalentGridFieldsUserList = _viewTalentGridFieldsUserList;
        //}
    }
}
