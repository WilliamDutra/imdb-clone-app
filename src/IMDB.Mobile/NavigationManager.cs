using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile
{
    public class NavigationManager : INavigationManager
    {
        private IPopupService _popupService;

        public NavigationManager(IPopupService popupService)
        {
            _popupService = popupService;
        }

        public Task GoToPage(string pageName) => Shell.Current.GoToAsync(pageName, true);
        
        public Task GoToPage(string pageName, Dictionary<string, object> @params) => Shell.Current.GoToAsync(pageName, animate: true, parameters: @params);

        public async Task OpenPopup<TViewModel>(Shell shell) => await _popupService.ShowPopupAsync<TViewModel>(shell);

        public async Task<TResult> OpenPopup<TVieModel, TResult>(Shell shell) 
        { 
            var popup = await _popupService.ShowPopupAsync<TVieModel, TResult>(shell);
            return popup.Result;
        }
        
    }
}
