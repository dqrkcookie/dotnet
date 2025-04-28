using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Pawfect_Care;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
    ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set the status bar color to a brown color
        Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#542a0e"));

    }
}
