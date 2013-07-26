using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Services
{
    public class FacebookTip
    {
        private string m_user;

        public string User
        {
            get { return m_user; }
            set { m_user = value; }
        }

        private string m_message;

        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

    }
}
