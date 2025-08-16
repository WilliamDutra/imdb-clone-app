using Refit;
using System;

namespace IMDB.ApiClient.GetMoviesTopFiveDay
{
    public interface IGetMoviesTopFiveDay
    {
        [Get("/trending/movie/day")]
        Task<TmdbResponse<List<Movies>>> Execute();
    }
}
