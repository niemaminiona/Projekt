#nullable enable
using System;
using System.Runtime.Versioning;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Projekt
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
                               ConfigChanges.UiMode | ConfigChanges.ScreenLayout |
                               ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    // Optionally tell the analyzer this class is Android-specific
    [SupportedOSPlatform("android21.0")]
    public class MainActivity : MauiAppCompatActivity
    {
        // Keep the signature non-nullable to match the base method
        [SupportedOSPlatform("android21.0")]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set status bar color on Android 21+ (Lollipop+)
            if (OperatingSystem.IsAndroidVersionAtLeast(21))
            {
                // Use a simple Color constant instead of ParseColor to avoid analyzer noise
                Window.SetStatusBarColor(Android.Graphics.Color.White);
            }

            // Use WindowInsetsController on Android 30+; fallback to SystemUiFlags for older versions.
            if (OperatingSystem.IsAndroidVersionAtLeast(30))
            {
                var controller = Window.InsetsController;
                if (controller != null)
                {
                    // Use ints to satisfy the analyzer/platform checks
                    controller.SetSystemBarsAppearance(
                        (int)WindowInsetsControllerAppearance.LightStatusBars,
                        (int)WindowInsetsControllerAppearance.LightStatusBars);
                }
            }
            else if (OperatingSystem.IsAndroidVersionAtLeast(23)) // API 23 introduced LightStatusBar flag
            {
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
            }
        }
    }
}
