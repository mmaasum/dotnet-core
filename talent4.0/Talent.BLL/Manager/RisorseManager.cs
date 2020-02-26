using AutoMapper;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talent.BLL.DTO;
using Talent.BLL.Repositories;
using Talent.DataModel;
using Talent.DataModel.DataModels;
using Talent.DataModel.Models;

namespace Talent.BLL.Manager
{
    public class RisorseManager : IRisorseManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RisorseManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        /// <summary>
        ///     Pasing data to data access layer for inserting risorse retrieved from controller end.
        /// </summary>
        /// <param name="risorseDto"></param>
        /// <returns></returns>
        public async Task<string> InsertAsync(ClaimsPrincipal User, RisorseDto risorseDto)
        {
            try
            {
                // Create new domain object from DTO.
                Risorse risorse = _mapper.Map<RisorseDto,Risorse>(risorseDto);


                // Set auditable properties.
                risorse.RisInsUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                risorse.RisInsTimestamp = DateTime.Now;
                risorse.RisModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                risorse.RisModTimestamp = DateTime.Now;
                risorse.RisCliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;


                // Execute persistence.
                _unitOfWork.Risorse.Add(risorse);
                await _unitOfWork.CompleteAsync();

                return risorse.RisTitolo;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        ///     Pasing data to data access layer for updating risorse retrieved from controller end.
        /// </summary>
        /// <param name="richiesteDto"></param>
        /// <returns></returns>
        public async Task<string> UpdateAsync(ClaimsPrincipal User, RisorseDto risorseDto)
        {
            try
            {
                //map dto dto to table risorse
                Risorse risorse = await _unitOfWork.Risorse
                    .FirstOrDefaultAsync(x => x.RisId == risorseDto.RisId 
                                              && x.RisCliId == risorseDto.RisCliId);

                _mapper.Map(risorseDto, risorse);

                risorse.RisModUteId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
                risorse.RisModTimestamp = DateTime.Now;

                await _unitOfWork.CompleteAsync();

                return risorse.RisTitolo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        ///     Upload CV file.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="risId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> UploadCvAsync(string clientId, int risId, IFormFile file)
        {
            Risorse risorse = await _unitOfWork.Risorse
                .FirstOrDefaultAsync(x => x.RisId == risId && x.RisCliId == clientId);

            if (risorse == null)
                return "Failed";

            var extension = System.IO.Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;

            risorse.RisCvNomeFile = fileName;
            risorse.RisCvDimInKb = file.Length / 1024;
            risorse.RisCvDataInserimento = DateTime.Now;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                risorse.RisCvAllegato = stream.ToArray();
            }



            var extLower = extension.ToLower();
            string cvTextContent = "";
            if (extLower == ".doc" || extLower == ".docx")
            {
                cvTextContent = DocStreamByteToText(risorse.RisCvAllegato);
            }
            else if (extLower == ".pdf")
            {
                cvTextContent = PdfStreamByteToText(risorse.RisCvAllegato);
            }

            if (!string.IsNullOrEmpty(cvTextContent))
            {
                risorse.RisCvTesto = cvTextContent;
            }

            await _unitOfWork.CompleteAsync();

            return risorse.RisTitolo;
        }


        /// <summary>
        ///     Extract cv content from database cv saved as byte[]
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="risId"></param>
        /// <returns>string</returns>
        public async Task<string> ScanCVAsync(string clientId, int risId)
        {
            Risorse risorse = await _unitOfWork.Risorse
                .FirstOrDefaultAsync(x => x.RisId == risId && x.RisCliId == clientId);

            if (risorse == null)
                return "";

            if (risorse.RisCvAllegato == null || risorse.RisCvAllegato.Length == 0)
            {
                return "";
            }

            var extension = System.IO.Path.GetExtension(risorse.RisCvNomeFile);
            var extLower = extension.ToLower();

            string cvTextContent = "";
            if (extLower == ".doc" || extLower == ".docx")
            {
                cvTextContent = DocStreamByteToText(risorse.RisCvAllegato);
            }
            else if (extLower == ".pdf")
            {
                cvTextContent = PdfStreamByteToText(risorse.RisCvAllegato);
            }


            if (!string.IsNullOrEmpty(cvTextContent))
            {
                risorse.RisCvTesto = cvTextContent;
                await _unitOfWork.CompleteAsync();
            }

            return cvTextContent;
        }

        public async Task<IEnumerable<RisorseDto>> GetAllAsync(string clientId, int nextCount)
        {
            try
            {
                var data = await _unitOfWork.ViewRisorseNoAllegati.FindAsync(a => a.RisCliId.Equals(clientId));
                return _mapper.Map<List<ViewRisorseNoAllegati>, List<RisorseDto>>(data.Take(500).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<RisorseDto> GetDetailAsync(int risId)
        {
            // Fetching data from dal.
            Risorse risorse = await _unitOfWork.Risorse.FirstOrDefaultAsync(x => x.RisId == risId);
            // Returning the retrieved data to controller end
            return _mapper.Map<Risorse, RisorseDto>(risorse);

        }

        public async Task<string> LaunchRisorseSPBl(string richId, string cvInviati, string clientId)
        {
            try
            {
                var logs = await _unitOfWork.Risorse.LaunchRisorseSP(richId, cvInviati, clientId);
                return logs;
            }
            catch (Exception)
            {
                throw;
            }
        }


        
        public async Task<IEnumerable<RisInfoStatusDto>> GetRisInfoByRichIdAsync(ClaimsPrincipal User, string richId)
        {
            try
            {
                var cliId = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"))?.Value;
                // Fetching data from dal.
                //var data = await _wrapper.RisorseRepo.GetRisInfoByRichIdAsync(richId, cliId);
                //return new List<RisorseDto>(data.Select(x => _risorseDto.MapRisorseToDto(x)));

                var data = await _unitOfWork.Risorse.GetRisInfoByRichIdAsync(richId, cliId);

                return _mapper.Map<List<MatchingRisorse>, List<RisInfoStatusDto>>(data.ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<IEnumerable<RisorseDto>> GetRisInfoByRisNomeCognomeAsync(string risnome, string risCognome, string clientId)
        {
            // Fetching data from dal.
            IEnumerable<ViewRisorseNoAllegati> data;
            if (risnome == "0")
            {
                data = await _unitOfWork.ViewRisorseNoAllegati
                    .FindAsync(x => x.RisCognome == risCognome && x.RisCliId == clientId);
            }
            else if (risCognome == "0")
            {
                data = await _unitOfWork.ViewRisorseNoAllegati
                    .FindAsync(x => x.RisNome == risnome && x.RisCliId == clientId);
            }
            else
            {
                data = await _unitOfWork.ViewRisorseNoAllegati
                    .FindAsync(x => x.RisNome == risnome 
                                    && x.RisCognome == risCognome 
                                    && x.RisCliId == clientId);
            }

            return _mapper.Map<List<ViewRisorseNoAllegati>, List<RisorseDto>>(data.ToList());
        }



        private string DocStreamByteToText(byte[] streamBytes)
        {
            string text = "";

            var tmpFile = System.IO.Path.GetTempFileName();
            var tmpFileStream = File.OpenWrite(tmpFile);
            tmpFileStream.Write(streamBytes, 0, streamBytes.Length);
            tmpFileStream.Close();

            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc;
            try
            {
                //doc = app.Documents.Open(tmpFile);
                //text = doc.Content.Text;
            }
            catch
            {
                return "";
            }
            finally
            {
                //object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                object missing = Type.Missing;
                //app.Quit(ref saveChanges, ref missing, ref missing);
            }
            return text;
        }


        private string PdfStreamByteToText(byte[] streamBytes)
        {
            StringBuilder text = new StringBuilder();

            var tmpFile = System.IO.Path.GetTempFileName();
            var tmpFileStream = File.OpenWrite(tmpFile);
            tmpFileStream.Write(streamBytes, 0, streamBytes.Length);
            tmpFileStream.Close();

            ITextExtractionStrategy its = new LocationTextExtractionStrategy();
            using (PdfReader reader = new PdfReader(tmpFile))
            {

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, its);
                    string[] theLines = thePage.Split('\n');
                    foreach (var theLine in theLines)
                    {
                        text.AppendLine(theLine);
                    }
                }
            }
            return text.ToString();
        }

        public async Task<RisorseCvInfo> GetCvInfoAsync(int risId)
        {
            // Fetching data from dal.
            Risorse risorse = await _unitOfWork.Risorse.FirstOrDefaultAsync(x => x.RisId == risId);
            // Returning the retrieved data to controller end
            return _mapper.Map<Risorse, RisorseCvInfo>(risorse);
        }
    }
}