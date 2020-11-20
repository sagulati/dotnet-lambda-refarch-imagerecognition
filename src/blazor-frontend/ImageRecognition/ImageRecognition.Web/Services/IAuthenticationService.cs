using ImageRecognition.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageRecognition.Web.Services
{
    public interface IAuthenticationService
    {
       Task<LoginResponse> Login(LoginModel loginModel);

        Task Logout();
    }
}
