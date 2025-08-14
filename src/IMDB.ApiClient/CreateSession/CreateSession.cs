using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMDB.ApiClient.CreateSession
{
    public class CreateSession
    {
        [JsonPropertyName("request_token")]
        public string RequestToken { get; set; }
    }
}
