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

        private ISearchByTitle _searchByTitle;

        public SearchPageViewModel(ISearchByTitle searchByTitle)
        {
            _searchByTitle = searchByTitle;
        }

        [RelayCommand]
        public async Task SearchFilms()
        {
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
            Movies = MovieMapper.ToMap(films.Data);
        }

    }
}
