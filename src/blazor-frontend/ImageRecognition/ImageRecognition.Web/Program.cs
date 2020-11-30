using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;

namespace ImageRecognition.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            string CognitoPoolId = "us-east-1_zw4lsGNVb";
            string region = CognitoPoolId.Substring(0, CognitoPoolId.IndexOf('_', StringComparison.InvariantCultureIgnoreCase));
            string CognitoAuthority = $"https://cognito-idp.{region}.amazonaws.com/{CognitoPoolId}";
            string CognitoMetadataAddress = $"https://cognito-idp.{region}.amazonaws.com/{CognitoPoolId}/.well-known/openid-configuration";


            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = CognitoAuthority;
                options.ProviderOptions.MetadataUrl = CognitoMetadataAddress;
                options.ProviderOptions.ClientId = "56jqqu9tr853g7qdc8p2s5su0j";
                options.ProviderOptions.RedirectUri = $"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/authentication/login-callback";
                options.ProviderOptions.ResponseType = "code";
                //builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddHttpClient("BlazorAuthentication.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //// Supply HttpClient instances that include access tokens when making requests to the server project
            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAuthentication.ServerAPI"));

            //builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
