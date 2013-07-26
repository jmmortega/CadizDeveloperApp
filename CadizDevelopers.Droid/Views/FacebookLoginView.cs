using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Android.Webkit;
using CadizDevelopers.Core.ViewModels;

namespace CadizDevelopers.Droid.Views
{
    [Activity(Label = "My Activity")]
    public class FacebookLoginView : MvxActivity
    {
        #region Elements

        private WebView webView;

        #endregion

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //SetContentView(Resource.Layout.LoginView);

            LoadElements();
        }

        private void LoadElements()
        {
            //webView = FindViewById<WebView>(Resource.Id.webViewFb);

            SetWebView();

        }

        private void SetWebView()
        {
            webView = new WebView(this);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.SetSupportZoom(true);
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.LoadWithOverviewMode = true; //Load 100% zoomed out
            webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            webView.ScrollbarFadingEnabled = true;


            webView.VerticalScrollBarEnabled = true;
            webView.HorizontalScrollBarEnabled = true;

            webView.SetWebViewClient(new FBWebClient(this));
            webView.SetWebChromeClient(new FBWebChromeClient(this));

            AddContentView(webView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));

            webView.LoadUrl((ViewModel as FacebookLoginViewModel).LoginUri.AbsoluteUri);
        }

    }
}