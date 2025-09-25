using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.Mappings;
using Plugin.Maui.BottomSheet.Navigation;
using System;
using System.Collections.ObjectModel;

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

        private IBottomSheetNavigationService _bottomSheetNavigationService;

        public MyListsPopupViewModel(IGetMyLists getMyLists, IGetAccount getAccount, IBottomSheetNavigationService bottomSheetNavigationService)
        {
            _getMyLists = getMyLists;
            _getAccount = getAccount;
            _bottomSheetNavigationService = bottomSheetNavigationService;   
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var sessionId = query["SessionId"].ToString();

            Task.Run(async () =>
            {
                var responseAccount = await _getAccount.Execute(sessionId);
                var responseLists = await _getMyLists.Execute(responseAccount.Id, sessionId);
                MyLists = ListsMapper.ToMap(responseLists);
            });
        }

        [RelayCommand]
        public async Task SelectedList()
        {
            var selectedList = ListSelected;
            var parameters = new BottomSheetNavigationParameters();
            parameters["listSelected"] = selectedList;
            await _bottomSheetNavigationService.GoBackAsync(parameters);
        }

    }
}
