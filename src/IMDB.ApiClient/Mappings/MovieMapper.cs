using IMDB.ApiClient.GetCastMovie;
using IMDB.ApiClient.GetMovieById;
using System;
using System.Collections.ObjectModel;

namespace IMDB.ApiClient.Mappings
{
    public static class MovieMapper
    {
        public static ObservableCollection<Movie> ToMap(List<Movies> response)
        {
            var movies = new ObservableCollection<Movie>();

            foreach (var item in response)
            {

                movies.Add(Movie.Restore(item.Id, item.Title, item.Overview, $"https://image.tmdb.org/t/p/original{item.PosterPath}", (int)item.VoteAverage));
            }

            return movies;
        }

        public static Movie ToMap(MovieByIdResponse response)
        {
            var movie = Movie.Restore(response.Id, response.Title, response.Overview, $"https://image.tmdb.org/t/p/original{response.Poster}", 0);
            return movie;
        }

        public static ObservableCollection<Actor> ToMap(CastResponse response)
        {
            var actors = new ObservableCollection<Actor>();
            foreach (var item in response.Credits.Cast)
            {
                actors.Add(Actor.Restore(item.Id, item.Name, $"https://image.tmdb.org/t/p/original{item.ProfilePath}"));
            }
            return actors;
        }
    }
}
