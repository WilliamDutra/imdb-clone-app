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

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private ObservableCollection<Movie> movies;

        [ObservableProperty]
        private string genreName;

        private int _TotalPages  = 0;

        private int _CurrentPage = 1;

        private int _GenreId = 0;

        public MoviesByGenresPageViewModel(IGetMoviesByGenres getMoviesByGenres, INavigationManager navigationManager)
        {
            _getMoviesByGenres = getMoviesByGenres;
            _navigationManager = navigationManager;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int genreId = (int)query["genreId"];
            GenreName = query["genreName"].ToString();
            _GenreId = genreId;
            IsBusy = true;
            EachMoviesByGenres(genreId);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task RemainingItems()
        {
            IsBusy = true;
            await Toast.Make($"carregando novos filmes", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            if (_CurrentPage > _TotalPages)
                return;

            await Task.Delay(3000);

            _CurrentPage++;

            var results = await _getMoviesByGenres.Execute(_GenreId, _CurrentPage);
            Movies.AddRange(MovieMapper.ToMap(results.Data));
            await Toast.Make($"página {_CurrentPage}", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            IsBusy = false;
        }

        [RelayCommand]
        public async void Detail(Movie movie)
        {
            var movieId = movie.Id;
            var parameters = new Dictionary<string, object>();
            parameters["Id"] = movieId;
            await _navigationManager.GoToPage("details", parameters);
        }

        [RelayCommand]
        public async Task BackToHomePage()
        {
            await _navigationManager.GoToPage("..");
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
