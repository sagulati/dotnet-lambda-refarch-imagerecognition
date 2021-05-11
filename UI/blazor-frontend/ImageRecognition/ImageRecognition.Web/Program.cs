using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blazored.SessionStorage;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using ImageRecognition.Web.Models;

namespace ImageRecognition.Web
{
    public class Program
    {
        //private static readonly string _token = "eyJraWQiOiJZTjNPMzBaM1VmSkxHYWF6RUV3TjA0dWJ0MkVVZ1VLWEo3ZjVxM01FdE1zPSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJkYjBjMmU0Ni1mNTAxLTQ0MzItYTc1NC1lNmE1Nzk1ZmYzNzkiLCJldmVudF9pZCI6Ijk1NWI2ZDdmLWYwYWEtNDEwYy04NjVhLWMxNTQ4YzQ5NWE0YyIsInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUiLCJhdXRoX3RpbWUiOjE2MDc0NTczMDEsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTEuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0xX3p3NGxzR05WYiIsImV4cCI6MTYwNzQ2MDkwMSwiaWF0IjoxNjA3NDU3MzAxLCJ2ZXJzaW9uIjoyLCJqdGkiOiIwMGViZTJhNC0xMzNiLTRlN2QtOGYwOS02ZWIxMDM3ZTBhYzAiLCJjbGllbnRfaWQiOiI1NmpxcXU5dHI4NTNnN3FkYzhwMnM1c3UwaiIsInVzZXJuYW1lIjoic2FndWxhdGkifQ.HLH3mjuYGathtgcDl6n_vfgtT13UXtUV2I4nWV8m6e4wzuCGojZegx5ZtiGmvZzpaEJvGW_qQSoMxK3HgPhUClXWRzNSNkLHXJs5htlwdq18Njpj6Ps0SwYDr_J0JJVYKvivAo6JGaEiBy7aIhS9ElaaLtGpDUi8Stdw8FD-lb7gj4EN1EZlhsHcCvlbKe22rTxITquJNyQJeojR8OCQOFb1dTs4ScqCkZKzJj6c1B7bViVsoQ70_P71piIqPyqRNox3eStJ1TLTyPiVymnZ9D8__YFbnm2Hz5Qrz02Dm4zkZmQIipi1SfUjlG5mRfoj_2n64sWZ29BT5payz-na4A";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.RedirectUri = $"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/authentication/login-callback";
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<ImageRecognition.Web.Models.AuthorizationMessageHandler>();

            builder.Services.AddScoped<ImageRecognition.Web.Models.S3Hander>();

            builder.Services.AddHttpClient(
                "AlbumClient", 
                (services, client) =>
                {
                    client.BaseAddress = new Uri("https://syb6ykx6crfhlfchv5fnss2ekq.appsync-api.us-east-1.amazonaws.com/graphql");
                    //client.DefaultRequestHeaders.Add("Authorization", _token);
                        //new System.Net.Http.Headers.AuthenticationHeaderValue("", _token);
                }).AddHttpMessageHandler<ImageRecognition.Web.Models.AuthorizationMessageHandler>();

            builder.Services.AddAlbumClient();

            //builder.Services.AddHttpClient("BlazorAuthentication.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //// Supply HttpClient instances that include access tokens when making requests to the server project
            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAuthentication.ServerAPI"));

            //builder.Services.AddApiAuthorization();
            
            builder.RootComponents.Add<App>("#app");
            await builder.Build().RunAsync();
        }
    }
}
