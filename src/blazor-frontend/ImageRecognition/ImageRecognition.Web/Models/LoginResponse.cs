using Amazon.Extensions.CognitoAuthentication;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageRecognition.Web.Models
{
    public class LoginResponse
    {
        public LoginResponse(ResponseType responseType, AuthFlowResponse response = null, CognitoUser user = null)
        {

            ResponseType = responseType;

            if (response != null)
            {
                SessionId = response.SessionID;
                AccessToken = response.AuthenticationResult?.AccessToken;
                IdentityToken = response.AuthenticationResult?.IdToken;
                RefreshToken = response.AuthenticationResult?.RefreshToken;
            }

            if (user != null && user.SessionTokens != null)
            {
                TokenIssuedAt = user.SessionTokens.IssuedTime;
                TokenExpiresAt = user.SessionTokens.ExpirationTime;
            }

            ParseIdToken();
        }

        public ResponseType ResponseType { get; }

        public bool Successful => IsAuthenticated;

        public string Error { get; set; }

        public string AccessToken { get; private set; }

        public string IdentityToken { get; private set; }

        public string RefreshToken { get; private set; }

        public string SessionId { get; private set; }

        public string Username { get; set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public List<string> Roles { get; private set; }

        public Exception Exception { get; set; }

        public string UserAgent { get; set; }

        public DateTime TokenIssuedAt { get; }
        
        public DateTime TokenExpiresAt { get; }

        public bool IsAuthenticated =>
            ResponseType == ResponseType.Ok &&
            TokenExpiresAt > DateTime.Now;

        private void ParseIdToken()
        {
            Username = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Roles = new List<string>();

            if (!string.IsNullOrEmpty(IdentityToken))
            {
                try
                {
                    string idToken = IdentityToken.Split('.')[1];
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
