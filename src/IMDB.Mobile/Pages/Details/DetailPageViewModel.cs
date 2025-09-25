using AsyncAwaitBestPractices;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.AddMovieToList;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetCastMovie;
using IMDB.ApiClient.GetMovieById;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.Mappings;
using IMDB.Mobile.Popups.MyLists;
using Plugin.Maui.BottomSheet;
using Plugin.Maui.BottomSheet.Navigation;
using System;
using System.Collections.ObjectModel;

namespace IMDB.Mobile.Pages.Details
{
    public partial class DetailPageViewModel : ViewModel, IQueryAttributable
    {

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private int rating;

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

        private IBottomSheetNavigationService _bottomSheetNavigationService;

        private IPopupService _popupService;

        private int MovieId = 0;

        public DetailPageViewModel(IGetMovieById getMovieById, IAddMovieToList addMovieToList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager, IPopupService popupService, IGetCastMovie getCastMovie, IBottomSheetNavigationService bottomSheetNavigationService)
        {
            _getMovieById = getMovieById;
            _addMovieToList = addMovieToList;
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            _navigationManager = navigationManager;
            _popupService = popupService;
            _getCastMovie = getCastMovie;
            _bottomSheetNavigationService = bottomSheetNavigationService;
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

            var parameters = new BottomSheetNavigationParameters();
            parameters["SessionId"] = sessionId;

            await _bottomSheetNavigationService.NavigateToAsync("mylist-popup", parameters, (btm) => btm.CurrentState = BottomSheetState.Medium);
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
            if (query.ContainsKey("Id"))
            {

                var id = Convert.ToInt32(query["Id"]);

                Task.Run(async () =>
                {
                    var movie = await _getMovieById.Execute(id);
                    MovieId = id;
                    Title = movie.Title;
                    Overview = movie.Overview;
                    Rating = (int)movie.Rating;
                    Thumbnail = $"https://image.tmdb.org/t/p/w500{movie.Poster}";

                    var cast = await _getCastMovie.Execute(id);
                    Actors = MovieMapper.ToMap(cast);

                });
            }

            if (query.ContainsKey("listSelected"))
            {
                Task.Run(async () =>
                {

                    var listSelected = (MyList)query["listSelected"];
                    var sessionId = await SecureStorage.Default.GetAsync("session_id");
                    var listId = listSelected.Id;
                    await _addMovieToList.Execute(sessionId, listId, new AddMovie { MediaId = MovieId });
                    MainThread.BeginInvokeOnMainThread(() =>
                    {

                        var toast = Toast.Make(string.Format(IMDB.Mobile.Resources.Resource.film_add_with_success_message, listSelected.Name), ToastDuration.Short);
                        toast.Show();
                    });
                });
                
            }
        }
    }
}
