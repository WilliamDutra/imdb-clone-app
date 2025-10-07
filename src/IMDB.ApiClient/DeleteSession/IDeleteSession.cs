using Refit;
using System;

namespace IMDB.ApiClient.DeleteSession
{
    public interface IDeleteSession
    {
        [Delete("/authentication/session?session_id={sessionId}")]
        Task<TmdbBaseResponse> Execute(string sessionId);
    }
}
