using Refit;
using System;

namespace IMDB.ApiClient.GetListById
{
    public interface IGetListById
    {
        [Get("/list/{listId}")]
        Task<ListById> Execute(int listId);
    }
}
