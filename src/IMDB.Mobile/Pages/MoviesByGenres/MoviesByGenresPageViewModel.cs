using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.GetMoviesByGenres;
using IMDB.ApiClient.Mappings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Pages.MoviesByGenres
{
    public partial class MoviesByGenresPageViewModel : ObservableObject, IQueryAttributable
    {

        private IGetMoviesByGenres _getMoviesByGenres;

        [ObservableProperty]
        private ObservableCollection<Movie> movies;

        private int TotalPages  = 0;

        public MoviesByGenresPageViewModel(IGetMoviesByGenres getMoviesByGenres)
        {
            _getMoviesByGenres = getMoviesByGenres;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int genreId = (int)query["genreId"];
            EachMoviesByGenres(genreId);
        }

        [RelayCommand]
        public async void RemainingItems()
        {
            await Toast.Make($"página {TotalPages = TotalPages - 1}", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }

        private async void EachMoviesByGenres(int genreId)
        {
            var results = await _getMoviesByGenres.Execute(genreId);
            TotalPages = results.TotalPages;
            Movies = MovieMapper.ToMap(results.Data);
        }
    }
}
