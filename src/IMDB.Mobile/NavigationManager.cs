using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile
{
    public class NavigationManager : INavigationManager
    {
        public Task GoToPage(string pageName) => Shell.Current.GoToAsync(pageName, true);
        

        public Task GoToPage(string pageName, Dictionary<string, object> @params) => Shell.Current.GoToAsync(pageName, animate: true, parameters: @params);

    }
}
