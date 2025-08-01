using System;
using System.Collections.ObjectModel;
using IMDB.ApiClient.GetMoviesTopFiveDay;

namespace IMDB.ApiClient.Mappings
{
    public static class MovieMapper
    {
        public static ObservableCollection<Movie> ToMap(List<Movies> response)
        {
            var movies = new ObservableCollection<Movie>();

            foreach (var item in response)
            {

                movies.Add(Movie.Restore(item.Id, item.Title, item.Overview));
            }

            return movies;
        }
    }
}
