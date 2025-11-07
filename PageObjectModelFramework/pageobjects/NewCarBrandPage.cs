using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class NewCarBrandPage : BasePage
    {
        public NewCarBrandPage(IWebDriver driver) : base(driver)
        {
        }

        public BMWCarBrandPage OpenBMWCarBrandPage()
        {
            keyword.Click("NewCarBrandPage", "bmw", "LINK");

            Thread.Sleep(10000);

            return new BMWCarBrandPage(driver);
        }

        public KIACarBrandPage OpenKiaCarBrandPage()
        {
            keyword.Click("NewCarBrandPage", "kia", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new KIACarBrandPage(driver);
        }

        public ToyotaCarBrandPage OpenToyotaCarBrandPage()
        {
            keyword.Click("NewCarBrandPage", "toyota", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new ToyotaCarBrandPage(driver);
        }

        public AudiCarBrandPage OpenAudiCarBrandPage()
        {
            keyword.Click("NewCarBrandPage", "audiar", "LINK");
            // driver.FindElement(By.LinkText("BMW")).Click();

            Thread.Sleep(10000);

            return new AudiCarBrandPage(driver);
        }

    }
}
