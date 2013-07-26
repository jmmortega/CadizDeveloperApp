using Android.Content;
using CadizDevelopers.Core.Resources;
using CadizDevelopers.Core.Services.Interfaces;
using CadizDevelopers.Droid.Services;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.File.Droid;
using Cirrious.MvvmCross.ViewModels;

namespace CadizDevelopers.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IFacebookService>(new FacebookService(AppResources.AppIdFacebook, AppResources.AppSecretFacebook));
            Mvx.RegisterSingleton<IMvxFileStore>(new MvxAndroidFileStore());

            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}