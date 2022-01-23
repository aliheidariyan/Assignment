using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class App
    {
        static public String IOSApp()
        {
            return Env.IsSauce() ? "http://appium.github.io/appium/assets/TestApp7.1.app.zip" : $"{Env.rootDirectory}/apps/TestApp.app.zip";
        }

        static public String IOSDeviceName()
        {
            return Environment.GetEnvironmentVariable("IOS_DEVICE_NAME") ?? "iPhone 6s";
        }

        static public String IOSPlatformVersion()
        {
            return Environment.GetEnvironmentVariable("IOS_PLATFORM_VERSION") ?? "11.4";
        }

        static public String AndroidApp()
        {
            //return Env.IsSauce() ? "http://appium.github.io/appium/assets/ApiDemos-debug.apk" : $"{Env.rootDirectory}/apps/ApiDemos-debug.apk";
            //return Env.IsSauce() ? $"{Env.rootDirectory}/apps/ApiDemos-debug.apk" : $"{Env.rootDirectory}/apps/ApiDemos-debug.apk";
            return Env.IsSauce() ? "http://com.payamgostarmobileapp" : $"{Env.rootDirectory}/apps/app-release.apk";
        }

        static public String AndroidDeviceName()
        {
            return Environment.GetEnvironmentVariable("ANDROID_DEVICE_VERSION") ?? "Android";
        }

        static public String AndroidPlatformVersion()
        {
            return Environment.GetEnvironmentVariable("ANDROID_PLATFORM_VERSION") ?? "9";
        }


    }
}
