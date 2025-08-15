using System;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.GetAuthenticationToken;

namespace IMDB.Mobile.Pages.Login
{
    public partial class LoginPageViewModel : ViewModel
    {
        private ICreateSession _createSession;

        private IGetAuthenticationToken _getAuthenticationToken;

        private ILocalStorage _localStorage;

        public LoginPageViewModel(ICreateSession createSession, IGetAuthenticationToken getAuthenticationToken, ILocalStorage localStorage)
        {
            _createSession = createSession;
            _getAuthenticationToken = getAuthenticationToken;
            _localStorage = localStorage;
        }

        [RelayCommand]
        public async void Login()
        {
            var autenticationResponse = await _getAuthenticationToken.Execute();

            var token = autenticationResponse.RequestToken;

            var authUrl = $"https://www.themoviedb.org/authenticate/{token}?redirect_to=imdb://auth";
            var options = new WebAuthenticatorOptions
            {
                CallbackUrl = new Uri("imdb://auth"),
                Url = new Uri(authUrl)
            };

            var autentication = await WebAuthenticator.AuthenticateAsync(options);

            var requestToken = autentication.Properties["request_token"];

            var resultado = await _createSession.Execute(new CreateSession { RequestToken = requestToken });

            if (!string.IsNullOrEmpty(resultado.SessionId))
            {
                await SecureStorage.Default.SetAsync("session_id", resultado.SessionId);
                var currentWindow = Application.Current.Windows.FirstOrDefault();
                currentWindow.Page = new AppShell();
            }
        }

    }
}
