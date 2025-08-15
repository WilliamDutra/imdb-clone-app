using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.AddMovieToList
{
    public interface IAddMovieToList
    {
        [Post("/list/{listId}/add_item?session_id={sessionId}")]
        Task Execute(string sessionId, string listId, [Body] AddMovie request);
    }
}
