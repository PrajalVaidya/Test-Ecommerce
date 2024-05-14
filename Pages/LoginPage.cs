using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ecommerce.Pages
{
    public class LoginPage : Global
    {
        IWebElement email => driver.FindElement(By.Id("input-email"));
        IWebElement passWord => driver.FindElement(By.Id("input-password"));
        IWebElement loginBtn => driver.FindElement(By.CssSelector("input[value='Login']"));
        string title => driver.Title;
        public LoginPage EnterEmail(string email)
        {
            this.email.SendKeys(email);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            this.passWord.SendKeys(password);
            return this;
        }
        public LoginPage ClickLogin()
        {
            loginBtn.Click();
            return this;
        }
        public IWebElement getLoginButton()
        {
            return loginBtn;
        }
    }
}
