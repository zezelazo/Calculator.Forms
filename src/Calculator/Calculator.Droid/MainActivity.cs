﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Calculator.Droid
{
    [Activity(Label = "Calculator", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            MobileCenter.Start("1c4ee466-9568-4f59-a43e-2afc5c3a6a47",
                typeof(Analytics), typeof(Crashes));

            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.AutomationId))
                {
                    e.NativeView.ContentDescription = e.View.AutomationId;
                }
            };

            LoadApplication(new App());
        }
    }
}

