using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Input;

namespace IMDB.Mobile.Popups.ConfirmDeleteMovieInMyList
{
    public partial class ConfirmDeleteMovieInMyListPopupViewModel : ViewModel
    {
        private IPopupService _popupService;

        public ConfirmDeleteMovieInMyListPopupViewModel(IPopupService popupService)
        {
            _popupService = popupService;
        }

        [RelayCommand]
        private async Task Confirm()
        {
            await _popupService.ClosePopupAsync(Shell.Current, ConfirmOptionResult.Ok);
        }

        [RelayCommand]
        private async Task Cancel()
        {
            await _popupService.ClosePopupAsync(Shell.Current, ConfirmOptionResult.Cancel);
        }

        
    }
}
