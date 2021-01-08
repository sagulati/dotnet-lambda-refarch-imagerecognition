using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace ImageRecognition.Web.Services
{
    public class TokenStore
        : ITokenStore
    {
     
        private ISessionStorageService _sessionStorage;
        public TokenStore(ISessionStorageService sessionStorage) => _sessionStorage = sessionStorage;
        
        // public async Task<string> GetToken()
        // {
            
        //     //return await _sessionStorage.GetItemAsync<>
        // }

        // public void SetToken(string token)
        // {
        //     _token = token;
        // }
    }
}