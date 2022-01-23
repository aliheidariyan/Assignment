using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Page
{
    public class LoginPage /*: BasePage*/
    {
        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "txtUserName")]
        public IWebElement UsernameTextBox { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "txtPassword")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "btnLogin")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "wpcf7-response-output")]
        public IWebElement SuccMessage;

        public bool IsAt()
        {
            return Browsers.Title.Contains("ورود");
        }

        //public void Goto()
        //{
        //    GotoPage("Login.aspx");
        //}

        public void SetUsername(string username)
        {
            UsernameTextBox.SendKeys(username);
        }
        public void SetPassword(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ValidateMessage()
        {
            try
            {
                string text = SuccMessage.Text;
            }
            catch (Exception)
            {
                Assert.True(false, "Message does not submited");
            }
        }
    }
}
