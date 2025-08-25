using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.ApiClient
{
    public class Actor
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Photo { get; private set; }

        private Actor(int id, string name, string photo)
        {
            Id = id;
            Name = name;
            Photo = photo;
        }

        public static Actor Restore(int id, string name, string photo)
        {
            return new Actor(id, name, photo);
        }
    }
}
