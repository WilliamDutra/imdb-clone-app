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

        [JsonPropertyName("avatar")]
        public Avatar Avatar { get; set; }

    }

    public class Avatar
    {
        [JsonPropertyName("gravatar")]
        public Gravatar Gravatar { get; set; }

    }

    public class Gravatar
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
