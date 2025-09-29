using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.GetActorById
{
    public class Actors
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("profile_path")]
        public string Profile { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }
}
