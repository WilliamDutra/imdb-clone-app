using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Resources.Styles.Handlers
{
    public class TabBarCustomHandler
    {
        public static void Customize()
        {
            Microsoft.Maui.Handlers.TabbedViewHandler.Mapper.Add("TabBarCustomHandler", (handler, tab) =>
            {

            });
        }
    }
}
