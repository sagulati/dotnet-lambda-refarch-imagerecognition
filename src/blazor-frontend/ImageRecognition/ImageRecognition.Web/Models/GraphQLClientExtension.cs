using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace ImageRecognition.Web.Models
{
    public static class GraphQLClientExtension
    {
        public static void AddGraphQLHttpClient<THttpMessageHandler>(
            this IServiceCollection services
            ) where THttpMessageHandler : DelegatingHandler
        {
            var clientName = "album-client"; // in reality you can pass in this name directly or through an appsetting
            services.AddHttpClient(clientName).AddHttpMessageHandler<THttpMessageHandler>();
            services.AddScoped(sp =>
            {
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                var _apiClient = httpClientFactory.CreateClient(clientName);

                var graphQLOptions = new GraphQLHttpClientOptions
                {
                    EndPoint = new Uri("https://qpwk2sy3bza6dag23lzxktm3ky.appsync-api.us-east-1.amazonaws.com/graphql"),
                };

                return new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer(), _apiClient);

            });
        }
    }

}
