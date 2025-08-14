using Refit;
using System;

namespace IMDB.ApiClient.GetAccessToken
{
    public interface IGetAccessToken
    {
        [Post("/auth/access_token")]
        Task<AccessToken> Execute([Body]AccessTokenRequest request);
    }
}
