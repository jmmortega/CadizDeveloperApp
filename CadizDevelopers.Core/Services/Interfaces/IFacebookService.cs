using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Services.Interfaces
{
    public interface IFacebookService
    {
        string AccessToken { get; set; }
        string ApiKey { get; set; }
        string ApiKeySecret { get; set; }
        bool isAuthenticated { get; set; }
        string UserId { get; set; }
       
        Uri AuthenticateUri();
        void GetAccessToken(Uri uri, Action<FacebookLoginSucceedArgs> callbackOK, Action<Exception> callbackError);
        void GetGraph(string url, Action<IDictionary<string,object>> callbackOK , Action<Exception> callbackError);
        Uri GetUserProfilePicture();
    }
}
