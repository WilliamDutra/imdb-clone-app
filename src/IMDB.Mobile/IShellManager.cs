using System;

namespace IMDB.Mobile
{
    public interface IShellManager
    {
        Task SwitchUnAuthorizeShellRoutes();

        Task SwitchAuthorizeShellRoutes();

    }
}
