
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment.Page;
using TaskAssignment.Page.UserControlPage;

namespace TaskAssignment
{
    public static class Pages
    {
        public static T GetPages<T>(ISearchContext context = null)
            where T : new()
        {
            var page = new T();
            try
            {
                PageFactory.InitElements(context ?? Browsers.Driver, page);
                return page;
            }
            catch (StaleElementReferenceException)
            {
                System.Threading.Thread.Sleep(1500);
                PageFactory.InitElements(context ?? Browsers.Driver, page);
                return page;
            }
        }

        //public static BasePage BasePage
        //{
        //    get { return GetPages<BasePage>(); }
        //}

        public static LoginPage LoginPage
        {
            get { return GetPages<LoginPage>(); }
        }
        public static PgMasterDefaultPage PgMasterDefaultPage
        {
            get { return GetPages<PgMasterDefaultPage>(); }
        }
        public static UcChangePasswordPage UcChangePasswordPage
        {
            get { return GetPages<UcChangePasswordPage>(); }
        }


    }
}
