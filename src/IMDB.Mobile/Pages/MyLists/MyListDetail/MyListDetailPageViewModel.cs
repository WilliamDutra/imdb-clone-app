using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IMDB.ApiClient;
using IMDB.ApiClient.DeleteMovieOfList;
using IMDB.ApiClient.GetListById;
using IMDB.ApiClient.Mappings;
using System;
using System.Collections.ObjectModel;
using static Java.Util.Jar.Attributes;

namespace IMDB.Mobile.Pages.MyLists.MyListDetail
{
    public partial class MyListDetailPageViewModel : ViewModel, IQueryAttributable
    {
        private IGetListById _getListById;

        private IDeleteMovieOfList _deleteMovieOfList;

        private INavigationManager _navigationManager;

        [ObservableProperty]
        private MyList listDetail;

        [ObservableProperty]
        private string listName;

        private int ListId;

        public MyListDetailPageViewModel(IGetListById getListById, INavigationManager navigationManager, IDeleteMovieOfList deleteMovieOfList)
        {
            _getListById = getListById;
            _deleteMovieOfList = deleteMovieOfList;
            _navigationManager = navigationManager;
        }

        [RelayCommand]
        public async Task BackToHomePage()
        {
            await _navigationManager.GoToPage("..");
        }

        [RelayCommand]
        public async Task Delete(int movieId)
        {
            await _deleteMovieOfList.Execute(ListId, new MovieRequest { MediaId = movieId });
            GetList(ListId);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var listId = Convert.ToInt32(query["ListId"].ToString());
            ListId = listId;
            var name = query["ListName"].ToString();
            ListName = name;
            GetList(listId);
        }

        private void GetList(int listId)
        {
            var response = _getListById.Execute(listId);
            response.Wait();
            ListDetail = ListsMapper.ToMap(response.Result);
        }
    }
}
