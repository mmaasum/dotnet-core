using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Talent.BLL.DTO
{
    public class UserLoginDto
    {
        [Required,StringLength(20)]
        public string UteId { get; set; }
        [Required, StringLength(10)]
        public string UtePassword { get; set; }
        [Required, StringLength(30)]
        public string UteCliId { get; set; }
    }
    public class LoginUserResponseDto
    {
        public string UteAttivo { get; set; }
        public string UteRuolo { get; set; }
        public string UteId { get; set; }
        public string UteNome { get; set; }
        public string Token { get; set; }
        public string UteMail { get; set; }

        public List<string> userAuthList { get; set; }
    }
    public class UserLogoutDto
    {
        [Required, StringLength(20)]
        public string UteId { get; set; }
        [Required, StringLength(30)]
        public string UteCliId { get; set; }
    }
}
