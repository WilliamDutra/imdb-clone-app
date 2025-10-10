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

        [ObservableProperty]
        private ObservableCollection<string> fakeMovies;

        [ObservableProperty]
        private ObservableCollection<WatchProvider> watchProviders;

        private List<int> watchProvidersSelecteds = new List<int>();

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

            var parameters = new MoviesByGenresParams();
            parameters.GenreId = _GenreId;
            parameters.Page = _CurrentPage;
            var results = await _getMoviesByGenres.Execute(parameters);
            Movies.AddRange(MovieMapper.ToMap(results.Data));
            await Toast.Make($"página {_CurrentPage}", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task Detail(Movie movie)
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

        [RelayCommand]
        public async Task Initialize()
        {
            IsBusy = true;
            await EachFakeMovies();
            await EachWatchProviders();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task WatchProviderSelected(int id)
        {
            IsBusy = true;
            if (!watchProvidersSelecteds.Contains(id))
            {
                watchProvidersSelecteds.Add(id);
            }
            else
            {
                watchProvidersSelecteds.Remove(id);
            }

            var parameters = new MoviesByGenresParams();
            parameters.GenreId = _GenreId;
            parameters.WithWatchProviders = watchProvidersSelecteds;
            var results = await _getMoviesByGenres.Execute(parameters);
            Movies = MovieMapper.ToMap(results.Data);

            IsBusy = false;
        }

        private async void EachMoviesByGenres(int genreId)
        {
            var parameters = new MoviesByGenresParams();
            parameters.GenreId = genreId;
            var results = await _getMoviesByGenres.Execute(parameters);
            _TotalPages = results.TotalPages;
            Movies = MovieMapper.ToMap(results.Data);
        }

        private async Task EachFakeMovies()
        {
            FakeMovies = new ObservableCollection<string>();
            await Task.Run(() =>
            {
                FakeMovies.Add("01");
                FakeMovies.Add("02");
                FakeMovies.Add("03");
                FakeMovies.Add("04");
                FakeMovies.Add("05");
                FakeMovies.Add("06");
                FakeMovies.Add("07");
                FakeMovies.Add("08");
                FakeMovies.Add("09");
                FakeMovies.Add("10");
                FakeMovies.Add("11");
                FakeMovies.Add("12");
                FakeMovies.Add("13");
                FakeMovies.Add("14");
            });
        }

        private async Task EachWatchProviders()
        {
            await Task.Run(() =>
            {
                WatchProviders = new ObservableCollection<WatchProvider>();
                WatchProviders.Add(WatchProvider.Restore(8, "Netflix"));
                WatchProviders.Add(WatchProvider.Restore(9, "Amazon Prime Video"));
                WatchProviders.Add(WatchProvider.Restore(10, "AppleTv"));
                WatchProviders.Add(WatchProvider.Restore(337, "Disney+"));
                WatchProviders.Add(WatchProvider.Restore(8, "HBOMax"));
            });
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
