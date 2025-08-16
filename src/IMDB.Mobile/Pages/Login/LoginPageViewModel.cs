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

        private INavigationManager _navigationManager;

        public LoginPageViewModel(ICreateSession createSession, IGetAuthenticationToken getAuthenticationToken, ILocalStorage localStorage, INavigationManager navigationManager)
        {
            _createSession = createSession;
            _getAuthenticationToken = getAuthenticationToken;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        [RelayCommand]
        public async void Login()
        {
            var autenticationResponse = await _getAuthenticationToken.Execute();

            if (autenticationResponse.Success.HasValue && !autenticationResponse.Success.Value)
            {
                var parameters = new Dictionary<string, object>();
                parameters["errors"] = autenticationResponse.Message!;
                parameters["code"] = autenticationResponse.StatusCode!;
                await _navigationManager.GoToPage("errors", parameters);
            }

            var token = autenticationResponse.Data.RequestToken;

            var authUrl = $"https://www.themoviedb.org/authenticate/{token}?redirect_to=imdb://auth";
            var options = new WebAuthenticatorOptions
            {
                CallbackUrl = new Uri("imdb://auth"),
                Url = new Uri(authUrl)
            };

            var autentication = await WebAuthenticator.AuthenticateAsync(options);
            
            var requestToken = autentication.Properties["request_token"];

            var sessionResponse = await _createSession.Execute(new CreateSession { RequestToken = requestToken });

            if(sessionResponse.Success.HasValue && !sessionResponse.Success.Value)
            {
                var parameters = new Dictionary<string, object>();
                parameters["errors"] = sessionResponse.Message!;
                parameters["code"] = sessionResponse.StatusCode!;
                await _navigationManager.GoToPage("errors", parameters);
            }

            if (!string.IsNullOrEmpty(sessionResponse.Data.SessionId))
            {
                await SecureStorage.Default.SetAsync("session_id", sessionResponse.Data.SessionId);
                var currentWindow = Application.Current.Windows.FirstOrDefault();
                currentWindow.Page = new AppShell();
            }
        }

    }
}
