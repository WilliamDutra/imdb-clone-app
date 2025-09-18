using IMDB.ApiClient.GetMyLists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.Mappings
{
    public static class ListsMapper
    {
        public static ObservableCollection<MyList> ToMap(TmdbResponse<List<GetMyLists.List>>? response)
        {
            var lists = new ObservableCollection<MyList>();

            foreach (var item in response.Data)
            {
                lists.Add(MyList.Restore(item.Id, item.Name, item.Description, item.ItemCount));
            }

            return lists;
        }

        public static MyList ToMap(GetListById.ListById response)
        {
            var myList = MyList.Restore(response.Id, "", "", response.FavoriteCount);

            foreach (var item in response.Items)
            {
                myList.AddMovie(item.Id, item.Title, item.Overview, $"https://image.tmdb.org/t/p/original{item.Poster}", 0);
            }

            return myList;
        }
    }
}
