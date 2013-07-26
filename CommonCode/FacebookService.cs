using Bfax.Core.Resources;
using Bfax.Core.Services;
using Bfax.Core.Services.Interfaces;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bfax.WP7.Services
{
    public class FacebookService : IFacebookService
    {
        #region Fields

        private FacebookClient client;

        #endregion

        #region Constructor

        public FacebookService()
        {
            Instance();
        }

        public FacebookService(string apiKey, string apikeySecret)
        {
            Instance();
            this.ApiKey = apiKey;
            this.ApiKeySecret = apikeySecret;
        }

        public FacebookService(string accessToken)
        {
            Instance(accessToken);
            this.AccessToken = accessToken;
        }

        private void Instance(string accessToken = "")
        {
            if (string.IsNullOrEmpty(accessToken) == false)
            {
                client = new FacebookClient(accessToken);
            }
            else
            {
                client = new FacebookClient();
            }
        }

        #endregion
                                
        #region Properties

        private bool m_isAuthenticated;

        public bool isAuthenticated
        {
            get { return m_isAuthenticated; }
            set { m_isAuthenticated = value; }
        }

        public string ApiKey
        {
            get { return client.AppId; }
            set
            {
                client.AppId = value;
            }
        }

        public string ApiKeySecret
        {
            get { return client.AppSecret; }
            set
            {
                client.AppSecret = value;
            }
        }

        public string AccessToken
        {
            get { return client.AccessToken; }
            set
            {
                client.AccessToken = value;
                //If set AccessToken then isAuthenticated
                this.isAuthenticated = true;
            }
        }

        private string m_userId;

        public string UserId
        {
            get { return m_userId; }
            set { m_userId = value; }
        }

        #endregion
        
        #region Methods

        public Uri AuthenticateUri()
        {
            if (this.isAuthenticated == false)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                parameters["client_id"] = this.ApiKey;
                parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
                parameters["response_type"] = "token";
                parameters["display"] = "touch";

                return client.GetLoginUrl(parameters);
            }
            else
            {
                return null;
            }
        }

        public void GetAccessToken(Uri uri, Action<FacebookLoginSucceedArgs> callbackOK, Action<Exception> callbackError)
        {
            FacebookOAuthResult oauthResult;

            if (client.TryParseOAuthCallbackUrl(uri, out oauthResult) == false)
            {
                if (oauthResult != null)
                {
                    callbackError.Invoke(new Exception(FacebookMessages.ErrorParseOauth));
                }
            }

            if (oauthResult != null)
            {
                if (oauthResult.IsSuccess == true)
                {
                    this.AccessToken = oauthResult.AccessToken;

                    client = new FacebookClient(this.AccessToken);
                    string message = string.Empty;

                    client.GetCompleted += (o, e) =>
                    {
                        if (e.Error != null)
                        {
                            callbackError.Invoke(e.Error);
                        }

                        var resultData = (IDictionary<string, object>)e.GetResultData();
                        this.UserId = resultData["id"].ToString();

                        callbackOK.Invoke(new FacebookLoginSucceedArgs(int.Parse(this.UserId), this.AccessToken));
                    };

                    client.GetAsync(new FacebookRouting().GetLogin());
                }
                else
                {
                    callbackError.Invoke(new Exception(FacebookMessages.ErrorParseOauth));
                }
            }
        }

        public void GetGraph(string url , Action<IDictionary<string,object>> callbackOK, Action<Exception> callbackError)
        {
            client.GetCompleted += (s, e) =>
                {
                    var resultData = (IDictionary<string, object>)e.GetResultData();
                    callbackOK.Invoke(resultData);                        
                };

            client.GetAsync(url);
        }

        public Uri GetUserProfilePicture()
        {            
            return new Uri(new FacebookRouting().GetProfilePicture(this.UserId, "square", this.AccessToken));
        }

        #endregion                            
    }
}
