using Newtonsoft.Json;
using System.Globalization;

namespace amocrm.library.Models.Account
{
    public class AccountInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "subdomain")]
        public string SubDomain { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }
        [JsonProperty(PropertyName = "timezone_offset")]
        public string TimezoneOffset { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        [JsonProperty(PropertyName = "current_user")]
        public int CurrentUser { get; set; }
        [JsonProperty(PropertyName = "date_pattern")]
        public DataPattern DataPattern { get; set; }

        [JsonProperty(PropertyName = "_embedded")]
        public TypeInfoStore FieldsTypeStore { get; set; }
    }

    public class DataPattern
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string DateAndTime { get; set; }
        public string TimeFull { get; set; }

        public CultureInfo DateTimeFormat()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            culture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            culture.DateTimeFormat.FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
            return culture;
        }
    }

    public class TypeInfoStore
    {
        [JsonProperty(PropertyName = "custom_fields")]
        public CustomFieldInfo FieldInfo { get; set; }

    }
}
