using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.DeleteMovieOfList
{
    public class MovieRequest
    {
        [JsonPropertyName("media_id")]
        public int MediaId { get; set; }
    }
}
