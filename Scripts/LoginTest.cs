using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ecommerce.Pages;

namespace Test_Ecommerce.Scripts
{

    public class LoginTest : BaseTest
    {
        [Test]
        public void loginWithEmptyValues()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail("").EnterPassword("").ClickLogin();
            Assert.That(driver.FindElement(By.CssSelector(".alert.alert-danger.alert-dismissible")).Displayed, Is.EqualTo(true));
            Assert.That(loginpage.getLoginButton().Displayed, Is.EqualTo(true));
            Assert.AreEqual(driver.FindElement(By.CssSelector(".alert.alert-danger.alert-dismissible")).Text, "Warning : Please Enter email and password");
            Assert.AreEqual(driver.Title, "Account Login");
        }
        [Test]
        public void loginWithValidCredentials()
        {
            new LoginPage().EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();

        }
        [Test]
        public void loginWithInValidCredentials()
        {
            new LoginPage().EnterEmail("Invalid").EnterPassword("Invalid").ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");

        }

        [Test]
        public void loginWithValidEmail()
        {
            new LoginPage().EnterEmail(TestData.LoginData.email).ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");

        }

        [Test]
        public void loginWithValidPassword()
        {
            new LoginPage().EnterEmail(TestData.LoginData.email).ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");

        }







    }
}
