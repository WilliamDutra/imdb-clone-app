using System;
using IMDB.ApiClient;
using CommunityToolkit.Maui;
using IMDB.ApiClient.Mappings;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMyLists;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IMDB.Mobile.Popups.MyLists
{
    public partial class MyListsPopupViewModel : ViewModel, IQueryAttributable
    {
        private IGetMyLists _getMyLists;

        private IGetAccount _getAccount;

        [ObservableProperty]
        private ObservableCollection<MyList> myLists;

        [ObservableProperty]
        private MyList listSelected;

        private IPopupService _popupService;

        public MyListsPopupViewModel(IGetMyLists getMyLists, IGetAccount getAccount, IPopupService popupService)
        {
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            _popupService = popupService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var sessionId = query["SessionId"].ToString();
            var responseAccount = _getAccount.Execute(sessionId);
            responseAccount.Wait();
            var responseLists = _getMyLists.Execute(responseAccount.Result.Id);
            responseLists.Wait();
            MyLists = ListsMapper.ToMap(responseLists.Result);
        }

        [RelayCommand]
        public async void SelectedList()
        {
            var selectedList = ListSelected;
            await _popupService.ClosePopupAsync(Shell.Current, selectedList);
        }

    }
}
