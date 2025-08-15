using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.CreateList;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.Mappings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Pages.MyLists
{
    public partial class MyListsPageViewModel : ViewModel
    {
        private ICreateList _createList;

        private IGetAccount _getAccount;

        private IGetMyLists _getMyLists;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        public ObservableCollection<MyList> lists;

        public MyListsPageViewModel(ICreateList createList, IGetAccount getAccount, IGetMyLists getMyLists)
        {
            _createList = createList;
            _getAccount = getAccount;
            _getMyLists = getMyLists;
            EachMyLists();
        }

        [RelayCommand]
        public async void CreateList()
        {
            var list = new ApiClient.CreateList.List();
            list.Name = Name;
            list.Description = "lista padrão";
            list.Iso6391 = "pt";
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            await _createList.Execute(list, sessionId);
            EachMyLists();
        }

        public void EachMyLists()
        {
            var sessionId = SecureStorage.Default.GetAsync("session_id").Result;
            var responseAccount = _getAccount.Execute(sessionId);
            responseAccount.Wait();
            var accountId = responseAccount.Result.Id;
            var responseList = _getMyLists.Execute(accountId);
            responseList.Wait();
            var lists = responseList.Result;
            Lists = ListsMapper.ToMap(lists);
        }
    }
}
