using Test_Ecommerce.Base;

namespace Test_Ecommerce.Scripts
{
    public class BaseTest : Driver
    {
        [SetUp]
        public void setUp()
        {
            initializeDriver();
            driver.Navigate().GoToUrl(TestData.Url.LoginUrl);
        }
        [TearDown]
        public void tearDown()
        {
            quitDriver();
        }
    }

}
