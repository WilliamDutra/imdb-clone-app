using System;
using IMDB.ApiClient.GetMovieById;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IMDB.Mobile.Pages.Details
{
    public partial class DetailPageViewModel : ViewModel, IQueryAttributable
    {

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string rating;

        [ObservableProperty]
        private string overview;

        [ObservableProperty]
        private string thumbnail;

        private IGetMovieById _getMovieById;

        private INavigationManager _navigationManager;

        public DetailPageViewModel(IGetMovieById getMovieById, INavigationManager navigationManager)
        {
            _getMovieById = getMovieById;
            _navigationManager = navigationManager;
        }

        [RelayCommand]
        public async void BackToHomePage()
        {
            await _navigationManager.GoToPage("home");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = Convert.ToInt32(query["Id"]);
            var movie = _getMovieById.Execute(id);
            movie.Wait();
            Title = movie.Result.Title;
            Overview = movie.Result.Overview;
            Rating = "2";
            Thumbnail = $"https://image.tmdb.org/t/p/original{movie.Result.Poster}";
        }
    }
}
