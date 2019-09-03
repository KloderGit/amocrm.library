using Newtonsoft.Json;

namespace Crm.Service.Models
{

    public class Error
    {
        [JsonProperty(PropertyName = "response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "server_time")]
        public int ServerTime { get; set; }

        [JsonProperty(PropertyName = "auth")]
        public bool AuthResult { get; set; }
    }

}
