using Refit;
using System;

namespace IMDB.ApiClient.GetMoviesByGenres
{
    public class MoviesByGenresParams
    {
        [AliasAs("with_genres")]
        public int GenreId { get; set; }

        [AliasAs("page")]
        public int Page { get; set; } = 1;

        [AliasAs("include_video")]
        public string IncludeVideo { get; set; } = "false";

        [AliasAs("include_adult")]
        public string IncludeAdult { get; set; } = "false";

        [AliasAs("sort_by")]
        public string SortBy { get; set; }

        [Query(CollectionFormat.Csv)]
        [AliasAs("with_watch_providers")]
        public List<int> WithWatchProviders { get; set; }

    }
}
