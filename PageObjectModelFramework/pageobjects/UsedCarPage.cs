using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectModelFramework.basetest;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class UsedCarPage : BasePage
    {
        public UsedCarPage(IWebDriver driver) : base(driver)
        {

        }
            public void SearchUsedcars(string carname, string carbrand, string cartitle, string searchtype)
            {

            if (searchtype == "car")
            {
                BasePage.keyword.Type("UsedCarPage", "searchsecondhandcar", "XPATH", carname);
                BaseTest.log.Info("Carname " + carname + " is entered for Search ");

            }
            else if (searchtype == "brand")
            {
                BasePage.keyword.Type("UsedCarPage", "searchsecondhandcar", "XPATH", carbrand);
                BaseTest.log.Info("Car Brand Name " + carbrand + " is entered for Search ");
                
            }
           
            //WebDriverWait wait = new WebDriverWait(BaseTest.GetDriver(), TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementSelectionStateToBe(BasePage.keyword.FindWebElement("UsedCarPage", "searchbutton", "XPATH"), true));
 
            BasePage.keyword.Click("UsedCarPage", "searchbutton", "XPATH");
            BaseTest.log.Info("search is clicked ");
           
            Thread.Sleep(9000);


        }
    }
}
