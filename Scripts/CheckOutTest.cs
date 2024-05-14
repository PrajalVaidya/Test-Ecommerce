using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Ecommerce.Pages;

namespace Test_Ecommerce.Scripts
{
    public class CheckOutTest : BaseTest
    {
        [Test]
        public void checkOutwithExistingAddress()
        {

            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            checkOut.checkoutWithExistingAddress();
            checkOut.confirmOrder();
            checkOut.getOrderSucessPage();
            Assert.AreEqual(driver.FindElement(By.XPath("//h1[normalize-space()='Your order has been placed!']")).Text, "Your order has been placed!");
        }
        [Test]
        public void checkOutWithAllFieldsOnlyInAddress()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            checkOut.FillBillingAddressWithAllFields();
            checkOut.confirmOrder();
            checkOut.getOrderSucessPage();
            Assert.AreEqual(driver.FindElement(By.XPath("//h1[normalize-space()='Your order has been placed!']")).Text, "Your order has been placed!");
        }
        [Test]
        public void checkoutWithRequiredFieldsOnly()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            checkOut.FillBillingAddressWithRequiredFieldsOnly();
            checkOut.confirmOrder();
            checkOut.getOrderSucessPage();
            Assert.AreEqual(driver.FindElement(By.XPath("//h1[normalize-space()='Your order has been placed!']")).Text, "Your order has been placed!");

        }
        [Test]
        public void checkCheckoutWithEmptyFields()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            checkOut.FillBillingAddressWithNoFields();
            Assert.AreEqual(driver.FindElement(By.XPath("//div[contains(text(),'First Name must be between 1 and 32 characters!')]")).Text,
                "First Name must be between 1 and 32 characters!"); 
            Assert.AreEqual(driver.FindElement(By.XPath("//div[contains(text(),'Last Name must be between 1 and 32 characters!')]")).Text,
                "Last Name must be between 1 and 32 characters!"); 
            Assert.AreEqual(driver.FindElement(By.XPath("//div[contains(text(),'Address 1 must be between 3 and 128 characters!')]")).Text,
                "Address 1 must be between 3 and 128 characters!");
            Assert.AreEqual(driver.FindElement(By.XPath("//div[contains(text(),'City must be between 2 and 128 characters!')]")).Text,
                "City must be between 2 and 128 characters!");
            Assert.AreEqual(driver.FindElement(By.XPath("//div[normalize-space()='Please select a country!']")).Text,
                "Please select a country!");
        }
        [Test]
        public void checkOutWithoutCheckingTermsandConditions()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            checkOut.FillBillingAddressWithNoCheckOnTermAndConditons();
            Assert.AreEqual(driver.FindElement(By.XPath("//div[@class='alert alert-warning alert-dismissible']")).Text, "Warning: You must agree to the Terms & Conditions!\r\n×");

        }
        [Test]
        public void checkSelectedProductImageIsPresent()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            Assert.IsTrue(checkOut.getProductImg());

        }
        [Test]
        public void checkSelectedProductTextIsPresent()
        {
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);

            CheckOutPage checkOut = new CheckOutPage();
            Assert.AreEqual(checkOut.getProductTitle(),"HTC Touch HD");
        }
        
    }
}
