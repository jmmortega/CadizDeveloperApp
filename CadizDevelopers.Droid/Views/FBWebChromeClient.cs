using Android.App;
using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadizDevelopers.Droid.Views
{
    public class FBWebChromeClient : WebChromeClient
    {
        private Activity m_parentActivity;

        public FBWebChromeClient(Activity parentActivity)
        {
            m_parentActivity = parentActivity;
        }

        public override void OnProgressChanged(WebView view, int newProgress)
        {
            m_parentActivity.Title = string.Format("Loading {0}%", newProgress);
            m_parentActivity.SetProgress(newProgress * 100);

            if (newProgress == 100)
            {
                m_parentActivity.Title = view.Url;
            }
        }

    }
}
