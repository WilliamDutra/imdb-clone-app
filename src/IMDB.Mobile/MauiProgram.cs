using CommunityToolkit.Maui;
using IMDB.ApiClient.GetAllCategories;
using IMDB.ApiClient.GetMovieById;
using IMDB.ApiClient.GetMoviesByGenres;
using IMDB.ApiClient.GetMoviesLatest;
using IMDB.ApiClient.GetMoviesTopFiveDay;
using IMDB.ApiClient.SearchByTitle;
using IMDB.Mobile.Networks;
using IMDB.Mobile.Pages.Details;
using IMDB.Mobile.Pages.Home;
using IMDB.Mobile.Pages.MoviesByGenres;
using IMDB.Mobile.Pages.Search;
using IMDB.Mobile.Resources.Styles.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;

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
                .AddPages()
                .AddApiClient()
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
            appBuilder.Services.AddTransientWithShellRoute<HomePage, HomePageViewModel>("home");
            appBuilder.Services.AddTransientWithShellRoute<DetailPage, DetailPageViewModel>("details");
            appBuilder.Services.AddTransientWithShellRoute<SearchPage, SearchPageViewModel>("search");
            appBuilder.Services.AddTransientWithShellRoute<MoviesByGenresPage, MoviesByGenresPageViewModel>("movies-by-genres");
            return appBuilder;
        }

        public static MauiAppBuilder AddApiClient(this MauiAppBuilder appBuilder)
        {
            
            appBuilder.Services.AddScoped<BearerTokenHandler>();
            appBuilder.Services.AddScoped<LanguageApiHandler>();
            
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

            return appBuilder;
        }

        private static void httpClientSettings(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.themoviedb.org/3");
        }
    }
}
