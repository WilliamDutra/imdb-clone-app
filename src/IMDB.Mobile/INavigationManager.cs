using CommunityToolkit.Maui.Core;
using System;

namespace IMDB.Mobile
{
    public interface INavigationManager
    {
        Task GoToPage(string pageName);

        Task GoToPage(string pageName, Dictionary<string, object> @params);

        Task OpenPopup<TViewModel>(Shell shell);

        Task<TResult> OpenPopup<TVieModel, TResult>(Shell shell);
    }
}
