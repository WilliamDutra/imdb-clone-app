using System;
using IMDB.ApiClient;
using IMDB.ApiClient.Mappings;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using IMDB.ApiClient.GetMoviesByGenres;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Pages.MoviesByGenres
{
    public partial class MoviesByGenresPageViewModel : ViewModel, IQueryAttributable
    {

        private IGetMoviesByGenres _getMoviesByGenres;

        [ObservableProperty]
        private ObservableCollection<Movie> movies;

        private int _TotalPages  = 0;

        private int _CurrentPage = 1;

        private int _GenreId = 0;

        public MoviesByGenresPageViewModel(IGetMoviesByGenres getMoviesByGenres)
        {
            _getMoviesByGenres = getMoviesByGenres;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int genreId = (int)query["genreId"];
            _GenreId = genreId;
            EachMoviesByGenres(genreId);
        }

        [RelayCommand]
        public async void RemainingItems()
        {
            await Toast.Make($"carregando novos filmes", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            if (_CurrentPage > _TotalPages)
                return;

            await Task.Delay(3000);
            
            var results = await _getMoviesByGenres.Execute(_GenreId, _CurrentPage);
            Movies.AddRange(MovieMapper.ToMap(results.Data));
            await Toast.Make($"página {_CurrentPage}", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            _CurrentPage++;
        }

        private async void EachMoviesByGenres(int genreId)
        {
            var results = await _getMoviesByGenres.Execute(genreId);
            _TotalPages = results.TotalPages;
            Movies = MovieMapper.ToMap(results.Data);
        }
    }

    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> lista, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                lista.Add(item);
            }
        }
    }

}
