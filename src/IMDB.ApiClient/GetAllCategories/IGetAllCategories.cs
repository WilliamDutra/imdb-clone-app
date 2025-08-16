using Refit;
using System;

namespace IMDB.ApiClient.GetAllCategories
{
    public interface IGetAllCategories
    {
        [Get("/genre/movie/list")]
        Task<TmdbResponse<GenresResponse>> Execute();
    }
}
