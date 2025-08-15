using System;
using IMDB.ApiClient.GetMovieById;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.AddMovieToList;
using CommunityToolkit.Maui.Core;
using IMDB.Mobile.Popups.MyLists;

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

        private IAddMovieToList _addMovieToList;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        private int MovieId = 0;

        public DetailPageViewModel(IGetMovieById getMovieById, IAddMovieToList addMovieToList, INavigationManager navigationManager, IPopupService popupService)
        {
            _getMovieById = getMovieById;
            _addMovieToList = addMovieToList;
            _navigationManager = navigationManager;
            _popupService = popupService;
        }

        [RelayCommand]
        public async void BackToHomePage()
        {
            await _navigationManager.GoToPage("home");
        }

        [RelayCommand]
        public async void AddToMyList()
        {
            _popupService.ShowPopup<MyListsPopupViewModel>();
        }



        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = Convert.ToInt32(query["Id"]);
            var movie = _getMovieById.Execute(id);
            movie.Wait();
            MovieId = id;
            Title = movie.Result.Title;
            Overview = movie.Result.Overview;
            Rating = "2";
            Thumbnail = $"https://image.tmdb.org/t/p/original{movie.Result.Poster}";
        }
    }
}
