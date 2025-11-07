using OpenQA.Selenium;
using PageObjectModelFramework.basetest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class CarNamePage : BasePage
    {
        public CarNamePage(IWebDriver driver) : base(driver)
        {

        }

        public void OpenCarNamePage(string carName)
        {
            ReadOnlyCollection<IWebElement> carnamelist  = BasePage.keyword.GetWebElements("CarBase", "carname", "XPATH");
            foreach (IWebElement car in carnamelist)
            {
                string name = car.Text.Trim();
                if (name.Equals(carName))
                {
                    car.Click();
                    Thread.Sleep(5000);
                    break;
                }
                
            }
        }
            

    }
}
