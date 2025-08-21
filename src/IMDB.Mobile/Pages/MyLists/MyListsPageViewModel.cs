using System;
using IMDB.ApiClient;
using IMDB.ApiClient.Mappings;
using IMDB.ApiClient.CreateList;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMyLists;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Pages.MyLists
{
    public partial class MyListsPageViewModel : ViewModel
    {
        private ICreateList _createList;

        private IGetAccount _getAccount;

        private IGetMyLists _getMyLists;

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private MyList myListSelected;

        [ObservableProperty]
        public ObservableCollection<MyList> lists;

        public MyListsPageViewModel(ICreateList createList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager)
        {
            _createList = createList;
            _getAccount = getAccount;
            _getMyLists = getMyLists;
            _navigationManager = navigationManager;
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
            var toast = Toast.Make(string.Format(Resources.Resource.list_created_with_success_menssage, Name), ToastDuration.Short);
            await toast.Show();
        }

        [RelayCommand]
        public async void Detail()
        {
            var parameters = new Dictionary<string, object>();
            parameters["ListId"] = MyListSelected.Id;
            await _navigationManager.GoToPage("my-list-detail", parameters);
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
