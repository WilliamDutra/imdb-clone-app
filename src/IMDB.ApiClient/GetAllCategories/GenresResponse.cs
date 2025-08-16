using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.GetAllCategories
{
    public class GenresResponse
    {
        [JsonPropertyName("genres")]
        public List<Generes> Genres { get; set; }
    }

    public class Generes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
