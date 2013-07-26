using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cirrious.MvvmCross.WindowsPhone.Views;
using CadizDevelopers.Core.ViewModels;

namespace CadizDevelopers.WP7.Views
{
    public partial class FacebookLoginView : MvxPhonePage
    {
        public FacebookLoginView()
        {
            InitializeComponent();
        }

        private void WebBrowserLoaded(object sender, RoutedEventArgs e)
        {
            Uri uri = (ViewModel as FacebookLoginViewModel).LoginUri;
            (sender as WebBrowser).Navigate(uri);
        }

        private void OnNavigating(object sender, NavigatingEventArgs e)
        {
            (ViewModel as FacebookLoginViewModel).ProcessUriCommand.Execute(e.Uri);
        }      
    }
}