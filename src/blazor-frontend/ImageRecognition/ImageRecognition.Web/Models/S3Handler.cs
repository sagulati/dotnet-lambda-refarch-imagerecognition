using Microsoft.JSInterop;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ImageRecognition.Web.Models
{
    public class S3Hander{

        private readonly IJSRuntime _jsRuntime;
        private readonly IConfiguration _configuration;

        public S3Hander(IJSRuntime jSRuntime, IConfiguration Configuration){
            _jsRuntime = jSRuntime;
            _configuration = Configuration;

        }

        public async Task InitializeAsync()
        {
            await _jsRuntime.InvokeVoidAsync("s3.initialize", 
                _configuration["oidc:Authority"], 
                _configuration["cognito:identityPoolId"], 
                _configuration["cognito:region"], 
                _configuration["oidc:ClientId"] );
        }

        public async Task<string> GetSignedUrlAsync(string albumBucketName, string key)
        {
            var signedUrl = 
                await _jsRuntime.InvokeAsync<string>("s3.getSignedUrl", albumBucketName, key);

            return signedUrl;
        }

    }
}