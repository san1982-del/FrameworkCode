using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObjectModelFramework.basetest;
using PageObjectModelFramework.utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace PageObjectModelFramework.pageobjects
{
    internal class HomePage:BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public NewCarPage FindNewCar()
        {

            keyword.MoveToElemet("HomePage", "newcar", "XPATH");
            keyword.Click("HomePage", "findnewcar", "XPATH");

            return new NewCarPage(driver);
        }

        public void FindYourRightCarSearch(string carname, string carbrand, string cartitle, string searchtype)
        {
            if (searchtype == "car")
            {
                BasePage.keyword.Type("HomePage", "findyourrightcar", "XPATH", carname);
            }
            else if (searchtype == "brand")
            {
                BasePage.keyword.Type("HomePage", "findyourrightcar", "XPATH", carbrand);
            }

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menu = BasePage.keyword.GetWebElements("HomePage", "findyourrightcardropdownmenu", "XPATH");
            BasePage.carBase.SearchDropDownSelection(carname, carbrand, cartitle, menu);
            Thread.Sleep(5000);
        }

        public void FindYourRightUsed_CarSearch(string carname, string carbrand, string cartitle, string searchtype)
        {
            BasePage.keyword.Click("HomePage", "locationicon", "XPATH");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@title='Mumbai']")));

            BasePage.keyword.Click("HomePage", "citiselection", "XPATH");
            BasePage.keyword.Click("HomePage", "citiselectionpopup", "XPATH");
            Thread.Sleep(5000);
            BasePage.keyword.Click("HomePage", "usedsearch", "XPATH");
        
            if (searchtype == "car")
            {
                BasePage.keyword.Type("HomePage", "findyourrightcar", "XPATH", carname);
            }
            else if (searchtype == "brand")
            {
                BasePage.keyword.Type("HomePage", "findyourrightcar", "XPATH", carbrand);
            }

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/div/ul/li[1]/ul/li")));
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menu = BasePage.keyword.GetWebElements("HomePage", "findyourrightcardropdownmenu", "XPATH");
          
            foreach (IWebElement item in menu)
            {
                Console.WriteLine(item.GetAttribute("data-label"));
                if (item.GetAttribute("data-label") == "Used " + carname + " in Mumbai")
                {
                    item.Click();
                    Assert.That(carname.Equals(BasePage.carBase.ValidatePageTitle()), "car titles not matching for : " + carname);
                    break;
                }
                else if (item.GetAttribute("data-label") == "Used " + carbrand + " in Mumbai")
                {
                    menu.Count();
                    item.Click();
                    Assert.That(cartitle.Equals(BasePage.carBase.ValidatePageTitle()), "car titles not matching for : " + cartitle);
                    break;
                }
            }

            Thread.Sleep(10000);
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname" };

            return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

        }

        public UsedCarPage ExploreUsedCar()
        {
            BasePage.keyword.MoveToElemet("HomePage", "usedcars", "XPATH");
            BasePage.keyword.Click("HomePage", "exploreusedcars", "XPATH");
            BaseTest.log.Info("Used Cars page is launched");
            return new UsedCarPage(driver);
        }
    }
}
