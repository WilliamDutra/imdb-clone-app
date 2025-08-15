using Refit;
using System;

namespace IMDB.ApiClient.GetAccount
{
    public interface IGetAccount
    {
        [Get("/account?session_id={sessionId}")]
        Task<Account> Execute(string sessionId);
    }
}
