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
            Assert.That(loginpage.getLoginErrorMsg().Contains("Warning : Please Enter email and password"), Is.EqualTo(true));
            Assert.AreEqual(driver.Title, "Account Login");
        }
        [Test]
        public void loginWithValidCredentials()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            loginpage.waitForLogin();
            Assert.AreEqual(new DashboardPage().getMyAccount(), "My Account");
            Assert.AreEqual(new DashboardPage().geteditAccount(), "Edit your account information");
        }
        [Test]
        public void loginWithInvalidCredentials()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail("Invalid").EnterPassword("Invalid").ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");
            Assert.AreEqual(loginpage.getLoginErrorMsg(), "Warning: No match for E-Mail Address and/or Password.");
        }

        [Test]
        public void loginWithValidEmail()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");
            Assert.AreEqual(loginpage.getLoginErrorMsg(), "Warning: No match for E-Mail Address and/or Password.");

        }

        [Test]
        public void loginWithValidPassword()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterPassword(TestData.LoginData.email).ClickLogin();
            Assert.AreEqual(driver.Title, "Account Login");
            Assert.AreEqual(loginpage.getLoginErrorMsg(), "Warning: No match for E-Mail Address and/or Password.");

        }
    }
}
