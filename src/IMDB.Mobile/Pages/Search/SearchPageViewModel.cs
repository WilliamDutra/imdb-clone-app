using System;
using IMDB.ApiClient;
using IMDB.ApiClient.Mappings;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.SearchByTitle;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace IMDB.Mobile.Pages.Search
{
    public partial class SearchPageViewModel : ViewModel
    {
        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private int totalSearched;

        [ObservableProperty]
        private ObservableCollection<Movie> movies;

        [ObservableProperty]
        private ObservableCollection<string> fakeSearchFilms;

        [ObservableProperty]
        private Movie movieSelected;

        private ISearchByTitle _searchByTitle;

        private INavigationManager _navigationManager;

        public SearchPageViewModel(ISearchByTitle searchByTitle, INavigationManager navigationManager)
        {
            _searchByTitle = searchByTitle;
            _navigationManager = navigationManager;
            IsBusy = false;
        }

        [RelayCommand]
        public async Task SearchFilms()
        {
            IsBusy = true;
            var film = SearchText;

            if (string.IsNullOrEmpty(film))
            {
                Movies.Clear();
                TotalSearched = 0;
                return;
            }

            if (film.Count() < 5)
                return;
            
            var films = await _searchByTitle.Execute(film);
            TotalSearched = films.TotalResults;
            await Task.Run(() =>
            {
                Movies = MovieMapper.ToMap(films.Data.ToList());
            });
            IsBusy = false;

            await Task.Delay(3000);
        }

        [RelayCommand]
        public async Task Detail()
        {
            var parameters = new Dictionary<string, object>();
            parameters["Id"] = MovieSelected.Id;
            await _navigationManager.GoToPage("details", parameters);
        }

    }
}
