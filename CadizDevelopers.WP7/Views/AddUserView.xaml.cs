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
    public partial class AddUserView : MvxPhonePage
    {
        public AddUserView()
        {
            InitializeComponent();
        }

        private void ButtonFromCamera(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as AddUserViewModel).AddImageCommand.Execute(true);
        }

        private void ButtonFromPicture(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as AddUserViewModel).AddImageCommand.Execute(false);
        }

        private void ButtonSave(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as AddUserViewModel).SaveCommand.Execute(null);
        }
    }
}