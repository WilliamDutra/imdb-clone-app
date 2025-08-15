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
        public static ObservableCollection<MyList> ToMap(Response<GetMyLists.List>? response)
        {
            var lists = new ObservableCollection<MyList>();

            foreach (var item in response.Data)
            {
                lists.Add(MyList.Restore(item.Id, item.Name, item.Description, item.ItemCount));
            }

            return lists;
        }
    }
}
