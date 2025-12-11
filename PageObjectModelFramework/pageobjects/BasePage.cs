using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModelFramework.utilities;
using SeleniumExtras.PageObjects;
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
        protected WebDriverWait wait;
        protected WaitHelper waitHelper;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            keyword = new KeywordDriven();
            carBase = new CarBase(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.waitHelper = new WaitHelper(driver);

            // Initialize Page Factory elements
            PageFactory.InitElements(driver, this);
        }
        // Fluent wait for element to be clickable
        protected IWebElement WaitForElementToBeClickable(IWebElement element)
        {
            return waitHelper.WaitForElementToBeClickable(element);
        }

        // Fluent wait for element to be visible
        protected IWebElement WaitForElementToBeVisible(IWebElement element)
        {
            return waitHelper.WaitForElementToBeVisible(element);
        }

        // Get page title
        public string GetPageTitle()
        {
            return driver.Title;
        }

        // Scroll to element
        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
