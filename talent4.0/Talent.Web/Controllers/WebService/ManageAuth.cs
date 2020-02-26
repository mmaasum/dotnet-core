using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talent.Web.Controllers.WebService
{
    public static class ManageAuth
    {
        public static async Task<bool> IsAuthorizedAsync(this ControllerBase controller)
        {
            var token = ExtractToken(controller);
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            string base64Decoded = DecodeToken(token);
            var allTokenParts = base64Decoded.Split(' ');
            if (allTokenParts.Length != 3)
            {
                return false;
            }
            

            // need to implement validation logic

            return true;
        }

        public static string[] AllTokenParts(this ControllerBase controller)
        {
            var token = ExtractToken(controller);
            if (string.IsNullOrEmpty(token))
            {
                var st = new List<string>();
                return st.ToArray();
            }

            string base64Decoded = DecodeToken(token);
            var allTokenParts = base64Decoded.Split(' ');
            return allTokenParts;
        }

        public static string ExtractToken(ControllerBase controller)
        {
            return controller.HttpContext.Request.Headers["Authorization"];
        }

        public static string DecodeToken(string base64Encoded)
        {
            base64Encoded = base64Encoded.Substring(7);
            string base64Decoded;
            byte[] data = System.Convert.FromBase64String(base64Encoded);
            base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
            return base64Decoded;
        }

        public static string LoggedInUserId(this ControllerBase controller) {
            return controller.User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
        }
    }
}
