using Refit;
using System;

namespace IMDB.ApiClient.GetActorById
{
    public interface IGetActorById
    {
        [Get("/person/{personId}")]
        public Task<Actors> Execute(int personId);
    }
}
