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
        internal class CarNameandPrice : BaseTest
        {

            // [Parallelizable(ParallelScope.Children)]
            [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
            public void CarNamePrice(string browser, string runmode, string carbrand, string cartitle, string carname)
            {
                SetUp(browser);
                HomePage homePage = new HomePage(driver.Value);
                NewCarPage newcarbrand = homePage.FindNewCar();
                newcarbrand.ViewBrand();
                BasePage.carBase.carBrandPage(carbrand, newcarbrand);
                BaseTest.log.Info("Car Price and Car name fetching started");
                BasePage.carBase.GetCarNameAndPrice();
                BaseTest.log.Info("Car Price and Car name fetching completed");
                Thread.Sleep(5000);
                Assert.That(cartitle.Equals(BasePage.carBase.ValidatePageTitle()), "car titles not matching for : " + cartitle);
            }

            public static IEnumerable<TestCaseData> GetTestData()
            {

                var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname" };

                return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

            }

        }
    
}
