using System;

namespace IMDB.ApiClient
{
    public class WatchProvider
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public WatchProvider(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static WatchProvider Restore(int id, string name)
        {
            return new WatchProvider(id, name);
        }
    }
}
