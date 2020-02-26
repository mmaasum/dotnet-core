using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Talent.BLL.Repositories;
using Talent.Common.Enums;
using Talent.DataModel;
using Talent.DataModel.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
//using GrapeCity.Documents.Word;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System.Xml;

namespace Talent.BLL.Manager
{
    public class SubscriberManager : ISubscriberManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubscriberManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Aziende>> GetAziendeByClientIdAsync(string cliId)
        {
            // Fetching data from dal.
            var data = await _unitOfWork.Aziende.FindInOrderAsync(
                x => x.AzCliId.Equals(cliId),
                x => x.AzRagSociale,
                OrderType.Ascending);

            // Returning the retrieved data to controller end
            return data;
        }

        public async Task<int> GetTokenValidationDataAsync(string username, string password)
        {
            return 1;
        }

        public async Task<string> TextFromFileAsync(IFormFile file)
        {
            byte[] RisCvAllegato;
            var extension = System.IO.Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                RisCvAllegato = stream.ToArray();
            }

            var extLower = extension.ToLower();
            string cvTextContent = "";
            if (extLower == ".doc" || extLower == ".docx")
            {
                cvTextContent = TextFromWord(file);
            }
            else if (extLower == ".pdf")
            {
                cvTextContent = PdfStreamByteToText(RisCvAllegato);
            }

            return await Task.FromResult(cvTextContent);
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


        public static string TextFromWord(IFormFile file)
        {
            const string wordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            StringBuilder textBuilder = new StringBuilder();
            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(file.OpenReadStream(), false))
            {
                // Manage namespaces to perform XPath queries.  
                NameTable nt = new NameTable();
                XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
                nsManager.AddNamespace("w", wordmlNamespace);

                // Get the document part from the package.  
                // Load the XML in the document part into an XmlDocument instance.  
                XmlDocument xdoc = new XmlDocument(nt);
                xdoc.Load(wdDoc.MainDocumentPart.GetStream());

                XmlNodeList paragraphNodes = xdoc.SelectNodes("//w:p", nsManager);
                foreach (XmlNode paragraphNode in paragraphNodes)
                {
                    XmlNodeList textNodes = paragraphNode.SelectNodes(".//w:t", nsManager);
                    foreach (System.Xml.XmlNode textNode in textNodes)
                    {
                        textBuilder.Append(textNode.InnerText);
                    }
                    textBuilder.Append(Environment.NewLine);
                }

            }
            return textBuilder.ToString();
        }
    }
}