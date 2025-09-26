using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using IMDB.ApiClient.AddMovieToList;
using IMDB.ApiClient.CreateList;
using IMDB.ApiClient.CreateSession;
using IMDB.ApiClient.DeleteList;
using IMDB.ApiClient.DeleteMovieOfList;
using IMDB.ApiClient.GetAccessToken;
using IMDB.ApiClient.GetAccount;
using IMDB.ApiClient.GetAllCategories;
using IMDB.ApiClient.GetAuthenticationToken;
using IMDB.ApiClient.GetCastMovie;
using IMDB.ApiClient.GetListById;
using IMDB.ApiClient.GetMovieById;
using IMDB.ApiClient.GetMoviesByGenres;
using IMDB.ApiClient.GetMoviesLatest;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using IMDB.ApiClient.GetMyLists;
using IMDB.ApiClient.SearchByTitle;
using IMDB.Mobile.Networks;
using IMDB.Mobile.Pages;
using IMDB.Mobile.Pages.Details;
using IMDB.Mobile.Pages.Errors;
using IMDB.Mobile.Pages.Home;
using IMDB.Mobile.Pages.Login;
using IMDB.Mobile.Pages.MoviesByGenres;
using IMDB.Mobile.Pages.MyLists;
using IMDB.Mobile.Pages.MyLists.MyListDetail;
using IMDB.Mobile.Pages.Search;
using IMDB.Mobile.Popups.MyLists;
using IMDB.Mobile.Resources.Styles.Handlers;
#if ANDROID
using Plugin.Firebase.Core.Platforms.Android;
#endif
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Maui.BottomSheet.Hosting;
using Refit;
using SkiaSharp.Views.Maui.Controls.Hosting;
using IMDB.Mobile.Popups.ConfirmDeleteMovieInMyList;

namespace IMDB.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .UseFFImageLoading()
                .UseBottomSheet()
                .AddPages()
                .AddPopups()
                .AddApiClient()
                .AddFirebaseServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Black.ttf", "PoppinsBlack");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                })
                .ConfigureMauiHandlers((config) =>
                {
                    EntrySearchHandler.Customize();
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder AddPages(this MauiAppBuilder appBuilder)
        {
            appBuilder.Services.AddSingleton<INavigationManager, NavigationManager>();
            appBuilder.Services.AddSingleton<IShellManager, ShellManager>();
            appBuilder.Services.AddTransient<AppShellViewModel>();

            appBuilder.Services.AddTransientWithShellRoute<LoginPage, LoginPageViewModel>("login");
            appBuilder.Services.AddTransientWithShellRoute<ErrorsPage, ErrorsPageViewModel>("errors");
            appBuilder.Services.AddTransientWithShellRoute<HomePage, HomePageViewModel>("home");
            appBuilder.Services.AddTransientWithShellRoute<DetailPage, DetailPageViewModel>("details");
            appBuilder.Services.AddTransientWithShellRoute<SearchPage, SearchPageViewModel>("search");
            appBuilder.Services.AddTransientWithShellRoute<MyListsPage, MyListsPageViewModel>("my-lists");
            appBuilder.Services.AddTransientWithShellRoute<MyListDetailPage, MyListDetailPageViewModel>("my-list-detail");
            appBuilder.Services.AddTransientWithShellRoute<MoviesByGenresPage, MoviesByGenresPageViewModel>("movies-by-genres");
            return appBuilder;
        }

        public static MauiAppBuilder AddApiClient(this MauiAppBuilder appBuilder)
        {
            
            appBuilder.Services.AddScoped<BearerTokenHandler>();
            appBuilder.Services.AddScoped<LanguageApiHandler>();
            appBuilder.Services.AddSingleton<ILocalStorage, LocalStorage>();
            
            appBuilder.Services.AddRefitClient<IGetMoviesTopFiveDay>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetMoviesLatest>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetMovieById>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<ISearchByTitle>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetAllCategories>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetMoviesByGenres>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<LanguageApiHandler>()
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetAuthenticationToken>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetAccessToken>()
                                .ConfigureHttpClient(httpClientSettings2)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<ICreateSession>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<ICreateList>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetAccount>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetMyLists>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IAddMovieToList>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetListById>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IGetCastMovie>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IDeleteMovieOfList>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            appBuilder.Services.AddRefitClient<IDeleteList>()
                                .ConfigureHttpClient(httpClientSettings)
                                .AddHttpMessageHandler<BearerTokenHandler>();

            return appBuilder;
        }

        public static MauiAppBuilder AddPopups(this MauiAppBuilder appBuilder)
        {
            appBuilder.Services.AddTransientPopup<ConfirmDeleteMovieInMyListPopup, ConfirmDeleteMovieInMyListPopupViewModel>();

            appBuilder.Services.AddBottomSheet<MyListsPopup, MyListsPopupViewModel>("mylist-popup");
            return appBuilder;
        }

        private static void httpClientSettings(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/3");
        }

        private static void httpClientSettings2(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/4");
        }

        private static MauiAppBuilder AddFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events => {
                #if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, _) =>
                    CrossFirebase.Initialize(activity)));
                #endif

            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }

    }
}
