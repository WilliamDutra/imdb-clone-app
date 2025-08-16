using System.Text.Json.Serialization;

namespace IMDB.ApiClient
{
    public class TmdbResponse<T> : TmdbBaseResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public T Data { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
