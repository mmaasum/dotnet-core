using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Talent.BLL.Repositories;

namespace Talent.Web.Controllers.WebService
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class SubscriberController : Controller
    {
        private readonly ISubscriberManager _subscriberManager;

        public SubscriberController(ISubscriberManager subscriberManager)
        {
            _subscriberManager = subscriberManager;
        }


        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Index()
        {
            if(!await this.IsAuthorizedAsync())
            {
                return Unauthorized();
            }

            var tokenParts = this.AllTokenParts();
            var data = await _subscriberManager.GetAziendeByClientIdAsync(tokenParts[2]);
            return Ok(data);
        }


        [HttpPost]
        [Route("FileToText")]
        public async Task<IActionResult> FileToText(IFormFile file)
        {
            string staticToken = "YWxlc3Npby5jaWFyZGluaSBwYXNzd29yZDAxIElUUElUQQ==";
            string token = HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
           
            if (staticToken == token)
            {
                FileToText fileToText = new FileToText();
                fileToText.ProcessStartTime = DateTime.Now;
                try
                {
                    if (file == null)
                        //return BadRequest("No file selected");
                        fileToText.ProcessEndTime = DateTime.Now;
                    fileToText.StatusCode = "No File/Invalid File";
                    if (file.Length == 0)
                        //return BadRequest("Invalid file");
                        fileToText.ProcessEndTime = DateTime.Now;
                    fileToText.StatusCode = "No File/Invalid File";
                    if (file.Length > 5 * 1024 * 1024)
                        //return BadRequest("File size is too large. Max file size is 5 MB");
                        fileToText.ProcessEndTime = DateTime.Now;
                    fileToText.StatusCode = "No File/Invalid File";
                    fileToText.ConvertedText = await _subscriberManager.TextFromFileAsync(file);

                    char[] delimiters = new char[] { ' ', '\r', '\n' };
                    fileToText.NoOfWord = fileToText.ConvertedText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
                    fileToText.NoOfChar = fileToText.ConvertedText.Length;
                    fileToText.NoOfRows = countSpecChar(fileToText.ConvertedText, '\r');
                    fileToText.NoOfComma = countSpecChar(fileToText.ConvertedText, ',');
                    fileToText.InputFileName = file.FileName;
                    fileToText.StatusCode = "OK";

                    fileToText.ProcessEndTime = DateTime.Now;
                    return Ok(fileToText);
                }
                catch(Exception ex)
                {
                    fileToText.ProcessEndTime = DateTime.Now;
                    fileToText.StatusCode = "KO " + ex.InnerException.Message + " || " + ex.InnerException.StackTrace;
                    return Ok(fileToText);
                }
            }
            else
            {
                return Unauthorized();
            }
        }


        [NonAction]
        private int countSpecChar(string textData, char specChar)
        {
            int count = 0;
            foreach (char c in textData)
            {
                if (c == specChar) count++;
            }
            return count;
        } 

    }


    public class FileToText
    {
        public string StatusCode { get; set; }
        public DateTime ProcessStartTime { get; set; }
        public DateTime ProcessEndTime { get; set; }
        public string InputFileName { get; set; }
        public int NoOfWord { get; set; }
        public int NoOfChar { get; set; }
        public int NoOfRows { get; set; }
        public int NoOfComma { get; set; }
        public string ConvertedText { get; set; }

    }
}