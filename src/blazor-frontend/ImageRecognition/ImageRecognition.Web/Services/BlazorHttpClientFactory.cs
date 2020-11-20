using Amazon.Runtime;
using System.Net.Http;

namespace ImageRecognition.Web.Services
{
    public class BlazorHttpClientFactory : HttpClientFactory
    {
        private readonly HttpClient client;

        // HttpClient comes from Blazor's Dependency Injection
        public BlazorHttpClientFactory(HttpClient client)
        {
            this.client = client;
        }
        public override HttpClient CreateHttpClient(IClientConfig clientConfig)
        {
            // return a cached client from your pool
            return client;
        }

        public override bool UseSDKHttpClientCaching(IClientConfig clientConfig)
        {
            // return false to indicate that the SDK should not cache clients internally            
            return false;
        }
        public override bool DisposeHttpClientsAfterUse(IClientConfig clientConfig)
        {
            // return false to indicate that the SDK shouldn't dispose httpClients because they're cached in your pool            
            return false;
        }
        public override string GetConfigUniqueString(IClientConfig clientConfig)
        {
            // has no effect because UseSDKHttpClientCaching returns false
            return null;
        }
    }
}