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

namespace ImageRecognition.Web.Services
{
    public class CognitoAuthenticationService
    {
        private readonly RegionEndpoint awsRegionEndpoint = RegionEndpoint.USEast1;
        private readonly string poolId = "us-east-1_zw4lsGNVb";
        private readonly string clientId = "4o626lq79t74infef2i8aops92";
        private readonly string clientSecret = null;
        private readonly string identityPoolId = "us-east-1:749d1c8f-b9f8-4991-9a7f-3cb2cb2abb29";

        private readonly HttpClient httpClient;

        public LoginResponse LoginResponse { get; private set; }
        
        

        public CognitoAuthenticationService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<LoginResponse> TryLoginAsync(string username, string password)
        {
            using (var client = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), CreateProviderConfig()))
            {
                var user = GetCognitoUser(client, username);
                var watch = Stopwatch.StartNew();

                try
                {
                    var authFlowResponse = await
                        user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest() { Password = password }).ConfigureAwait(false);

                    if (authFlowResponse.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
                    {
                        LoginResponse = new LoginResponse(ResponseType.PasswordChangeRequired, authFlowResponse, user);
                    }
                    else
                    {
                        Debug.WriteLine($"AWS Cognito > Get Credentials ({watch.Elapsed.TotalSeconds:N1}s elapsed)");
                        //var credentials = await GetCredentialsWithCustomConfigAsync(user);
                        LoginResponse = new LoginResponse(ResponseType.Ok, authFlowResponse, user);

                        watch.Stop();
                        Debug.WriteLine($"AWS Cognito > Completed after {watch.Elapsed.TotalSeconds:N1}s");
                        return LoginResponse;
                    }
                }
                catch (NotAuthorizedException exc1)
                {
                    LoginResponse = new LoginResponse(ResponseType.NotAuthorized)
                    {
                        Username = username,
                        Exception = exc1,
                        UserAgent = client.Config.UserAgent
                    };
                }
                catch (UserNotFoundException)
                {
                    LoginResponse = new LoginResponse(ResponseType.UserNotFound);
                }
                catch (UserNotConfirmedException)
                {
                    LoginResponse = new LoginResponse(ResponseType.NotConfirmed);
                }
                catch (OperationCanceledException exc4)
                {
                    LoginResponse = new LoginResponse(ResponseType.Timeout)
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
                        LoginResponse = new LoginResponse(ResponseType.Offline);
                    }
                    else
                    {
                        LoginResponse = new LoginResponse(ResponseType.Unknown);
                    }
                    LoginResponse.Username = username;
                    LoginResponse.Exception = exc5;
                    LoginResponse.UserAgent = client.Config.UserAgent;
                }
                watch.Stop();
                Debug.WriteLine($"AWS Cognito > Failed after {watch.Elapsed.TotalSeconds:N1}s");
            }
            return LoginResponse;
        }

        //private async Task<ImmutableCredentials> GetCredentialsWithCustomConfigAsync(CognitoUser user)
        //{
        //    if (user.SessionTokens == null || !user.SessionTokens.IsValid())
        //    {
        //        throw new NotAuthorizedException("User is not authenticated.");
        //    }

        //    string poolRegion = user.UserPool.PoolID.Substring(0, user.UserPool.PoolID.IndexOf("_"));
        //    string providerName = "cognito-idp." + poolRegion + ".amazonaws.com/" + user.UserPool.PoolID;

        //    //user.GetCognitoAWSCredentials(identityPoolId, awsRegionEndpoint);

        //    using (var awsCredentials = new CognitoAWSCredentials(null, identityPoolId, null, null,
        //        new AmazonCognitoIdentityClient(new AnonymousAWSCredentials(), CreateIdentityConfig()),
        //        new AmazonSecurityTokenServiceClient(new AnonymousAWSCredentials(), CreateSecurityTokenServiceConfig())))
        //    {
        //        awsCredentials.Clear();
        //        awsCredentials.AddLogin(providerName, user.SessionTokens.IdToken);

        //        var credentials = await awsCredentials.GetCredentialsAsync();
        //        return credentials;
        //    }
        //}

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

        //private AmazonCognitoIdentityConfig CreateIdentityConfig()
        //{
        //    var config = new AmazonCognitoIdentityConfig
        //    {
        //        RegionEndpoint = awsRegionEndpoint,
        //        HttpClientFactory = new BlazorHttpClientFactory(httpClient)
        //    };
        //    return config;
        //}

        //private AmazonSecurityTokenServiceConfig CreateSecurityTokenServiceConfig()
        //{
        //    var config = new AmazonSecurityTokenServiceConfig
        //    {
        //        RegionEndpoint = awsRegionEndpoint,
        //        HttpClientFactory = new BlazorHttpClientFactory(httpClient)
        //    };
        //    return config;
        //}
    }
}