using Refit;
using System;
using System.Text.Json.Serialization;

namespace IMDB.ApiClient.GetAccessToken
{
    public class AccessTokenRequest
    {
        [AliasAs("request_token")]
        public string RequestToken { get; set; }
    }
}
