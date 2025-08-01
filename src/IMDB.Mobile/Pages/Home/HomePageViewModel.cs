using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.GetMoviesLatest;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using IMDB.ApiClient.Mappings;
using System;
using System.Collections.ObjectModel;

namespace IMDB.Mobile.Pages.Home
{
    public partial class HomePageViewModel : ObservableObject
    {
        private IGetMoviesTopFiveDay _getMoviesTopFiveDay;

        private IGetMoviesLatest _getMoviesLatest;

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesTopFive;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesLatest;

        [ObservableProperty]
        private Movie movieSelected;

        public HomePageViewModel(IGetMoviesTopFiveDay getMoviesTopFiveDay, IGetMoviesLatest getMoviesLatest, INavigationManager navigationManager)
        {
            _getMoviesTopFiveDay = getMoviesTopFiveDay;
            _getMoviesLatest = getMoviesLatest;
            _navigationManager = navigationManager;
            EachMoviesTopFive();
            EachMoviesLatest();
        }

        [RelayCommand]
        public void Detail()
        {
            var id = MovieSelected.Id;
            var paramsNavigation = new Dictionary<string, object>();
            paramsNavigation["Id"] = id;
            _navigationManager.GoToPage("details", paramsNavigation);
        }

        private void EachMoviesTopFive()
        {
            var result = _getMoviesTopFiveDay.Execute();
            result.Wait();
            var moviesResponse = result.Result.Data;

            if(moviesResponse != null )
                MoviesTopFive = MovieMapper.ToMap(moviesResponse);
        }

        private void EachMoviesLatest()
        {
            var result = _getMoviesLatest.Execute();
            result.Wait();
            var moviesResponse = result.Result.Data;

            MoviesLatest = MovieMapper.ToMap(moviesResponse);

        }

    }
}
