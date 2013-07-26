using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadizDevelopers.Core.ExtensionMethods
{
    public static class ExtensionMethodsJson
    {
        public static T ValueOrDefault<T>(this JToken jtoken)
        {            
            try
            {                
                return jtoken.Value<T>();
            }
            catch
            {                
                return default(T);
            }
        }
        
        public static DateTime ParseDateJson(this JToken jtoken) 
        {            
            //2013-07-08T09:11:03.383Z
            //return DateTime.Parse(jtoken.ValueOrDefault<String>());

            return jtoken.ValueOrDefault<DateTime>();
        }
               
        public static List<JToken> ToList(this JArray jarray)
        {
            if (jarray.Count > 0)
            {
                return jarray.ToList<JToken>();
            }
            else
            {
                return new List<JToken>();
            }

        }
        
        
    }
}
