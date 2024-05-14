using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ecommerce.Base;

namespace Test_Ecommerce.Pages
{
    public class SearchPage : BasePage
    {
        IWebElement searchBar => driver.FindElement(By.CssSelector("div[id='entry_217822'] input[placeholder='Search For Products']"));
        IWebElement searchBtn => driver.FindElement(By.CssSelector("button[class='type-text']"));

        IWebElement inputSearchfield => driver.FindElement(By.Id("input-search"));

        IWebElement inputSearchBtn => driver.FindElement(By.Id("button-search"));

        IWebElement gridView => driver.FindElement(By.CssSelector(".fas.fa-th"));

        IWebElement listView => driver.FindElement(By.CssSelector(".fas.fa-th-list"));

        IWebElement searchQueryLabel => driver.FindElement(By.XPath("//div[@id='entry_212456']/h1"));

        IWebElement noProductMessage => driver.FindElement(By.CssSelector("div[id='entry_212469'] p"));

        IWebElement subCategoryCheckBox => driver.FindElement(By.CssSelector("label[for='sub_category']"));

        SelectElement selectCategory = new SelectElement(driver.FindElement(By.CssSelector("select[name='category_id']")));

        public SearchPage searchWithWords(string productName)
        {
            inputSearchfield.SendKeys(productName);
            inputSearchBtn.Click();
            return this;
        }

        public SearchPage clickSearch()
        {
            inputSearchBtn.Click();
            return this;
        }
        public int getProductCount()
        {
            List<IWebElement> list = driver.FindElements(By.XPath("//div[@class='product-thumb']//h4")).ToList();
            return list.Count;
        }

        public string getBrowserTitle()
        {
            return driver.Title;
        }

        public string getNoproductMessage()
        {
            return noProductMessage.Text;
        }

        public void selectSubcategory()
        {
            subCategoryCheckBox.Click();
        }
        public string getSearchItemsContainerClass()
        {    
            List <IWebElement> searchItemContainer = driver.FindElements(By.XPath("//div[@id='entry_212469']/div/div")).ToList();

            return searchItemContainer[1].GetAttribute("class");
        }

        public void toggleListView()
        {
            listView.Click();
        }
        public void toggleGridView()
        {
            gridView.Click();
        }

    }
}
