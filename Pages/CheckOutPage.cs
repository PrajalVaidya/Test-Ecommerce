using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Test_Ecommerce.Pages
{
    public class CheckOutPage : BasePage
    {
        //Billing address section
        IWebElement selectExistingAddress => driver.FindElement(By.CssSelector("label[for='input-payment-address-existing']"));
        IWebElement selectNewAddress => driver.FindElement(By.CssSelector("label[for='input-payment-address-new']"));
        IWebElement firstName => driver.FindElement(By.Id("input-payment-firstname"));
        IWebElement lastName => driver.FindElement(By.Id("input-payment-lastname"));
        IWebElement companyName => driver.FindElement(By.Id("input-payment-company"));
        IWebElement address1 => driver.FindElement(By.Id("input-payment-address-1"));
        IWebElement address2 => driver.FindElement(By.Id("input-payment-address-2"));
        IWebElement cityName => driver.FindElement(By.Id("input-payment-city"));
        IWebElement postCode => driver.FindElement(By.Id("input-payment-postcode"));

        //Shipping Address section
        IWebElement ShippingSelectExistingAddress => driver.FindElement(By.CssSelector("label[for='input-shipping-address-existing']"));
        IWebElement ShippingSelectNewAddress => driver.FindElement(By.CssSelector("label[for='input-shipping-address-new']"));
        IWebElement ShipingfirstName => driver.FindElement(By.Id("input-shipping-firstname"));
        IWebElement ShippinglastName => driver.FindElement(By.Id("input-shipping-lastname"));
        IWebElement ShippingcompanyName => driver.FindElement(By.Id("input-shipping-company"));
        IWebElement Shippingaddress1 => driver.FindElement(By.Id("input-shipping-address-1"));
        IWebElement Shippingaddress2 => driver.FindElement(By.Id("input-shipping-address-2"));
        IWebElement ShippingcityName => driver.FindElement(By.Id("input-shipping-city"));
        IWebElement ShippingpostCode => driver.FindElement(By.Id("input-shipping-postcode"));

        //Comment Section
        IWebElement commentSection => driver.FindElement(By.Id("input-comment"));

        //TermAndConditonsSection
        IWebElement checkboxTermsAndConditon => driver.FindElement(By.CssSelector("label[for='input-agree']"));

        //Continue Checkout
        IWebElement continueCheckoutBtn => driver.FindElement(By.CssSelector("#button-save"));

        //Confirm Order// this is another page objects
        IWebElement confirmOrderbtn => driver.FindElement(By.Id("button-confirm"));
        IWebElement editOrderbtn => driver.FindElement(By.CssSelector(".btn.btn-lg.btn-secondary.flex-grow-1.mr-3"));

        //SideCart Sections
        IWebElement prodImg => driver.FindElement(By.XPath("//td[@class='text-center']//img[@title='HTC Touch HD']"));
        IWebElement prodTitle => driver.FindElement(By.XPath("//td[@class='text-left']//a[contains(text(),'HTC Touch HD')]"));


        public string getProductTitle()
        {
            return driver.FindElement(By.XPath("//td[@class='text-left']//a[contains(text(),'HTC Touch HD')]")).Text;
        }
        public bool getProductImg()
        {
            return driver.FindElement(By.XPath("//td[@class='text-center']//img[@title='HTC Touch HD']")).Displayed;
        }
        public void checkoutWithExistingAddress()
        {
            selectExistingAddress.Click();
            checkboxTermsAndConditon.Click();
            continueCheckoutBtn.Click();
        }
        public void FillBillingAddressWithAllFields()
        {
            selectNewAddress.Click();
            firstName.SendKeys("test");
            lastName.SendKeys("test");
            companyName.SendKeys("testcompany");
            address1.SendKeys("testadd1");
            address2.SendKeys("testadd2");
            cityName.SendKeys("Bhaktapur");
            postCode.SendKeys("109123");
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByValue("149");
            Thread.Sleep(2000);
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-payment-zone")));
            selectRegion.SelectByValue("2315");
            Thread.Sleep(2000);
            checkboxTermsAndConditon.Click();
            continueCheckoutBtn.Click();
        }
        public void FillBillingAddressWithRequiredFieldsOnly()
        {
            selectNewAddress.Click();
            firstName.SendKeys("test");
            lastName.SendKeys("test");
            address1.SendKeys("testadd1");
            cityName.SendKeys("Bhaktapur");
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByValue("149");
            Thread.Sleep(2000);
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-payment-zone")));
            selectRegion.SelectByValue("2315");
            Thread.Sleep(2000);
            checkboxTermsAndConditon.Click();
            continueCheckoutBtn.Click();
        }
        public void FillBillingAddressWithNoFields()
        {
            selectNewAddress.Click();
            firstName.SendKeys("");
            lastName.SendKeys("");
            companyName.SendKeys("");
            address1.SendKeys("");
            address2.SendKeys("");
            cityName.SendKeys("");
            postCode.SendKeys("");
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByIndex(0);
            Thread.Sleep(2000);
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            //SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-payment-zone")));
            //selectRegion.SelectByValue("2315");
            //Thread.Sleep(2000);
            checkboxTermsAndConditon.Click();
            continueCheckoutBtn.Click();
        }
        public void FillBillingAddressWithNoCheckOnTermAndConditons()
        {
            selectNewAddress.Click();
            firstName.SendKeys("");
            lastName.SendKeys("");
            companyName.SendKeys("");
            address1.SendKeys("");
            address2.SendKeys("");
            cityName.SendKeys("");
            postCode.SendKeys("");
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            driver.FindElement(By.Id("input-payment-country")).Click();
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Id("input-payment-country")));
            selectCountry.SelectByIndex(0);
            Thread.Sleep(2000);
            new Actions(driver).ScrollByAmount(0, 200).Perform();
            //SelectElement selectRegion = new SelectElement(driver.FindElement(By.Id("input-payment-zone")));
            //selectRegion.SelectByValue("2315");
            //Thread.Sleep(2000);
            continueCheckoutBtn.Click();
            waitTillElementIsPresent(By.XPath("//div[@class='alert alert-warning alert-dismissible']"));
        }
        public void confirmOrder()
        {
            waitTillElementIsPresent(By.CssSelector(".page-title.mb-3"));
            confirmOrderbtn.Click();
            Thread.Sleep(3000);
           
        }
        public void getOrderSucessPage()
        {
            waitTillElementIsPresent(By.XPath("//h1[normalize-space()='Your order has been placed!']"));
        }
        

    }
}
