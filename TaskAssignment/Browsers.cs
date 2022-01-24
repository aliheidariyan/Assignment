using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAssignment
{
    public class Browsers
    {
        public static readonly string BaseURL = ConfigurationManager.AppSettings["baseUrl"];
        public static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private static AndroidDriver<AndroidElement> webDriver;

        public enum Platforms
        {
            Apk,
            Ios,
            Web,
            Pwa
        }
        public static void Init(Platforms platform)
        {
            if (platform == Platforms.Apk)
            {
                AppiumOptions capabilities = new AppiumOptions();
                //Cap For Write Android Mobile Apk
                capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
                capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, App.AndroidPlatformVersion());
                capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
                capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
                capabilities.AddAdditionalCapability(MobileCapabilityType.App, "C:\\yy\\pg.apk");
                capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
                capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
                 webDriver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities);
            }
            if (platform == Platforms.Web)
            {
                switch (Browser)
                {
                    case "Chrome":
                        AppiumOptions capabilities = new AppiumOptions();
                        capabilities.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
                        capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
                        capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
                        capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
                        // capabilities.SetCapability(MobileCapabilityType.BrowserName, "");
                        // capabilities.SetCapability(MobileCapabilityType.PlatformName, App.AndroidDeviceName());
                        // capabilities.SetCapability(MobileCapabilityType.PlatformVersion, App.AndroidPlatformVersion());
                        // capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
                        // capabilities.SetCapability(MobileCapabilityType.DeviceName, "Nexus");
                        // capabilities.SetCapability("appActivity", ".app.SearchInvoke");
                        //capabilities.SetCapability(MobileCapabilityType.App, App.AndroidApp());
                        // //capabilities.SetCapability(MobileCapabilityType.App, "C:\\yy\\WikipediaSample.apk");

                        //capabilities.SetCapability(MobileCapabilityType.PlatformVersion, App.IOSPlatformVersion());
                        //capabilities.SetCapability(MobileCapabilityType.DeviceName, App.IOSDeviceName());
                        //capabilities.SetCapability(MobileCapabilityType.App, App.IOSApp());
                        //var c = new RemoteWebDriver(Env.ServerUri(), capabilities);
                        webDriver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities);

                        //driver = new AndroidDriver<AndroidElement>(Env.ServerUri(), capabilities, Env.INIT_TIMEOUT_SEC);
                        //driver=new ChromeDriver(AppiumOptions)
                        //driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
                        Goto(BaseURL);
                        break;
                }
            }
        }

        public static string Title => webDriver.Title;
        public static AndroidDriver<AndroidElement> Driver => webDriver;
        public static void Goto(string url)
        {
            webDriver.Url = url;
            //reports.verifyURL(url);
        }
        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
