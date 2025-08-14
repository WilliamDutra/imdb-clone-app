using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.GetAuthenticationToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Pages.Login
{
    public partial class LoginPageViewModel : ViewModel
    {
        private ICreateSession _createSession;

        private IGetAuthenticationToken _getAuthenticationToken;

        private ILocalStorage _localStorage;

        private INavigationManager _navigationManager;

        public LoginPageViewModel(ICreateSession createSession, IGetAuthenticationToken getAuthenticationToken, ILocalStorage localStorage, INavigationManager navigationManager)
        {
            _createSession = createSession;
            _getAuthenticationToken = getAuthenticationToken;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            CheckSession();
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

            var result = await WebAuthenticator.AuthenticateAsync(options);

            var requestToken = result.Properties["request_token"];

            var resultado = await _createSession.Execute(new CreateSession { RequestToken = requestToken });
            _localStorage.SetItem("session_id", resultado.SessionId);
        }

        private void CheckSession()
        {
            bool isLogged = !string.IsNullOrEmpty(SecureStorage.Default.GetAsync("session_id").Result) ? true : false;
            if (isLogged)
                _navigationManager.GoToPage("home");
        }

    }
}
