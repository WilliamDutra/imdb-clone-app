using System;
using IMDB.ApiClient;
using CommunityToolkit.Maui;
using IMDB.ApiClient.Mappings;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.GetAccount;
using CommunityToolkit.Maui.Core;
using IMDB.Mobile.Popups.MyLists;
using IMDB.ApiClient.GetMovieById;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.GetCastMovie;
using CommunityToolkit.Maui.Alerts;
using IMDB.ApiClient.AddMovieToList;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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
        private ObservableCollection<Actor> actors;

        private IGetMovieById _getMovieById;

        private IGetAccount _getAccount;

        private IAddMovieToList _addMovieToList;

        private IGetMyLists _getMyLists;

        private IGetCastMovie _getCastMovie;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        private int MovieId = 0;

        public DetailPageViewModel(IGetMovieById getMovieById, IAddMovieToList addMovieToList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager, IPopupService popupService, IGetCastMovie getCastMovie)
        {
            _getMovieById = getMovieById;
            _addMovieToList = addMovieToList;
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            _navigationManager = navigationManager;
            _popupService = popupService;
            _getCastMovie = getCastMovie;
        }

        [RelayCommand]
        public async void BackToHomePage()
        {
            await _navigationManager.GoToPage("..");
        }

        [RelayCommand]
        public async Task AddToMyList()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id"); ;
            var parameters = new Dictionary<string, object>();
            parameters["SessionId"] = sessionId;
            var result = await _popupService.ShowPopupAsync<MyListsPopupViewModel, MyList>(Shell.Current, new PopupOptions() { }, shellParameters: parameters);


            var listSelected = result.Result;
            var listId = listSelected.Id;
            await _addMovieToList.Execute(sessionId, listId, new AddMovie { MediaId = MovieId });
            var toast = Toast.Make(string.Format(IMDB.Mobile.Resources.Resource.film_add_with_success_message, listSelected.Name), ToastDuration.Short);
            await toast.Show();
        }

        [RelayCommand]
        public async Task Initialize()
        {
            IsBusy = true;
            await EachLists();
            IsBusy = false;
        }

        public async Task EachLists()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var responseAccount = await _getAccount.Execute(sessionId);
            var responseLists = await _getMyLists.Execute(responseAccount.Id);
            MyLists = ListsMapper.ToMap(responseLists);
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
            var cast = _getCastMovie.Execute(id);
            cast.Wait();
            Actors = MovieMapper.ToMap(cast.Result);
        }
    }
}
