using System;
using IMDB.ApiClient;
using IMDB.ApiClient.Mappings;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMyLists;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace IMDB.Mobile.Popups.MyLists
{
    public partial class MyListsPopupViewModel : ViewModel
    {
        private IGetMyLists _getMyLists;

        private IGetAccount _getAccount;

        [ObservableProperty]
        private ObservableCollection<MyList> myLists;

        public MyListsPopupViewModel(IGetMyLists getMyLists, IGetAccount getAccount)
        {
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            EachLists();
        }

        public void EachLists()
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;
            var responseAccount = _getAccount.Execute(sessionId);
            responseAccount.Wait();
            var responseLists = _getMyLists.Execute(responseAccount.Result.Id);
            responseLists.Wait();
            MyLists = ListsMapper.ToMap(responseLists.Result);
        }

    }
}
