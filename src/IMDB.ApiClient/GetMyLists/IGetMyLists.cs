using Refit;
using System;

namespace IMDB.ApiClient.GetMyLists
{
    public interface IGetMyLists
    {
        [Get("/account/{accountId}/lists")]
        Task<TmdbResponse<System.Collections.Generic.List<List>>> Execute(int accountId);
    }
}
