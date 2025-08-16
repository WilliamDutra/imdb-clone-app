using Refit;
using System;

namespace IMDB.ApiClient.GetAccessToken
{
    public interface IGetAccessToken
    {
        [Post("/auth/access_token")]
        Task<TmdbAuthenticationTokenResponse> Execute([Body]AccessTokenRequest request);
    }
}
