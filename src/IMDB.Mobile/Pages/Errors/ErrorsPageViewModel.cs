using System;

namespace IMDB.Mobile.Pages.Errors
{
    public partial class ErrorsPageViewModel : ViewModel, IQueryAttributable
    {
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var message = query["errors"];
        }
    }
}
