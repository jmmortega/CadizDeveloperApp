using CadizDevelopers.Core.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Views;
using System.Windows.Controls;

namespace CadizDevelopers.WP7.Views
{
    public partial class MainView : MvxPhonePage
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void OptionListSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;

            if (listbox.SelectedIndex != -1)
            {
                (ViewModel as MainViewModel).OptionSelectedCommand.Execute(listbox.SelectedItem.ToString());
            }
        }
    }
}