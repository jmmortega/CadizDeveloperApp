using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CadizDevelopers.Core.Utils
{
    public class HttpCalls
    {
        public void Post(string url, string contentType , Action<Stream> actionResponse)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = contentType;
            request.Method = "POST";

            request.BeginGetResponse((resultResponse) =>
            {
                var beginResponse = (HttpWebRequest)resultResponse.AsyncState;

                var response = (HttpWebResponse)beginResponse.EndGetResponse(resultResponse);

                var streamResponse = response.GetResponseStream();

                actionResponse.Invoke(streamResponse);
            }, request);
        }

    }
}
