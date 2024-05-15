using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Test_Ecommerce.Scripts
{

    public class NavBarTest :BaseTest
    {

        [Test]
        public void checkNavBarLinks()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement navbar = wait.Until(d => d.FindElement(By.CssSelector(".navbar-nav.horizontal")));
            IList<IWebElement> navLinks = navbar.FindElements(By.XPath("//ul[@class='navbar-nav horizontal']/li/a"));

            foreach (var link in navLinks)
            {
                string url = link.GetAttribute("href");
                
                if (url != "")
                {
                    link.Click();
                    wait.Until(ExpectedConditions.UrlToBe(url));
                    Assert.AreEqual(url, driver.Url, $"Clicking on the link should navigate to {url}");

                    // Navigate back to the initial page to test the next link
                    driver.Navigate().Back();
                    wait.Until(ExpectedConditions.ElementToBeClickable(link));
                }
                
                
            }
        }
        [Test]
        public void TestNavbarIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement navbar = wait.Until(d => d.FindElement(By.CssSelector(".navbar-nav.horizontal")));
            Assert.IsTrue(navbar.Displayed, "Navbar should be visible on the page");
        }
        [Test]
        public void TestNavbarItemsCount()
        {
            IWebElement navbar = driver.FindElement(By.CssSelector(".navbar-nav.horizontal"));
            IList<IWebElement> navLinks = navbar.FindElements(By.XPath("//ul[@class='navbar-nav horizontal']/li/a"));
            Assert.AreEqual(navLinks.Count, 6,"Expected");
        }
  
    }
}
