using CadizDevelopers.Core.Resources;
using CadizDevelopers.Core.Services.Interfaces;
using CadizDevelopers.WP7.Services;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.File.WindowsPhone;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;

namespace CadizDevelopers.WP7
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IFacebookService>(new FacebookService(AppResources.AppIdFacebook, AppResources.AppSecretFacebook));
            Mvx.RegisterSingleton<IMvxFileStore>(new MvxIsolatedStorageFileStore());

            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}