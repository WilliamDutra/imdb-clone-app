using System;
using CommunityToolkit.Mvvm.Input;

namespace IMDB.Mobile.Pages.Errors.NetworkUnavailable
{
    public partial class NetworkUnavailablePageViewModel : ViewModel
    {

        private INavigationManager _navigationManager;

        public NetworkUnavailablePageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        [RelayCommand]
        public async Task TryOut()
        {
            bool network = IsNetworkAvailable;
            if (!network)
                return;
            await _navigationManager.GoToPage("login");
        }

    }
}
