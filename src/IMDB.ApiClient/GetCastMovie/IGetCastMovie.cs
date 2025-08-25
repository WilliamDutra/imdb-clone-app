using Refit;
using System;

namespace IMDB.ApiClient.GetCastMovie
{
    public interface IGetCastMovie
    {
        [Get("/movie/{movieId}?append_to_response=credits")]
        Task<CastResponse> Execute(int movieId);
    }
}
