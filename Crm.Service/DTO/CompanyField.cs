using Newtonsoft.Json;

namespace amocrm.library.DTO
{
    public class CompanyField
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
