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
    public partial class RestApiListDataView : MvxPhonePage
    {
        public RestApiListDataView()
        {
            InitializeComponent();
        }

        private void ApplicationBarAdd(object sender, EventArgs e)
        {
            (ViewModel as RestApiListDataViewModel).AddCommand.Execute(null);
        }

        private void ApplicationBarRefresh(object sender, EventArgs e)
        {
            (ViewModel as RestApiListDataViewModel).RefreshCommand.Execute(null);
        }
    }
}