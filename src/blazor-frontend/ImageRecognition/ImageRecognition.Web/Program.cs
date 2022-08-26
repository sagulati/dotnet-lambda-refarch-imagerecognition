using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blazored.SessionStorage;
using ImageRecognition.Web.Models;

namespace ImageRecognition.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Cognito", options.ProviderOptions);
                options.ProviderOptions.MetadataUrl = "https://r8fpnxon16.execute-api.us-east-1.amazonaws.com/test/.well-known/openid-configuration";
            });

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<AuthorizationMessageHandler>();

            //builder.Services.AddScoped<ImageRecognition.Web.Models.S3Hander>();

            builder.Services.AddGraphQLHttpClient<Models.AuthorizationMessageHandler>();

            builder.RootComponents.Add<App>("#app");
            
            await builder.Build().RunAsync();
        }
    }
}
