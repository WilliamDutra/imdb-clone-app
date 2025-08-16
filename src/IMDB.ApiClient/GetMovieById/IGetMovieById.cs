using Refit;
using System;


namespace IMDB.ApiClient.GetMovieById
{
    public interface IGetMovieById
    {
        [Get("/movie/{id}")]
        Task<MovieByIdResponse> Execute(int id);
    }
}
