using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class NewCarPage : BasePage
    {
        public NewCarPage(IWebDriver driver) : base(driver)
        {
        }

        public BMWCarPage OpenBMWCarPage()
        {
            keyword.Click("NewCarPage","bmwcar","LINK");
            
            Thread.Sleep(10000);

            return new BMWCarPage(driver);
        }

        public CarNamePage OpenKiaCarPage()
        {
            keyword.Click("NewCarPage", "kiacar", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new CarNamePage(driver);
        }

        public ToyotaCarPage OpenToyotaCarPage()
        {
            keyword.Click("NewCarPage", "toyotacar", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new ToyotaCarPage(driver);
        }

        public AudiCarPage OpenAudiCarPage()
        {
            keyword.Click("NewCarPage", "audicar", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new AudiCarPage(driver);
        }

        public void ViewBrand()
        {
            keyword.Click("NewCarPage", "viewbrand", "XPATH");
        }
    }
}
