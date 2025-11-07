using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectModelFramework.basetest;
using PageObjectModelFramework.pageobjects;
using PageObjectModelFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.testcases
{
    [TestFixture]
   // [Parallelizable]
    internal class SearchCarTest :BaseTest
    {

        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
        public void GlobalCarBrandSearch(string browser, string runmode, string carbrand, string cartitle, string carname, string searchtype)
        {
            SetUp(browser);
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            BasePage.carBase.GlobalSearch(carname, carbrand, cartitle, searchtype);

         }

        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt")]
        public void FindYourRightNew_CarBrandSearch(string browser, string runmode, string carbrand, string cartitle, string carname, string searchtype)
        {
            SetUp(browser);
            BaseTest.log.Info(browser + " Browser is launched");
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            homePage.FindYourRightCarSearch(carname, carbrand, cartitle, searchtype);

        }

        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt")]
        public void FindYourRightUsed_CarBrandSearch(string browser, string runmode, string carbrand, string cartitle, string carname, string searchtype)
        {
            SetUp(browser);
            BaseTest.log.Info(browser + " Browser is launched");
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            homePage.FindYourRightUsed_CarSearch(carname, carbrand, cartitle, searchtype);

        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            var columns = new List<string> { "browser", "runmode","carbrand","cartitle", "carname", "searchtype" };

            return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

        }

    }
}
