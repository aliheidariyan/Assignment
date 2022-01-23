using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class WebElementExtensions
    {
        public static IWebElement PgFindElement(this ISearchContext SearchContext, By by, bool needWaitToClicable = false, int timeSpan = 100)
        {
            bool result = false;
            int counter = 0;

            IWebElement foundElement = null;

            while (!result)
            {
                try
                {
                    foundElement = SearchContext.FindElement(by);
                    var b = foundElement.Displayed;
                    result = true;
                }
                catch (StaleElementReferenceException)
                {
                    counter++;
                    if (counter == timeSpan)
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    counter++;
                    if (counter == timeSpan)
                    {
                        counter = 0;
                        return null;
                    }
                }

            }
            if (result)
            {
                //if (needWaitToClicable)
                //{
                //    BasePage.WaitUntileElementClickAble(foundElement);
                //}
                System.Threading.Thread.Sleep(200);
                return foundElement;
            }
            else
            {
                throw new WebDriverException("elementi peida nashod");
            }

        }


        public static ReadOnlyCollection<IWebElement> PgFindElements(this ISearchContext SearchContext, By by, int timeSpan = 100)
        {
            bool result = false;
            int counter = 0;

            ReadOnlyCollection<IWebElement> foundElements = null;

            while (!result)
            {
                try
                {
                    foundElements = SearchContext.FindElements(by);

                    result = true;
                }
                //catch (StaleElementReferenceException)
                //{                    

                //    counter++;
                //}
                catch (Exception)
                {

                    counter++;
                    if (counter == timeSpan)
                    {
                        return null;
                    }
                }
            }
            if (result)
            {
                return foundElements;
            }
            else
            {
                throw new WebDriverException("elementi peida nashod");
            }

        }

        public static void AliSendKeys(this IWebElement webElemnt, string text, int timeSpan = 300)
        {
            int counter = 0;
            bool result = false;
            while (!result)
                try
                {
                    System.Threading.Thread.Sleep(10);
                    webElemnt.SendKeys(text);
                    result = true;
                }
                catch (Exception ex)
                {
                    counter++;
                    if (counter == timeSpan)
                    {
                        throw new WebDriverException(ex.Message);
                    }
                }
        }



        public static bool HasCssClass(this IWebElement element, string className)
        {
            var value = element.GetAttribute("class");
            return !string.IsNullOrWhiteSpace(value) && value.Contains(className);
        }

        #region Checkbox&RadioButtonMethods
        //public static IWebElement SelectElementFromOptionalList(this ISearchContext iSearchContextObj, string SecondArgument, int timespan = 100)
        //{
        //    IWebElement element = null;
        //    bool result = false;
        //    int counter = 0;
        //    while (!result)
        //    {
        //        try
        //        {
        //            var testStaled = (iSearchContextObj as IWebElement).Selected;
        //            var findOptions = iSearchContextObj.PgFindElements(By.TagName("option"));
        //            if (findOptions != null)
        //            {
        //                while (findOptions.Count <= 0)
        //                {
        //                    counter++;
        //                    if (counter >= timespan)
        //                    {
        //                        counter = 0;
        //                        break;
        //                    }
        //                    findOptions = iSearchContextObj.PgFindElements(By.TagName("option"));
        //                }
        //            }
        //            element = findOptions.FirstOrDefault(x => x.Text.Trim().Replace(" ", "").ToLower().Contains(SecondArgument.Trim().Replace(" ", "").ToLower()));
        //            result = true;
        //        }

        //        catch (StaleElementReferenceException)
        //        {
        //            counter++;
        //            if (counter >= timespan)
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                return SelectElementFromOptionalList(iSearchContextObj, SecondArgument);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            counter++;
        //            if (counter >= timespan)
        //            {
        //                return null;
        //            }
        //            else
        //            {

        //                return SelectElementFromOptionalList(iSearchContextObj, SecondArgument);
        //            }
        //        }
        //    }

        //    if (element != null)
        //    {
        //        System.Threading.Thread.Sleep(500);
        //        return element;
        //    }
        //    else
        //    {
        //        var findOptions = iSearchContextObj.PgFindElements(By.TagName("option"));
        //        //throw new WebElementExceptions("CanNotFind_TagName(specifidtext)_In_This_List_Element", "SelectElementFromOptionalList-findOptions");
        //    }
        //    //throw new WebElementExceptions("CanNotFind_TagName(specifidtext)_In_This_List_Element", "SelectElementFromOptionalList");
        //}

        public static void ClickCheckBox(this ISearchContext iSearchContext)
        {

            var element = iSearchContext.PgFindElements(By.TagName("label")).FirstOrDefault();
            if (element == null)
            {
                element = iSearchContext.PgFindElements(By.TagName("input")).FirstOrDefault();
            }
            if (element != null)
            {
                element.Click();
            }
            else
            {
                //throw new WebElementExceptions("CanNotFind_TagName(Label)_In_This_CheckBox_Element", "ClickCheckBox");
            }

        }

        public static void SelectRadioButton(this ISearchContext iSearchContext)
        {
            //BasePage.WaitUntileElementClickAble(iSearchContext.PgFindElements(By.TagName("label")).FirstOrDefault());
            var element = iSearchContext.PgFindElements(By.TagName("label")).FirstOrDefault();
            if (element == null)
            {
                //BasePage.WaitUntileElementClickAble(iSearchContext.PgFindElements(By.TagName("input")).FirstOrDefault());
                element = iSearchContext.PgFindElements(By.TagName("input")).FirstOrDefault();
            }
            if (element != null)
            {
                element.Click();
            }
            else
            {
                //throw new WebElementExceptions("CanNotFind_TagName(Label)_In_This_RadioButton_Element", "SelectRadioButton");
            }

        }

        public static bool GetCheckBoxStatus(this ISearchContext iSearchContext, string tagName)
        {
            var findElement = iSearchContext.PgFindElements(By.TagName(tagName)).FirstOrDefault(x => x.GetAttribute("checked") == "true");

            bool result = false;
            if (findElement != null)
            {
                var element = findElement.GetAttribute("checked");
                if (element.Trim().ToLower() == "true")
                {
                    result = true;
                }
                if (element.Trim().ToLower() == "false")
                {
                    result = false;
                }
                return result;

            }
            else
            {
                return result;
            }

        }

        #endregion Checkbox&RadioButtonMethods

        #region GridMethods

        public static bool FindAddedToGrid(this ISearchContext iSearchContextObj, IList<IWebElement> ListOfAllRows, string ColumnNameTestClass, string rowNameForFind)
        {
            System.Threading.Thread.Sleep(500);
            foreach (IWebElement elm in ListOfAllRows)
            {
                IWebElement tdName = null;
                if ((elm.PgFindElements(By.ClassName(ColumnNameTestClass), 1)) != null)
                {
                    tdName = elm.PgFindElements(By.ClassName(ColumnNameTestClass)).FirstOrDefault();
                }

                if (tdName != null)
                {
                    if (tdName.Text.Contains(rowNameForFind) || tdName.Text.Trim().Replace(" ", "") == rowNameForFind.Trim().Replace(" ", ""))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void SelectGrid(this ISearchContext iSearchContextObj, IList<IWebElement> ListOfAllRows, string ColumnNameTestClass, string rowNameForFind, int timeSpan = 100)
        {
            System.Threading.Thread.Sleep(2000);
            int counter = 0;
            try
            {
                var a = iSearchContextObj;

                foreach (IWebElement elm in ListOfAllRows)
                {
                    IWebElement tdName = null;
                    var b = elm.PgFindElements(By.ClassName(ColumnNameTestClass));
                    if ((elm.PgFindElements(By.ClassName(ColumnNameTestClass))) != null)
                    {
                        tdName = elm.PgFindElements(By.ClassName(ColumnNameTestClass), 20).FirstOrDefault();
                    }

                    if (tdName != null)
                    {
                        if (tdName.Text.Contains(rowNameForFind) || tdName.Text.Trim().Replace(" ", "") == rowNameForFind.Trim().Replace(" ", ""))
                        {
                            elm.PgFindElement(By.ClassName(ColumnNameTestClass)).Click();
                            break;
                        }
                    }
                }
            }
            catch (StaleElementReferenceException)
            {
                counter++;
                if (counter < timeSpan)
                {
                    SelectGrid(iSearchContextObj, ListOfAllRows, ColumnNameTestClass, rowNameForFind);
                }
            }

        }

        public static bool ClickOnGridButton(this ISearchContext iSearchContextObj, List<IWebElement> ListOfAllRows, string ColumnNameTestClass, string rowNameForFind, string btnClassName, By finalFind = null)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {
                var test = ListOfAllRows[0].Text;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            foreach (IWebElement elm in ListOfAllRows)
            {
                IWebElement tdName = null;
                if ((elm.PgFindElements(By.ClassName(ColumnNameTestClass))) != null)
                {
                    tdName = elm.PgFindElements(By.ClassName(ColumnNameTestClass)).FirstOrDefault();
                }

                if (tdName != null)
                {

                    if (tdName.Text.Contains(rowNameForFind) || tdName.Text.Trim().Replace(" ", "") == rowNameForFind.Trim().Replace(" ", ""))
                    {
                        IWebElement element = null;
                        if (!string.IsNullOrEmpty(btnClassName))
                        {
                            element = elm.PgFindElements(By.ClassName(btnClassName)).FirstOrDefault();
                            if (element != null)
                            {
                                if (element.PgFindElements(By.TagName("input")).FirstOrDefault() != null)
                                {
                                    element = element.PgFindElement(By.TagName("input"));
                                }
                            }
                        }
                        if (finalFind != null)
                        {
                            element = elm.PgFindElement(finalFind);
                        }
                        try
                        {
                            element.Click();
                        }
                        catch (ElementNotInteractableException)
                        {
                            System.Threading.Thread.Sleep(500);
                            //BasePage b = new BasePage();
                            //b.ScrollToElement(element);
                            System.Threading.Thread.Sleep(1000);
                            element.Click();
                        }
                        break;
                    }
                }
            }
            return true;

        }

        public static bool FindBtnOnGrid(this ISearchContext iSearchContextObj, IList<IWebElement> ListOfAllRows, string ColumnNameTestClass, string rowNameForFind, string btnClassName, By finalFind = null)
        {
            System.Threading.Thread.Sleep(2000);
            bool result = false;
            foreach (IWebElement elm in ListOfAllRows)
            {
                IWebElement tdName = null;
                if ((elm.PgFindElements(By.ClassName(ColumnNameTestClass))) != null)
                {
                    tdName = elm.PgFindElements(By.ClassName(ColumnNameTestClass), 1).FirstOrDefault();
                }

                if (tdName != null)
                {
                    if (tdName.Text.Contains(rowNameForFind) || tdName.Text.Trim().Replace(" ", "") == rowNameForFind.Trim().Replace(" ", ""))
                    {
                        IWebElement element = null;
                        if (!string.IsNullOrEmpty(btnClassName))
                        {
                            element = elm.PgFindElements(By.ClassName(btnClassName)).FirstOrDefault();
                            if (element != null)
                            {
                                result = true;
                            }
                        }
                        if (finalFind != null)
                        {

                            element = elm.PgFindElements(finalFind).FirstOrDefault();
                            if (element != null)
                            {
                                result = true;
                            }
                        }

                        break;
                    }
                }
            }
            return result;

        }

        #endregion GridMethods

        #region SwitchMethods

        public static void SwitchToIframe(this IWebDriver webDriver, string src, int timeSpan = 1, int waitTime = 2000)
        {

            System.Threading.Thread.Sleep(waitTime);
            try
            {

                var AllIframe = Browsers.Driver.PgFindElements(By.TagName("iframe"));
                //if (AllIframe.Count <= 0)
                //{
                //    System.Threading.Thread.Sleep(4000);
                //    AllIframe = Browsers.Driver.PgFindElements(By.TagName("iframe"));
                //}

                bool hasSwitched = false;
                int counter = 0;
                if (/*AllIframe.Count > 0*/true)
                {
                    while (!hasSwitched)
                    {

                        var fact = AllIframe.FirstOrDefault(x => x.GetAttribute("src").Contains(src));
                        if (fact != null)
                        {
                            //do
                            //{
                            //    Browsers.Driver.SwitchTo().Frame(fact);
                            //    System.Threading.Thread.Sleep(waitTime);
                            //    fact = Browsers.Driver.PgFindElements(By.TagName("iframe")).FirstOrDefault(x => x.GetAttribute("src").Contains(src));
                            //    hasSwitched = true;
                            //} while (Browsers.Driver.PgFindElements(By.TagName("iframe")).Count > 0 && fact != null);

                            //BasePage.WaitUntilDocumentReadyStatic();
                        }
                        else
                        {
                            counter++;
                            if (counter == timeSpan)
                            {
                                break;
                            }
                            SwitchToIframe(webDriver, src);
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                //throw new WebElementExceptions("Can Not Switch To This Iframe Src in the extension Method==> " + src + " " + Environment.NewLine + ex.Message, "SwitchToIframe");
            }

        }

        //public static bool CheckIframeIsOpened(this IWebDriver webDriver, string src, int waitTime = 2000)
        //{

        //    System.Threading.Thread.Sleep(waitTime);
        //    bool result = false;
        //    try
        //    {
        //        IList<IWebElement> AllIframe = null;
        //        if ((Browsers.Driver.PgFindElements(By.TagName("option"))) != null)
        //        {
        //            AllIframe = Browsers.Driver.PgFindElements(By.TagName("iframe"));
        //        }

        //        if (AllIframe.Count > 0)
        //        {
        //            var fact = AllIframe.FirstOrDefault(x => x.GetAttribute("src").Contains(src));
        //            if (fact != null)
        //            {
        //                result = true;
        //                return result;
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new WebElementExceptions("Can Not CheckIframeIsOpened Src in the extension Method==> " + src + " " + Environment.NewLine + ex.Message, "CheckIframeIsOpened");
        //    }

        //}

        public static void SwitchToCurrentWindowHanldler(this IWebDriver webDriver, int waitTime = 2000)
        {
            Browsers.Driver.SwitchTo().Window(Browsers.Driver.CurrentWindowHandle);
            System.Threading.Thread.Sleep(waitTime);
        }

        #endregion SwitchMethods

        public static void ClickOnSettingMenuSubItem(this IWebDriver webDriver, SettingMenuSubType SubMenuItemParent, SettingMenuChildSubType SubMenuItemChild)
        {
            //Pages.PgMasterDefaultPage.GotoHomePage();
            System.Threading.Thread.Sleep(4000);

            //while (!Pages.PgMasterDefaultPage.SettingsMenuItem.Displayed)
            //{
            //    Pages.PgMasterDefaultPage.MenuMoreButton.Click();
            //    System.Threading.Thread.Sleep(2000);
            //    //if (Pages.PgMasterDefaultPage.SettingsMenuItem.Displayed)
            //    //{
            //    //    break;
            //    //}
            //}

            //Pages.PgMasterDefaultPage.SettingsMenuItem.Click();
            System.Threading.Thread.Sleep(2000);
            switch (SubMenuItemParent)
            {
                case SettingMenuSubType.NumberingTemplateMenuItem:
                    {
                        try
                        {
                            //Pages.PgMasterDefaultPage.NumberingTemplatePageMenuItem.Click();
                        }
                        catch
                        {
                            Browsers.Driver.Navigate().Refresh();
                            ClickOnSettingMenuSubItem(webDriver, SubMenuItemParent, SubMenuItemChild);
                        }
                        break;
                    }
                case SettingMenuSubType.CrmEventListMenuItem:
                    {
                        try
                        {
                            // Pages.PgMasterDefaultPage.CrmEventListPageMenuItem.Click();
                        }
                        catch
                        {
                            Browsers.Driver.Navigate().Refresh();
                            ClickOnSettingMenuSubItem(webDriver, SubMenuItemParent, SubMenuItemChild);
                        }
                        break;
                    }
                case SettingMenuSubType.GeneralSettings:
                    {
                        try
                        {
                            //Pages.PgMasterDefaultPage.GeneralSettingsMenuItem.Click();
                        }
                        catch
                        {
                            Browsers.Driver.Navigate().Refresh();
                            ClickOnSettingMenuSubItem(webDriver, SubMenuItemParent, SubMenuItemChild);
                        }
                        break;
                    }
                case SettingMenuSubType.PersonalizeSettings:
                    {
                        try
                        {
                            //Pages.PgMasterDefaultPage.PersonalizeSettings.Click();
                        }
                        catch
                        {
                            Browsers.Driver.Navigate().Refresh();
                            ClickOnSettingMenuSubItem(webDriver, SubMenuItemParent, SubMenuItemChild);
                        }
                        break;
                    }

            }

            System.Threading.Thread.Sleep(2000);
            switch (SubMenuItemChild)
            {
                case SettingMenuChildSubType.none:
                    {
                        break;
                    }
                case SettingMenuChildSubType.PersonalizeSettingsOverview:
                    {
                        //Pages.PgMasterDefaultPage.PersonalizeSettingsOverview.Click();
                        break;
                    }
            }
        }

        public enum SettingMenuSubType
        {
            NumberingTemplateMenuItem,
            CrmEventListMenuItem,
            GeneralSettings,
            PersonalizeSettings

        }

        public enum SettingMenuChildSubType
        {
            none,
            PersonalizeSettingsOverview
        }

        public static readonly string ReportBasePath = ConfigurationManager.AppSettings["reportBasePath"];
        public static void ScreenShot(this Exception exception, string filename)
        {
            Random generator = new Random();
            Screenshot ss = ((ITakesScreenshot)Browsers.Driver).GetScreenshot();
            String path = ReportBasePath;//Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            //String filepath = Path.Combine(ReportBasePath + "/screenshots/", filename + generator.Next(1, 10) + ".png");
            //ss.SaveAsFile(filepath, ScreenshotImageFormat.Png);
        }
    }
}
