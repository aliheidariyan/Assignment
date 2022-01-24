using TaskAssignment.FunctionAction;
using TaskAssignment.InfoClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace TaskAssignment
{
    public class BaseTestSenarios : BaseAUT
    {
        [Fact]
        public void Login_and_changePassword_Whith_PWA()
        {
            var logininfo = new LoginAndChangePasswordInfo();
            logininfo.UserName = "admin";
            logininfo.CurrentPassword = "admin";
            logininfo.NewPassword = "aA123456789";
            logininfo.RepeateNewPassword = logininfo.NewPassword;
            var login =  new LoginAndChangePasswordAction(logininfo);

            //بررسی اینکه اگر تغییر پسورد صورت گرفته مجددا پسورد را به صورت دستی به  ادمین برگرداند
            if (logininfo.PasswordHasChangedWithLogin)
            {
                logininfo.UserName = "org.selenium";
                logininfo.CurrentPassword = logininfo.NewPassword;
                logininfo.NewPassword = "123456";
                logininfo.RepeateNewPassword = logininfo.NewPassword;
                var changepasspage = new ChangePasswordAction();
                changepasspage.SaveChangePassword(logininfo);
                changepasspage.LoginAgainAfterChangePassword(logininfo);
            }

            //var elm = Browsers.Driver.FindElement(new TestIdBy("txtUserName"));
            //elm.SendKeys("ali");
            //IEnumerable<AppiumWebElement> elementsOne = Browsers.Driver.FindElementsByAccessibilityId("SomeAccessibilityID");
        }


        [Fact]
        public void Apk_Login_With_ValidData()
        {
            //Find Txt ServerName
            AndroidElement serverAddress = (AndroidElement)new WebDriverWait(
             Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                   MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[1]/android.view.ViewGroup/android.widget.EditText")));

            //Find TxtUserName
            AndroidElement username = (AndroidElement)new WebDriverWait(
            Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                  MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.EditText")));

            //Find TxtPassword
            AndroidElement password = (AndroidElement)new WebDriverWait(
             Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                  MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.EditText")));
            //Find BtnLogin
            AndroidElement btnLogin = (AndroidElement)new WebDriverWait(
            Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                 MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[4]/android.view.ViewGroup/android.widget.Button")));


            try
            {
            //Action of=> Use the "Send Text" widget to send values to the security fields (username, email, password fields). 
                serverAddress.SendKeys("http://192.168.11.9/");
                username.SendKeys("admin");
                password.SendKeys("admin");

            //  Incorporate the action of clicking the login button. 
                btnLogin.Click();
            }
            catch (Exception ex)
            {
                Browsers.Driver.GetScreenshot();
                Console.WriteLine(ex.Message);
            }

            System.Threading.Thread.Sleep(4000);

            //Verify the successful execution of the test. 

            var PgLogoAfterLogin = Browsers.Driver.FindElements(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.ImageView"));
            var countLogoFind = PgLogoAfterLogin.Count();
            var expectedValue = 1;

            Assert.Equal(countLogoFind, expectedValue);

            var cardtableButton = Browsers.Driver.FindElements(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.Button[3]/android.widget.TextView[1]"));
            Assert.Equal(cardtableButton.Count(), expectedValue);

        }

        [Fact]
        public void Apk_Login_With_InValidData()
        {
            //Check the UI elements  For servername has Displayed
            AndroidElement serverAddress = (AndroidElement)new WebDriverWait(
             Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                   MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[1]/android.view.ViewGroup/android.widget.EditText")));
            
            bool displayedUiElement = false;
            if (serverAddress.Displayed)
            {
                displayedUiElement = true;
            }
            Assert.True(displayedUiElement);

            //Check the UI elements  For username has Displayed
            AndroidElement username = (AndroidElement)new WebDriverWait(
            Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                  MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.EditText")));

            displayedUiElement = false;
            if (username.Displayed)
            {
                displayedUiElement = true;
            }
            Assert.True(displayedUiElement);

            //Check the UI elements  For password has Displayed
            AndroidElement password = (AndroidElement)new WebDriverWait(
             Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
             SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                  MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.EditText")));

            displayedUiElement = false;
            if (password.Displayed)
            {
                displayedUiElement = true;
            }
            Assert.True(displayedUiElement);

            //Check the UI elements  For btnLogin has Displayed
            AndroidElement btnLogin = (AndroidElement)new WebDriverWait(
            Browsers.Driver, TimeSpan.FromSeconds(30)).Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                 MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[4]/android.view.ViewGroup/android.widget.Button")));


            displayedUiElement = false;
            if (btnLogin.Displayed)
            {
                displayedUiElement = true;
            }
            Assert.True(displayedUiElement);


            var exceptionLocation = Browsers.Driver.FindElementsByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[4]/android.widget.TextView");
            //Assert.Null(exceptionLocation);

            //Run test
            serverAddress.SendKeys("http://192.168.11.7/");
            username.SendKeys("admin");
            password.SendKeys("incorect");
            btnLogin.Click();
            System.Threading.Thread.Sleep(4000);

            //Check whether the error messages and associated elements are working as expected
            exceptionLocation = Browsers.Driver.FindElementsByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[4]/android.widget.TextView");
            Assert.Equal(exceptionLocation[0].Text.Trim(), "نام کاربری و یا کلمه عبور صحیح نمی باشد!!!".Trim());




        }
    }
}
