using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Talent.BLL;
using Talent.BLL.Utilities;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel.DataModels;
using UAParser;

namespace Talent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private CommonBLL _cm = new CommonBLL();

        private readonly IAuthManager _authManager;
        private readonly IUsersManager _userManager;
        private readonly IClientManager _clientManager;
        private readonly IEmailManager _emailManager;
        private readonly IAzioniManager _azioniManager;
        private readonly IUtilityManager _utilityManager;

        public AuthController(IAuthManager authManager, IClientManager clientManager, IEmailManager emailManager, IAzioniManager azioniManager, IUtilityManager utilityManager, IUsersManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
            _clientManager = clientManager;
            _emailManager = emailManager;
            _azioniManager = azioniManager;
            _utilityManager = utilityManager;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///  this is test code
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        [NonAction]
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsDto.Secret));

            var jwt = new JwtSecurityToken(
                issuer: "Blinkingcaret",
                audience: "Everyone",
                claims: claims, //the user's claims, for example new Claim[] { new Claim(ClaimTypes.Name, "The username"), //... 
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt); //the method is called WriteToken but returns a string
        }

        [NonAction]
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        [NonAction]
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

         
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh([FromBody]TokenObj tokenObj)
        {

            string token = tokenObj.JwtToken;
            
            var principal = GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            //var savedRefreshToken = GetRefreshToken(username); //retrieve the refresh token from a data store
            //if (savedRefreshToken != refreshToken)
            //  throw new SecurityTokenException("Invalid refresh token");

            var newJwtToken = GenerateToken(principal.Claims);
            var newRefreshToken = GenerateRefreshToken();
            //DeleteRefreshToken(username, refreshToken);
            //SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }






        ////////////////////////////////////////////////////////////////////////////////////////////////////////




























        /// <summary>
        ///     To get all clients list for different client login purpose
        /// </summary>
        /// <purpose>
        ///    As this application will be used for sevelar clients, so it is necessary
        ///    to define for which company the user is getting logged.
        /// </purpose>
        /// <returns>List object of client</returns>
        [HttpGet]
        [Route("loginclients")]
        public async Task<IActionResult> LoginClients()
        {
            try
            {
                var log = await _clientManager.GetAllClientDataAsync();
                return Ok(log);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "Get Client list");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To manage user login according to the provided credential
        /// </summary>
        /// <purpose>
        ///     To get the access to the system if the credential is valid or prevent 
        ///     for any kind of unauthorized/forbidden access.
        /// </purpose>
        /// <param name="user">Dto object of user having provided access credential.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            try
            {
                var tipo = "login_ok";
                // Check user valid or not
                var checkuser = await _authManager.ValidateUserAsync(user);
                HttpContext httpContext = this.HttpContext;
                var ip = httpContext.Connection.RemoteIpAddress.ToString();
               
                // Getting the browser name
                var userAgent = httpContext.Request.Headers["User-Agent"];
                string uaString = Convert.ToString(userAgent[0]);
                var uaParser = Parser.GetDefault();
                ClientInfo c = uaParser.Parse(uaString);

                var description = $"IP -> {ip} . Client -> {c.UA} . OS -> {c.OS}";

                var authHeader = Request.Headers["Authorization"].ToString();
                AzioniDto azioniDto = CreateAzioniObj(description, tipo, user.UteId, user.UteCliId, user.UtePassword);
               

                if (checkuser.UteId == null)
                {
                    tipo = "login_ko";
                    azioniDto = CreateAzioniObj(description, tipo, user.UteId, user.UteCliId, user.UtePassword);

                    await _azioniManager.AzioniInsert(azioniDto);

                    var result = new
                    {
                        error = "Login failed",
                        error_type = "usrmsg_err",
                        message = "L1008_wrongcredentials"
                    };
                    return BadRequest(result);
                }
                // Find out five times failed login attempts
                var userHas5FailedAttempts = await _authManager.Has5ConsecutiveFailedAttemptsWithin5Miniutes(checkuser.UteId);
                if (userHas5FailedAttempts)
                {
                    
                    await _authManager.LockUser(user.UteId);

                    tipo = "login_ko";
                    azioniDto = CreateAzioniObj(description, tipo, user.UteId, user.UteCliId, user.UtePassword);
                    await _azioniManager.AzioniInsert(azioniDto);
                    var result = new
                    {
                        error = "Login failed",
                        error_type = "usrmsg_err",
                        message = "L1002_userLocked"
                    };
                    return BadRequest(result);
                }
                // Checking whether the user status is active or not 
                if (checkuser.UteAttivo == "N")
                {
                    tipo = "login_ko";
                    azioniDto = CreateAzioniObj(description, tipo, user.UteId, user.UteCliId, user.UtePassword);
                    await _azioniManager.AzioniInsert(azioniDto);
                    var result = new
                    {
                        error = "Login failed",
                        error_type = "usrmsg_err",
                        message = "L1001_userInactive"
                    };
                    return BadRequest(result);
                }

                await _azioniManager.AzioniInsert(azioniDto);
                HttpContext.Session.SetObjectAsJson("userDto", checkuser);

                var userProfile = await _userManager.FindUserProfileData(user.UteId, user.UteCliId);

                return Ok(new {Token=checkuser.Token , userAuthList = checkuser.userAuthList, Email = checkuser.UteMail, UserProfile = userProfile });
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj = await _utilityManager.ReturnErrorObj(x, User, "login_ko");
                // Returning the error object.
                return BadRequest(errorObj);
            }
        }


        /// <summary>
        ///     To have the access to the client to change the password in case of forgotten.
        /// </summary>
        /// <param name="email">the mail address of the user.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("forgetPassword")]
        public string PostForgetPassword([FromBody] string email)
        {
            try
            {
                // Mail sending to client with a invitation link and newly generated OTP.
                var invitationLink = AppSettingsDto.BaseDomainName + "/Email/ResetPassword?email=" + email;
                var mailBody =
                    $"<br />Dear User,<br /><br />This is your OTP: <b>{_cm.GenerateRandomOtp()}</b><br />Click here to reset new password: {invitationLink}\n";
                //_emailManager.ReceiverEmail.Add(email);
                _emailManager.To.Add(email);
                _emailManager.Subject = "Talent_OTP";
                _emailManager.Body = mailBody.ToString();
                _emailManager.Send();
                return "Success!";
            }
            catch (Exception ex)
            {
                string error = _cm.GenerateErrorMessage(ex) + "\n" + _cm.GenerateCustomErrorMessage(ex.HResult);
                return error;
            }
        }

        /// <summary>
        ///      Creating the Object of AzioniDto Class.
        /// </summary>
        /// <param name="desc">Description of azioni</param>
        /// <param name="tipo">type of azioni</param>
        /// <param name="uteId">Ute Id of logged in user.</param>
        /// <param name="cliId">Client Id of logged in User's client</param>
        /// <param name="utePass">Password of logged in user.</param>
        /// <returns></returns>
        [NonAction]
        public AzioniDto CreateAzioniObj(string desc, string tipo, string uteId, string cliId, string utePass)
        {
            if (tipo == "login_ko")
            {
                uteId = "system";
            }
            AzioniDto azioniDto = new AzioniDto();
            azioniDto.AzioneDescrizione = desc;
            azioniDto.AzioneTipo = tipo;
            azioniDto.AzioneDettaglio01 = uteId;
            azioniDto.AzioneDettaglio02 = utePass;
            azioniDto.AzioneDettaglio03 = cliId;
            azioniDto.AzioneUteId = uteId;
            azioniDto.AzioneInsUteId = uteId;
            azioniDto.AzioneModUteId = uteId;
            azioniDto.AzioneCliId = cliId;
            return azioniDto;
        }


    }

    public class TokenObj
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
