using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IMDB.Mobile
{
    public class LocalStorage : ILocalStorage
    {
        public async Task<T> GetItemAsync<T>(string key)
        {
            var result = await SecureStorage.Default.GetAsync(key);

            if (string.IsNullOrEmpty(result))
                return Activator.CreateInstance<T>();

            return JsonSerializer.Deserialize<T>(result) ?? Activator.CreateInstance<T>();
        }

        public T GetItem<T>(string key)
        {
            return GetItemAsync<T>(key).GetAwaiter().GetResult();
        }

        public void SetItem(string key, object value)
        {
            var storage = SecureStorage.Default.SetAsync(key, JsonSerializer.Serialize(value));
            storage.Wait();
        }
    }
}
