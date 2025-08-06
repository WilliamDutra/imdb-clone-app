using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Pages.Search
{
    public partial class SearchPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string searchText;

        public SearchPageViewModel()
        {
                            
        }

    }
}
