using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class SeleniumGetMethods
    {
        public static string GetText(string element, string elementType)
        {
            if (elementType == "Id")
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementType == "Name")
                return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            return String.Empty;
        }
        public static string GetTextFromDDL(string element, string elementType)
        {
            if (elementType == "Id")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            if (elementType == "Name")
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            return String.Empty;
        }
    }
}
