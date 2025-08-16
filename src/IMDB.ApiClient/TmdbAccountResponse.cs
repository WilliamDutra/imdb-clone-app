using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient
{
    public class TmdbAccountResponse : TmdbBaseResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
