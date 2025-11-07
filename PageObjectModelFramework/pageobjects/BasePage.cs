using OpenQA.Selenium;
using PageObjectModelFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class BasePage
    {
        public IWebDriver driver;
        public static KeywordDriven keyword;
        public static CarBase carBase;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            keyword = new KeywordDriven();
            carBase = new CarBase(driver);
        }
    }
}
