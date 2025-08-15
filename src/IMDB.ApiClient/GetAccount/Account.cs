using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.GetAccount
{
    public class Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
