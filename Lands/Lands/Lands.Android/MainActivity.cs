namespace Lands.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;
    using FFImageLoading.Forms.Droid;
    using Plugin.CurrentActivity;
    using Plugin.Permissions;
    using System.IO;

    [Activity(Label = "Lands", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Set DB root
            string dbName = "LandsDBLite.db3";
            string dbBinder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbRoot = Path.Combine(dbBinder, dbName);
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);

            //Inicialized builder
            LoadApplication(new App(dbRoot));
            //LoadApplication(new App());
            CrossCurrentActivity.Current.Init(this, bundle);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}