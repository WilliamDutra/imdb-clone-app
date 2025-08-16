using Refit;
using System;

namespace IMDB.ApiClient.GetAuthenticationToken
{
    public interface IGetAuthenticationToken
    {
        [Get("/authentication/token/new")]
        Task<TmdbAuthenticationTokenResponse> Execute();
    }
}
