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

        public string Poster { get; private set; }

        private Movie(int id, string title, string overview, string poster)
        {
            Title = title;
            Id = id;
            Overview = overview;
            Poster = poster;
        }

        public static Movie Restore(int id, string title, string overview, string poster)
        {
            return new Movie(id, title, overview, poster);
        }
    }
}
