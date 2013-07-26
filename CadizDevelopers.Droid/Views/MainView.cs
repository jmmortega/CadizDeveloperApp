using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace CadizDevelopers.Droid.Views
{
    [Activity(Label = "CadizDeveloper App")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}