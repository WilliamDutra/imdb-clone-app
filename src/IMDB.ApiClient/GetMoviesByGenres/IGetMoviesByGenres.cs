using Refit;
using System;
using System.Collections.Generic;

namespace IMDB.ApiClient.GetMoviesByGenres
{
    public interface IGetMoviesByGenres
    {
        [Get("/discover/movie?include_adult=false&include_video=false&language=en-US&page={page}&sort_by=popularity.desc&with_genres={genreId}")]
        Task<Response<Movies>> Execute(int genreId, int page = 1);
    }
}
