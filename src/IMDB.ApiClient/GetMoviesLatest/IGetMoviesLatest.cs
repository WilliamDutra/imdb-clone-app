using Refit;
using System;

namespace IMDB.ApiClient.GetMoviesLatest
{
    public interface IGetMoviesLatest
    {
        [Get("/discover/movie?include_adult=false&page=1&sort_by=release_date.desc")]
        Task<Response<Movies>> Execute();
    }
}
