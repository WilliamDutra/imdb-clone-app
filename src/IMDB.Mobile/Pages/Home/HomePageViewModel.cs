using CommunityToolkit.Mvvm.ComponentModel;
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

        [ObservableProperty]
        private ObservableCollection<Movie> moviesTopFive;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesLatest;

        public HomePageViewModel(IGetMoviesTopFiveDay getMoviesTopFiveDay, IGetMoviesLatest getMoviesLatest)
        {
            _getMoviesTopFiveDay = getMoviesTopFiveDay;
            _getMoviesLatest = getMoviesLatest;
            EachMoviesTopFive();
            EachMoviesLatest();
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
