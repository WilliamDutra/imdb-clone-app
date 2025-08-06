using Refit;
using System;

namespace IMDB.ApiClient.SearchByTitle
{
    public interface ISearchByTitle
    {
        [Get("/search/movie?query={title}&include_adult=false&page=1")]
        Task<Response<Movies>> Execute(string title); 
    }
}
