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
        public List<User> ParseUser(List<KeyValuePair<string,JToken>> obj)
        {
            List<User> users = new List<User>();

            foreach (KeyValuePair<string,JToken> value in obj)
            {
                var token = value.Value;
                string user = token.SelectToken("Name").Value<string>();
                string mail = token.SelectToken("Mail").Value<string>();

                users.Add(new User() { Name = user, Mail = mail });
            }

            return users;

        }
    }
}
