using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.DeleteSession;
using IMDB.ApiClient.GetAccount;

namespace IMDB.Mobile.Pages
{
    public partial class AppShellViewModel : ObservableObject
    {
        private IGetAccount _getAccount;

        private IDeleteSession _deleteSession;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string photo;

        public AppShellViewModel(IGetAccount getAccount, IDeleteSession deleteSession)
        {
            _getAccount = getAccount;
            _deleteSession = deleteSession;
        }

        [RelayCommand]
        public async Task Initialize()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var account = await _getAccount.Execute(sessionId);
            Username = account.Username;
            Photo = $"https://www.gravatar.com/avatar/{account.Avatar.Gravatar.Hash}?s=200&d=identicon";
        }

        [RelayCommand]
        public async Task Sair()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var result = await _deleteSession.Execute(sessionId);
            await SecureStorage.Default.SetAsync("session_id", "");
            Application.Current.MainPage = new LoginAppShell();
        }

    }
}
