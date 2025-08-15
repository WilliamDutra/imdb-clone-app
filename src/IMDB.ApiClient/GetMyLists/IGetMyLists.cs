using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.GetMyLists
{
    public interface IGetMyLists
    {
        [Get("/account/{accountId}/lists")]
        Task<Response<List>> Execute(int accountId);
    }
}
