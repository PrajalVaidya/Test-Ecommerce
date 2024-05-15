using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Test_Ecommerce.Pages;
using Test_Ecommerce.TestData;

namespace Test_Ecommerce.Scripts
{
    public class SearchTest : BaseTest
    {
        [Test]
        public void TestProductsDisplayed()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords("Iphone");
            Assert.AreNotEqual(searchpage.getProductCount(), 0);
            Thread.Sleep(1000);

        }
        [Test]
        public void testSearchLabelTitleUrl()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords("Iphone");
            Assert.AreEqual(searchpage.getBrowserTitle(), "Search - Iphone");
        }
        [Test]
        public void testSearchWithNonExistingProduct()
        {
            String productName = "Elephant";
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords(productName);
            Assert.AreEqual(searchpage.getProductCount(), 0);
            Assert.AreEqual(searchpage.getNoproductMessage(), "There is no product that matches the search criteria.");
        }
        [Test]
        public void testSearchWithEmptyTerm()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords("");
            Assert.AreEqual(searchpage.getProductCount(), 0);
            Assert.AreEqual(searchpage.getNoproductMessage(), "There is no product that matches the search criteria.");
        }
        //Search ipod in sub category selected as PC
        [Test]
        public void testsearchInSubCategories()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            SelectElement selectCategory = new SelectElement(driver.FindElement(By.CssSelector("select[name='category_id']")));
            selectCategory.SelectByValue("26");
            searchpage.selectSubcategory();
            searchpage.searchWithWords("ipod");
            Assert.AreEqual(searchpage.getProductCount(), 0);
            Assert.AreEqual(searchpage.getNoproductMessage(), "There is no product that matches the search criteria.");

        }
        [Test]
        public void testGridView()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords("ipod");
            searchpage.toggleGridView();
            Assert.AreEqual(searchpage.getSearchItemsContainerClass(), "product-layout product-grid no-desc col-xl-4 col-lg-4 col-md-4 col-sm-6 col-6");

        }
        [Test]
        public void testListView()
        {
            driver.Navigate().GoToUrl(Url.searchUrl);
            SearchPage searchpage = new SearchPage();
            searchpage.searchWithWords("ipod");
            searchpage.toggleListView();
            Assert.AreEqual(searchpage.getSearchItemsContainerClass(), "product-layout product-list col-12");

        }
    }
}
