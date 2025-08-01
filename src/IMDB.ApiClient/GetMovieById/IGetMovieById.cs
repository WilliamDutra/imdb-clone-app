using Refit;
using System;


namespace IMDB.ApiClient.GetMovieById
{
    public interface IGetMovieById
    {
        [Get("/movie/{id}")]
        Task<MovieById> Execute(int id);
    }
}
