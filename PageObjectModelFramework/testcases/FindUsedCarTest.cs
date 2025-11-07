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
    internal class FindUsedCarTest : BaseTest
    {
        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
        public void ExploreUsedCar(string browser, string runmode, string carbrand, string cartitle, string carname, string searchtype)
        {
            SetUp(browser);
            BaseTest.log.Info(browser + " Browser is launched");
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            UsedCarPage usedcarpage = homePage.ExploreUsedCar();
            usedcarpage.SearchUsedcars(carname, carbrand, cartitle, searchtype);
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname", "searchtype" };

            return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

        }
    }
}
