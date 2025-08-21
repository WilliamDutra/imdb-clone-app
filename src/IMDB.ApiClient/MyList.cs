using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMDB.ApiClient
{
    public class MyList
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int ItemCount { get; private set; }

        public IReadOnlyCollection<Movie> Movies => _Movies;

        private List<Movie> _Movies = new List<Movie>();

        private MyList(int id, string name, string description, int itemCount)
        {
            Id = id;
            Name = name;
            Description = description;
            ItemCount = itemCount;
        }

        public void AddMovie(int id, string name, string overview, string poster, int rating)
        {
            _Movies.Add(Movie.Restore(id, name, overview, poster, rating));
        }

        public static MyList Restore(int id, string name, string description, int itemCount)
        {
            return new MyList(id, name, description, itemCount);
        }
    }
}
