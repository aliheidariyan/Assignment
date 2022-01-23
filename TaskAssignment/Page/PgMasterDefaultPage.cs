using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAssignment.Page
{
    public class PgMasterDefaultPage
    {

        public IWebElement MainMenuBar
        {
            get
            {
                //WaitUntilDocumentReady();
                if (Browsers.Driver.PgFindElements(By.ClassName("rnvRootGroupWrapper")).Count <= 0)
                {
                    //ReTryFindElements(20, By.ClassName("rnvRootGroupWrapper"));
                }
                //WaitAMoment();
                //Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
                System.Threading.Thread.Sleep(500);
                return Browsers.Driver.PgFindElement(By.ClassName("rnvRootGroupWrapper"));
            }
        }

        public void GotoHomePage()
        {
            //GotoPage("MyFirst/");
        }

        public IWebElement LogoItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.ClassName("logo"));
            }
        }
        public IWebElement ProfileMenuItem => Browsers.Driver.PgFindElement(new TestIdBy("profile-menu-item"));

        public IWebElement DrpProfileMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.ClassName("drp-profile-menu-item"));
            }
        }

        public IWebElement ChangePasswordMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.ClassName("change-password-menu-item"));
            }
        }

        public IWebElement ExitMenuItem
        {
            get
            {
                //WaitUntileElementClickAble(By.ClassName("exit-menu-item"));
                return Browsers.Driver.PgFindElement(By.ClassName("exit-menu-item"));
            }
        }
        //

        //public UcChangePasswordPage SwitchToChangePasswordPage()
        //{
        //    IList<IWebElement> iframe = Browsers.Driver.AliFindElements(By.TagName("iframe"));
        //    if (iframe.Count <= 0)
        //    {
        //        //WaitAMoment();
        //        //WaitAMoment();
        //        iframe = Browsers.Driver.AliFindElements(By.TagName("iframe"));
        //    }

        //    foreach (IWebElement elm in iframe)
        //    {
        //        var att = elm.GetAttribute("src");
        //        if (att.Contains("/User/ChangePassword.aspx"))
        //        {
        //            var driver = Browsers.Driver.SwitchTo().Frame(elm);
        //            return Pages.GetPages<UcChangePasswordPage>(driver);
        //        }
        //    }

        //    return null;
        //}





        public IWebElement MenuMoreButton
        {
            get
            {
                return MainMenuBar.PgFindElement(By.ClassName("rnvMore"));
            }
        }

        //تنظیمات
        private IWebElement _settingsMenuItem = null;
        public IWebElement SettingsMenuItem
        {
            get
            {
                if (_settingsMenuItem == null)
                {
                    var settingsClassName = ".setting-menu-item";

                    var elements = MainMenuBar.PgFindElements(By.CssSelector(settingsClassName));
                    if (elements != null && elements.Count > 0)
                    {
                        _settingsMenuItem = elements[0];
                    }
                    else
                    {
                        _settingsMenuItem = Browsers.Driver.PgFindElement(By.ClassName("rnvMoreNodes")).PgFindElement(By.ClassName("rnvUL")).PgFindElement(By.CssSelector("li" + settingsClassName));
                    }
                }

                return _settingsMenuItem;
            }
        }

        #region GeneralSetting
        //تنظیمات کلی
        public IWebElement GeneralSettingsMenuItem
        {
            get
            {
                IWebElement toRet = null;
                toRet = SettingsMenuItem.PgFindElement(By.CssSelector("a.general-setting-menu-item"));
                if (toRet == null)
                    toRet = Browsers.Driver.PgFindElement(By.CssSelector("a.general-setting-menu-item"));
                return toRet;
            }
        }
        //public GeneralSettingPage SwitchToGeneralSettings()
        //{
        //    //WaitAMoment();
        //    //WaitAMoment();         
        //    var iframe = Browsers.Driver.PgFindElements(By.TagName("iframe"));
        //    foreach (IWebElement elm in iframe)
        //    {
        //        var att = elm.GetAttribute("src");

        //        if (att.Contains("/MyFirst/Settings/General/Default.aspx"))
        //        {
        //            var driver = Browsers.Driver.SwitchTo().Frame(elm);
        //            break;

        //        }
        //    }
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Settings/General/Default.aspx");

        //    return Pages.GetPages<GeneralSettingPage>(Browsers.Driver);
        //}
        #endregion GeneralSetting


        #region ManageUserAndGroup
        //تنظیمات کلی
        public IWebElement ManageUserAndGroupMenuItem
        {
            get
            {
                IWebElement webElement;
                webElement = SettingsMenuItem.PgFindElement(By.CssSelector("a.manage-user-and-group-menu-item"));
                if (webElement == null)
                    webElement = Browsers.Driver.PgFindElement(By.CssSelector("a.manage-user-and-group-menu-item"));

                return webElement;
            }
        }

        //public ManageUserAndGroupPage SwitchToManageUserAndGroup()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Settings/Users/ManageUSersAndGroups.aspx");
        //    return Pages.GetPages<ManageUserAndGroupPage>(Browsers.Driver);
        //}

        #endregion ManageUserAndGroup

        #region ManageInventories

        public IWebElement ManageInventoriesMenuItem
        {
            get
            {
                IWebElement toRet = null;
                toRet = SettingsMenuItem.PgFindElement(By.CssSelector("a.manage-inventories-menu-item"));
                if (toRet == null)
                    toRet = Browsers.Driver.PgFindElement(By.CssSelector("a.manage-inventories-menu-item"));
                return toRet;
            }
        }
        //public ManageInventoriesPage SwitchToManageInventories()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Inventory/ManageInventories.aspx");
        //    return Pages.GetPages<ManageInventoriesPage>(Browsers.Driver);
        //}

        #endregion ManageInventories

        //شخصی سازی
        public IWebElement PersonalizeSettings
        {
            get
            {
                IWebElement toRet = null;
                toRet = SettingsMenuItem.PgFindElement(By.CssSelector(".setting-personalize-crm"));
                if (toRet == null)
                    toRet = Browsers.Driver.PgFindElement(By.CssSelector(".setting-personalize-crm"));
                return toRet;
            }
        }


        //نمای کلی
        #region Personalizesettinf Over view
        public IWebElement PersonalizeSettingsOverview
        {
            get
            {
                IWebElement toRet = null;
                toRet = PersonalizeSettings.PgFindElement(By.ClassName("setting-personalize-crm-overview"));
                if (toRet == null)
                    toRet = Browsers.Driver.PgFindElement(By.ClassName("setting-personalize-crm-overview"));
                return toRet;
            }
        }

        //public CrmTypesPage SwitchToManageCrmObjectTypeOverView()
        //{
        //    //WaitAMoment();
        //    var windowscount = Browsers.Driver.WindowHandles.Count;
        //    for (int i = 0; i <= windowscount; i++)
        //    {
        //        var driver = Browsers.Driver.SwitchTo().Window(Browsers.Driver.WindowHandles[i]);

        //        if (Browsers.Driver.Url.Contains("/MyFirst/Settings/ManageCrmTypes/CrmTypes.aspx"))
        //        {
        //            Pages.GetPages<CrmTypesPage>(driver).WaitUntilDocumentReady();
        //            return Pages.GetPages<CrmTypesPage>(driver);
        //        }

        //    }
        //    return null;

        //}

        #endregion  Personalizesettinf Over view

        //اطلاعات پایه
        private IWebElement _baseInformationMenuItem = null;
        public IWebElement BaseInformationMenuItem
        {
            get
            {
                if (_baseInformationMenuItem == null)
                {
                    var baseInfoClassName = ".base-information-menu-item";

                    var elements = MainMenuBar.PgFindElements(By.CssSelector(baseInfoClassName));
                    if (elements.Count > 0)
                    {
                        _baseInformationMenuItem = elements[0];
                    }
                    else
                    {
                        _baseInformationMenuItem = Browsers.Driver.PgFindElement(By.ClassName("rnvMoreNodes")).PgFindElement(By.ClassName("rnvUL")).PgFindElement(By.CssSelector("li" + baseInfoClassName));
                    }
                }
                return _baseInformationMenuItem;

            }
        }

        #region ManageProducts
        //مدیریت محصولات
        public IWebElement ManageProductMenuItem
        {
            get
            {
                try
                {
                    return BaseInformationMenuItem.PgFindElement(By.CssSelector("a.manage-product-menu-item"));
                }
                catch (Exception ex)
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-product-menu-item"));
                }

            }
        }
        //public BrowseProductsPage SwitchToManageProduct()
        //{
        //    var windowscount = Browsers.Driver.WindowHandles.Count;
        //    for (int i = 0; i <= windowscount; i++)
        //    {
        //        var driver = Browsers.Driver.SwitchTo().Window(Browsers.Driver.WindowHandles[i]);
        //        if (Browsers.Driver.Url.Contains("/MyFirst/Settings/Products/BrowseProducts.aspx"))
        //        {
        //            Pages.BrowseProductsPage.WaitUntilDocumentReady();
        //            return Pages.GetPages<BrowseProductsPage>(driver);
        //        }
        //    }
        //    return null;
        //}
        #endregion ManageProducts


        //مدیریت شعب دپارتمان سمت
        #region ManageDepartmentAndPosition

        public IWebElement ManageDepartmentAndPositionMenuItem
        {
            get
            {
                try
                {
                    return BaseInformationMenuItem.PgFindElement(By.CssSelector("a.manage-department-and-position-menu-item"));
                }
                catch (Exception ex)
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-department-and-position-menu-item"));
                }
            }
        }

        //public ManageDepartmentsAndPositionsPage SwitchToManageDepartmentAndPositon()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Settings/Offices/Offices.aspx");
        //    return Pages.GetPages<ManageDepartmentsAndPositionsPage>(Browsers.Driver);
        //}

        #endregion ManageDepartmentAndPosition


        //مدیریت اتاق ها
        #region ManageRooms

        public IWebElement ManageRoomsMenuItem
        {
            get
            {
                try
                {
                    return BaseInformationMenuItem.PgFindElement(By.CssSelector("a.manage-rooms-menu-item"));
                }
                catch (Exception ex)
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-rooms-menu-item"));
                }
            }
        }

        //public ManageRoomsPage SwitchToManageRooms()
        //{

        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Settings/Offices/ManageRooms.aspx");
        //    return Pages.GetPages<ManageRoomsPage>(Browsers.Driver);
        //}

        #endregion ManageRooms

        //مدیریت سیستم تلفنی
        #region ManageTelephonySystem

        public IWebElement TelephonySystemMenuItem
        {
            get
            {
                try
                {
                    return BaseInformationMenuItem.PgFindElement(By.CssSelector(".telephony-system-menu-item"));
                }
                catch (Exception ex)
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector(".telephony-system-menu-item"));
                }
            }
        }
        public IWebElement ManageTelephonySystemMenuItem
        {
            get
            {
                return TelephonySystemMenuItem.PgFindElement(By.CssSelector("a.manage-telephony-system-menu-item"));
            }
        }

        //public ManageTelephonySystemPage SwitchToManageTelephonySystem()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/ManageTelephonySystems.aspx");
        //    return Pages.GetPages<ManageTelephonySystemPage>(Browsers.Driver);
        //}


        #endregion ManageTelephonySystem

        //مدیریت پیام های الگو
        #region ManageTemplate

        public IWebElement ManageTemplatesMenuItem
        {
            get
            {
                try
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-template-menu-item"));
                }
                catch (Exception ex)
                {
                    return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-template-menu-item"));
                }
            }
        }

        //public ManageTemplatePage SwitchToManageTemplates()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/ManageTemplates.aspx");
        //    return Pages.GetPages<ManageTemplatePage>(Browsers.Driver);
        //}


        #endregion ManageTemplate

        //مدیریت اعیاد و مناسبت ها
        #region ManageTemplate


        public IWebElement ManageSpecialDatesMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-special-dates-menu-item"));
            }
        }

        //public ManageSpecialDatesPage SwitchToManageSpecialDates()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/ManageSpecialDates.aspx");
        //    return Pages.GetPages<ManageSpecialDatesPage>(Browsers.Driver);
        //}


        #endregion ManageTemplate

        //مدیریت کشور استان شهر ها
        #region ManageAddress


        public IWebElement AddressManagementMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-address-menu-item"));
            }
        }

        //public AddressManagementPage SwitchToAddressManagement()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/AddressManagement.aspx");
        //    return Pages.GetPages<AddressManagementPage>(Browsers.Driver);
        //}

        #endregion ManageAddress

        //مدیریت نشانی ها
        #region ManageidentityAddressType

        public IWebElement ManageIdentityAddressTypeMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.identity-addres-type-management-menu-item"));
            }
        }

        //public IdentityAddresTypeManagmentPage SwitchToManageIdentityAddressType()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/IdentityAddressTypeManagement.aspx");
        //    return Pages.GetPages<IdentityAddresTypeManagmentPage>(Browsers.Driver);
        //}

        #endregion ManageidentityAddressType

        //مدیریت حساب های مالی
        #region ManageidentityAddressType

        public IWebElement ManageMoneyAccountMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-money-acount-menu-item"));
            }
        }

        //public ManageMoneyAccountPage SwitchToManageMoneyAccount()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/ManageMoneyAccount.aspx");
        //    return Pages.GetPages<ManageMoneyAccountPage>(Browsers.Driver);
        //}

        #endregion ManageidentityAddressType


        //مدیریت حساب های مالی
        #region ManageidentityAddressType

        public IWebElement ManageCalendarMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-calendar-menu-item"));
            }
        }

        //public ManageCalendarPage SwitchToManageCalendar()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/ManageCalendar.aspx");
        //    return Pages.GetPages<ManageCalendarPage>(Browsers.Driver);
        //}

        #endregion ManageidentityAddressType

        //مدیریت مراحل فروش
        #region ManageSaleStages

        public IWebElement ManagealeStagesMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.manage-sale-stages-menu-item"));
            }
        }

        //public ManageSaleStagePage SwitchToManageSaleStages()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/SaleStages.aspx");
        //    return Pages.GetPages<ManageSaleStagePage>(Browsers.Driver);
        //}

        #endregion ManageSaleStages

        public IWebElement FirstMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement MyCardtableMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }





        #region NumberingTemplate
        //قالب شماره دهی
        public IWebElement NumberingTemplatePageMenuItem
        {
            get
            {
                IWebElement toRet = null;
                toRet = SettingsMenuItem.PgFindElement(By.CssSelector("a.numbering-template-menu-item"));
                if (toRet == null)
                    toRet = Browsers.Driver.PgFindElement(By.CssSelector("a.numbering-template-menu-item"));
                return toRet;
            }
        }
        //public NumberingTemplatePage SwitchToNumberingTemplate()
        //{
        //    WebElementExtensions.SwitchToIframe(Browsers.Driver, "/MyFirst/Settings/General/NumberingTemplate.aspx");
        //    return Pages.GetPages<NumberingTemplatePage>(Browsers.Driver);
        //}

        #endregion NumberingTemplate


        #region CrmEventList
        //مدیریت لیست رویداد ها
        public IWebElement CrmEventListPageMenuItem
        {
            get
            {
                bool result = false;
                IWebElement toRet = null;
                while (!result)
                {
                    try
                    {
                        toRet = SettingsMenuItem.PgFindElement(By.CssSelector("a.crm-event-list-menu-item"));
                        if (toRet == null)
                            toRet = Browsers.Driver.PgFindElement(By.CssSelector("a.crm-event-list-menu-item"));
                        return toRet;
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(1000);
                        return CrmEventListPageMenuItem;
                    }
                }
                return toRet;
            }
        }
        //public CrmEventListPage SwitchToCrmEventListWindows()
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    var windowscount = Browsers.Driver.WindowHandles.Count;
        //    for (int i = 0; i < windowscount; i++)
        //    {
        //        var driver = Browsers.Driver.SwitchTo().Window(Browsers.Driver.WindowHandles[i]);
        //        if (Browsers.Driver.Url.Contains("/MyFirst/CRM/Lists/CrmEventList.aspx"))
        //        {
        //            return Pages.GetPages<CrmEventListPage>(Browsers.Driver);
        //        }
        //    }
        //    return null;
        //}

        #endregion CrmEventList

        #region IntegratedBank_MenuItem

        //بانک یکپارچه
        private IWebElement _IntegratedBankMenuItem = null;
        public IWebElement IntegratedBankMenuItem
        {
            get
            {
                if (_IntegratedBankMenuItem == null)
                {
                    var integratedbankClassName = ".integrated-bank-menu-item";

                    var elements = MainMenuBar.PgFindElements(By.CssSelector(integratedbankClassName));
                    if (elements.Count > 0)
                    {
                        _IntegratedBankMenuItem = elements[0];
                    }
                    else
                    {
                        _IntegratedBankMenuItem = Browsers.Driver.PgFindElement(By.ClassName("rnvMoreNodes")).PgFindElement(By.ClassName("rnvUL")).PgFindElement(By.CssSelector("li" + integratedbankClassName));
                    }
                }

                return _IntegratedBankMenuItem;
            }
        }

        #endregion IntegratedBank_MenuItem

        #region BrowseOrganizationPage

        //بانک اطلاعاتی
        public IWebElement BrowseOrganizationMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.browse-organization-menu-item"));
            }
        }

        //public BrowseOrganizationPage OpenBrowseOrganizationPage()
        //{
        //    if (!Browsers.Driver.Url.Contains("/BrowseOrganizations.aspx"))
        //    {
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        Pages.PgMasterDefaultPage.GotoHomePage();
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        if (!Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Displayed)
        //        {
        //            Pages.PgMasterDefaultPage.MenuMoreButton.Click();
        //            System.Threading.Thread.Sleep(500);
        //        }
        //        if (Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Displayed)
        //        {
        //            Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Click();
        //        }
        //        Pages.PgMasterDefaultPage.BrowseOrganizationMenuItem.Click();
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        return Pages.BrowseOrganizationPage;
        //    }
        //    else
        //    {
        //        Pages.BrowseOrganizationPage.Goto();
        //    }

        //    Pages.BrowseOrganizationPage.WaitUntilDocumentReady();
        //    return Pages.BrowseOrganizationPage;

        //}

        #endregion BrowseOrganizationPage

        #region AdvancedSearchPage

        public IWebElement AdvancedSearchMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.advanced-search-menu-item"));
            }
        }

        //public AdvancedSearchPage OpenAdvancedSearchPage()
        //{

        //    if (!Browsers.Driver.Url.Contains("/AdvancedSearch/AdvancedSearch.aspx"))
        //    {
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        Pages.PgMasterDefaultPage.GotoHomePage();
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        if (!Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Displayed)
        //        {
        //            Pages.PgMasterDefaultPage.MenuMoreButton.Click();
        //            System.Threading.Thread.Sleep(500);
        //        }
        //        if (Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Displayed)
        //        {
        //            Pages.PgMasterDefaultPage.IntegratedBankMenuItem.Click();

        //        }
        //        System.Threading.Thread.Sleep(500);
        //        Pages.PgMasterDefaultPage.AdvancedSearchMenuItem.Click();
        //        Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
        //        return Pages.AdvancedSearchPage;
        //    }
        //    else
        //    {
        //        Pages.AdvancedSearchPage.Goto();
        //    }

        //    Pages.BrowseOrganizationPage.WaitUntilDocumentReady();
        //    return Pages.AdvancedSearchPage;

        //}

        #endregion AdvancedSearch

        //کارتابل من-واقع در منوی راست
        public IWebElement MyCartableInRightMenuItem
        {
            get
            {
                return Browsers.Driver.PgFindElement(By.CssSelector("a.my-cartable-in-right-menu-item"));
            }
        }

        public IWebElement CustomerRelationManagementMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement SalesAndInventoryMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement CommunicationsMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement AdvertisementsMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement ReportsMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement WindowsMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebElement HelpMenuItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
