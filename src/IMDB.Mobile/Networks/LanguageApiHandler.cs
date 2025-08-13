using System;
using System.Globalization;

namespace IMDB.Mobile.Networks
{
    public class LanguageApiHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            string languageOptions = request.RequestUri.OriginalString.Contains("?") ? $"&language={culture}" : $"?language={culture}";

            request.RequestUri = new Uri(request.RequestUri + languageOptions);
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}
