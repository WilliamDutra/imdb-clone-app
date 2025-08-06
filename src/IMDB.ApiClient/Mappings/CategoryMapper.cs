using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient.Mappings
{
    public class CategoryMapper
    {
        public static ObservableCollection<Category> ToMap(List<GetAllCategories.Generes> response)
        {
            var categories = new ObservableCollection<Category>();

            foreach (var item in response)
            {

                categories.Add(Category.Restore(item.Id, item.Name));
            }

            return categories;
        }
    }
}
