using IMDB.Mobile.Pages;
using System;

namespace IMDB.Mobile
{
    public class ShellManager : IShellManager
    {
        public async Task SwitchAuthorizeShellRoutes() => Application.Current.MainPage = new AppShell();


        public async Task SwitchUnAuthorizeShellRoutes() => Application.Current.MainPage = new LoginAppShell();
        
    }
}
