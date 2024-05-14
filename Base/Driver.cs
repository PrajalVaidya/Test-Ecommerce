using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Ecommerce.Base
{
    public class Driver : Global
    {
        public void initializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public void quitDriver()
        {
            driver.Quit();
        }

    }
}
