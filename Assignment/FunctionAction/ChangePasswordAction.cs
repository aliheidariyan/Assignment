using Assignment.InfoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.FunctionAction
{
    public class ChangePasswordAction
    {
        public void SaveChangePassword(LoginAndChangePasswordInfo ChangePasswordInfo)
        {
            if (ChangePasswordInfo.PasswordHasChangedWithLogin)
            {
                Browsers.Driver.Navigate().Refresh();
                //Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
                System.Threading.Thread.Sleep(1000);
                if (Pages.PgMasterDefaultPage.ProfileMenuItem.Displayed)
                {
                    Pages.PgMasterDefaultPage.DrpProfileMenuItem.Click();
                    Pages.PgMasterDefaultPage.ChangePasswordMenuItem.Click();
                    //Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
                    //Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
                    Browsers.Driver.SwitchTo().Window(Browsers.Driver.CurrentWindowHandle);
                    System.Threading.Thread.Sleep(500);
                    //Pages.UcChangePasswordPage.WaitUntilDocumentReady();
                }
            }
            System.Threading.Thread.Sleep(500);
            Pages.UcChangePasswordPage.TxtCurrentPassword.SendKeys(ChangePasswordInfo.CurrentPassword);
            Pages.UcChangePasswordPage.TxtNewPassword.SendKeys(ChangePasswordInfo.NewPassword);
            Pages.UcChangePasswordPage.TxtRepeateNewPassword.SendKeys(ChangePasswordInfo.RepeateNewPassword);
            System.Threading.Thread.Sleep(500);
            Pages.UcChangePasswordPage.BtnSavePassword.Click();
            System.Threading.Thread.Sleep(500);
        }

        public void LoginAgainAfterChangePassword(LoginAndChangePasswordInfo changePasswordInfo)
        {
            Browsers.Driver.SwitchTo().Window(Browsers.Driver.CurrentWindowHandle);
            Browsers.Driver.Navigate().Refresh();
            //Pages.PgMasterDefaultPage.WaitUntilDocumentReady();
            changePasswordInfo.CurrentPassword = "admin";
            System.Threading.Thread.Sleep(500);
            var loginPage = new LoginAndChangePasswordAction(changePasswordInfo);
        }
    }
}
