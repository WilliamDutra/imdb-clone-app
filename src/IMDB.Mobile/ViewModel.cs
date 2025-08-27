using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile
{
    public abstract partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isBusy;

        protected ViewModel()
        {
            IsBusy = true;
        }

    }
}
