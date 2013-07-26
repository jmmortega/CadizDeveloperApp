using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Model
{
    public class User
    {
        private string m_user;

        public string Name
        {
            get { return m_user; }
            set { m_user = value; }
        }

        private string m_mail;

        public string Mail
        {
            get { return m_mail; }
            set { m_mail = value; }
        }



    }
}
