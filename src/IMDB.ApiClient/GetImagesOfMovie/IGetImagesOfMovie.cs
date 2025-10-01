using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.GetImagesOfMovie
{
    public interface IGetImagesOfMovie
    {
        [Get("/movie/{movieId}/images")]
        public Task<MovieImages> Execute(int movieId);
    }
}
