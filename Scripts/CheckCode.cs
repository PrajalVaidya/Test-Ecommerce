using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Ecommerce.Pages;
using Test_Ecommerce.TestData;

namespace Test_Ecommerce.Scripts
{
    public class CheckCode : BaseTest
    {
        [Test]
        public void checkCode()
        {
            LoginPage login = new LoginPage();
            login.EnterEmail(LoginData.email).EnterPassword(LoginData.passWord).ClickLogin();
            Thread.Sleep(5000);
        }
    }
}
