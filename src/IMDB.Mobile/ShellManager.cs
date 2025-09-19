using IMDB.Mobile.Pages;
using System;

namespace IMDB.Mobile
{
    public class ShellManager : IShellManager
    {
        private AppShellViewModel _appShellViewModel;

        public ShellManager(AppShellViewModel appShellViewModel)
        {
            _appShellViewModel = appShellViewModel;
        }

        public async Task SwitchAuthorizeShellRoutes() => Application.Current.MainPage = new AppShell(_appShellViewModel);


        public async Task SwitchUnAuthorizeShellRoutes() => Application.Current.MainPage = new LoginAppShell();
        
    }
}
