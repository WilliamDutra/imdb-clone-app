using CommunityToolkit.Mvvm.ComponentModel;
using IMDB.ApiClient.GetMovieById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Pages.Details
{
    public partial class DetailPageViewModel : ObservableObject, IQueryAttributable
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

        public DetailPageViewModel(IGetMovieById getMovieById)
        {
            _getMovieById = getMovieById;
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
