using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient
{
    public class TmdbSessionResponse : TmdbBaseResponse
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }
    }
}
