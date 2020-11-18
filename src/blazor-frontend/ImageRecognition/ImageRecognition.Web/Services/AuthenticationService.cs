using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Amazon.SecurityToken;
using ImageRecognition.Web.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AwsCognitoExample.Services
{
    public class AuthenticationService
    {
        // sample data taken from https://github.com/aws-samples/aws-cognito-dot-net-desktop-app/blob/master/app.config

        private readonly RegionEndpoint awsRegionEndpoint = RegionEndpoint.USEast1;
        private readonly string poolId = "us-east-1_zw4lsGNVb";
        private readonly string clientId = "4o626lq79t74infef2i8aops92";
        private readonly string clientSecret = null;
        private readonly string identityPoolId = "us-east-1:749d1c8f-b9f8-4991-9a7f-3cb2cb2abb29";

        private readonly HttpClient httpClient;

        public CognitoResponse CognitoResponse { get; private set; }
        public bool IsLoggedIn => CognitoResponse?.Type == CognitoResponseType.Ok && CognitoResponse?.TokenExpiresAt > DateTime.Now;


        public AuthenticationService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<bool> TryLoginAsync(string username, string password)
        {
            using (var client = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), CreateProviderConfig()))
            {
                var user = GetCognitoUser(client, username);
                var watch = Stopwatch.StartNew();

                try
                {

                    var authFlowResponse = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
                    {
                        Password = password
                    }).ConfigureAwait(false);

                    if (authFlowResponse.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
                    {
                        CognitoResponse = new CognitoResponse(CognitoResponseType.PasswordChangeRequired, authFlowResponse, user);
                    }
                    else
                    {
                        Debug.WriteLine($"AWS Cognito > Get Credentials ({watch.Elapsed.TotalSeconds:N1}s elapsed)");
                        var credentials = await GetCredentialsWithCustomConfigAsync(user);
                        CognitoResponse = new CognitoResponse(CognitoResponseType.Ok, authFlowResponse, user, credentials);

                        watch.Stop();
                        Debug.WriteLine($"AWS Cognito > Completed after {watch.Elapsed.TotalSeconds:N1}s");
                        return true;
                    }
                }
                catch (NotAuthorizedException exc1)
                {
                    CognitoResponse = new CognitoResponse(CognitoResponseType.NotAuthorized)
                    {
                        Username = username,
                        Exception = exc1,
                        UserAgent = client.Config.UserAgent
                    };
                }
                catch (UserNotFoundException)
                {
                    CognitoResponse = new CognitoResponse(CognitoResponseType.UserNotFound);
                }
                catch (UserNotConfirmedException)
                {
                    CognitoResponse = new CognitoResponse(CognitoResponseType.NotConfirmed);
                }
                catch (OperationCanceledException exc4)
                {
                    CognitoResponse = new CognitoResponse(CognitoResponseType.Timeout)
                    {
                        Username = username,
                        Exception = exc4,
                        UserAgent = client.Config.UserAgent
                    };
                }
                catch (Exception exc5)
                {
                    if (exc5.Message.ToLower().Contains("no such host is known"))
                    {
                        CognitoResponse = new CognitoResponse(CognitoResponseType.Offline);
                    }
                    else
                    {
                        CognitoResponse = new CognitoResponse(CognitoResponseType.Unknown);
                    }
                    CognitoResponse.Username = username;
                    CognitoResponse.Exception = exc5;
                    CognitoResponse.UserAgent = client.Config.UserAgent;
                }
                watch.Stop();
                Debug.WriteLine($"AWS Cognito > Failed after {watch.Elapsed.TotalSeconds:N1}s");
            }
            return false;
        }

        private async Task<ImmutableCredentials> GetCredentialsWithCustomConfigAsync(CognitoUser user)
        {
            if (user.SessionTokens == null || !user.SessionTokens.IsValid())
            {
                throw new NotAuthorizedException("User is not authenticated.");
            }

            string poolRegion = user.UserPool.PoolID.Substring(0, user.UserPool.PoolID.IndexOf("_"));
            string providerName = "cognito-idp." + poolRegion + ".amazonaws.com/" + user.UserPool.PoolID;

            using (var awsCredentials = new CognitoAWSCredentials(null, identityPoolId, null, null,
                new AmazonCognitoIdentityClient(new AnonymousAWSCredentials(), CreateIdentityConfig()),
                new AmazonSecurityTokenServiceClient(new AnonymousAWSCredentials(), CreateSecurityTokenServiceConfig())))
            {
                awsCredentials.Clear();
                awsCredentials.AddLogin(providerName, user.SessionTokens.IdToken);

                var credentials = await awsCredentials.GetCredentialsAsync();
                return credentials;
            }
        }

        private CognitoUser GetCognitoUser(AmazonCognitoIdentityProviderClient client, string username)
        {
            var userPool = new CognitoUserPool(poolId, clientId, client, clientSecret);
            return new CognitoUser(username, clientId, userPool, client, clientSecret);
        }

        private AmazonCognitoIdentityProviderConfig CreateProviderConfig()
        {
            var config = new AmazonCognitoIdentityProviderConfig
            {
                RegionEndpoint = awsRegionEndpoint,
                HttpClientFactory = new BlazorHttpClientFactory(httpClient)
            };
            return config;
        }

        private AmazonCognitoIdentityConfig CreateIdentityConfig()
        {
            var config = new AmazonCognitoIdentityConfig
            {
                RegionEndpoint = awsRegionEndpoint,
                HttpClientFactory = new BlazorHttpClientFactory(httpClient)
            };
            return config;
        }

        private AmazonSecurityTokenServiceConfig CreateSecurityTokenServiceConfig()
        {
            var config = new AmazonSecurityTokenServiceConfig
            {
                RegionEndpoint = awsRegionEndpoint,
                HttpClientFactory = new BlazorHttpClientFactory(httpClient)
            };
            return config;
        }
    }
}