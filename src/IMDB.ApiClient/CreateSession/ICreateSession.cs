using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.CreateSession
{
    public interface ICreateSession
    {
        [Post("/authentication/session/new")]
        Task<TmdbSessionResponse> Execute([Body] CreateSessionRequest request);
    }
}
