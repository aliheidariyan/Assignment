using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Page.UserControlPage
{
    public class UcChangePasswordPage
    {
        //رمز فعلی
        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "uc-change-password-txt-current-password")]
        public IWebElement TxtCurrentPassword { get; set; }

        //رمز جدید
        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "uc-change-password-txt-new-password")]
        public IWebElement TxtNewPassword { get; set; }

        //تکرار رمز جدید
        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "uc-change-password-txt-repeate-new-password")]
        public IWebElement TxtRepeateNewPassword { get; set; }

        //ذخیزه 
        [FindsBy(How = How.Custom, CustomFinderType = typeof(TestIdBy), Using = "uc-change-password-btn-save-password")]
        public IWebElement BtnSavePassword { get; set; }
    }
}
