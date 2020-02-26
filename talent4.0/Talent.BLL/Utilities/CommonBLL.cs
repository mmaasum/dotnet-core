using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Utilities
{
    public class CommonBLL
    {
        /// <summary>
        /// send mail function
        /// </summary>
        /// <param name="receiverEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        //public void SendMail(MailAddress receiverEmail, string subject, string body)
        //{
        //    var senderEmail = new MailAddress("relay@ict-euro.com", "Talent_Project");
        //    var password = "+ictRel18";

        //    ServicePointManager
        //          .ServerCertificateValidationCallback +=
        //          (sender, cert, chain, sslPolicyErrors) => true;

        //    using (MailMessage mail = new MailMessage(senderEmail, receiverEmail))
        //    {
        //        mail.Subject = subject;
        //        mail.Body = body;

        //        mail.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.ict-euro.com";

        //        smtp.EnableSsl = false;
        //        NetworkCredential networkCredential = new NetworkCredential(senderEmail.Address, password);
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = networkCredential;
        //        smtp.Port = 25;
        //        smtp.Send(mail);
        //    }
        //}
        /// <summary>
        /// generate random number
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomOtp()
        {
            Random r = new Random();
            var otp = r.Next(0, 1000000).ToString("D6");
            return otp;
        }
        /// <summary>
        /// return custom message
        /// </summary>
        /// <param name="hrResult"></param>
        /// <returns></returns>
        public string GenerateCustomErrorMessage(int hrResult)
        {
            string errMsg = "";

            switch (hrResult)
            {
                case -2146233087:
                    errMsg = "Duplicate Value! ";
                    break;
                case -2146233033:
                    errMsg = "Wrong Input/File Type! ";
                    break;
                case -2146232032:
                    errMsg = "Value Exceeds it's Max Range! ";
                    break;
                case -2147467261:
                    errMsg = "Object Not Found/ Ambiguous with another object";
                    break;
                case -2146233067:
                    errMsg = "Query Attempt with NULL value/Check Session";
                    break;
                case -2146232060:
                    errMsg = "DB_ERROR";
                    break;
                default:
                    errMsg = "Something Unusual occured !";
                    break;
            }
            return errMsg;
        }
        /// <summary>
        /// generate common message exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public string GenerateErrorMessage(Exception ex)
        {
            var message = "";
            try
            {
                if (ex.InnerException?.InnerException != null)
                    message = ex.InnerException.InnerException.Message;
            }
            catch
            {
                try
                {
                    if (ex.InnerException != null) message = ex.InnerException.Message;
                }
                catch
                {
                    message = ex.Message;
                }

            }

            return message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// token generate with claims and user name using jwt
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public string GenerateToken(Utenti utenti)
        {
            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsDto.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utenti.UteNome),
                new Claim(ClaimTypes.Role, utenti.UteRuolo),
                new Claim(ClaimTypes.NameIdentifier, utenti.UteId),
                new Claim(ClaimTypes.Sid, utenti.UteCliId)
            };
            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(14),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }


        public Object returnErrorObj(Exception ex)
        {
            var errObj = new
            {
                error = ex.StackTrace,
                error_type = ex.InnerException,
                message = ex.Message
            };
            return errObj;
        }

        public string ReturnEmptyStringForNull(string data)
        {
            if(data == null)
            {
                return "";
            }
            return data;
        }


    }
}
