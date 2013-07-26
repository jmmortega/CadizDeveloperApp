using CadizDevelopers.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.Utils
{
    public class ParserApi
    {
        public List<User> ParseUser(JArray obj)
        {
            List<User> users = new List<User>();

            foreach (JToken token in obj)
            {
                
                string user = token.SelectToken("Name").Value<string>();
                string mail = token.SelectToken("Mail").Value<string>();

                users.Add(new User() { Name = user, Mail = mail });
            }

            return users;

        }
    }
}
