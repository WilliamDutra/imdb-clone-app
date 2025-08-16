using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient
{
    public class TmdbBaseResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("status_code")]
        public int? StatusCode { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }
    }
}
