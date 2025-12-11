using OpenQA.Selenium;
using PageObjectModelFramework.basetest;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class CarBrandPage : BasePage
    {
        // Page Factory Elements
        [FindsBy(How = How.XPath, Using = "//div/div/div/div/a/h3")]
        private IList<IWebElement> carNameList;

        // Constructor
        public CarBrandPage(IWebDriver driver) : base(driver)
        {
        }

        // Open specific car name page - Fluent method with improved wait
        public CarNamePage OpenCarNamePage(string carName)
        {
            // Wait for car names to be loaded
            waitHelper.WaitForElements(By.XPath("//div/div/div/div/a/h3"));

            foreach (var car in carNameList)
            {
                string name = car.Text.Trim();
                Console.WriteLine(name);
                if (name.Equals(carName, StringComparison.OrdinalIgnoreCase))
                {
                    WaitForElementToBeClickable(car);
                    //ScrollToElement(car); // Scroll into view
                    car.Click();

                    BaseTest.GetExtentTest()?.Info($"Clicked on car: {carName}");
                    BaseTest.log.Info($"Opened car name page for: {carName}");

                    // Wait for page to load
                    waitHelper.WaitForPageLoad();
                    break;
                }
            }

            return new CarNamePage(driver);
        }

        // Get all available car names
        public List<string> GetAllCarNames()
        {
            waitHelper.WaitForElements(By.XPath("//div[contains(@class,'car-name')]"));

            var names = new List<string>();
            foreach (var car in carNameList)
            {
                names.Add(car.Text.Trim());
            }

            BaseTest.GetExtentTest()?.Info($"Retrieved {names.Count} car names");
            return names;
        }
    }
}
