using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ecommerce.Base;

namespace Test_Ecommerce.Pages
{
    public class DashboardPage : BasePage
    {
        IWebElement myAccount = driver.FindElement(By.XPath("//h2[normalize-space()='My Account']"));
        IWebElement editYourAcBtn => driver.FindElement(By.XPath("//a[normalize-space()='Edit your account information']"));

        public string getMyAccount()
        {
            return myAccount.Text;
        }
        public string geteditAccount()
        {
            return editYourAcBtn.Text;
        }

    }
}
