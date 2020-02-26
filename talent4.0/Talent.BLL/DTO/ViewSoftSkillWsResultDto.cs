namespace Talent.BLL.DTO
{
    // Custom Dto class to have the retrieved data of join table.
    public class ViewSoftSkillWsResultDto
    {
        // Fields of [softskills_test_ws_result] table
        public decimal SsktestresPlayField1;
        public decimal SsktestresPlayField2;
        public decimal SsktestresPlayField3;
        public decimal SsktestresPlayField4;
        // Fields of [softskills_profili] table
        public string SskprofProfilo;
        public int SskprofIdPlay;
        public string SskprofDescrizione;
    }
}
