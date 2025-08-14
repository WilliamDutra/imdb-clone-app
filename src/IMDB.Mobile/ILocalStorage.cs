using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile
{
    public interface ILocalStorage
    {
        void SetItem(string key, object value);

        T GetItem<T>(string key);
    }
}
