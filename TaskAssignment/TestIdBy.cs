using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAssignment
{
    public class TestIdBy : By
    {
        public TestIdBy(string testid)
        {
            string xPath = "//*[@testid='" + testid + "']";
            string cssSelector = $"[testId='{testid}']";
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.CssSelector(cssSelector));
                return mockElement;
            };
            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.CssSelector(cssSelector));
                return mockElements;
            };

        }
        //public AppiumWebElement Find(AndroidDriver<AndroidElement> driver, string testid)
        //{
        //    string xPath = "//*[@testid='" + testid + "']";
        //    string cssSelector = $"[testId='{testid}']";
        //    var mockElement = driver.FindElementByCssSelector(cssSelector);
        //    return mockElement;
        //}

        //public IEnumerable<AppiumWebElement> Finds(AndroidDriver<AndroidElement> driver, string testid)
        //{
        //    string xPath = "//*[@testid='" + testid + "']";
        //    string cssSelector = $"[testId='{testid}']";
        //    IEnumerable<AppiumWebElement> mockElement = driver.FindElementsByCssSelector(cssSelector);
        //    return mockElement;
        //}
    }

    public class EndsWithIdBy : By
    {
        public EndsWithIdBy(string endsWithId)
        {
            string cssSelector = "[id$='" + endsWithId + "']";

            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.CssSelector(cssSelector));
                return mockElement;
            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElement = context.FindElements(By.CssSelector(cssSelector));
                return mockElement;
            };
        }
    }
}
