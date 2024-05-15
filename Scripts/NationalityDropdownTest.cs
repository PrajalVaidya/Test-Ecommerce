using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test_Ecommerce.Pages;

namespace Test_Ecommerce.Scripts
{
    public class NationalityDropdownTest :BaseTest
    {
        [Test]
        public void TestSelectedValueIsSaved()
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label[for='input-payment-address-new']")).Click();
            new Actions(driver).ScrollByAmount(0, 400).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByValue("149");
            Thread.Sleep(2000);
            Assert.AreEqual("Nepal", selectCountry.SelectedOption.Text, "Selected value should be 'Nepal'");
        }
        [Test]
        public void TestCountryOptionsAreNotNull()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label[for='input-payment-address-new']")).Click();
            new Actions(driver).ScrollByAmount(0, 400).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            var opt = selectCountry.Options.Count;
            Assert.AreNotEqual(0,selectCountry.Options.Count);
        }
        [Test]
        public void TestRegionIsSelected()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label[for='input-payment-address-new']")).Click();
            new Actions(driver).ScrollByAmount(0, 400).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByValue("149");
            Thread.Sleep(2000);
            SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-payment-zone")));
            selectRegion.SelectByValue("2315");
            Thread.Sleep(2000);
            Assert.AreEqual("Bagmati", selectRegion.SelectedOption.Text, "Selected value should be 'Bagmati'");
        }
        [Test]
        public void TestDropDownOptionsAreVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label[for='input-payment-address-new']")).Click();
            new Actions(driver).ScrollByAmount(0, 400).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            
            foreach (var option in selectCountry.Options)
            {
                var opt = option.Displayed;
                Assert.IsTrue(option.Displayed, $"Option '{option.Text}' should be visible");
            }
        }
        [Test]
        public void TestDropdownBackGroundColor()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            LoginPage loginpage = new LoginPage();
            loginpage.EnterEmail(TestData.LoginData.email).EnterPassword(TestData.LoginData.passWord).ClickLogin();
            driver.Navigate().GoToUrl(TestData.Url.productUrl);
            new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut)).Until(ExpectedConditions.ElementExists(By.CssSelector("button[title='Buy now']")));
            driver.FindElement(By.CssSelector("button[title='Buy now']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("label[for='input-payment-address-new']")).Click();
            new Actions(driver).ScrollByAmount(0, 400).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            IWebElement element = driver.FindElement(By.Id("input-payment-country"));
            string backgroundColor = element.GetCssValue("background-color");
            Assert.AreEqual("rgba(255, 255, 255, 1)", backgroundColor, "Dropdown should have the correct background color");

        }
    }
}
