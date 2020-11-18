using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageRecognition.Web.Models
{
    public class CognitoResponse
    {
        public CognitoResponseType Type { get; }

        public string SessionId { get; }
        public string AccessToken { get; private set; }
        public string IdToken { get; private set; }
        public string RefreshToken { get; private set; }

        public DateTime TokenIssuedAt { get; }
        public DateTime TokenExpiresAt { get; }

        public string CredentialsAccessKey { get; private set; }
        public string CredentialsSecretKey { get; private set; }
        public string CredentialToken { get; private set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; private set; }
        public List<string> Roles { get; private set; }
        public Exception Exception { get; set; }
        public string UserAgent { get; set; }

        public string TraceLog { get; set; }

        public CognitoResponse(CognitoResponseType type, AuthFlowResponse response = null, CognitoUser user = null, ImmutableCredentials credentials = null)
        {
            Type = type;
            if (response != null)
            {
                SessionId = response.SessionID;
                AccessToken = response.AuthenticationResult?.AccessToken;
                IdToken = response.AuthenticationResult?.IdToken;
                RefreshToken = response.AuthenticationResult?.RefreshToken;
            }
            if (user != null && user.SessionTokens != null)
            {
                TokenIssuedAt = user.SessionTokens.IssuedTime;
                TokenExpiresAt = user.SessionTokens.ExpirationTime;
            }
            if (credentials != null)
            {
                CredentialsAccessKey = credentials.AccessKey;
                CredentialsSecretKey = credentials.SecretKey;
                CredentialToken = credentials.Token;
            }
            ParseIdToken();
        }


        private void ParseIdToken()
        {
            Username = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Roles = new List<string>();

            if (!string.IsNullOrEmpty(IdToken))
            {
                try
                {
                    string idToken = IdToken.Split('.')[1];
                    idToken = DecodeBase64Url(idToken);
                    var jObject = JObject.Parse(idToken);

                    Username = jObject["cognito:username"]?.ToString();
                    Name = jObject["name"]?.ToString();
                    Email = jObject["email"]?.ToString().ToLower();
                    var test = jObject["cognito:groups"] as JArray;
                    Roles = test.Values<string>().ToList();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private string DecodeBase64Url(string base64String)
        {
            base64String = base64String.Replace('-', '+').Replace('_', '/');
            base64String = base64String.PadRight(base64String.Length + (4 - base64String.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(base64String);
            return System.Text.Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
        }
    }
}
