using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.GetAccount;

namespace IMDB.Mobile.Pages
{
    public partial class AppShellViewModel : ObservableObject
    {
        private IGetAccount _getAccount;

        [ObservableProperty]
        private string username;

        public AppShellViewModel(IGetAccount getAccount)
        {
            _getAccount = getAccount;
        }

        [RelayCommand]
        public async Task Initialize()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var account = await _getAccount.Execute(sessionId);
            Username = account.Username;
        }

        [RelayCommand]
        public async Task Sair()
        {
            await SecureStorage.Default.SetAsync("session_id", "");
            Application.Current.MainPage = new LoginAppShell();
        }

    }
}
