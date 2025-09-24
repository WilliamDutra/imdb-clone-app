using IMDB.Mobile.Pages;
using Plugin.Firebase.RemoteConfig;

namespace IMDB.Mobile
{
    public partial class App : Application
    {
        private IShellManager _shellManager;

        private AppShellViewModel _appShellViewModel;

        public App(IShellManager shellManager, AppShellViewModel appShellViewModel)
        {
            InitializeComponent();
            UseFirebaseRemoteConfig();
            _shellManager = shellManager;
            _appShellViewModel = appShellViewModel;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;

            if (!string.IsNullOrEmpty(sessionId))
            {
                return new Window(new AppShell(_appShellViewModel));
            }
            else
            {
                return new Window(new LoginAppShell());
            }
        }

        private async Task UseFirebaseRemoteConfig()
        {
            var remoteConfig = CrossFirebaseRemoteConfig.Current;

            await remoteConfig.EnsureInitializedAsync();
            await remoteConfig.FetchAsync();
            await remoteConfig.ActivateAsync();
        }

    }
}