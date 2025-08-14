using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.GetAuthenticationToken
{
    public class Token
    {
        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonPropertyName("request_token")]
        public string RequestToken { get; set; }
    }
}
