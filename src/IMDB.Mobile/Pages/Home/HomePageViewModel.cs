using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.AddMovieToList;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.GetAllCategories;
using IMDB.ApiClient.GetAuthenticationToken;
using IMDB.ApiClient.GetMoviesLatest;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using IMDB.ApiClient.Mappings;
using IMDB.Mobile.Popups.MyLists;
using System;
using System.Collections.ObjectModel;

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
            EachMoviesTopFive();
            EachMoviesLatest();
            EachAllCategories();
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
            var result = await _getMoviesTopFiveDay.Execute();
            var moviesResponse = result.Data;

            if (moviesResponse != null)
                MoviesTopFive = MovieMapper.ToMap(moviesResponse);
        }

        private async Task EachMoviesLatest()
        {
            var result = await _getMoviesLatest.Execute();
            var moviesResponse = result.Data;

            MoviesLatest = MovieMapper.ToMap(moviesResponse);

        }

        private async Task EachAllCategories()
        {
            var result = await _getAllCategories.Execute();
            var categoriesResponse = result.Genres;
            Categories = CategoryMapper.ToMap(categoriesResponse.ToList());
        }



    }
}
