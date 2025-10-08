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
using CommunityToolkit.Maui;
using IMDB.Mobile.Popups.ConfirmDeleteMyList;
using IMDB.Mobile.Popups;

namespace IMDB.Mobile.Pages.MyLists
{
    public partial class MyListsPageViewModel : ViewModel
    {
        private ICreateList _createList;

        private IGetAccount _getAccount;

        private IGetMyLists _getMyLists;

        private IDeleteList _deleteList;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        public ObservableCollection<MyList> lists;

        [ObservableProperty]
        private ObservableCollection<string> fakeLists;

        public MyListsPageViewModel(ICreateList createList, IGetAccount getAccount, IGetMyLists getMyLists, INavigationManager navigationManager, IDeleteList deleteList, IPopupService popupService)
        {
            _createList = createList;
            _getAccount = getAccount;
            _getMyLists = getMyLists;
            _deleteList = deleteList;
            _navigationManager = navigationManager;
            _popupService = popupService;
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
            Name = string.Empty;
            IsBusy = true;
            await EachMyLists();
            var toast = Toast.Make(string.Format(Resources.Resource.list_created_with_success_menssage, Name), ToastDuration.Short);
            await toast.Show();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task Detail(MyList myListSelected)
        {
            var parameters = new Dictionary<string, object>();
            parameters["ListId"] = myListSelected.Id;
            parameters["ListName"] = myListSelected.Name;
            await _navigationManager.GoToPage("my-list-detail", parameters);
        }

        [RelayCommand]
        public async Task Delete(MyList myListSelected)
        {
            var result = await _popupService.ShowPopupAsync<ConfirmDeleteMyListPopupViewModel, ConfirmOptionResult>(Shell.Current);

            if(result.Result == ConfirmOptionResult.Ok)
            {
                var sessionId = await SecureStorage.Default.GetAsync("session_id");
                await _deleteList.Execute(myListSelected.Id, sessionId);
                IsBusy = true;
                await EachMyLists();
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task Initialize()
        {
            IsBusy = true;
            await EachFakeLists();
            await EachMyLists();
            IsBusy = false;
        }


        private async Task EachMyLists()
        {
            var sessionId = await SecureStorage.Default.GetAsync("session_id");
            var responseAccount = await _getAccount.Execute(sessionId);
            var accountId = responseAccount.Id;
            var responseList = await _getMyLists.Execute(accountId, sessionId);
            var lists = responseList;
            Lists = ListsMapper.ToMap(lists);
        }

        private async Task EachFakeLists()
        {
            FakeLists = new ObservableCollection<string>();
            FakeLists.Add("01");
            FakeLists.Add("02");
            FakeLists.Add("03");
            FakeLists.Add("04");
            FakeLists.Add("05");
            FakeLists.Add("06");
            FakeLists.Add("07");
            await Task.CompletedTask;
        }
    }
}
