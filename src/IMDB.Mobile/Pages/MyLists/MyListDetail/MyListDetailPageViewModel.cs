using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.DeleteMovieOfList;
using IMDB.ApiClient.GetListById;
using IMDB.ApiClient.Mappings;
using IMDB.Mobile.Popups.ConfirmDeleteMovieInMyList;
using System;
using System.Collections.ObjectModel;

namespace IMDB.Mobile.Pages.MyLists.MyListDetail
{
    public partial class MyListDetailPageViewModel : ViewModel, IQueryAttributable
    {
        private IGetListById _getListById;

        private IDeleteMovieOfList _deleteMovieOfList;

        private INavigationManager _navigationManager;

        private IPopupService _popupService;

        [ObservableProperty]
        private MyList listDetail;

        [ObservableProperty]
        private string listName;

        private int ListId;

        [ObservableProperty]
        private ObservableCollection<string> fakeDetailsList;

        public MyListDetailPageViewModel(IGetListById getListById, INavigationManager navigationManager, IDeleteMovieOfList deleteMovieOfList, IPopupService popupService)
        {
            _getListById = getListById;
            _deleteMovieOfList = deleteMovieOfList;
            _navigationManager = navigationManager;
            _popupService = popupService;
        }

        [RelayCommand]
        public async Task BackToHomePage()
        {
            await _navigationManager.GoToPage("..");
        }

        [RelayCommand]
        public async Task Delete(int movieId)
        {
            var result = await _popupService.ShowPopupAsync<ConfirmDeleteMovieInMyListPopupViewModel, ConfirmOptionResult>(Shell.Current);

            if (result?.Result == ConfirmOptionResult.Ok)
            {
                await _deleteMovieOfList.Execute(ListId, new MovieRequest { MediaId = movieId });
                await GetListById(ListId);
            }
        }

        [RelayCommand]
        private async Task Initialize()
        {
            IsBusy = true;
            await EachFakeDetailsList();
            IsBusy = false;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var listId = Convert.ToInt32(query["ListId"].ToString());
            Task.Run(async () =>
            {
                IsBusy = true;
                ListId = listId;
                var name = query["ListName"].ToString();
                ListName = name;
                await EachFakeDetailsList();
                await GetListById(listId);
                IsBusy = false;
            });
        }

        private async Task GetListById(int listId)
        {
            var response = await _getListById.Execute(listId);
            ListDetail = ListsMapper.ToMap(response);
        }

        private async Task EachFakeDetailsList()
        {
            FakeDetailsList = new ObservableCollection<string>();
            FakeDetailsList.Add("01");
            FakeDetailsList.Add("02");
            FakeDetailsList.Add("03");
            FakeDetailsList.Add("04");
            FakeDetailsList.Add("05");
            FakeDetailsList.Add("06");
            FakeDetailsList.Add("07");
            FakeDetailsList.Add("08");
            FakeDetailsList.Add("09");
            FakeDetailsList.Add("10");
            await Task.CompletedTask;
        }

    }
}
