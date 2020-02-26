namespace Talent.BLL.Utilities
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Environment { get; set; }
        public string ConnectionString { get; set; }
        public string SqlServerDateFormat { get; set; }
        public string BaseDomainName { get; set; }
        public string HostName { get; set; }
        public string SenderMail { get; set; }
        public string SenderMailAccessKeyToken { get; set; }
        public string APIDomainName { get; set; }
    }
}
