using System;
using System.Collections.Generic;
using System.Text;

namespace Talent.DataModel.DataModels
{
    public static class AppSettingsDto
    {
        public static string Secret { get; set; }
        public static string Environment { get; set; }
        public static string ConnectionString { get; set; }
        public static string SqlServerDateFormat { get; set; }
        public static string BaseDomainName { get; set; }
        public static string HostName { get; set; }
        public static string SenderMail { get; set; }
        public static string SenderMailAccessKeyToken { get; set; }
        public static string APIDomainName { get; set; }
    }
}
