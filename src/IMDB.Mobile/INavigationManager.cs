using System;

namespace IMDB.Mobile
{
    public interface INavigationManager
    {
        Task GoToPage(string pageName);

        Task GoToPage(string pageName, Dictionary<string, object> @params);
    }
}
