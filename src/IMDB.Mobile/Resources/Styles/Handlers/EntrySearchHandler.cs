using System;
using Microsoft.Maui.Platform;

namespace IMDB.Mobile.Resources.Styles.Handlers
{
    public class EntrySearchHandler
    {
        public static void Customize()
        {
            #if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.Add("EntrySearch", (handler, entry) =>
            {
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
            });
            #endif
        }
    }
}
