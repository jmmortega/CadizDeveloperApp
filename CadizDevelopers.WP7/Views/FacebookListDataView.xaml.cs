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
    public partial class FacebookListDataView : MvxPhonePage
    {
        public FacebookListDataView()
        {
            InitializeComponent();
        }

        private void ButtonSearch(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as FacebookListDataViewModel).SearchCommand.Execute(null);
        }
    }
}