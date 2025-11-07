using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using PageObjectModelFramework.utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.basetest
{
    /* Extent reports, Logs, Keywords Screenshots, WebDriver, Configuration*/

    [SetUpFixture]
    internal class BaseTest
    {

        public static ThreadLocal<IWebDriver> driver = new();  //Static variable and methods cannot be accessed by the objects of the class. This is different than java.
                                                               //We can only access them through the class name. Only one copy of the static variables exists,
                                                               //regardless of how many instances of the class are created.
                                                               //java -jar selenium-server-4.36.0.jar standalone
        private static ExtentReports extent;
        public static ThreadLocal<ExtentTest> exTest = new();
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IConfiguration configuration;
        static string fileName;
        


        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static ExtentTest GetExtentTest()
        {
            return exTest.Value;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            log.Info("Test Execution is Started");
            exTest.Value = extent.CreateTest(TestContext.CurrentContext.Test.ClassName + " @ Test Case Name : " + TestContext.CurrentContext.Test.Name);

        }

        [TearDown]
        public void AfterEachTest()
        {
            log.Info("Test Execution is Completed");
            //Get the test status
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;


            if (testStatus == TestStatus.Passed)
            {
                GetExtentTest().Pass("Test case passed");
                IMarkup markup = MarkupHelper.CreateLabel("PASS", ExtentColor.Green);
                GetExtentTest().Pass(markup);

            }
            else if (testStatus == TestStatus.Skipped)
            {
                GetExtentTest().Skip("Test Skipped : " + TestContext.CurrentContext.Result.Message);
                IMarkup markup = MarkupHelper.CreateLabel("SKIP", ExtentColor.Amber);
                GetExtentTest().Skip(markup);
            }
            else if (testStatus == TestStatus.Failed)
            {


                CaptureScreenshot();

                GetExtentTest().Fail("Test Failed : " + TestContext.CurrentContext.Result.Message);
                GetExtentTest().Fail("<b><font color=red>  Screenshot of failure </font></b><br>", MediaEntityBuilder.CreateScreenCaptureFromPath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\" + fileName).Build());
                IMarkup markup = MarkupHelper.CreateLabel("FAIL", ExtentColor.Red);
                GetExtentTest().Fail(markup);
            }

            if (driver.Value != null)
            {

                GetDriver().Quit();
            }


        }

        private void CaptureScreenshot()
        {

            DateTime currentTime = DateTime.Now;
            fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            Screenshot screenshot = GetDriver().TakeScreenshot();
            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\" + fileName);

            
        }

        private dynamic GetBrowserOptions(string browserName)
        {

            switch (browserName)
            {

                case "chrome":
                    return new ChromeOptions();// Summary:  Class to manage options specific to OpenQA.Selenium.Chrome.ChromeDriver
                                              
                case "firefox":
                    return new FirefoxOptions();
            }

            return new ChromeOptions();
        }


        public void SetUp(string browserName)
        {
            dynamic options = GetBrowserOptions(browserName);
            options.PlatformName = "windows";
            //options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            driver.Value = new RemoteWebDriver(new Uri(configuration["AppSettings:gridurl"]), options.ToCapabilities());
           
            GetDriver().Navigate().GoToUrl(configuration["AppSettings:testsiteurl"]);
            BaseTest.log.Info(browserName+" browser with following url "+ configuration["AppSettings:testsiteurl"]+ " is launched");
            GetDriver().Manage().Cookies.DeleteAllCookies();
            GetDriver().Manage().Window.Maximize();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(configuration["AppSettings:implicit.wait"]));
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Loging();
            //log.Info("");
            

            DateTime currentTime = DateTime.Now;
            string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";
            extent = CreateInstance(fileName);

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        }

        private void Loging()
        {
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\log4net.config"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            
            extent.Flush();
            if (driver == null)
            {
                driver.Dispose();
                exTest.Dispose();
                log.Info("Test Execution Completed");
            }
            

        }

        public static ExtentReports CreateInstance(string fileName)
        {
            var htmlReporter = new ExtentSparkReporter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\reports\\" + fileName);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "AUTOMATION Test Suite";
            htmlReporter.Config.ReportName = "Automation Test Results";
            htmlReporter.Config.Encoding = "utf-8";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Automation Tester", "XXXX");
            extent.AddSystemInfo("Organization", "YYYY");
            extent.AddSystemInfo("Build No: ", "ZZZZ");

            return extent;
        }

    }

}
