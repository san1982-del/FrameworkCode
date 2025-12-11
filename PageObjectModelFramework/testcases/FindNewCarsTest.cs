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
    [Parallelizable]
    internal class FindNewCarsTest : BaseTest
    {
        [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("smoke"), Retry(1)]
        public void TestFindNewCar(string browser, string runmode, string carbrand, string cartitle, string carname)
        {
            // Check if test should run
            runmodecheck(runmode);

            // Setup browser
            SetUp(browser);

            try
            {
                // FLUENT PATTERN - Method Chaining!
                // Notice how readable and clean this is compared to before
                var carPrice = new HomePage(driver.Value)
                    .FindNewCar()                          // Navigate to new cars
                    .ViewBrand()                           // View all brands
                    .OpenCarBrandPage(carbrand)            // Open specific brand
                    .OpenCarNamePage(carname)              // Open specific car
                    .GetCarPrice();                        // Get the price

                // Assertions
                string actualTitle = driver.Value.Title;
                Assert.That(actualTitle, Does.Contain(carname),
                    $"Car Name title not matching. Expected: {carname}, Actual: {actualTitle}");

                // Log results
                BaseTest.GetExtentTest()?.Info($"Price of {carname} is {carPrice}");
                BaseTest.log.Info($"Test completed successfully for {carname}");

                Console.WriteLine($"Successfully validated {carname} with price {carPrice}");
            }
            catch (Exception ex)
            {
                BaseTest.GetExtentTest()?.Fail($"Test failed with error: {ex.Message}");
                BaseTest.log.Error($"Test execution failed: {ex.Message}", ex);
                throw;
            }
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname" };
            return DataUtil.GetTestDataFromExcel(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx",
                "FindNewCar",
                columns);
        }
    }
}
