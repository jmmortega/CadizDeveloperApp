using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Services
{
    public class FacebookRouting
    {        
        #region Methods

        private const string c_getLogin = "me?fields=id";

        public string GetLogin()
        {
            return c_getLogin;
        }

        private const string c_getProfilePictures = "https://graph.facebook.com/{0}/picture?type={1}&access_token={2}";

        public string GetProfilePicture(string id, string type, string accessToken)
        {
            return string.Format(c_getProfilePictures, new object[] { id, type, accessToken });
        }


        private const string c_getMe = "me";
        public string GetMe()
        {
            return c_getMe;
        }


        private const string c_getGroupsInfo = "https://graph.facebook.com/{0}/feed";
        public string GetGroups(string groupId)
        {
            return string.Format(c_getGroupsInfo, new object[] { groupId });
        }

        #endregion

    }
}
