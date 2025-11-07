using OpenQA.Selenium;
using PageObjectModelFramework.basetest;
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
               BaseTest.log.Info("city selection icon to be selected first");
               BasePage.keyword.Click("UsedCarPage", "locationicon", "XPATH");
               BasePage.keyword.Click("HomePage", "citiselection", "XPATH");
               BasePage.keyword.Click("HomePage", "citiselectionpopup", "XPATH");
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

                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> menu = BasePage.keyword.GetWebElements("UsedCarPage", "dropdownmenu", "XPATH");
                BasePage.carBase.SearchDropDownSelection(carname, carbrand, cartitle, menu);
                Thread.Sleep(5000);
            
               
            }
    }
}
