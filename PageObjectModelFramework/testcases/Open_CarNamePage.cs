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
    internal class Open_CarNamePage : BaseTest
    {
            // [Parallelizable(ParallelScope.Children)]
            [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
            public void OpenCarNamePageTest(string browser, string runmode, string carbrand, string cartitle, string carname)
            {
                SetUp(browser);
                HomePage homePage = new HomePage(driver.Value);
                NewCarPage newcarbrand = homePage.FindNewCar();
                newcarbrand.ViewBrand();
                BasePage.carBase.carBrandPage(carbrand, newcarbrand);
                CarNamePage carnamePageview = new CarNamePage(driver.Value);
                BaseTest.log.Info("Car Name Page search started");
                carnamePageview.OpenCarNamePage(carname);
                BaseTest.log.Info("Car Name Page Opened");
              
                Thread.Sleep(5000);
                Assert.That(carname.Equals(BasePage.carBase.ValidatePageTitle()), "car titles not matching for : " + carname);
            }

            public static IEnumerable<TestCaseData> GetTestData()
            {

                var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname" };

                return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

            }

    }
}

