using System;
using System.Text.Json.Serialization;


namespace IMDB.ApiClient.GetAccessToken
{
    public class AccessToken
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("access_token")]
        public string AcessToken { get; set; }
    }
}
