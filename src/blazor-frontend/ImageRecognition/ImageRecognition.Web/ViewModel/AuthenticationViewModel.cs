using AwsCognitoExample.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageRecognition.Web.ViewModel
{
    public class AuthenticationViewModel
    {
        private readonly AuthenticationService authenticationService;

        #region Properties
        public bool IsBusy { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool WasLoginSuccessful { get; set; }
        #endregion

        public AuthenticationViewModel(AuthenticationService authentication)
        {
            authenticationService = authentication;
        }

        public async Task TryLoginAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            await Task.Delay(100);
            WasLoginSuccessful = await authenticationService.TryLoginAsync(Username, Password);

            IsBusy = false;
        }
    }
}
