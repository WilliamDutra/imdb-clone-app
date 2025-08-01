using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient
{
    public class Movie
    {
        public string Title { get; private set; }

        public string Overview { get; private set; }

        public int Id { get; private set; }

        private Movie(int id, string title, string overview)
        {
            Title = title;
            Id = id;
            Overview = overview;
        }

        public static Movie Restore(int id, string title, string overview)
        {
            return new Movie(id, title, overview);
        }
    }
}
