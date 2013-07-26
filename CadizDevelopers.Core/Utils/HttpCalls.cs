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
        #region Public Methods

        public void Get(string url, Action<Stream> callbackOK, Action<Exception> callbackError)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            CallHttp(request, callbackOK, callbackError);
        }

        public void Post(string url, string contentType, Action<Stream> callbackOK, Action<Exception> callbackError)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = contentType;
            request.Method = "POST";

            CallHttp(request, callbackOK, callbackError);
        }

        public void Post(string url, string contentType, byte[] bytes, Action<Stream> callbackOK, Action<Exception> callbackError)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            try
            {

                request.BeginGetRequestStream((result) =>
                {
                    var requestFromStream = (HttpWebRequest)(result.AsyncState as object[])[0];
                    var requestBytes = (byte[])(result.AsyncState as object[])[1];

                    var requestStream = requestFromStream.EndGetRequestStream(result);

                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Flush();
                    //Disposing are close too
                    requestStream.Dispose();

                    request.BeginGetResponse((resultResponse) =>
                    {
                        var requestFromResponse = (HttpWebRequest)resultResponse.AsyncState;
                        var response = requestFromResponse.EndGetResponse(resultResponse);

                        var responseStream = response.GetResponseStream();

                        callbackOK.Invoke(responseStream);

                    }, requestFromStream);

                }, new object[] { request, bytes });
            }
            catch (Exception e)
            {
                callbackError.Invoke(e);
            }

        }

        #endregion

        #region Private Methods

        private void CallHttp(HttpWebRequest request, Action<Stream> callbackOK, Action<Exception> callbackError)
        {
            try
            {
                request.BeginGetResponse((result) =>
                {
                    var responseRequest = (HttpWebRequest)result.AsyncState;
                    var response = responseRequest.EndGetResponse(result);

                    var streamResponse = response.GetResponseStream();

                    callbackOK.Invoke(streamResponse);

                }, request);

            }
            catch (Exception e)
            {
                callbackError.Invoke(e);
            }
        }



        #endregion        

    }
}
