using System;
using IMDB.ApiClient;
using IMDB.ApiClient.Mappings;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.GetMoviesLatest;
using IMDB.ApiClient.GetAllCategories;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using CommunityToolkit.Mvvm.ComponentModel;
using IMDB.ApiClient.GetAuthenticationToken;

using System.Collections.ObjectModel;

namespace IMDB.Mobile.Pages.Home
{
    public partial class HomePageViewModel : ViewModel
    {
        private IGetMoviesTopFiveDay _getMoviesTopFiveDay;

        private IGetMoviesLatest _getMoviesLatest;

        private IGetAllCategories _getAllCategories;

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesTopFive;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesLatest;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private Movie movieSelected;

        [ObservableProperty]
        private Category categorySelected;

        public HomePageViewModel(IGetMoviesTopFiveDay getMoviesTopFiveDay, IGetMoviesLatest getMoviesLatest, IGetAllCategories getAllCategories, IGetAuthenticationToken getAuthenticationToken, ICreateSession createSession, INavigationManager navigationManager, ILocalStorage localStorage)
        {
            _getMoviesTopFiveDay = getMoviesTopFiveDay;
            _getMoviesLatest = getMoviesLatest;
            _getAllCategories = getAllCategories;
            _navigationManager = navigationManager;
            EachMoviesTopFive();
            EachMoviesLatest();
            EachAllCategories();
        }

        [RelayCommand]
        public async void Detail()
        {
            var id = MovieSelected.Id;
            var paramsNavigation = new Dictionary<string, object>();
            paramsNavigation["Id"] = id;
            await _navigationManager.GoToPage("details", paramsNavigation);
        }

        [RelayCommand]
        public async void MoviesByCategory()
        {
            var queryParams = new Dictionary<string, object>();
            queryParams["genreId"] = categorySelected.Id;
            await _navigationManager.GoToPage("movies-by-genres", queryParams);
        }
        private void EachMoviesTopFive()
        {
            var result = _getMoviesTopFiveDay.Execute();
            result.Wait();
            var moviesResponse = result.Result.Data;

            if (moviesResponse != null)
                MoviesTopFive = MovieMapper.ToMap(moviesResponse);
        }

        private void EachMoviesLatest()
        {
            var result = _getMoviesLatest.Execute();
            result.Wait();
            var moviesResponse = result.Result.Data;

            MoviesLatest = MovieMapper.ToMap(moviesResponse);

        }

        private void EachAllCategories()
        {
            var result = _getAllCategories.Execute();
            result.Wait();
            var categoriesResponse = result.Result.Genres;
            Categories = CategoryMapper.ToMap(categoriesResponse.ToList());
        }

        

    }
}
