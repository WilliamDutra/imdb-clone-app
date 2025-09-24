using Plugin.Firebase.RemoteConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Networks
{
    public class BearerTokenHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var remoteConfig = CrossFirebaseRemoteConfig.Current;


            await remoteConfig.EnsureInitializedAsync();
            await remoteConfig.FetchAsync();
            await remoteConfig.ActivateAsync();

            var apiKey = remoteConfig.GetString("apiKeyImdb");
            
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);


            return await base.SendAsync(request, cancellationToken);
        }
    }
}
