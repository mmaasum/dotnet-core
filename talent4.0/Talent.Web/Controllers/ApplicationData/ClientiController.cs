using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Talent.BLL;
using System.Linq;
using Talent.BLL.DTO;
using Talent.DataModel.Models;
using Talent.BLL.Repositories;
using Talent.DataModel.DataModels;

namespace Talent.Web.Controllers.ApplicationData
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientiController : ControllerBase
    {

        private readonly IClientManager _clientManager;
        private readonly IGlobalGridManager _globalGridManager;
        private readonly IUtilityManager _utilityManager;

        public ClientiController(IGlobalGridManager globalGridManager, IClientManager clientManager, IAzioniManager azioniManager, IUtilityManager utilityManager)
        {
            _globalGridManager = globalGridManager;
            _clientManager = clientManager;
            _utilityManager = utilityManager;
        }

        [HttpPost]
        [Route("GetTerminiExcel/{fileName}")]
        public async Task<IActionResult> GetTerminiExcel([FromBody]IEnumerable<ViewTermini> dataList, string fileName)
        {

            var iDataList = dataList.ToList();
            var uploads = Path.Combine("../Talent.Web/", "TempUpload");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            string sWebRootFolder = "../Talent.Web/TempUpload";

            fileName = fileName + ".xlsx";
            string sFileName = @fileName;
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Termini");

                var rowIndex = 0;
                IRow row = excelSheet.CreateRow(0);
                rowIndex++;

                var cellIndex = 0;
                row.CreateCell(cellIndex).SetCellValue("Termine");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo1");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo2");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo3");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo4");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo5");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo6");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo7");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Sinonimo8");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Description");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Link");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Note");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Language");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Category");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("State");
                cellIndex++;

                row.CreateCell(cellIndex).SetCellValue("Ins Time");
                cellIndex++;

                foreach (var iData in iDataList)
                {
                    try
                    {
                        ViewTermini ViewTermini = (ViewTermini)iData;
                        row = excelSheet.CreateRow(rowIndex);
                        rowIndex++;

                        cellIndex = 0;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.Termine);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo1);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo2);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo3);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo4);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo5);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo6);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo7);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerSinonimo8);
                        cellIndex++;



                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerDescrizione);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerLink);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerNote);
                        cellIndex++;

                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerLingua);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerminiTipoDescr);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(ViewTermini.TerminiStatoDescr);
                        cellIndex++;


                        row.CreateCell(cellIndex).SetCellValue(Convert.ToDateTime(ViewTermini.TerInsUteId).ToString("dd/MM/yyyy hh:mm:ss"));
                        cellIndex++;

                    }
                    catch (Exception ex)
                    { }
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }





        [HttpPost]
        [Route("GetLogOperazioniExcel/{fileName}")]
        public async Task<IActionResult> GetLogOperazioniExcel([FromBody]IEnumerable<LogOperazioni> dataList, string fileName)
        {

            var iDataList = dataList.ToList();
            var uploads = Path.Combine("../Talent.Web/", "TempUpload");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            string sWebRootFolder = "../Talent.Web/TempUpload";

            fileName = fileName + ".xlsx";
            string sFileName = @fileName;
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Log_Operazioni");

                var rowIndex = 0;
                IRow row = excelSheet.CreateRow(0);
                rowIndex++;

                var cellIndex = 0;
                row.CreateCell(cellIndex).SetCellValue("Id");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Date hour");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("User");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Description");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Details");
                cellIndex++;
                foreach (var iData in iDataList)
                {
                    try
                    {
                        LogOperazioni logOperazioniDto = (LogOperazioni)iData;
                        row = excelSheet.CreateRow(rowIndex);
                        rowIndex++;

                        cellIndex = 0;
                        row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogId);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(Convert.ToDateTime(logOperazioniDto.LogTimestamp).ToString("dd/MM/yyyy hh:mm:ss"));
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogUteId);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogDescr);
                        cellIndex++;
                        row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogDettaglio);
                        cellIndex++;
                    }
                    catch (Exception ex)
                    { }
                }

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }


        [HttpGet]
        [Route("GetDemoExcel/{filterId}/{fileName}")]
        public async Task<IActionResult> OnPostExport([FromBody]FilterSortingDto filterSortingDto, int filterId, string fileName)
        {


            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            // Render an HTML document or snippet as a string
            Renderer.RenderHtmlAsPdf("<h1>Hello World</h1>").SaveAs("html-string.pdf");
            // Advanced: 
            // Set a "base url" or file path so that images, javascript and CSS can be loaded  
            var PDF = Renderer.RenderHtmlAsPdf("<img src='icons/iron.png'>", @"C:\site\assets\");
            PDF.SaveAs("html-with-assets.pdf");



            string sWebRootFolder = "../Talent.Web/TempUpload";


            FilterSortingDto FilterSortingDto = new FilterSortingDto();
            //var dataList = await talentBLLWrapper.GridBll.GetMasterFilterAppliedData(filterId);
            var dataList = await _globalGridManager.GetMasterFilterAppliedDataAsync(filterId, 0, 0, false, filterSortingDto, "ENG");
            var iDataList = dataList.data.ToList();

           
            //var uploads = System.IO.Path.Combine("../Talent.Web/", "TempUpload");
            //if (!Directory.Exists(uploads))
            //{
            //    Directory.CreateDirectory(uploads);
            //}
            //string sWebRootFolder = "../Talent.Web/TempUpload";

            fileName = fileName + ".xlsx";
            string sFileName = @fileName;
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Log_Operazioni");

                var rowIndex = 0;
                IRow row = excelSheet.CreateRow(0);
                rowIndex++;

                var cellIndex = 0;
                row.CreateCell(cellIndex).SetCellValue("Id");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Description");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Details");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("User");
                cellIndex++;
                row.CreateCell(cellIndex).SetCellValue("Client_Id");
                cellIndex++;
                

                foreach (var iData in iDataList)
                {
                    LogOperazioni logOperazioniDto = (LogOperazioni)iData;
                    row = excelSheet.CreateRow(rowIndex);
                    rowIndex++;

                    cellIndex = 0;
                    row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogId);
                    cellIndex++;
                    row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogDescr);
                    cellIndex++;
                    row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogDettaglio);
                    cellIndex++;
                    row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogUteId);
                    cellIndex++;
                    row.CreateCell(cellIndex).SetCellValue(logOperazioniDto.LogCliId);

                }


             

              

                //row = excelSheet.CreateRow(2);
                //row.CreateCell(0).SetCellValue(2);
                //row.CreateCell(1).SetCellValue("Martin Guptil");
                //row.CreateCell(2).SetCellValue(33);

                //row = excelSheet.CreateRow(3);
                //row.CreateCell(0).SetCellValue(3);
                //row.CreateCell(1).SetCellValue("Colin Munro");
                //row.CreateCell(2).SetCellValue(23);

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }








        [HttpGet]
        [Route("GetClientLogo/{cliId}/{secretKey}")]
        public async Task<IActionResult> GetClientLogo(string cliId, string secretKey)
        {
            try
            {
                var categories = await _clientManager.GetClientDataByClientId(cliId, secretKey);
                if (categories == null)
                {
                    return Ok(new
                    {
                        logoLink = "N/A",
                        isValid = false
                    });
                }
                return Ok(new
                {
                    logoLink = categories.CliLogoPath,
                    isValid = true
                });
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Client");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }


        /// <summary>
        ///     To get all the client list.
        /// </summary>
        /// <purpose>
        ///     Where the client list to be loaded.
        /// </summary>
        /// <returns>List object of clienti</returns>
        // GET: api/Clienti/GetAllClienti
        [HttpGet]
        [Route("GetAllClienti")]
        public async Task<IActionResult> GetAllClienti()
        {
            try
            {
                var categories = await _clientManager.GetAllClientDataAsync();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception x)
            {
                // Code block of Exception handling and logging into log_operazione table.
                var errorObj =  await _utilityManager.ReturnErrorObj(x, User, "Get Client");
                // Returning the error object.
                return BadRequest(errorObj);
            }

        }

    }
}
