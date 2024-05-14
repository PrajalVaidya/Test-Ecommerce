using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ecommerce.Pages
{
    public class LoginPage : BasePage
    {
        //Form section
        IWebElement email => driver.FindElement(By.Id("input-email"));
        IWebElement passWord => driver.FindElement(By.Id("input-password"));
        IWebElement loginBtn => driver.FindElement(By.CssSelector("input[value='Login']"));

        //TopErrorMessage
        IWebElement errMsg => driver.FindElement(By.CssSelector(".alert.alert-danger.alert-dismissible"));

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
        public void waitForLogin()
        {
            DashboardPage dashboard = new DashboardPage();
            waitTillElementIsPresent(By.XPath("//h2[normalize-space()='My Account']"));
        }
        public IWebElement getLoginButton()
        {
            return loginBtn;
        }
        public string getLoginErrorMsg()
        {
            return errMsg.Text;
        }
    }
}
