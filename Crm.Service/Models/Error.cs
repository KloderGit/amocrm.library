using Newtonsoft.Json;
using System.Collections.Generic;

namespace amocrm.library.Models
{

    public class AuthResponse
    {
        [JsonProperty(PropertyName = "response")]
        public AuthContent Content { get; set; }
    }

    public class AuthContent
    {
        [JsonProperty(PropertyName = "auth")]
        public bool AuthResult { get; set; }

        [JsonProperty(PropertyName = "server_time")]
        public int ServerTime { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "user")]
        public AuthUser User { get; set; }

        [JsonProperty(PropertyName = "accounts")]
        public List<AuthAccount> Accounts { get; set; }
    }

    public class AuthUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }

    public class AuthAccount
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }
    }
}