using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient
{
    public class TmdbAuthenticationTokenResponse : TmdbBaseResponse
    {
        [JsonPropertyName("request_token")]
        public string RequestToken { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }
    }
}
