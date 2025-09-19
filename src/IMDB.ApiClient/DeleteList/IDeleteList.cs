using Refit;
using System;

namespace IMDB.ApiClient.DeleteList
{
    public interface IDeleteList
    {
        [Delete("/list/{listId}?session_id={sessionId}")]
        Task Execute(int listId, string sessionId);
    }
}
