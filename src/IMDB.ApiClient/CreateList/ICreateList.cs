using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.CreateList
{
    public interface ICreateList
    {
        [Post("/list?session_id={sessionId}")]
        Task Execute([Body] List request, string sessionId);
    }
}
