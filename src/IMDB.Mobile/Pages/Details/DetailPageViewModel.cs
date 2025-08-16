using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.AddMovieToList;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMovieById;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.Mappings;
using System;
using System.Collections.ObjectModel;

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

        [ObservableProperty]
        private ObservableCollection<MyList> myLists;

        [ObservableProperty]
        private MyList listSelected;

        private IGetMovieById _getMovieById;

        private IGetAccount _getAccount;

        private IAddMovieToList _addMovieToList;

        private IGetMyLists _getMyLists;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        private int MovieId = 0;

        public DetailPageViewModel(IGetMovieById getMovieById, IAddMovieToList addMovieToList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager, IPopupService popupService)
        {
            _getMovieById = getMovieById;
            _addMovieToList = addMovieToList;
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            _navigationManager = navigationManager;
            _popupService = popupService;
            EachLists();
        }

        [RelayCommand]
        public async void BackToHomePage()
        {
            await _navigationManager.GoToPage("..");
        }

        [RelayCommand]
        public async void AddToMyList()
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;
            var listId = ListSelected.Id;
            await _addMovieToList.Execute(sessionId, listId, new AddMovie { MediaId = MovieId });
            var toast = Toast.Make(string.Format(IMDB.Mobile.Resources.Resource.film_add_with_success_message, ListSelected.Name), ToastDuration.Short);
            await toast.Show();
        }

        public void EachLists()
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;
            var responseAccount = _getAccount.Execute(sessionId);
            responseAccount.Wait();
            var responseLists = _getMyLists.Execute(responseAccount.Result.Id);
            responseLists.Wait();
            MyLists = ListsMapper.ToMap(responseLists.Result);
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
