using System;
using System.Threading.Tasks;
using Talent.BLL.Utilities;

namespace Talent.BLL.Repositories
{
    public interface IEmailManager
    {
        String AccessToken { get; set; }
        EmailTo To { get; set; }
        EmailCc Cc { get; set; }
        EmailBcc Bcc { get; set; }
        EmailAttachments Attachments { get; set; }
        String From { get; set; }
        String Subject { get; set; }
        String Body { get; set; }
        string Send();
    }
}