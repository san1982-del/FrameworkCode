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
    internal class FindNewCarsTest :BaseTest
    {

        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
        public void TestFindNewCar(string browser, string runmode, string carbrand,string cartitle)
        {   
            SetUp(browser);
            BaseTest.log.Info(browser+" Browser is launched");
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            NewCarPage newcarbrand = homePage.FindNewCar();
            newcarbrand.ViewBrand();
            BasePage.carBase.carBrandPage(carbrand, newcarbrand);

            Console.WriteLine(BasePage.carBase.ValidatePageTitle());
            Assert.That(cartitle.Equals(BasePage.carBase.ValidatePageTitle()), "car titles not matching for : "+cartitle);
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            var columns = new List<string> { "browser", "runmode","carbrand","cartitle"};

            return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

        }

    }
}
