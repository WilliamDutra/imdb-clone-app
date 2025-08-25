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

        public int Rating { get; set; }

        private IReadOnlyCollection<Actor> Cast => _Actors;

        private List<Actor> _Actors = new List<Actor>();

        private Movie(int id, string title, string overview, string poster, int rating)
        {
            Title = title;
            Id = id;
            Overview = overview;
            Poster = poster;
            Rating = rating;
        }

        public void AddCast(Actor actor)
        {
            _Actors.Add(actor);
        }

        public static Movie Restore(int id, string title, string overview, string poster, int rating)
        {
            return new Movie(id, title, overview, poster, rating);
        }
    }
}
