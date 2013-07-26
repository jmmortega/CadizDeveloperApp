using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Services
{
    public class FacebookLoginSucceedArgs : EventArgs
    {
        public FacebookLoginSucceedArgs(int id, string accessToken)
        {
            m_id = id;
            m_accessToken = accessToken;
        }

        public FacebookLoginSucceedArgs(string error)
        {
            m_error = error;
        }

        #region Properties

        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_accessToken;

        public string AccessToken
        {
            get { return m_accessToken; }
            set { m_accessToken = value; }
        }

        private string m_error;

        public string Error
        {
            get { return m_error; }
            set { m_error = value; }
        }


        #endregion
    }
}
