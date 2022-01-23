using TaskAssignment.InfoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskAssignment.FunctionAction
{
    public class LoginAndChangePasswordAction
    {
        public LoginAndChangePasswordAction(LoginAndChangePasswordInfo logininfo)
        {

            AuthorizeByLoginPage(logininfo);
            if (Browsers.Driver.Url.Contains("/ChangePassword.aspx"))
            {
                WebElementExtensions.SwitchToCurrentWindowHanldler(Browsers.Driver);
                var changePass = new ChangePasswordAction();
                //changePass.SaveChangePassword(logininfo);
                logininfo.PasswordHasChangedWithLogin = true;
                if (Browsers.Driver.Url.Contains(Browsers.BaseURL + "/Login.aspx"))
                {
                    logininfo.CurrentPassword = logininfo.NewPassword;
                    AuthorizeByLoginPage(logininfo);
                }
            }
            if (logininfo.PasswordHasChangedWithLogin)
            {
                logininfo.CurrentPassword = logininfo.NewPassword;
            }
        }

        public void AuthorizeByLoginPage(LoginAndChangePasswordInfo logininfo)
        {
            Pages.LoginPage.UsernameTextBox.SendKeys(logininfo.UserName);
            Pages.LoginPage.PasswordTextBox.SendKeys(logininfo.CurrentPassword);
            Pages.LoginPage.LoginButton.Click();
            System.Threading.Thread.Sleep(500);
        }


    }
}
