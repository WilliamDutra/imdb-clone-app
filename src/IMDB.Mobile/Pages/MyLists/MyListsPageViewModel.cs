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
using IMDB.ApiClient.DeleteList;

namespace IMDB.Mobile.Pages.MyLists
{
    public partial class MyListsPageViewModel : ViewModel
    {
        private ICreateList _createList;

        private IGetAccount _getAccount;

        private IGetMyLists _getMyLists;

        private IDeleteList _deleteList;

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private MyList myListSelected;

        [ObservableProperty]
        public ObservableCollection<MyList> lists;

        public MyListsPageViewModel(ICreateList createList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager, IDeleteList deleteList)
        {
            _createList = createList;
            _getAccount = getAccount;
            _getMyLists = getMyLists;
            _deleteList = deleteList;
            _navigationManager = navigationManager;
        }

        [RelayCommand]
        public async Task CreateList()
        {
            var list = new ApiClient.CreateList.List();
            list.Name = Name;
            list.Description = "lista padrão";
            list.Iso6391 = "pt";
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            await _createList.Execute(list, sessionId);
            await EachMyLists();
            var toast = Toast.Make(string.Format(Resources.Resource.list_created_with_success_menssage, Name), ToastDuration.Short);
            await toast.Show();
        }

        [RelayCommand]
        public async Task Detail()
        {
            var parameters = new Dictionary<string, object>();
            parameters["ListId"] = MyListSelected.Id;
            parameters["ListName"] = MyListSelected.Name;
            await _navigationManager.GoToPage("my-list-detail", parameters);
        }

        [RelayCommand]
        public async Task Delete(int listId)
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            await _deleteList.Execute(listId, sessionId);
            await EachMyLists();
        }

        [RelayCommand]
        public async Task Initialize()
        {
            IsBusy = true;
            await EachMyLists();
            IsBusy = false;
        }


        public async Task EachMyLists()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var responseAccount = await _getAccount.Execute(sessionId);
            var accountId = responseAccount.Id;
            var responseList = await _getMyLists.Execute(accountId, sessionId);
            var lists = responseList;
            Lists = ListsMapper.ToMap(lists);
        }
    }
}
