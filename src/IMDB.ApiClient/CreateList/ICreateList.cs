using Refit;
using System;

namespace IMDB.ApiClient.CreateList
{
    public interface ICreateList
    {
        [Post("/list?session_id={sessionId}")]
        Task<TmdbBaseResponse> Execute([Body] List request, string sessionId);
    }
}
