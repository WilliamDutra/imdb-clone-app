using System;
using IMDB.ApiClient;
using CommunityToolkit.Maui;
using IMDB.ApiClient.Mappings;
using CommunityToolkit.Maui.Core;
using IMDB.Mobile.Popups.MyLists;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.AddMovieToList;
using IMDB.ApiClient.GetMoviesLatest;
using System.Collections.ObjectModel;
using IMDB.ApiClient.GetAllCategories;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using CommunityToolkit.Mvvm.ComponentModel;
using IMDB.ApiClient.GetAuthenticationToken;


namespace IMDB.Mobile.Pages.Home
{
    public partial class HomePageViewModel : ViewModel
    {
        private IGetMoviesTopFiveDay _getMoviesTopFiveDay;

        private IGetMoviesLatest _getMoviesLatest;

        private IGetAllCategories _getAllCategories;

        private IAddMovieToList _addMovieToList;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        [ObservableProperty]
        private ObservableCollection<string> fakeTopFive;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesTopFive;

        [ObservableProperty]
        private ObservableCollection<Movie> moviesLatest;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private Category categorySelected;

        public HomePageViewModel(IGetMoviesTopFiveDay getMoviesTopFiveDay, IGetMoviesLatest getMoviesLatest, IGetAllCategories getAllCategories, IGetAuthenticationToken getAuthenticationToken, ICreateSession createSession, INavigationManager navigationManager, ILocalStorage localStorage, IPopupService popupService, IAddMovieToList addMovieToList)
        {
            _getMoviesTopFiveDay = getMoviesTopFiveDay;
            _getMoviesLatest = getMoviesLatest;
            _getAllCategories = getAllCategories;
            _navigationManager = navigationManager;
            _popupService = popupService;
            _addMovieToList = addMovieToList;
        }

        [RelayCommand]
        public async void Detail(Movie movie)
        {
            var id = movie.Id;
            var paramsNavigation = new Dictionary<string, object>();
            paramsNavigation["Id"] = id;
            await _navigationManager.GoToPage("details", paramsNavigation);
        }

        [RelayCommand]
        public async void MoviesByCategory()
        {
            var queryParams = new Dictionary<string, object>();
            queryParams["genreId"] = categorySelected.Id;
            queryParams["genreName"] = categorySelected.Name;
            await _navigationManager.GoToPage("movies-by-genres", queryParams);
        }

        [RelayCommand]
        public async void Add(Movie movie)
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var parameters = new Dictionary<string, object>();
            parameters["SessionId"] = sessionId;
            var optionSelected = await _popupService.ShowPopupAsync<MyListsPopupViewModel, MyList>(shell: Shell.Current, options: new PopupOptions(), shellParameters: parameters);
            var listSelected = optionSelected.Result;
            await _addMovieToList.Execute(sessionId, listSelected.Id, new AddMovie { MediaId = movie.Id });
            var toast = Toast.Make(string.Format(IMDB.Mobile.Resources.Resource.film_add_with_success_message, listSelected.Name), ToastDuration.Short);
            await toast.Show();
        }

        private async Task EachMoviesTopFive()
        {
            IsBusy = true;
            var result = await _getMoviesTopFiveDay.Execute();
            var moviesResponse = result.Data;

            if (moviesResponse != null)
                MoviesTopFive = MovieMapper.ToMap(moviesResponse);

            IsBusy = false;
        }

        private async Task EachMoviesLatest()
        {
            IsBusy = true;
            var result = await _getMoviesLatest.Execute();
            var moviesResponse = result.Data;

            MoviesLatest = MovieMapper.ToMap(moviesResponse);
            IsBusy = false;
        }

        private async Task EachAllCategories()
        {
            var result = await _getAllCategories.Execute();
            var categoriesResponse = result.Genres;
            Categories = CategoryMapper.ToMap(categoriesResponse.ToList());
        }

        [RelayCommand]
        public async Task Initialize()
        {
            await EachFakeTopFive();
            await EachMoviesTopFive();
            await EachMoviesLatest();
            await EachAllCategories();
        }

        private async Task EachFakeTopFive()
        {
            FakeTopFive = new ObservableCollection<string>();
            await Task.Run(() =>
            {
                FakeTopFive.Add("01");
                FakeTopFive.Add("02");
                FakeTopFive.Add("03");
                FakeTopFive.Add("04");
            });
        }

    }
}
