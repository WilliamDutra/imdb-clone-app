using System;
using IMDB.ApiClient.GetActorById;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Pages.ActorDetails
{
    public partial class ActorDetailPageViewModel : ViewModel, IQueryAttributable
    {
        private IGetActorById _getActorById;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string profile;

        [ObservableProperty]
        private string biography;

        [ObservableProperty]
        private string gender;

        public ActorDetailPageViewModel(IGetActorById getActorById)
        {
            _getActorById = getActorById;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = Convert.ToInt32(query["Id"]);

            Task.Run(async () =>
            {

                var actor = await _getActorById.Execute(id);

                Name = actor.Name;
                Profile = $"https://image.tmdb.org/t/p/w500/{actor.Profile}";
                Biography = actor.Biography;
                Gender = actor.Gender.ToString();

            });
        }
    }
}
