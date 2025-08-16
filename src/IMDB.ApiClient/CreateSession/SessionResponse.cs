using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMDB.ApiClient.CreateSession
{
    public class SessionResponse
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }
    }
}
