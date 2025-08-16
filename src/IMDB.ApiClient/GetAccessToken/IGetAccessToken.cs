using Refit;
using System;

namespace IMDB.ApiClient.GetAccessToken
{
    public interface IGetAccessToken
    {
        [Post("/auth/access_token")]
        Task<TmdbResponse<AccessTokenResponse>> Execute([Body]AccessTokenRequest request);
    }
}
