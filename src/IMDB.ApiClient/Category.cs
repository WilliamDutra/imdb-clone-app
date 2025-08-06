using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient
{
    public class Category
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        private Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Category Restore(int id, string name)
        {
            return new Category(id, name);  
        }

    }
}
