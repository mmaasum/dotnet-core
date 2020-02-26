using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;

namespace Talent.BLL.DTO
{
    public class KeyValuePairDto
    {
        public string Key;
        public string Value;

        public KeyValuePairDto()
        {
            
        }

        public KeyValuePairDto(string k)
        {
            Key = k;
            Value = k;
        }

        public KeyValuePairDto(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}