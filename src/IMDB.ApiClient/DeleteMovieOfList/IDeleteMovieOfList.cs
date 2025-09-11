using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.DeleteMovieOfList
{
    public interface IDeleteMovieOfList
    {
        [Post("/list/{listId}/remove_item")]
        Task Execute(int listId, [Body]MovieRequest request);
    }
}
