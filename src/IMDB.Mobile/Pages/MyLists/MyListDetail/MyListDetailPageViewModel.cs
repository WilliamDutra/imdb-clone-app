using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using IMDB.ApiClient;
using IMDB.ApiClient.GetListById;
using IMDB.ApiClient.Mappings;

namespace IMDB.Mobile.Pages.MyLists.MyListDetail
{
    public partial class MyListDetailPageViewModel : ViewModel, IQueryAttributable
    {
        private IGetListById _getListById;

        [ObservableProperty]
        private MyList listDetail;

        public MyListDetailPageViewModel(IGetListById getListById)
        {
            _getListById = getListById;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var listId = Convert.ToInt32(query["ListId"].ToString());
            var response = _getListById.Execute(listId);
            response.Wait();

            ListDetail = ListsMapper.ToMap(response.Result);

        }
    }
}
