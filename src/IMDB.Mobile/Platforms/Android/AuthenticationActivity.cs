using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace IMDB.Mobile.Platforms.Android;

[Activity(Label = "AuthenticationActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] {
        Intent.CategoryDefault,
        Intent.CategoryBrowsable
    },
    DataScheme = "imdb",
    DataHost = "auth"
)]
public class AuthenticationActivity : WebAuthenticatorCallbackActivity
{

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }
}