using IMDB.Mobile.Pages;

namespace IMDB.Mobile
{
    public partial class App : Application
    {
        private IShellManager _shellManager;

        public App(IShellManager shellManager)
        {
            InitializeComponent();
            _shellManager = shellManager;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;

            if (!string.IsNullOrEmpty(sessionId))
            {
                return new Window(new AppShell());
            }
            else
            {
                return new Window(new LoginAppShell());
            }
        }
    }
}