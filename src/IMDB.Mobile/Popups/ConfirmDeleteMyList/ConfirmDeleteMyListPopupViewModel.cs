using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Popups.ConfirmDeleteMyList
{
    public partial class ConfirmDeleteMyListPopupViewModel : ViewModel
    {

        private IPopupService _popupService;

        [ObservableProperty]
        private string name;

        public ConfirmDeleteMyListPopupViewModel(IPopupService popupService)
        {
            _popupService = popupService;
        }


        [RelayCommand]
        public async Task Confirm()
        {
            await _popupService.ClosePopupAsync(Shell.Current, ConfirmOptionResult.Ok);
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await _popupService.ClosePopupAsync(Shell.Current, ConfirmOptionResult.Cancel);
        }
    }
}
