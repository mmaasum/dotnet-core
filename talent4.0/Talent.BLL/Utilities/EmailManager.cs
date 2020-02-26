using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Talent.BLL.Repositories;
using Talent.DataModel.DataModels;

namespace Talent.BLL.Utilities
{
    public class EmailManager : IEmailManager
    {
        public EmailManager()
        {

        }
        private string errorMessage = string.Empty;

        private string accessToken = string.Empty;
        public String AccessToken
        {
            get { return accessToken; }
            set { accessToken = value; }
        }

        private EmailTo to = new EmailTo();
        public EmailTo To
        {
            get { return to; }
            set { to = value; }
        }
        private EmailCc cc = new EmailCc();
        public EmailCc Cc
        {
            get { return cc; }
            set { cc = value; }
        }
        private EmailBcc bcc = new EmailBcc();
        public EmailBcc Bcc
        {
            get { return bcc; }
            set { bcc = value; }
        }
        private EmailAttachments attachments = new EmailAttachments();
        public EmailAttachments Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        //private string mailFrom = AppSettingsDto.SenderMail;
        private string mailFrom = string.Empty;
        public String From
        {
            get { return mailFrom; }
            set { mailFrom = value; }
        }

        private string mailSubject = string.Empty;
        public String Subject
        {
            get { return mailSubject; }
            set { mailSubject = value; }
        }

        public String Body { get; set; } = string.Empty;

        public string Send()
        {
            if (mailFrom == String.Empty)
            {
                mailFrom = AppSettingsDto.SenderMail;
                if (mailFrom == String.Empty)
                {
                    return "From Address is absent";
                }
               
            }
            if (to == null) return "To Address is absent";
            if (mailSubject == String.Empty) return "No Mail Subject";
            if (Body == String.Empty) return "No Mail Body";
            MailMessage mailMessage = new MailMessage();
            SmtpClient sendMail = new SmtpClient();

            MailAddress addressFrom = new MailAddress(mailFrom);
            mailMessage.From = addressFrom;
            sendMail.Host = AppSettingsDto.HostName;


            string appAccessKeyToken = AppSettingsDto.SenderMailAccessKeyToken;

            if (accessToken == null || accessToken == "")
            {
                accessToken = AppSettingsDto.SenderMailAccessKeyToken;
            }


            sendMail.EnableSsl = false;
            NetworkCredential networkCredential = new NetworkCredential(addressFrom.Address, accessToken);
            sendMail.UseDefaultCredentials = true;
            sendMail.Credentials = networkCredential;
            sendMail.Port = 25;
                            
            foreach (String strTo in to)
            {
                try
                {
                    mailMessage.To.Add(strTo);
                }
                catch
                {
                    errorMessage = errorMessage + "Invalid Email";
                }
            }
            mailMessage.Subject = mailSubject;
            //CC
            if (cc != null)
            {
                foreach (String strCc in cc)
                {
                    try
                    {
                        mailMessage.CC.Add(strCc);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            //Bcc
            if (bcc != null)
            {
                foreach (String strBcc in bcc)
                {
                    try
                    {
                        mailMessage.Bcc.Add(strBcc);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            //Add Mail Attachments
            if (attachments != null)
            {
                int i = 0;
                foreach (AttachmentWrapper attachment in attachments)
                {
                    try
                    {
                        if(attachment.Stream != null)
                        {
                            mailMessage.Attachments.Add(new Attachment(attachment.Stream, attachment.FileName));
                            mailMessage.Attachments[i++].ContentStream.Position = 0;
                        }
                        else if(!string.IsNullOrEmpty(attachment.FileReferencePath))
                        {
                            mailMessage.Attachments.Add(new Attachment(attachment.FileReferencePath));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }                        

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = Body;
            try
            {
                if (mailMessage.To.Count > 0)
                {
                    sendMail.SendAsync(mailMessage, "tt");
                }
                else
                {
                    return "Add email";
                }
            }
            catch (Exception ex)
            {
                errorMessage = errorMessage + "Error:" + ex.Message;
                return errorMessage;
            }

            return "success";
        }
    }
    public class EmailAttachments : CollectionBase
    {
        public int Add(string attachmentResourcePath)
        {
            if (attachmentResourcePath.Trim() != String.Empty)
            {
                return List.Add(new AttachmentWrapper { FileReferencePath = attachmentResourcePath});
            }
            else
            {
                return 0;
            }
        }

        public int Add(System.IO.Stream stream, string fileName)
        {
            return List.Add(new AttachmentWrapper { Stream = stream, FileName = fileName });
        }
    }

    public class EmailFrom : CollectionBase
    {
        public int Add(string From)
        {
            return From.Trim() != String.Empty ? List.Add(From) : 0;
        }
    }

    public class EmailTo : CollectionBase
    {
        public int Add(string To)
        {
            return To.Trim() != String.Empty ? List.Add(To) : 0;
        }
    }
    public class EmailCc : CollectionBase
    {
        public int Add(string Cc)
        {
            return Cc.Trim() != String.Empty ? List.Add(Cc) : 0;
        }
    }
    public class EmailBcc : CollectionBase
    {
        public int Add(string Bcc)
        {
            return Bcc.Trim() != String.Empty ? List.Add(Bcc) : 0;
        }
    }


    //public class AccessKeyToken : CollectionBase
    //{
    //    public string Add(string Token)
    //    {
    //        return Token;
    //    }
    //}


    public class AttachmentWrapper
    {
        public string FileReferencePath { get; set; }
        public System.IO.Stream Stream { get; set; }
        public string FileName { get; set; }
    }
}

