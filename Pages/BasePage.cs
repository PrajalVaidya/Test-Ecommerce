using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test_Ecommerce.Pages
{
    public class BasePage : Global
    {
        public void waitTillElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void waitTillElementIsPresent(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public void waitTillElementIsClickable(WebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestData.Configs.explicitWaitTimeOut));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

    }
}
