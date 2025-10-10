using Refit;
using System;
using System.Collections.Generic;

namespace IMDB.ApiClient.GetMoviesByGenres
{
    public interface IGetMoviesByGenres
    {
        [Get("/discover/movie")]
        Task<TmdbResponse<List<Movies>>> Execute([Query] MoviesByGenresParams parameters);
    }
}
