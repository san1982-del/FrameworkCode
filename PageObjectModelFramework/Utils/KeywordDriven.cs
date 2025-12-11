using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObjectModelFramework.basetest;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PageObjectModelFramework.utilities 
{
    internal class KeywordDriven
    {
        private string text;
        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements;
        private IWebElement webelement;

        public void Click(string pageName, string locatorName, string locatorType)
        {
            if (locatorType.Contains("ID"))
            {
                BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Click();

            }
            else if (locatorType.Contains("XPATH"))
            {
                BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Click();

            }
            else if (locatorType.Contains("CSS"))
            {
                BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Click();

            }
            else if (locatorType.Contains("LINK"))
            {
                BaseTest.GetDriver().FindElement(By.LinkText(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Click();

            }

            BaseTest.GetExtentTest().Info("Clicking on an Element : "+locatorName);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetWebElements(string pageName, string locatorName, string locatorType)
        {
            if (locatorType.Contains("ID"))
            {
               elements = BaseTest.GetDriver().FindElements(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("XPATH"))
            {
                elements = BaseTest.GetDriver().FindElements(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("CSS"))
            {
                elements = BaseTest.GetDriver().FindElements(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("LINK"))
            {
                elements = BaseTest.GetDriver().FindElements(By.LinkText(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            
            BaseTest.GetExtentTest().Info("Get Collection of WebElements : " + locatorName);
            return elements;
        }

        public void MoveToElemet(string pageName, string locatorName, string locatorType)
        {
            IWebElement element;
            
            if (locatorType.Contains("ID"))
            {
               element = BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));
               new Actions(BaseTest.GetDriver()).MoveToElement(element).Perform();

            }
            else if (locatorType.Contains("XPATH"))
            {
                element = BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));
                new Actions(BaseTest.GetDriver()).MoveToElement(element).Perform();
            }
            else if (locatorType.Contains("CSS"))
            {
                element = BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));
                new Actions(BaseTest.GetDriver()).MoveToElement(element).Perform();
            }

            BaseTest.GetExtentTest().Info("Clicking on an Element : " + locatorName);
        }

        public void Type(string pageName, string locatorName, string locatorType, string value)
        {

            if (locatorType.Contains("ID"))
            {
                BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).SendKeys(value);

            }else if (locatorType.Contains("XPATH"))
            {
                BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).SendKeys(value);

            }else if (locatorType.Contains("CSS"))
            {
                BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).SendKeys(value);

            }


            BaseTest.GetExtentTest().Info("Typing in an Element : " + locatorName+ " value entered as : "+value);

        }

        public void Select(string pageName, string locatorName, string locatorType, string value)
        {

            IWebElement element = null;

            if (locatorType.Contains("ID"))
            {
                element = BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("XPATH"))
            {
                element = BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("CSS"))
            {
                element = BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }

            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);

            BaseTest.GetExtentTest().Info("Seleting an Element : " + locatorName + " selected the value as : " + value);

        }

        public bool isElementPresent(string pageName, string locatorName, string locatorType)
        {
            try
            {
                if (locatorType.Contains("ID"))
                {
                    BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

                }
                else if (locatorType.Contains("XPATH"))
                {
                    BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

                }
                else if (locatorType.Contains("CSS"))
                {
                    BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

                }
                BaseTest.GetExtentTest().Info("Finding an Element : " + locatorName);

                return true;
            }
            catch (Exception ex)
            {
                BaseTest.GetExtentTest().Info("Error while finding an Element : " + locatorName);

                return false;
            }
        }

        public string GetText(string pageName, string locatorName, string locatorType)
        {
            if (locatorType.Contains("ID"))
            {
                text = BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Text;

            }
            else if (locatorType.Contains("XPATH"))
            {
                text = BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Text;

            }
            else if (locatorType.Contains("CSS"))
            {
                text = BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Text;

            }
            else if (locatorType.Contains("LINK"))
            {
                text = BaseTest.GetDriver().FindElement(By.LinkText(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType))).Text;

            }

            BaseTest.GetExtentTest().Info("Getting the text of an Element : " + locatorName);
            return text;
        }

        public IWebElement FindWebElement(string pageName, string locatorName, string locatorType)
        {

            if (locatorType.Contains("ID"))
            {
               webelement = BaseTest.GetDriver().FindElement(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("XPATH"))
            {
                webelement = BaseTest.GetDriver().FindElement(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("CSS"))
            {
                webelement = BaseTest.GetDriver().FindElement(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("LINK"))
            {
                webelement = BaseTest.GetDriver().FindElement(By.LinkText(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }

            BaseTest.GetExtentTest().Info("Finding the WebElement : " + locatorName);
            return webelement;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetWebElementsFromVariable(string pageName, string locatorName, string locatorType, IWebElement webelement)
        {
            
            if (locatorType.Contains("ID"))
            {
                elements = webelement.FindElements(By.Id(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("XPATH"))
            {
                elements = webelement.FindElements(By.XPath(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("CSS"))
            {
                elements = webelement.FindElements(By.CssSelector(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }
            else if (locatorType.Contains("LINK"))
            {
                elements = webelement.FindElements(By.LinkText(XMLLocatorReader.GetLocatorValue(pageName, locatorName, locatorType)));

            }

            BaseTest.GetExtentTest().Info("Get Collection of WebElements : " + locatorName);
            return elements;
        }

    }
}
