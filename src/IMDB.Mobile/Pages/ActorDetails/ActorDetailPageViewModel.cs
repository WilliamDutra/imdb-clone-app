using System;
using IMDB.ApiClient.GetActorById;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Pages.ActorDetails
{
    public partial class ActorDetailPageViewModel : ViewModel, IQueryAttributable
    {
        private IGetActorById _getActorById;

        [ObservableProperty]
        private string nome;

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


            var actor = _getActorById.Execute(id);
            actor.Wait();
            Nome = actor.Result.Name;
            Profile = $"{actor.Result.Profile}";
            Biography = actor.Result.Biography;
            Gender = actor.Result.Gender;

        }
    }
}
