using Android.App;
using Android.Content;
using Android.Webkit;
using CadizDevelopers.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadizDevelopers.Droid.Views
{
    public class FBWebClient : WebViewClient
    {
        FacebookLoginView parentActivity;

        public FBWebClient(FacebookLoginView parentactivity)
        {
            this.parentActivity = parentactivity;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);

            (parentActivity.ViewModel as FacebookLoginViewModel).ProcessUriCommand.Execute(new Uri(url));
        }

    }
}
