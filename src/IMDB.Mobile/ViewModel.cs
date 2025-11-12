using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile
{
    public abstract partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isBusy;

        public bool IsNetworkAvailable => CheckConnectionNetwork();

        protected ViewModel()
        {
            IsBusy = true;
        }

        private bool CheckConnectionNetwork()
        {
            NetworkAccess networkAccess = Connectivity.Current.NetworkAccess;
            if (networkAccess != NetworkAccess.Internet)
                return false;
            return true;
        }

    }
}
