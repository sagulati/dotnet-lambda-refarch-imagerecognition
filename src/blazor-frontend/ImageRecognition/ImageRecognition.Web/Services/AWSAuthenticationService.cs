using Blazored.LocalStorage;
using ImageRecognition.Web.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageRecognition.Web.Services
{
    public class AWSAuthenticationService: IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly CognitoAuthenticationService _cognitoAuthenticationService;

        public AWSAuthenticationService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage,
                           CognitoAuthenticationService cognitoAuthenticationService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _cognitoAuthenticationService = cognitoAuthenticationService;
        }

        //public async Task<RegisterResult> Register(RegisterModel registerModel)
        //{
        //    var result = await _httpClient.PostJsonAsync<RegisterResult>("api/accounts", registerModel);

        //    return result;
        //}

        public async Task<LoginResponse> Login(LoginModel loginModel)
        {
            LoginResponse loginResponse = await _cognitoAuthenticationService.TryLoginAsync(loginModel.UserName, loginModel.Password);
            
            if (!loginResponse.IsAuthenticated)
            {
                return loginResponse;
            }

            await _localStorage.SetItemAsync("authToken", loginResponse.AccessToken);
            await _localStorage.SetItemAsync("identityToken", loginResponse.IdentityToken);
            await _localStorage.SetItemAsync("refreshToken", loginResponse.RefreshToken);
            await _localStorage.SetItemAsync("sessionId", loginResponse.SessionId);
            await _localStorage.SetItemAsync("authUser", loginResponse.Username);
            await _localStorage.SetItemAsync("email", loginResponse.Email);

            ((AWSAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResponse;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("identityToken");
            await _localStorage.RemoveItemAsync("refreshToken");
            await _localStorage.RemoveItemAsync("sessionId");
            await _localStorage.RemoveItemAsync("authUser");
            await _localStorage.RemoveItemAsync("email");
            ((AWSAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
